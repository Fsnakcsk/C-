using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1차원_배열
{
    class Program
    {
        static double getSum(double[] a)
        {
            double sum = 0.0;

            for (int i = 0; i < a.Length; i++)
            {
                sum = sum + a[i];
            }
            return sum;
        }

        static int getMax(int[] a)
        {
            int max = -1;
            for(int i=0; i<a.Length; i++)
            {
                if(max < a[i])
                {
                    max = a[i];
                }
            }
            return max;
        }

        static void Main(string[] args)
        {
            // double형의 배열 래프란스
            double[] x = new double[3]; // 선언문 [반드시 힙영역에서 활동]

            x[0] = 34.78;
            x[1] = 23.65;
            x[2] = 83.45;

            for(int i=0; i<x.Length; i++)
            {
                Console.WriteLine(x[i]);
            }
//-----------------------------------------------------------------------------------------------------
            int[] y = new int[5];

            y[0] = 29;
            y[1] = 83;
            y[2] = 23;
            y[3] = 88;
            y[4] = 12;

            for (int i = 0; i < y.Length; i++)
            {
                Console.WriteLine(y[i]);
            }

            Console.WriteLine("max = " + getMax(y));

//-----------------------------------------------------------------------------------------------------

            double sum = getSum(x);
            Console.WriteLine("sum of x = " + sum);

//-----------------------------------------------------------------------------------------------------

            char[] c = new char[10];

            c[0] = 'a';
            for (int i = 0; i < 10; i++)
            {
                c[i] = (char) ((int)c[0] + i);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.Write((int)c[i] + " ");
            }
            Console.WriteLine("\n\n");

        }
    }
}
