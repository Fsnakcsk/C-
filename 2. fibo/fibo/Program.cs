using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * f(n) = f(-1) + f(n-2) when n >= 2  시그니처 
 * f(1) = 1 when n = 1
 * f(0) = 1 when n = 0
*/


// 1   1   2   3   5   8   13   21
// f0  f1  f2  f3  f4  f5  f6   f7
namespace fibo
{
    class Program
    {
        static int fibo(int n) // 시그니처 , for말 파라메타
        {
              // 재귀함수로 피보니치
            if (n == 0) return 1;
            if (n == 1) return 1;
            if (n >= 2) return fibo(n - 1) + fibo(n - 2);

            Console.WriteLine("Unexpected minus argument");
            Environment.Exit(-1);
            return -1;
            
            
            /*
            int f0 = 1;
            int f1 = 1;
            int f2 = 0;

            for (int i = 1; i < n; i++)
            {
                f2 = f1 + f0;
                f0 = f1;
                f1 = f2;
            }
            return f2;
            */

        }
        static void Main(string[] args)
        {   /*
            for (int i = 0; i <= 44; i++)
            {
                Console.WriteLine(i + " = " + fibo(i)); // 액취파라메타
            }
            */
            Console.WriteLine(fibo(7));
        }
    }
}
