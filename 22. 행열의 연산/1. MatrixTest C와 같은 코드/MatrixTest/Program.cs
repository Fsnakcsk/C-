using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTest
{
    class Program  
    {
        static int[,] add(int[,] a, int[,] b)
        {
            int row = a.GetLength(0);
            int col = a.GetLength(1);
            int[,] c = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }
            return c;
        }
        static int[,] subtract (int[,] a, int[,] b)
        {
            int row = a.GetLength(0);
            int col = a.GetLength(1);
            int[,] c = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    c[i, j] = a[i, j] - b[i, j];
                }
            }
            return c;
        }
        static int[,] multiply(int[,] a, int m)
        {
            int row = a.GetLength(0);
            int col = a.GetLength(1);
            int[,] c = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    c[i, j] = m * a[i, j];
                }
            }
            return c;
        }
        static int[,] multiply(int[,] a, int[,] b)
        {
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            int l = b.GetLength(1);
            int[,] c = new int[m, l];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < l; j++)
                {
//                    c[i, j] = a[i, 0] * b[0, j] + a[i,1] * b[1,j] + a[i,2]*b[2,j];........
                    c[i, j] = 0;
                    for (int k = 0; k < n; k++)
                    {
                        c[i, j] = c[i, j] + a[i, k] * b[k, j];
                    }
                }
            }
            return c;
        }
        static void print(int[,] a)
        {
            for(int i = 0; i<a.GetLength(0); i++)
            {
                for(int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[,] x = { { 1, 2, 3, 4 },
                         { 5, 6, 7, 8 },
                         { 9, 10, 11, 12} };

            int[,] y = { { 1, 1, 1, 1 },
                         { 2, 2, 2, 2 },
                         { 3, 3, 3, 3 }  };

            int[,] w = { { 1,1 },
                         { 1,1 },
                         { 2,2 },
                         { 2,2 } };

            int[,] z;

            print(x);
            print(y);

            z = add(x, y);      // 합 구하기
            print(z);

            z = subtract(x, y); // 차 구하기
            print(z);

            z = multiply(x, 2); // 합 구하기 scalar mutiplication
            print(z);


            print(x);
            print(w);
            z = multiply(x, w); // 합  구하기 scalar mutiplication
            print(z);
        }
    }
}
