using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Vector;
using Common.Memory;

namespace X3TCTools.SectorObjects
{
    public class SectorObjectData : MemoryObject
    {
        public const int ByteSize = 624;

        public MemoryObjectPointer<SectorObjectData> pNext = new MemoryObjectPointer<SectorObjectData>();
        public MemoryObjectPointer<SectorObjectData> pPrevious = new MemoryObjectPointer<SectorObjectData>();
        public int Unknown_3; // 0x8
        public MemoryObjectPointer<SectorObjectData> pFirstChild = new MemoryObjectPointer<SectorObjectData>();
        public int Unknown_5; // 0x10
        public MemoryObjectPointer<SectorObjectData> pLastChild = new MemoryObjectPointer<SectorObjectData>();
        public int Unknown_7; // 0x18
        public int Unknown_8;
        public int Unknown_9; // 0x20
        public int Unknown_10;
        public int Unknown_11; // 0x28
        public int Unknown_12;
        public Vector3 Position; // 0x30
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
        public int Unknown_41; // a0
        public int TotalSize;
        public int Unknown_43; // a8
        public int Unknown_44;
        public int Unknown_45;
        public int Unknown_46;
        public int Unknown_47;
        public int Unknown_48;
        public int Unknown_49;
        public int Unknown_50;
        public int Unknown_51;
        public int Unknown_52;
        public int Unknown_53;
        public int Unknown_54;
        public int Unknown_55;
        public int Unknown_56;
        public int Unknown_57;
        public int Unknown_58;
        public int Unknown_59;
        public int Unknown_60;
        public int Unknown_61;
        public int Unknown_62;
        public int Unknown_63;
        public int Unknown_64;
        public int Unknown_65;
        public int Unknown_66;
        public int Unknown_67;
        public int Unknown_68;
        public int Unknown_69;
        public int Unknown_70;
        public int Unknown_71;
        public int Unknown_72;
        public int Unknown_73;
        public int Unknown_74;
        public int Unknown_75;
        public int Unknown_76;
        public int Unknown_77;
        public int Unknown_78;
        public int Unknown_79;
        public int Unknown_80;
        public int Unknown_81;
        public int Unknown_82;
        public int Unknown_83;
        public int Unknown_84;
        public int Unknown_85;
        public int Unknown_86;
        public int Unknown_87;
        public int Unknown_88;
        public int Unknown_89;
        public int Unknown_90;
        public int Unknown_91;
        public int Unknown_92;
        public int Unknown_93;
        public int Unknown_94;
        public int Unknown_95;
        public int Unknown_96;
        public int Unknown_97;
        public int Unknown_98;
        public int Unknown_99;
        public int Unknown_100;
        public int Unknown_101;
        public int Unknown_102;
        public int Unknown_103;
        public int Unknown_104;
        public int Unknown_105;
        public int Unknown_106;
        public int Unknown_107;
        public int Unknown_108;
        public int Unknown_109;
        public int Unknown_110;
        public int Unknown_111;
        public int Unknown_112;
        public int Unknown_113;
        public int Unknown_114;
        public int Unknown_115;
        public int Unknown_116;
        public int Unknown_117;
        public int Unknown_118;
        public int Unknown_119;
        public int Unknown_120;
        public int Unknown_121;
        public int Unknown_122;
        public int Unknown_123;
        public int Unknown_124;
        public int Unknown_125;
        public int Unknown_126;
        public int Unknown_127;
        public int Unknown_128;
        public int Unknown_129;
        public int Unknown_130;
        public int Unknown_131;
        public int Unknown_132;
        public int Unknown_133;
        public int Unknown_134;
        public int Unknown_135;
        public int Unknown_136;
        public int Unknown_137;
        public int Unknown_138;
        public int Unknown_139;
        public int Unknown_140;
        public int Unknown_141;
        public int Unknown_142;
        public int Unknown_143;
        public int Unknown_144;
        public int Unknown_145;
        public int Unknown_146;
        public int Unknown_147;
        public int Unknown_148;
        public int Unknown_149;
        public int Unknown_150;
        public int Unknown_151;
        public int Unknown_152;
        public int Unknown_153;
        public int Unknown_154;
        public int Unknown_155;
        public int Unknown_156;

        public SectorObjectData()
        {
        }

        public void Save()
        {
            MemoryControl.Write(m_hProcess, pThis + 0x80, ModelScale);
        }

        public bool IsValid
        {
            get
            {
                return pNext.IsValid && pPrevious.IsValid;
            }
        }

