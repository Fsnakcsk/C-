using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type characters and <Enter> key:");
            while(true)
            {
            char ch = (char)Console.Read();
            if (ch == '\n') break;
            Console.Write(ch);
            }
            Console.WriteLine();
            
        }
    }
}
