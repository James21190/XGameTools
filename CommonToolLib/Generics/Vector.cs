using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Generics
{
    public class Vector<T> : ICloneable
    {
        // When converted int a matrix, this will be a Length x 1 matrix.

        public int Length { get; }

        public T[] Values;

        public T X => Values[0];
        public T Y => Values[1];
        public T Z => Values[2];
        public T W => Values[3];

        public Vector(int length)
        {
            Length = length;
            Values = new T[Length];
        }

        public Matrix<T> ToMatrix()
        {
            var matrix = new Matrix<T>(Length,1);
            for(int i = 0; i < Length; i++)
            {
                matrix.Values[0,i] = Values[i];
            }
            return matrix;
        }

        public static Matrix<T> operator * (Vector<T> a, Matrix<T> b)
        {
            // A is length x 1
            // B is height x width

            // Check compatability
            if (b.Rows != 1)
                throw new ArgumentException("Matrix not compatible.");

            // Get result matrix
            var result = new Matrix<T>(a.Length, b.Columns);

            for(int i = 0; i < result.Rows; i++)
            {
                for(int j = 0; j < result.Columns; j++)
                {
                    // For every cell in result
                    // Multiply row in vector by column in matrix
                    result.Values[i, j] = (a.Values[i] as dynamic) * (b.Values[0,j] as dynamic);
                }
            }

            return result;
        }

        public override string ToString()
        {
            return "(" + String.Join(", ", Values) + ")";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
