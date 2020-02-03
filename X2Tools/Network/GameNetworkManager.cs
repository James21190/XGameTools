using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using X2Tools.X2.SectorObjects;
using X2Tools;
using System.Threading;
using System.IO;
using X2Tools.Network.Packet;
using X2Tools.X2.SectorObjects.Meta;
using Common;
using Common.Network;
using Common.Memory;

namespace X2Tools.Network
{
    /// <summary>
    /// Main object that manages multiplayer.
    /// Interacts with other clients, manages connections, and sends update data.
    /// Recieves update data and implements updates.
    /// </summary>
    public partial class GameNetworkManager : NetworkManager
    {
        #region Private Fields
        private readonly GameHook m_GameHook;
        #endregion
        public static int RefreshRate = 100;

        public GameNetworkManager(GameHook gameHook, int port) :base (port)
        {
            m_GameHook = gameHook;
        }

        #region Object Managment

        private struct ObjectReference
        {
            public int localID;
            public byte ConnectionID;
            public int ReferenceID;
        }

        private List<ObjectReference> m_ObjectReferences = new List<ObjectReference>();

        private void AddObject(SectorObject sectorObject, byte ConnectionID, int ReferenceID)
        {
            m_ObjectReferences.Add(new ObjectReference() { localID = sectorObject.SectorObjectID, ConnectionID = ConnectionID, ReferenceID = ReferenceID });
        }

        private SectorObject GetObject(byte ConnectionID, int ReferenceID)
        {
            foreach(var item in m_ObjectReferences)
            {
                if (item.ConnectionID == ConnectionID && item.ReferenceID == ReferenceID)
                {
                    return m_GameHook.SectorObjectManager.GetSectorObject(item.localID);
                }
            }
            throw new IndexOutOfRangeException();
        }

        private void RemoveObject(byte ConnectionID, int ReferenceID)
        {
            for(int i = 0; i < m_ObjectReferences.Count; i++)
            {
                if (m_ObjectReferences[i].ReferenceID == ReferenceID && m_ObjectReferences[i].ConnectionID == ConnectionID)
                {
                    m_ObjectReferences.RemoveAt(i);
                }
            }
        }

        private bool LocalSectorObjectExists(byte ConnectionID, int ReferenceID, out SectorObject sectorObject)
        {
            try
            {
                sectorObject = GetObject(ConnectionID, ReferenceID);
                return true;
            }
            catch (Exception)
            {
                sectorObject = null;
                return false;
            }
        }

        private SectorObject GetLocalSectorObject(byte ConnectionID, int ReferenceID, SectorObject.Main_Type main_Type, int sub_Type)
        {
            try
            {
                return GetObject(ConnectionID, ReferenceID);
            }
            catch (Exception)
            {
                // If object did not previously exist,create it
                Log.AppendMessage(string.Format("Creating new SectorObject with type {0}-{1} for connectionID {2}.", main_Type.ToString(), sub_Type.ToString(), ConnectionID.ToString()), Logger.MessageSeverity.Debug);
                SectorObject parent = null;
                // If the object is a maintype that should be in a sector, move it into the sector
                if (main_Type == SectorObject.Main_Type.Ship || main_Type == SectorObject.Main_Type.Projectile || main_Type == SectorObject.Main_Type.Missile || main_Type == SectorObject.Main_Type.Dock || main_Type == SectorObject.Main_Type.Factory)
                    parent = m_GameHook.SectorObjectManager.GetSpace();

                // Create the object
                var sectorObject = m_GameHook.GameCodeRunner.CreateSectorObject(main_Type, sub_Type, parent);
                // Add object reference
                AddObject(sectorObject, ConnectionID, ReferenceID);
                Log.AppendMessage(string.Format("Created new SectorObject with type {0}-{1} for connectionID {2}.", main_Type.ToString(), sub_Type.ToString(), ConnectionID.ToString()), Logger.MessageSeverity.Debug);
                return sectorObject;
            }
        }

        #endregion

        #region Send and recieve

        private bool ShouldSendObject(SectorObject sectorObject)
        {
            if (sectorObject.RaceID == X2.Race.RaceID.Player)
            {
                return true;
            }
            return false;
        }

        public void SendUpdate()
        {
            // For every ship in sector
            foreach (var obj in m_GameHook.SectorObjectManager.GetSectorObjectsWithType(((SectorMeta)m_GameHook.SectorObjectManager.GetSpace().GetMetaData()).pFirstChild, SectorObject.Main_Type.Ship, false))
            {
                if (ShouldSendObject(obj))
                {
                    var SectorObjectData = new ShipUpdateData(obj);
                    // Send data to all clients
                    SendPacketToAll(new Common.Network.Packet(ConnectionID, SectorObjectData));

                    // Send shield data
                    SendPacketToAll(new Common.Network.Packet(ConnectionID, new ShieldUpdateData(obj, m_GameHook)));
                }
            }
            // For every projectile in sector
            foreach (var obj in m_GameHook.SectorObjectManager.GetSectorObjectsWithType(((SectorMeta)m_GameHook.SectorObjectManager.GetSpace().GetMetaData()).pFirstChild, SectorObject.Main_Type.Projectile, false))
            {
                if (ShouldSendObject(obj))
                {
                    var SectorObjectData = new ShipUpdateData(obj);
                    // Send data to all clients
                    SendPacketToAll(new Common.Network.Packet(ConnectionID, SectorObjectData));
                }
            }

        }

        protected override void OnPacketRecieved(Common.Network.Packet packet, IPAddress SenderIP)
        {
            if (packet.Handled)
                return;

            // Implement recieved data logic

            switch ((PacketTypes)packet.DataType)
            {
                // Data that updates a ship object
                case PacketTypes.ShipUpdateData:
                    var dataShipUpdate = new ShipUpdateData();
                    packet.ToObject(ref dataShipUpdate);

                    // If the object is a projectile, create it and do not update it
                    if(dataShipUpdate.Main_Type == (int)SectorObject.Main_Type.Projectile)
                    {
                        SectorObject temp;
                        // If the projectile already exists, skip it
                        if (LocalSectorObjectExists(packet.ConnectionID, dataShipUpdate.SectorObjectID, out temp)) return;

                        var localProjectile = GetLocalSectorObject(packet.ConnectionID, dataShipUpdate.SectorObjectID, (SectorObject.Main_Type)dataShipUpdate.Main_Type, dataShipUpdate.Sub_Type);
                        dataShipUpdate.ToSectorObject(localProjectile);
                        return;
                    }

                    var localSectorObject = GetLocalSectorObject(packet.ConnectionID, dataShipUpdate.SectorObjectID, (SectorObject.Main_Type)dataShipUpdate.Main_Type, dataShipUpdate.Sub_Type);
                    dataShipUpdate.ToSectorObject(localSectorObject);

                    break;
                // Data that updates an object's shields
                case PacketTypes.ShieldUpdateData:
                    SectorObject parent;
                    var dataShieldUpdate = new ShieldUpdateData();
                    packet.ToObject(ref dataShieldUpdate);

                    if(LocalSectorObjectExists(packet.ConnectionID, dataShieldUpdate.SectorObjectID, out parent))
                    {
                        parent.SetInstalledShields(dataShieldUpdate.Shield_1MW, dataShieldUpdate.Shield_5MW, dataShieldUpdate.Shield_25MW, dataShieldUpdate.Shield_125MW);
                    }
                    break;
            }

        }
        #endregion

    }
}
