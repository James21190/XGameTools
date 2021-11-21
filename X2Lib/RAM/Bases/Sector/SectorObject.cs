using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;
using X2Lib.RAM.Bases.B3D;
using XCommonLib.RAM.Bases.Sector.SectorObject_Meta;

namespace X2Lib.RAM.Bases.Sector
{
    public class SectorObject : XCommonLib.RAM.Bases.Sector.SectorObject
    {
        #region Memory Fields
        // All values stored in memory
        public MemoryObjectPointer<SectorObject> pNext = new MemoryObjectPointer<SectorObject>();
        public MemoryObjectPointer<SectorObject> pPrevious = new MemoryObjectPointer<SectorObject>();
        public override int ID { get; set; }
        public MemoryObjectPointer<MemoryString> pDefaultName = new MemoryObjectPointer<MemoryString>();
        public override int Speed { get; set; }
        public override int DesiredSpeed { get; set; }
        public override Vector3_32 EulerRotation { get; set; }
        public override Vector3_32 LocalEulerRotationDelta { get; set; }
        public override Vector3_32 LocalAutopilotRotationDeltaTarget { get; set; }
        public override ushort RaceID { get; set; }
        public ushort Unknown_4;
        public override BitField InteractionFlags { get; set; }
        public int Unknown_5;
        // base.ObjectType
        public IntPtr pMeta;
        public override ISectorObjectMeta Meta => throw new NotImplementedException();
        public MemoryObjectPointer<SectorObject> pParent = new MemoryObjectPointer<SectorObject>();
        public override Vector3_32 PositionStrafeDelta { get; set; }
        public MemoryObjectPointer<RenderObject> pRenderObject = new MemoryObjectPointer<RenderObject>();
        public int Unknown_6;
        public int Unknown_7;
        public int RunObjectParamID;
        public int Unknown_9;
        public int Unknown_10;
        public int Unknown_11;
        public int Unknown_12;
        public override int ScriptInstanceID { get; set; }
        public int Unknown_14;
        public int ModelCollectionID;
        public int Unknown_15;
        public int Unknown_16;
        public int Unknown_17;
        public int Unknown_18;
        public IntPtr p1;
        public int Unknown_19;
        public IntPtr p2;
        public override Vector3_32 Position { get; set; }
        public Vector3_32 EulterRotationCopy;
        public Vector3_32 LocalEulerRotationDeltaCopy;
        public int SpeedCopy;
        public int Hull;
        public int Unknown_20;
        public int Unknown_21;
        #endregion

        #region Common
        public override XCommonLib.RAM.Bases.Sector.SectorObject Next => pNext.obj.IsValid ? pNext.obj : null;
        public override XCommonLib.RAM.Bases.Sector.SectorObject Previous => pPrevious.obj.IsValid ? pPrevious.obj : null;
        public override MemoryString DefaultName => pDefaultName.obj;
        public override XCommonLib.RAM.Bases.B3D.RenderObject RenderObject => pRenderObject.obj.IsValid ? pRenderObject.obj : null;
        #endregion

        public override bool IsValid => throw new NotImplementedException();

        #region IMemoryObject
        public override int ByteSize => throw new NotImplementedException();


        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }


        protected override void SetDataFromObjectByteList(MemoryObjectConverter objectByteList)
        {
            base.SetDataFromObjectByteList(objectByteList);
        }
        #endregion
    }
}
