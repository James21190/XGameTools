using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files
{
    public class BOBFile
    {
        public string Info;
        public int Unknown_1, PathCount;
        public BOBFileSub[] SubArr;

        public struct BOBFileSub
        {
            public int Unknown_1, Unknown_2, Unknown_3, Unknown_4, Unknown_5;
        }

        private static byte[] EncryptionKey = new byte[2] { 4, 0 };
        private static void DecryptBytes(ref byte[] bytes)
        {
            int EncryptionKeyPosition = 0;
            int i = 0;
            byte temp;
            do
            {
                switch (EncryptionKey[EncryptionKeyPosition])
                {
                    case 0:
                        EncryptionKeyPosition = 0;
                        continue;
                    case 1:
                        i += 1;
                        break;
                    case 2:
                        temp = bytes[i];
                        bytes[i] = bytes[i + 1];
                        bytes[i] = temp;
                        i += 2;
                        break;
                    case 4:
                        temp = bytes[i];
                        bytes[i] = bytes[i + 3];
                        bytes[i+3] = temp;
                        temp = bytes[i+1];
                        bytes[i+1] = bytes[i + 2];
                        bytes[i+2] = temp;
                        i += 4;
                        break;
                }
                EncryptionKeyPosition += 1;
            } while (i < bytes.Length);
        }

        private class FileReader
        {
            public byte[] FileData;
            public int Index;
            public FileReader(string path)
            {
                FileData = File.ReadAllBytes(path);
                Index = 0;
            }

            public FileReader(byte[] bytes)
            {
                FileData = bytes;
                Index = 0;
            }

            public string GetNextAsTag(bool incrementIndex = true)
            {
                var str = Encoding.ASCII.GetString(FileData, Index, 4);
                if (incrementIndex)
                {
                    Index += 4;
                }
                return str;
            }

            public byte GetNextAsByte()
            {
                var b = FileData[Index];
                Index++;
                return b;
            }

            public int GetNextAsInt()
            {
                return BitConverter.ToInt32(GetNextAsBytes(4, true),0);
            }

            public byte[] GetNextAsBytes(int length, bool decrypt)
            {
                byte[] bytes = new byte[length];
                for(int i = 0; i < length; i++)
                {
                    bytes[i] = GetNextAsByte();
                }

                if (decrypt)
                {
                    DecryptBytes(ref bytes);
                }

                return bytes;
            }
        }

        public void FromBytes(byte[] fileBytes)
        {
            var fileData = new FileReader(fileBytes);

            if(fileData.GetNextAsTag(true) != "CUT1")
            {
                throw new Exception();
            }

            if(fileData.GetNextAsTag(false) == "INFO")
            {
                fileData.Index += 4;
                var sb = new StringBuilder();
                char infoChar = (char)fileData.GetNextAsByte();
                while(infoChar != '\0')
                {
                    sb.Append(infoChar);
                    infoChar = (char)fileData.GetNextAsByte();
                }
                Info = sb.ToString();
                if(fileData.GetNextAsTag(true) !=  "/INF")
                {
                    throw new Exception();
                }
            }

            Unknown_1 = BitConverter.ToInt32(fileData.GetNextAsBytes(4, true), 0);
            PathCount = BitConverter.ToInt32(fileData.GetNextAsBytes(4, true), 0);

            SubArr = new BOBFileSub[PathCount];

            int CurrentTagCount = 0;

            while(PathCount > CurrentTagCount)
            {
                // Ensure tag is PATH
                if(fileData.GetNextAsTag(true) != "PATH")
                {
                    throw new Exception();
                }

                var currentSub = SubArr[CurrentTagCount];

                currentSub.Unknown_1 = fileData.GetNextAsInt();
                currentSub.Unknown_2 = fileData.GetNextAsInt();
                currentSub.Unknown_3 = fileData.GetNextAsInt();
                currentSub.Unknown_4 = fileData.GetNextAsInt();
                currentSub.Unknown_5 = fileData.GetNextAsInt();

                var nextTag = fileData.GetNextAsTag(true);
                // Check for name tag
                if(nextTag == "NAME")
                {

                }
            }

        }
    }
}
