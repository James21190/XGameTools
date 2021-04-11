using Common.Memory;
using Common.Vector;
using System;

namespace X3Tools.RAM.Bases.B3D
{
    public class RenderObject : MemoryObject, INumericIDObject
    {
        #region Memory
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
        public int ID; // 0x28
        public int Unknown_12;
        public Vector3 ParentRelativePosition; // 0x30
        public int Unknown_16; // 0x3c
        public RotationMatrix_4 rotationMatrix = new RotationMatrix_4(); // 0x40
        public int Size; // 0x70
        public int Unknown_30;
        public int Unknown_31; // 0x78
        public int Unknown_32;
        public Vector3 ModelScale; // 0x80
        public int Unknown_36; // 8c
        public int Unknown_37; // 90
        public int Unknown_38;
        public int Unknown_39; //98
        public int Unknown_40;
        public int ThisSize; // a0
        public int TotalSize;
        public int Unknown_43; // a8
        public int Unknown_44;
        public Vector3 AbsolutePosition; // b0
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
        public Vector3 LightAttenuation;
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
        public Vector3 Saturation;
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

        int INumericIDObject.ID => ID;

        public RenderObject()
        {
        }

        public void Save()
        {
            MemoryControl.Write(this.hProcess, pThis + 0x80, ModelScale);

            MemoryControl.Write(this.hProcess, pThis + 0x140, ModelID);
        }

        public bool IsValid => pNext.IsValid && pPrevious.IsValid;

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            ObjectByteList collection = new ObjectByteList();

            collection.Append(pNext);
            collection.Append(pPrevious);
            collection.Append(Unknown_3);
            collection.Append(pFirstChild);
            collection.Append(ChildListNull);
            collection.Append(pLastChild);
            collection.Append(pParent);
            collection.Append(Unknown_8);
            collection.Append(Unknown_9);
            collection.Append(Unknown_10);
            collection.Append(ID);
            collection.Append(Unknown_12);
            collection.Append(ParentRelativePosition);
            collection.Append(Unknown_16);
            collection.Append(rotationMatrix);
            collection.Append(Size);
            collection.Append(Unknown_30);
            collection.Append(Unknown_31);
            collection.Append(Unknown_32);
            collection.Append(ModelScale);
            collection.Append(Unknown_36);
            collection.Append(Unknown_37);
            collection.Append(Unknown_38);
            collection.Append(Unknown_39);
            collection.Append(Unknown_40);
            collection.Append(ThisSize);
            collection.Append(TotalSize);
            collection.Append(Unknown_43);
            collection.Append(Unknown_44);
            collection.Append(AbsolutePosition);
            collection.Append(Unknown_48);
            collection.Append(Unknown_61);
            collection.Append(Unknown_62);
            collection.Append(Unknown_63);
            collection.Append(Unknown_64);
            collection.Append(Unknown_65);
            collection.Append(Unknown_66);
            collection.Append(Unknown_67);
            collection.Append(Unknown_68);
            collection.Append(Unknown_69);
            collection.Append(Unknown_70);
            collection.Append(Unknown_71);
            collection.Append(Unknown_72);
            collection.Append(Unknown_73);
            collection.Append(TypeDependentValue);
            collection.Append(Unknown_75);
            collection.Append(LightParameters);
            collection.Append(Flags);
            collection.Append(Unknown_78);
            collection.Append(SectorObjectSize);
            collection.Append(Unknown_80);
            collection.Append(ModelID);
            collection.Append(Unknown_82);
            collection.Append(Unknown_83);
            collection.Append(Unknown_84);
            collection.Append(LightColor_A);
            collection.Append(LightColor_B);
            collection.Append(LightColor_C);
            collection.Append(Unknown_86);
            collection.Append(LightRange);
            collection.Append(LightAttenuation);
            collection.Append(Unknown_91);
            collection.Append(Unknown_92);
            collection.Append(Unknown_93);
            collection.Append(Unknown_94);
            collection.Append(Unknown_95);
            collection.Append(Unknown_96);
            collection.Append(Unknown_97);
            collection.Append(Unknown_98);
            collection.Append(Unknown_99);
            collection.Append(Unknown_100);
            collection.Append(Unknown_101);
            collection.Append(Unknown_102);
            collection.Append(Unknown_103);
            collection.Append(Unknown_104);
            collection.Append(Unknown_105);
            collection.Append(Unknown_106);
            collection.Append(Unknown_107);
            collection.Append(Unknown_108);
            collection.Append(Unknown_109);
            collection.Append(Unknown_110);
            collection.Append(Unknown_111);
            collection.Append(Unknown_112);
            collection.Append(Unknown_113);
            collection.Append(Hue);
            collection.Append(Saturation);
            collection.Append(Unknown_118);
            collection.Append(Unknown_119);
            collection.Append(Unknown_120);
            collection.Append(Unknown_121);
            collection.Append(Unknown_122);
            collection.Append(Unknown_123);
            collection.Append(Unknown_124);
            collection.Append(Unknown_125);
            collection.Append(Unknown_126);
            collection.Append(Unknown_127);
            collection.Append(Unknown_128);
            collection.Append(Unknown_129);
            collection.Append(Unknown_130);
            collection.Append(Unknown_131);
            collection.Append(Unknown_132);
            collection.Append(Unknown_133);
            collection.Append(Unknown_134);
            collection.Append(Unknown_135);
            collection.Append(Unknown_136);
            collection.Append(Unknown_137);
            collection.Append(Unknown_138);
            collection.Append(Unknown_139);
            collection.Append(Unknown_140);
            collection.Append(Unknown_141);
            collection.Append(Unknown_142);
            collection.Append(Unknown_143);
            collection.Append(Unknown_144);
            collection.Append(Unknown_145);
            collection.Append(Unknown_146);
            collection.Append(Unknown_147);
            collection.Append(Unknown_148);
            collection.Append(FunctionIndex);
            collection.Append(Unknown_150);
            collection.Append(ModelCollectionID);
            collection.Append(Unknown_152);
            collection.Append(Unknown_153);
            collection.Append(Unknown_154);
            collection.Append(Unknown_155);
            collection.Append(Unknown_156);

