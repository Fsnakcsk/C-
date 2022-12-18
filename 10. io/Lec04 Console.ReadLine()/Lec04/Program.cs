using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec04
{
    class Program
    {
        static void Main(string[] args)
        {
            String buffer;
            Console.WriteLine("Type characters in a line and <Enter> key:");
            Console.WriteLine("An empty line stops this program:");
            while (true)
            {
                buffer = Console.ReadLine();
                if (buffer.Length == 0) break;
                Console.WriteLine(buffer);
            }
            Console.WriteLine("Bye !");

        }
    }
}
