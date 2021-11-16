﻿using CommonToolLib.Memory;
using System;
using System.Collections.Generic;

namespace CommonToolLib.Vector
{
    public class RotationMatrix_4 : MemoryObject
    {
        public override int ByteSize => 0x30;

        public double[,] Matrix = new double[3, 4];

        #region Constructors
        public RotationMatrix_4()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    Matrix[x, y] = 0;
                }
            }
        }

        public RotationMatrix_4(Vector4_32 A, Vector4_32 B, Vector4_32 C)
        {
            Matrix[0, 0] = (double)A.X;
            Matrix[0, 1] = (double)A.Y;
            Matrix[0, 2] = (double)A.Z;
            Matrix[0, 3] = (double)A.W;
            Matrix[1, 0] = (double)B.X;
            Matrix[1, 1] = (double)B.Y;
            Matrix[1, 2] = (double)B.Z;
            Matrix[1, 3] = (double)B.W;
            Matrix[2, 0] = (double)C.X;
            Matrix[2, 1] = (double)C.Y;
            Matrix[2, 2] = (double)C.Z;
            Matrix[2, 3] = (double)C.W;
        }
        #endregion

        #region IMemoryObject
        public override void SetData(byte[] Memory)
        {
            Matrix[0, 0] = BitConverter.ToInt32(Memory, 0);
            Matrix[0, 1] = BitConverter.ToInt32(Memory, 4);
            Matrix[0, 2] = BitConverter.ToInt32(Memory, 8);
            Matrix[0, 3] = BitConverter.ToInt32(Memory, 12);
            Matrix[1, 0] = BitConverter.ToInt32(Memory, 16);
            Matrix[1, 1] = BitConverter.ToInt32(Memory, 20);
            Matrix[1, 2] = BitConverter.ToInt32(Memory, 24);
            Matrix[1, 3] = BitConverter.ToInt32(Memory, 28);
            Matrix[2, 0] = BitConverter.ToInt32(Memory, 32);
            Matrix[2, 1] = BitConverter.ToInt32(Memory, 36);
            Matrix[2, 2] = BitConverter.ToInt32(Memory, 40);
            Matrix[2, 3] = BitConverter.ToInt32(Memory, 44);
        }

        public override byte[] GetBytes()
        {
            List<byte> arr = new List<byte>();

            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[0, 0])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[0, 1])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[0, 2])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[0, 3])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[1, 0])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[1, 1])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[1, 2])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[1, 3])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[2, 0])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[2, 1])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[2, 2])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[2, 3])));

            return arr.ToArray();
        }
        #endregion

        #region Vectors
        public Vector4_32 X => new Vector4_32((int)Matrix[0, 0], (int)Matrix[0, 1], (int)Matrix[0, 2], (int)Matrix[0, 3]);
        public Vector4_32 Y => new Vector4_32((int)Matrix[1, 0], (int)Matrix[1, 1], (int)Matrix[1, 2], (int)Matrix[1, 3]);
        public Vector4_32 Z => new Vector4_32((int)Matrix[2, 0], (int)Matrix[2, 1], (int)Matrix[2, 2], (int)Matrix[2, 3]);

        #endregion
    }
}
