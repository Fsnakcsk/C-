using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec02
{
    class TestStack
    {
        static void Main(string[] args)
        {
            Stack<int> a = new Stack<int>();

            a.Push(10);
            a.Push(20);
            a.Pop();
            a.Push(30);
            a.Push(40);

            Console.WriteLine("top of stack a = " + a.Peek());

            //----------------------------------------------------------

            Stack<double> b = new Stack<double>();

            b.Push(23.4);
            b.Push(20.2);
            b.Pop();
            b.Push(90.4);
            b.Push(12.8);

            Console.WriteLine("top of stack a = " + b.Peek());

            //----------------------------------------------------------

            Stack<String> c = new Stack<String>();

            c.Push("kim");
            c.Push("lee");
            c.Pop();
            c.Push("park");
            c.Push("kwon");

            Console.WriteLine("top of stack a = " + c.Peek());
        }
    }
}
