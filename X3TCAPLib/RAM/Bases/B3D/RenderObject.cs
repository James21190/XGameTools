using CommonToolLib.Generics;
using CommonToolLib.ProcessHooking;
using System;

namespace X3TCAPLib.RAM.Bases.B3D
{
    public class RenderObject : XCommonLib.RAM.Bases.B3D.RenderObject
    {
        #region Memory Fields
        public MemoryObjectPointer<RenderObject> pNext = new MemoryObjectPointer<RenderObject>();
        public MemoryObjectPointer<RenderObject> pPrevious = new MemoryObjectPointer<RenderObject>();
        public int Unknown_3; // 0x8
        public MemoryObjectPointer<RenderObject> pFirstChild = new MemoryObjectPointer<RenderObject>();
        public int ChildListNull; // 0x10
        public MemoryObjectPointer<RenderObject> pLastChild = new MemoryObjectPointer<RenderObject>();
        public MemoryObjectPointer<RenderObject> pParent = new MemoryObjectPointer<RenderObject>(); // 0x18
        public int Unknown_8;
        public int Unknown_9; // 0x20
        public int Unknown_10;
        //public int ID { get; set; } // 0x28
        public int Unknown_12;
        public Vector3_32 ParentRelativePosition; // 0x30
        public int Unknown_16; // 0x3c
        public RotationMatrix_4 rotationMatrix = new RotationMatrix_4(); // 0x40
        public int Size; // 0x70
        public int Unknown_30;
        public int Unknown_31; // 0x78
        public int Unknown_32;
        public Vector3_32 ModelScale; // 0x80
        public int Unknown_36; // 8c
        public int Unknown_37; // 90
        public int Unknown_38;
        public int Unknown_39; //98
        public int Unknown_40;
        public int ThisSize; // a0
        public int TotalSize;
        public int Unknown_43; // a8
        public int Unknown_44;
        //public Vector3_32 AbsolutePosition; // b0
        public int Unknown_48;
        public RotationMatrix_4 RotationMatrix_2; // c0
        public int Unknown_61; // f0
        public int Unknown_62;
        public int Unknown_63;
        public int Unknown_64;
        public int Unknown_65; // 100
        public int Unknown_66;
        public int Unknown_67;
        public int Unknown_68;
        public int Unknown_69; // 110
        public int Unknown_70;
        public int Unknown_71;
        public int Unknown_72;
        public int Unknown_73; // 120
        public int TypeDependentValue;
        public int Unknown_75;
        public int LightParameters;
        public int Flags; // 130
        public int Unknown_78;
        public int SectorObjectSize;
        public int Unknown_80;
        public int ModelID; // 140
        public int Unknown_82;
        public int Unknown_83;
        public int Unknown_84;
        public short LightColor_A; // 150
        public short LightColor_B;
        public short LightColor_C;
        public short Unknown_86;
        public int LightRange;
        public Vector3_32 LightAttenuation;
        public int Unknown_91;
        public int Unknown_92;
        public int Unknown_93; // 170
        public int Unknown_94;
        public int Unknown_95;
        public int Unknown_96;
        public int Unknown_97; // 180
        public int Unknown_98;
        public int Unknown_99;
        public int Unknown_100;
        public int Unknown_101; // 190
        public int Unknown_102;
        public int Unknown_103;
        public int Unknown_104;
        public int Unknown_105; // 1a0
        public int Unknown_106;
        public int Unknown_107;
        public int Unknown_108;
        public int Unknown_109; // 1b0
        public int Unknown_110;
        public int Unknown_111;
        public int Unknown_112;
        public int Unknown_113; // 1c0
        public int Hue;
        public Vector3_32 Saturation;
        public int Unknown_118;
        public int Unknown_119;
        public int Unknown_120;
        public int Unknown_121; // 1e0
        public int Unknown_122;
        public int Unknown_123;
        public int Unknown_124;
        public int Unknown_125; // 1f0
        public int Unknown_126;
        public int Unknown_127;
        public int Unknown_128;
        public int Unknown_129; // 200
        public int Unknown_130;
        public int Unknown_131;
        public int Unknown_132;
        public int Unknown_133; // 210
        public int Unknown_134;
        public int Unknown_135;
        public int Unknown_136;
        public int Unknown_137; // 220
        public int Unknown_138;
        public int Unknown_139;
        public int Unknown_140;
        public int Unknown_141; // 230
        public int Unknown_142;
        public int Unknown_143;
        public int Unknown_144;
        public int Unknown_145; // 240
        public int Unknown_146;
        public int Unknown_147;
        public int Unknown_148;
        public int FunctionIndex; // 250
        public int Unknown_150;
        public int ModelCollectionID;
        public int Unknown_152;
        public int Unknown_153; // 260
        public int Unknown_154;
        public int Unknown_155;
        public int Unknown_156; // 26c
        #endregion


        #region Common
        #endregion

        #region MemoryObject
        public override int ByteSize => throw new NotImplementedException();

        public override XCommonLib.RAM.Bases.B3D.RenderObject Parent => throw new NotImplementedException();

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        protected override void SetDataFromMemoryObjectConverter(MemoryObjectConverter memoryObjectConverter)
        {
            throw new NotImplementedException();
        }

        #endregion
        public override XCommonLib.RAM.Bases.B3D.RenderObject[] GetChildren(bool getChildrenOfChildren)
        {
            throw new NotImplementedException();
        }
    }
}