        #region IMemoryObject
        public override byte[] GetBytes()
        {
            var collection = new ObjectByteList();

            collection.Append(pNext);
            collection.Append(pPrevious);
            collection.Append(Unknown_3);
            collection.Append(pFirstChild);
            collection.Append(Unknown_5);
            collection.Append(pLastChild);
            collection.Append(Unknown_7);
            collection.Append(Unknown_8);
            collection.Append(Unknown_9);
            collection.Append(Unknown_10);
            collection.Append(Unknown_11);
            collection.Append(Unknown_12);
            collection.Append(Position);
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
            collection.Append(Unknown_41);
            collection.Append(TotalSize);
            collection.Append(Unknown_43);
            collection.Append(Unknown_44);
            collection.Append(Unknown_45);
            collection.Append(Unknown_46);
            collection.Append(Unknown_47);
            collection.Append(Unknown_48);
            collection.Append(Unknown_49);
            collection.Append(Unknown_50);
            collection.Append(Unknown_51);
            collection.Append(Unknown_52);
            collection.Append(Unknown_53);
            collection.Append(Unknown_54);
            collection.Append(Unknown_55);
            collection.Append(Unknown_56);
            collection.Append(Unknown_57);
            collection.Append(Unknown_58);
            collection.Append(Unknown_59);
            collection.Append(Unknown_60);
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
            collection.Append(Unknown_74);
            collection.Append(Unknown_75);
            collection.Append(Unknown_76);
            collection.Append(Unknown_77);
            collection.Append(Unknown_78);
            collection.Append(Unknown_79);
            collection.Append(Unknown_80);
            collection.Append(Unknown_81);
            collection.Append(Unknown_82);
            collection.Append(Unknown_83);
            collection.Append(Unknown_84);
            collection.Append(Unknown_85);
            collection.Append(Unknown_86);
            collection.Append(Unknown_87);
            collection.Append(Unknown_88);
            collection.Append(Unknown_89);
            collection.Append(Unknown_90);
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
            collection.Append(Unknown_114);
            collection.Append(Unknown_115);
            collection.Append(Unknown_116);
            collection.Append(Unknown_117);
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
            collection.Append(Unknown_149);
            collection.Append(Unknown_150);
            collection.Append(Unknown_151);
            collection.Append(Unknown_152);
            collection.Append(Unknown_153);
            collection.Append(Unknown_154);
            collection.Append(Unknown_155);
            collection.Append(Unknown_156);

            return collection.GetBytes();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory, m_hProcess, pThis);

            pNext = collection.PopIMemoryObject<MemoryObjectPointer<SectorObjectData>>();
            pPrevious = collection.PopIMemoryObject<MemoryObjectPointer<SectorObjectData>>();
            Unknown_3 = collection.PopInt();
            pFirstChild = collection.PopIMemoryObject<MemoryObjectPointer<SectorObjectData>>();
            Unknown_5 = collection.PopInt();
            pLastChild = collection.PopIMemoryObject<MemoryObjectPointer<SectorObjectData>>();
            Unknown_7 = collection.PopInt();
            Unknown_8 = collection.PopInt();
            Unknown_9 = collection.PopInt();
            Unknown_10 = collection.PopInt();
            Unknown_11 = collection.PopInt();
            Unknown_12 = collection.PopInt();
            Position = collection.PopIMemoryObject<Vector3>();
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
            Unknown_41 = collection.PopInt();
            TotalSize = collection.PopInt();
            Unknown_43 = collection.PopInt();
            Unknown_44 = collection.PopInt();
            Unknown_45 = collection.PopInt();
            Unknown_46 = collection.PopInt();
            Unknown_47 = collection.PopInt();
            Unknown_48 = collection.PopInt();
            Unknown_49 = collection.PopInt();
            Unknown_50 = collection.PopInt();
            Unknown_51 = collection.PopInt();
            Unknown_52 = collection.PopInt();
            Unknown_53 = collection.PopInt();
            Unknown_54 = collection.PopInt();
            Unknown_55 = collection.PopInt();
            Unknown_56 = collection.PopInt();
            Unknown_57 = collection.PopInt();
            Unknown_58 = collection.PopInt();
            Unknown_59 = collection.PopInt();
            Unknown_60 = collection.PopInt();
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
            Unknown_74 = collection.PopInt();
            Unknown_75 = collection.PopInt();
            Unknown_76 = collection.PopInt();
            Unknown_77 = collection.PopInt();
            Unknown_78 = collection.PopInt();
            Unknown_79 = collection.PopInt();
            Unknown_80 = collection.PopInt();
            Unknown_81 = collection.PopInt();
            Unknown_82 = collection.PopInt();
            Unknown_83 = collection.PopInt();
            Unknown_84 = collection.PopInt();
            Unknown_85 = collection.PopInt();
            Unknown_86 = collection.PopInt();
            Unknown_87 = collection.PopInt();
            Unknown_88 = collection.PopInt();
            Unknown_89 = collection.PopInt();
            Unknown_90 = collection.PopInt();
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
            Unknown_114 = collection.PopInt();
            Unknown_115 = collection.PopInt();
            Unknown_116 = collection.PopInt();
            Unknown_117 = collection.PopInt();
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
            Unknown_149 = collection.PopInt();
            Unknown_150 = collection.PopInt();
            Unknown_151 = collection.PopInt();
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
            pPrevious.SetLocation(hProcess, address+0x4);
            pFirstChild.SetLocation(hProcess, address+0xC);
            pLastChild.SetLocation(hProcess, address+0x14);
        }
        #endregion
    }
}
