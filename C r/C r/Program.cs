using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//   Console.WriteLine("n = {0}, from = {1}, temp ={2}, to = {3)", n, from, temp, to);

namespace C_r
{
    class Program
    {
//    Console.WriteLine("1 : 말뚝 A에서 C로 원반 1를 이동합니다.");
        static void moveHanoi(int n, char from, char tmp, char to)
        {
            int count = 1;
            string a1 = "*";
            string a2 = "**";
            string a3 = "***";
            string a4 = "****";
            string a5 = "*****";

            if (n == 5)
            {
                Console.WriteLine(a1);
                Console.WriteLine(a2);
                Console.WriteLine(a3);
                Console.WriteLine(a4);
                Console.WriteLine(a5);
                Console.WriteLine("-----A1-----  -----B2-----  -----C3-----");
                Console.WriteLine(count + " : 말뚝 A에서 C로 원반 1를 이동합니다.");

            }

                if (n == 1)
            {            
            
                return;
            }
            moveHanoi(n - 1, from, to, tmp);
            moveHanoi(1, from, tmp, to);
            moveHanoi(n - 1, tmp, from, to);


        }
        static void Main(string[] args)
        {

            moveHanoi(5, '1', '2', '3');
        }
    }
}
