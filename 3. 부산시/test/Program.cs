using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static int add(int x, int y)
        {
            return x + y;
        }
        static double add(int x, int y)
        {
            return x + y;
        }
        static int add(int x, int y, int z)
        {
            return x + y + z;
        }
        static void Main(string[] args)
        {
            int ans1;
            double ans2;
            int ans3;

            ans1 = add(10, 20);
            Console.WriteLine(ans1);

        }
    }
}
