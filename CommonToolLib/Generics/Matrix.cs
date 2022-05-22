using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonToolLib.Generics
{
    public class Matrix<T>
    {
        public int Rows { get; }
        public int Columns { get; }

        /// <summary>
        /// Structured as [Rows, Columns].
        /// </summary>
        public T[,] Values;

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Values = new T[Rows, Columns];
        }

        public static Vector<T> operator * (Matrix<T> a, Vector<T> b)
        {
            // Check compatibility.
            if (a.Columns != b.Length)
                throw new ArgumentException("Matrix not compatible.");

            // Because b is a vector, the result will be a.Rows x 1
            var result = new Vector<T>(a.Rows);

            for(int i = 0; i < result.Length; i++)
            {
                result.Values[i] = (a.Values[i, 0] as dynamic) * (b.Values[0] as dynamic);
                for(int j = 1; j < a.Columns; j++)
                {
                    result.Values[i] += (a.Values[i, j] as dynamic) * (b.Values[j] as dynamic);
                }
            }

            return result;
        }
    }
}
