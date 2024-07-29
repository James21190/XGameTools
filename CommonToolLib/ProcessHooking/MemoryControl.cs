﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using CommonToolLib.Generics.BinaryObjects;

namespace CommonToolLib.ProcessHooking
{
    internal static class MemoryControl
    {
        #region Kernel32
        [DllImport("kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint dwFreeType);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress,
            IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        public enum PageProtectionFlags
        {
            PAGE_NOACCESS = 0x01,
            PAGE_READONLY = 0x02,
            PAGE_READWRITE = 0x04,
            PAGE_WRITECOPY = 0x08,
            PAGE_EXECUTE = 0x10,
            PAGE_EXECUTE_READ = 0x20,
            PAGE_EXECUTE_READWRITE = 0x40,
            PAGE_EXECUTE_WRITECOPY = 0x80,
            PAGE_GUARD = 0x100,
            PAGE_NOCACHE = 0x200,
            PAGE_WRITECOMBINE = 0x400
        }

        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }
        #endregion

        #region Reads
        /// <summary>
        /// Read an array of bytes from data.
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="Address"></param>
        /// <param name="Bytes"></param>
        /// <returns></returns>
        public static byte[] Read(IntPtr hProcess, IntPtr Address, int Bytes)
        {
            byte[] buffer = new byte[Bytes];
            int BytesToRead = Bytes;
            ReadProcessMemory(hProcess, Address, buffer, Bytes, ref BytesToRead);
            return buffer;

        }

        /// <summary>
        /// Read a 4 byte int from data.
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="Address"></param>
        /// <returns></returns>
        public static int ReadInt(IntPtr hProcess, IntPtr Address)
        {
            return BitConverter.ToInt32(Read(hProcess, Address, 4), 0);
        }

        /// <summary>
        /// Read a null terminated string at the given address.
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="Address"></param>
        /// <returns></returns>
        public static string ReadNullTerminatedString(IntPtr hProcess, IntPtr Address)
        {
            List<byte> bytes = new List<byte>();
            byte value = Read(hProcess, Address, 1)[0];
            for (int i = 1; value != 0x0; i++)
            {
                bytes.Add(value);
                value = Read(hProcess, Address + i, 1)[0];
            }

            string result;
            result = Encoding.UTF8.GetString(bytes.ToArray());

            return result;

        }

        #endregion

        #region Writes

        /// <summary>
        /// Write an IBinaryObject to data.
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="address"></param>
        /// <param name="binaryObject"></param>
        public static void Write(IntPtr hProcess, IntPtr address, IBinaryObject binaryObject)
        {
            Write(hProcess, address, binaryObject.GetBytes());
        }

        public static void Write(IntPtr hProcess, IntPtr baseAddress, IntPtr offset, IBinaryObject binaryObject)
        {
            IntPtr address = (IntPtr)((int)baseAddress + (int)offset);
            Write(hProcess, address, binaryObject);
        }

        /// <summary>
        /// Write a 4 byte int to data.
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        public static void Write(IntPtr hProcess, IntPtr address, int value)
        {
            Write(hProcess, address, BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Write an array of bytes to data.
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="Address"></param>
        /// <param name="Bytes"></param>
        public static void Write(IntPtr hProcess, IntPtr Address, byte[] Bytes)
        {
            int numberOfBytesWritten = 0;
            uint old;
            if(!VirtualProtectEx(hProcess, Address, (IntPtr)Bytes.Length, (uint)PageProtectionFlags.PAGE_EXECUTE_READWRITE, out old))
            {
                throw new Exception();
            }
            if(!WriteProcessMemory(hProcess, Address, Bytes, (uint)Bytes.Length, numberOfBytesWritten))
            {
                throw new Exception();
            }
            if(!VirtualProtectEx(hProcess, Address, (IntPtr)Bytes.Length, old, out old))
            {
                throw new Exception();
            }

        }

        #endregion

        public static IntPtr AllocateMemory(IntPtr hProcess, int Size)
        {
            return VirtualAllocEx(hProcess, (IntPtr)null, (IntPtr)Size, (0x1000 | 0x2000), 0x40);
        }
        public static void FreeMemory(IntPtr hProcess, IntPtr pAddress, int size)
        {
            throw new NotImplementedException();
        }

        public static int CalculateArrayIndexAddress(int ArrayBase, int ObjectSize, int Index)
        {
            return ArrayBase + (ObjectSize * Index);
        }

    }
}
