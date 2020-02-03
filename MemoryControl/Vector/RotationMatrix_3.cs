using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Memory;

namespace Common.Vector
{
    public class RotationMatrix_3 : IMemoryObject
    {
        public const int ByteSize = 36;

        public double[,] Matrix = new double[3,3];

        public RotationMatrix_3()
        {
            for(int x = 0; x < 3; x++)
                for(int y = 0; y < 3; y++)
                {
                    Matrix[x,y] = 0;
                }
        }

        public Vector3 X { get
            {
                return new Vector3((int)Matrix[0, 0], (int)Matrix[0, 1], (int)Matrix[0, 2]);
            } }
        public Vector3 Y
        {
            get
            {
                return new Vector3((int)Matrix[1, 0], (int)Matrix[1, 1], (int)Matrix[1, 2]);
            }
        }
        public Vector3 Z
        {
            get
            {
                return new Vector3((int)Matrix[2, 0], (int)Matrix[2, 1], (int)Matrix[2, 2]);
            }
        }

        public RotationMatrix_3(Vector3 A, Vector3 B, Vector3 C)
        {
            Matrix[0, 0] = A.X;
            Matrix[0, 1] = A.Y;
            Matrix[0, 2] = A.Z;
            Matrix[1, 0] = B.X;
            Matrix[1, 1] = B.Y;
            Matrix[1, 2] = B.Z;
            Matrix[2, 0] = C.X;
            Matrix[2, 1] = C.Y;
            Matrix[2, 2] = C.Z;
        }

        public RotationMatrix_3(byte[] Memory)
        {
            SetData(Memory);
        }

        public void SetLocation(IntPtr hProcess, IntPtr address)
        {
            throw new NotImplementedException();
        }

        public void SetData(byte[] Memory)
        {
            Matrix[0, 0] = BitConverter.ToInt32(Memory, 0);
            Matrix[0, 1] = BitConverter.ToInt32(Memory, 4);
            Matrix[0, 2] = BitConverter.ToInt32(Memory, 8);
            Matrix[1, 0] = BitConverter.ToInt32(Memory, 12);
            Matrix[1, 1] = BitConverter.ToInt32(Memory, 16);
            Matrix[1, 2] = BitConverter.ToInt32(Memory, 20);
            Matrix[2, 0] = BitConverter.ToInt32(Memory, 24);
            Matrix[2, 1] = BitConverter.ToInt32(Memory, 28);
            Matrix[2, 2] = BitConverter.ToInt32(Memory, 32);
        }

        public byte[] GetBytes()
        {
            List<byte> arr = new List<byte>();

            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[0,0])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[0,1])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[0,2])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[1,0])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[1,1])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[1,2])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[2,0])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[2,1])));
            arr.AddRange(BitConverter.GetBytes(Convert.ToInt32(Matrix[2,2])));

            return arr.ToArray();
        }

        public int GetByteSize()
        {
            return ByteSize;
        }

        public static RotationMatrix_3 operator *(RotationMatrix_3 A, RotationMatrix_3 B)
        {
            var matrix = new RotationMatrix_3();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix.Matrix[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        matrix.Matrix[i, j] += A.Matrix[i, k] * B.Matrix[k, j];
                    }
                }
            }
            return matrix;
        }

        public static RotationMatrix_3 NewRotateAroundX(double radians)
        {
            var matrix = new RotationMatrix_3();
            matrix.Matrix[1, 1] = Math.Cos(radians);
            matrix.Matrix[1, 2] = Math.Sin(radians);
            matrix.Matrix[2, 1] = -(Math.Sin(radians));
            matrix.Matrix[2, 2] = Math.Cos(radians);
            return matrix;
        }
        public static RotationMatrix_3 NewRotateAroundY(double radians)
        {
            var matrix = new RotationMatrix_3();
            matrix.Matrix[0, 0] = Math.Cos(radians);
            matrix.Matrix[0, 2] = -(Math.Sin(radians));
            matrix.Matrix[2, 0] = Math.Sin(radians);
            matrix.Matrix[2, 2] = Math.Cos(radians);
            return matrix;
        }
        public static RotationMatrix_3 NewRotateAroundZ(double radians)
        {
            var matrix = new RotationMatrix_3();
            matrix.Matrix[0, 0] = Math.Cos(radians);
            matrix.Matrix[0, 1] = Math.Sin(radians);
            matrix.Matrix[1, 0] = -(Math.Sin(radians));
            matrix.Matrix[1, 1] = Math.Cos(radians);
            return matrix;
        }
    }
}
