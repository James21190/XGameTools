
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using X3TCTools.SectorObjects;
using Common.Network;

using X3TCTools.Network.Packets;

namespace X3TCTools.Network
{
    public partial class GameNetworkManager : NetworkManager
    {
        private GameHook m_GameHook;
        public GameNetworkManager(GameHook gameHook, int port) : base(port)
        {
            m_GameHook = gameHook;
        }
        #region Object Management

        private struct ObjectLink
        {
            public IntPtr LocalAddress;
            public int LocalID;
            public byte ConnectionID;
            public int ForeignID;
        }

        private List<ObjectLink> m_ObjectLinks = new List<ObjectLink>();

        private SectorObject GetLocalInstance(byte ConnectionID, int ReferenceID, SectorObjects.SectorObject.Main_Type main_Type, int sub_Type)
        {
            // Itterate through the list and check if the object exists
            var objects = m_ObjectLinks.ToArray();
            for(int i = 0; i < objects.Length; i++)
            {
                if (objects[i].ConnectionID == ConnectionID && objects[i].ForeignID == ReferenceID)
                {
                    // If object exists, return it.
                    SectorObject sectorObject;
                    if (m_GameHook.SectorObjectManager.SectorObjectExists(m_ObjectLinks[i].LocalAddress, out sectorObject))
                    {
                        return sectorObject;
                    }
                    // If it doesnt, remove it from the list and create a new one.
                    else
                    {
                        m_ObjectLinks.RemoveAt(i);
                        break;
                    }
                }
            }

            Log.AppendMessage(string.Format("Creating object with type {0}-{1} with ID {2} for {3}.", main_Type.ToString(), sub_Type.ToString(), ReferenceID, ConnectionID.ToString()), Common.Logger.MessageSeverity.Debug);

            // Create new object
            var newobj = m_GameHook.GameCodeRunner.CreateSectorObject(main_Type, sub_Type, m_GameHook.SectorObjectManager.GetSpace());
            // Add to the list
            m_ObjectLinks.Add(new ObjectLink() { ConnectionID = ConnectionID, ForeignID = ReferenceID, LocalAddress = newobj.pThis , LocalID = newobj.ObjectID});
            Log.AppendMessage(string.Format("Created object with type {0}-{1} with ID {2} for {3}.", main_Type.ToString(), sub_Type.ToString(), ReferenceID, ConnectionID.ToString()), Common.Logger.MessageSeverity.Debug);
            return newobj;
        }

        private bool LocalInstanceExists(byte ConnectionID, int ForeignID)
        {
            foreach(var item in m_ObjectLinks)
            {
                if (item.ConnectionID == ConnectionID && item.ForeignID == ForeignID)
                    return true;
            }
            return false;
        }

        #endregion
        public void SendData()
        {
            var space = m_GameHook.SectorObjectManager.GetSpace();

            // Send all ships owned by the player
            foreach (var ship in space.GetAllChildrenWithType(SectorObject.Main_Type.Ship))
            {
                if (ship.RaceID == GameHook.RaceID.Player)
                {
                    var packetData = new SectorObjectUpdate();

                    packetData.FromSectorObject(ship);

                    var packet = new Packet(ConnectionID, packetData);
                    SendPacketToAll(packet);
                }
            }

            // Send all projectiles owned by the player
            foreach (var projectile in space.GetAllChildrenWithType(SectorObject.Main_Type.Projectile))
            {
                if (projectile.RaceID == GameHook.RaceID.Player)
                {
                    var packetData = new SectorObjectUpdate();

                    packetData.FromSectorObject(projectile);

                    var packet = new Packet(ConnectionID, packetData);
                    SendPacketToAll(packet);
                }
            }

        }

        protected override void OnPacketRecieved(Packet packet, IPAddress sender)
        {
            if (packet.Handled)
                return;
            switch ((PacketTypes)packet.DataType)
            {
                case PacketTypes.SectorObjectUpdate:
                    var packetData = new SectorObjectUpdate();
                    packet.ToObject(ref packetData);

                    // If projectile exists, ignore it
                    //if (packetData.MainType == SectorObject.Main_Type.Projectile && LocalInstanceExists(packet.ConnectionID, packetData.ID))
                    //    return;

                    var localObject = GetLocalInstance(packet.ConnectionID, packetData.ID, packetData.MainType, packetData.SubType);

                    packetData.ToSectorObject(ref localObject);

                    break;
            }
        }
    }
}
