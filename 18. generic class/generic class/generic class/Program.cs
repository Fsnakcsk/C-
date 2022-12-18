using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec02
{
    class Stack<Type>
    {

        static int MAX = 100;
        private Type[] _s;
        private int _top;
        private int _size;

        private void initialize()
        {
            for (int i = 0; i < _size; i++)
            {
                _s[i] = default(Type); //String이면 null가되고 숫자이면 알아서 한다.
            }
        }

        private void overflowError()
        {
            Console.WriteLine("Stack overflow error occurs.");
            Environment.Exit(-1);
        }

        private void emptyError()
        {
            Console.WriteLine("Stack empty error occurs.");
            Environment.Exit(-1);
        }

        public Stack()
            : this(MAX)
        {
        }

        public Stack(int n)
        {
            if (n > MAX)
            {
                Console.WriteLine("Stack size must be less than " + MAX + ".");
                Environment.Exit(-1);
            }
            _s = new Type[MAX];
            _size = n;
            _top = -1;
            initialize();
        }

        public void push(Type item)
        {
            if (_top >= _size - 1) overflowError();
            _top++;
            _s[_top] = item;
        }

        public Type pop()
        {
            if (_top == -1) emptyError();
            Type value = _s[_top];
            _top--;
            return (value);
        }

        public Type peek()
        {
            if (_top == -1) emptyError();
            return (_s[_top]);
        }

        public void reset()
        {
            _top = -1;
            initialize();
        }
        
    }
//-----------------------------------------------------------------------------------------------------------
    class TestStack
    {
        static void Main(string[] args)
        {
            Stack<int> a = new Stack<int>();

            a.push(10);
            a.push(20);
            a.pop();
            a.push(30);
            a.push(40);

            Console.WriteLine("top of stack a = " + a.peek());

            //----------------------------------------------------------

            Stack<double> b = new Stack<double>();

            b.push(23.4);
            b.push(20.2);
            b.pop();
            b.push(90.4);
            b.push(12.8);

            Console.WriteLine("top of stack a = " + b.peek());

            //----------------------------------------------------------

            Stack<String> c = new Stack<String>();

            c.push("kim");
            c.push("lee");
            c.pop();
            c.push("park");
            c.push("kwon");

            Console.WriteLine("top of stack a = " + c.peek());
        }
    }
}
