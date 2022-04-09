using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Files
{
    public static class FileIdentifier
    {

        struct FileSignature
        {
            public string Extension;
            public byte[] Signature;
            public int[] WildcardIndexs;

            public bool DoesFileMatch(byte[] file)
            {
                for (int i = 0; i < Signature.Length; i++)
                {
                    if (WildcardIndexs == null || !WildcardIndexs.Contains(i))
                        if (file[i] != Signature[i]) return false;
                }
                return true;
            }
        }

        static FileSignature[] Signatures =
        {
            new FileSignature
            {
                Extension = ".jpg",
                Signature = new byte[] { 0xff,0xd8,0xff,0xdb},
            },
            new FileSignature
            {
                Extension = ".jpg",
                Signature = new byte[] { 0xff,0xd8,0xff,0xe0,0x00,0x10,0x4a,0x46,0x49,0x46,0x00,0x1}
            },
            new FileSignature
            {
                Extension = ".jpg",
                Signature = new byte[] { 0xff,0xd8,0xff,0xee }
            },
            new FileSignature
            {
                Extension = ".jpg",
                Signature = new byte[] { 0xff,0xd8,0xff,0xe1,0x00,0x00,0x45,0x78,0x69,0x66,0x00,0x00 },
                WildcardIndexs = new int[] { 4,5 }
            },
            new FileSignature
            {
                Extension = ".png",
                Signature = new byte[] { 0x89,0x50,0x4e,0x47,0x0d,0x0a,0x1a,0x0a }
            },
            new FileSignature
            {
                Extension = ".gif",
                Signature = new byte[] { 0x47,0x49,0x46,0x38,0x37,0x61 }
            },
            new FileSignature
            {
                Extension = ".gif",
                Signature = new byte[] { 0x47,0x49,0x46,0x38,0x39,0x61 }
            },
            new FileSignature
            {
                Extension = ".mp4",
                Signature = new byte[] { 0x00, 0x00 ,0x00 ,0x20 ,0x66 ,0x74 ,0x79 ,0x70, 0x69, 0x73,0x6f,0x6d}
            },
            new FileSignature
            {
                Extension = ".mp4",
                Signature = new byte[] { 0x00, 0x00 ,0x00 ,0x1c ,0x66 ,0x74 ,0x79 ,0x70, 0x6d, 0x70,0x34,0x32}
            },
            new FileSignature
            {
                Extension = ".webm",
                Signature = new byte[] {0x1a,0x45,0xdf,0xa3 }
            },
            new FileSignature
            {
                Extension = ".webp",
                Signature = new byte[] { 0x52, 0x49, 0x46, 0x46, 0x00, 0x00, 0x00, 0x00, 0x57, 0x45, 0x42, 0x50},
                WildcardIndexs = new int[] { 4,5,6,7}
            },
            new FileSignature
            {
                Extension = ".gz",
                Signature = new byte[] { 0x1f, 0x8b, 0x08}
            },
            //new FileSignature
            //{
            //    Extension = ".",
            //    Signature = new byte[] { }
            //},
            //new FileSignature
            //{
            //    Extension = ".",
            //    Signature = new byte[] { }
            //},
            //new FileSignature
            //{
            //    Extension = ".",
            //    Signature = new byte[] { }
            //},
            //new FileSignature
            //{
            //    Extension = ".",
            //    Signature = new byte[] { }
            //},
        };

        /// <summary>
        /// Returns the extension of a file, determined by the signature.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string IdentifyExtension(string path)
        {
            return IdentifyExtension(File.ReadAllBytes(path));
        }

        public static string IdentifyExtension(byte[] file)
        {
            foreach (var signature in Signatures)
            {
                if (signature.DoesFileMatch(file)) return signature.Extension;
            }
            return ".unknown";
        }
    }
}