            return collection.GetBytes();
        }

        public override int ByteSize => 624;

        public override void SetData(byte[] Memory)
        {
            ObjectByteList collection = new ObjectByteList(Memory, this.hProcess, pThis);

            pNext = collection.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();
            pPrevious = collection.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();
            Unknown_3 = collection.PopInt();
            pFirstChild = collection.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();
            ChildListNull = collection.PopInt();
            pLastChild = collection.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();
            pParent = collection.PopIMemoryObject<MemoryObjectPointer<RenderObject>>();
            Unknown_8 = collection.PopInt();
            Unknown_9 = collection.PopInt();
            Unknown_10 = collection.PopInt();
            ID = collection.PopInt();
            Unknown_12 = collection.PopInt();
            ParentRelativePosition = collection.PopIMemoryObject<Vector3>();
            Unknown_16 = collection.PopInt();
            rotationMatrix = collection.PopIMemoryObject<RotationMatrix_4>();
            Size = collection.PopInt();
            Unknown_30 = collection.PopInt();
            Unknown_31 = collection.PopInt();
            Unknown_32 = collection.PopInt();
            ModelScale = collection.PopIMemoryObject<Vector3>();
            Unknown_36 = collection.PopInt();
            Unknown_37 = collection.PopInt();
            Unknown_38 = collection.PopInt();
            Unknown_39 = collection.PopInt();
            Unknown_40 = collection.PopInt();
            ThisSize = collection.PopInt();
            TotalSize = collection.PopInt();
            Unknown_43 = collection.PopInt();
            Unknown_44 = collection.PopInt();
            AbsolutePosition = collection.PopIMemoryObject<Vector3>();
            Unknown_48 = collection.PopInt();
            RotationMatrix_2 = collection.PopIMemoryObject<RotationMatrix_4>();
            Unknown_61 = collection.PopInt();
            Unknown_62 = collection.PopInt();
            Unknown_63 = collection.PopInt();
            Unknown_64 = collection.PopInt();
            Unknown_65 = collection.PopInt();
            Unknown_66 = collection.PopInt();
            Unknown_67 = collection.PopInt();
            Unknown_68 = collection.PopInt();
            Unknown_69 = collection.PopInt();
            Unknown_70 = collection.PopInt();
            Unknown_71 = collection.PopInt();
            Unknown_72 = collection.PopInt();
            Unknown_73 = collection.PopInt();
            TypeDependentValue = collection.PopInt();
            Unknown_75 = collection.PopInt();
            LightParameters = collection.PopInt();
            Flags = collection.PopInt();
            Unknown_78 = collection.PopInt();
            SectorObjectSize = collection.PopInt();
            Unknown_80 = collection.PopInt();
            ModelID = collection.PopInt();
            Unknown_82 = collection.PopInt();
            Unknown_83 = collection.PopInt();
            Unknown_84 = collection.PopInt();
            LightColor_A = collection.PopShort();
            LightColor_B = collection.PopShort();
            LightColor_C = collection.PopShort();
            Unknown_86 = collection.PopShort();
            LightRange = collection.PopInt();
            LightAttenuation = collection.PopIMemoryObject<Vector3>();
            Unknown_91 = collection.PopInt();
            Unknown_92 = collection.PopInt();
            Unknown_93 = collection.PopInt();
            Unknown_94 = collection.PopInt();
            Unknown_95 = collection.PopInt();
            Unknown_96 = collection.PopInt();
            Unknown_97 = collection.PopInt();
            Unknown_98 = collection.PopInt();
            Unknown_99 = collection.PopInt();
            Unknown_100 = collection.PopInt();
            Unknown_101 = collection.PopInt();
            Unknown_102 = collection.PopInt();
            Unknown_103 = collection.PopInt();
            Unknown_104 = collection.PopInt();
            Unknown_105 = collection.PopInt();
            Unknown_106 = collection.PopInt();
            Unknown_107 = collection.PopInt();
            Unknown_108 = collection.PopInt();
            Unknown_109 = collection.PopInt();
            Unknown_110 = collection.PopInt();
            Unknown_111 = collection.PopInt();
            Unknown_112 = collection.PopInt();
            Unknown_113 = collection.PopInt();
            Hue = collection.PopInt();
            Saturation = collection.PopIMemoryObject<Vector3>();
            Unknown_118 = collection.PopInt();
            Unknown_119 = collection.PopInt();
            Unknown_120 = collection.PopInt();
            Unknown_121 = collection.PopInt();
            Unknown_122 = collection.PopInt();
            Unknown_123 = collection.PopInt();
            Unknown_124 = collection.PopInt();
            Unknown_125 = collection.PopInt();
            Unknown_126 = collection.PopInt();
            Unknown_127 = collection.PopInt();
            Unknown_128 = collection.PopInt();
            Unknown_129 = collection.PopInt();
            Unknown_130 = collection.PopInt();
            Unknown_131 = collection.PopInt();
            Unknown_132 = collection.PopInt();
            Unknown_133 = collection.PopInt();
            Unknown_134 = collection.PopInt();
            Unknown_135 = collection.PopInt();
            Unknown_136 = collection.PopInt();
            Unknown_137 = collection.PopInt();
            Unknown_138 = collection.PopInt();
            Unknown_139 = collection.PopInt();
            Unknown_140 = collection.PopInt();
            Unknown_141 = collection.PopInt();
            Unknown_142 = collection.PopInt();
            Unknown_143 = collection.PopInt();
            Unknown_144 = collection.PopInt();
            Unknown_145 = collection.PopInt();
            Unknown_146 = collection.PopInt();
            Unknown_147 = collection.PopInt();
            Unknown_148 = collection.PopInt();
            FunctionIndex = collection.PopInt();
            Unknown_150 = collection.PopInt();
            ModelCollectionID = collection.PopInt();
            Unknown_152 = collection.PopInt();
            Unknown_153 = collection.PopInt();
            Unknown_154 = collection.PopInt();
            Unknown_155 = collection.PopInt();
            Unknown_156 = collection.PopInt();
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pNext.SetLocation(hProcess, address);
            pPrevious.SetLocation(hProcess, address + 0x4);
            pFirstChild.SetLocation(hProcess, address + 0xC);
            pLastChild.SetLocation(hProcess, address + 0x14);
        }
        #endregion
    }
}
