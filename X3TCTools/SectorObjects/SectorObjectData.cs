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
        public int Unknown_29; // 0x70
        public int Unknown_30;
        public int Unknown_31; // 0x78
        public int Unknown_32;
        public Vector3 ComponentPositionMult; // 0x80
        public int Unknown_36;
        public int Unknown_37;
        public int Unknown_38;
        public int Unknown_39;
        public int Unknown_40;
        public int Unknown_41;
        public int Unknown_42;
        public int Unknown_43;
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
            MemoryControl.Write(m_hProcess, pThis + 0x80, ComponentPositionMult);
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
            collection.Append(Unknown_29);
            collection.Append(Unknown_30);
            collection.Append(Unknown_31);
            collection.Append(Unknown_32);
            collection.Append(ComponentPositionMult);
            collection.Append(Unknown_36);
            collection.Append(Unknown_37);
            collection.Append(Unknown_38);
            collection.Append(Unknown_39);
            collection.Append(Unknown_40);
            collection.Append(Unknown_41);
            collection.Append(Unknown_42);
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
            var collection = new ObjectByteList();
            collection.SetData(Memory);

            collection.PopFirst(ref pNext);
            collection.PopFirst(ref pPrevious);
            collection.PopFirst(ref Unknown_3);
            collection.PopFirst(ref pFirstChild);
            collection.PopFirst(ref Unknown_5);
            collection.PopFirst(ref pLastChild);
            collection.PopFirst(ref Unknown_7);
            collection.PopFirst(ref Unknown_8);
            collection.PopFirst(ref Unknown_9);
            collection.PopFirst(ref Unknown_10);
            collection.PopFirst(ref Unknown_11);
            collection.PopFirst(ref Unknown_12);
            collection.PopFirst(ref Position);
            collection.PopFirst(ref Unknown_16);
            collection.PopFirst(ref rotationMatrix);
            collection.PopFirst(ref Unknown_29);
            collection.PopFirst(ref Unknown_30);
            collection.PopFirst(ref Unknown_31);
            collection.PopFirst(ref Unknown_32);
            collection.PopFirst(ref ComponentPositionMult);
            collection.PopFirst(ref Unknown_36);
            collection.PopFirst(ref Unknown_37);
            collection.PopFirst(ref Unknown_38);
            collection.PopFirst(ref Unknown_39);
            collection.PopFirst(ref Unknown_40);
            collection.PopFirst(ref Unknown_41);
            collection.PopFirst(ref Unknown_42);
            collection.PopFirst(ref Unknown_43);
            collection.PopFirst(ref Unknown_44);
            collection.PopFirst(ref Unknown_45);
            collection.PopFirst(ref Unknown_46);
            collection.PopFirst(ref Unknown_47);
            collection.PopFirst(ref Unknown_48);
            collection.PopFirst(ref Unknown_49);
            collection.PopFirst(ref Unknown_50);
            collection.PopFirst(ref Unknown_51);
            collection.PopFirst(ref Unknown_52);
            collection.PopFirst(ref Unknown_53);
            collection.PopFirst(ref Unknown_54);
            collection.PopFirst(ref Unknown_55);
            collection.PopFirst(ref Unknown_56);
            collection.PopFirst(ref Unknown_57);
            collection.PopFirst(ref Unknown_58);
            collection.PopFirst(ref Unknown_59);
            collection.PopFirst(ref Unknown_60);
            collection.PopFirst(ref Unknown_61);
            collection.PopFirst(ref Unknown_62);
            collection.PopFirst(ref Unknown_63);
            collection.PopFirst(ref Unknown_64);
            collection.PopFirst(ref Unknown_65);
            collection.PopFirst(ref Unknown_66);
            collection.PopFirst(ref Unknown_67);
            collection.PopFirst(ref Unknown_68);
            collection.PopFirst(ref Unknown_69);
            collection.PopFirst(ref Unknown_70);
            collection.PopFirst(ref Unknown_71);
            collection.PopFirst(ref Unknown_72);
            collection.PopFirst(ref Unknown_73);
            collection.PopFirst(ref Unknown_74);
            collection.PopFirst(ref Unknown_75);
            collection.PopFirst(ref Unknown_76);
            collection.PopFirst(ref Unknown_77);
            collection.PopFirst(ref Unknown_78);
            collection.PopFirst(ref Unknown_79);
            collection.PopFirst(ref Unknown_80);
            collection.PopFirst(ref Unknown_81);
            collection.PopFirst(ref Unknown_82);
            collection.PopFirst(ref Unknown_83);
            collection.PopFirst(ref Unknown_84);
            collection.PopFirst(ref Unknown_85);
            collection.PopFirst(ref Unknown_86);
            collection.PopFirst(ref Unknown_87);
            collection.PopFirst(ref Unknown_88);
            collection.PopFirst(ref Unknown_89);
            collection.PopFirst(ref Unknown_90);
            collection.PopFirst(ref Unknown_91);
            collection.PopFirst(ref Unknown_92);
            collection.PopFirst(ref Unknown_93);
            collection.PopFirst(ref Unknown_94);
            collection.PopFirst(ref Unknown_95);
            collection.PopFirst(ref Unknown_96);
            collection.PopFirst(ref Unknown_97);
            collection.PopFirst(ref Unknown_98);
            collection.PopFirst(ref Unknown_99);
            collection.PopFirst(ref Unknown_100);
            collection.PopFirst(ref Unknown_101);
            collection.PopFirst(ref Unknown_102);
            collection.PopFirst(ref Unknown_103);
            collection.PopFirst(ref Unknown_104);
            collection.PopFirst(ref Unknown_105);
            collection.PopFirst(ref Unknown_106);
            collection.PopFirst(ref Unknown_107);
            collection.PopFirst(ref Unknown_108);
            collection.PopFirst(ref Unknown_109);
            collection.PopFirst(ref Unknown_110);
            collection.PopFirst(ref Unknown_111);
            collection.PopFirst(ref Unknown_112);
            collection.PopFirst(ref Unknown_113);
            collection.PopFirst(ref Unknown_114);
            collection.PopFirst(ref Unknown_115);
            collection.PopFirst(ref Unknown_116);
            collection.PopFirst(ref Unknown_117);
            collection.PopFirst(ref Unknown_118);
            collection.PopFirst(ref Unknown_119);
            collection.PopFirst(ref Unknown_120);
            collection.PopFirst(ref Unknown_121);
            collection.PopFirst(ref Unknown_122);
            collection.PopFirst(ref Unknown_123);
            collection.PopFirst(ref Unknown_124);
            collection.PopFirst(ref Unknown_125);
            collection.PopFirst(ref Unknown_126);
            collection.PopFirst(ref Unknown_127);
            collection.PopFirst(ref Unknown_128);
            collection.PopFirst(ref Unknown_129);
            collection.PopFirst(ref Unknown_130);
            collection.PopFirst(ref Unknown_131);
            collection.PopFirst(ref Unknown_132);
            collection.PopFirst(ref Unknown_133);
            collection.PopFirst(ref Unknown_134);
            collection.PopFirst(ref Unknown_135);
            collection.PopFirst(ref Unknown_136);
            collection.PopFirst(ref Unknown_137);
            collection.PopFirst(ref Unknown_138);
            collection.PopFirst(ref Unknown_139);
            collection.PopFirst(ref Unknown_140);
            collection.PopFirst(ref Unknown_141);
            collection.PopFirst(ref Unknown_142);
            collection.PopFirst(ref Unknown_143);
            collection.PopFirst(ref Unknown_144);
            collection.PopFirst(ref Unknown_145);
            collection.PopFirst(ref Unknown_146);
            collection.PopFirst(ref Unknown_147);
            collection.PopFirst(ref Unknown_148);
            collection.PopFirst(ref Unknown_149);
            collection.PopFirst(ref Unknown_150);
            collection.PopFirst(ref Unknown_151);
            collection.PopFirst(ref Unknown_152);
            collection.PopFirst(ref Unknown_153);
            collection.PopFirst(ref Unknown_154);
            collection.PopFirst(ref Unknown_155);
            collection.PopFirst(ref Unknown_156);
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
