using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace курсач_2._0
{
    public class KZN_Data
    {
        public int[,] F;
        public int[,] D;
        public int Size;
        public KZN_Data(string fileName) 
        {
            var matrix = Loader.LoadFromFile(fileName,out Size);
            F = matrix.F;
            D = matrix.D;
        }
        void PrintMatrix(int[,] matrix)
        {
            int N = matrix.GetLength(0);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public int GetCriteria(int[] permutation)
        {
            int criteria = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (j == i) continue;
                    criteria += F[i, j] * D[permutation[i]-1, permutation[j]-1];
                }
            }
            return criteria;
        }
    }
}
