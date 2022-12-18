using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace growable_array_test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[4];
            x[0] = 1;
            x[1] = 2;
            x[2] = 3;
            x[3] = 4;
            

            if (4 >= x.Length)
            {
                int[] y = new int[2 * x.Length];

                for (int i = 0; i < x.Length; i++)
                {
                    y[i] = x[i];
                }
                x = y;
            }
            x[4] = 5;
            x[5] = 6;
            x[6] = 7;
            x[7] = 8;
            x[8] = 9;



            for (int i = 0; i < x.Length; i++)
            {
                Console.Write(x[i] + " ");
            }
            Console.WriteLine();

        }
    }
}
