using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec10
{
    class Stack<Type>
    {
        static int MAX = 100;
        protected Type[] _s;
        protected int _top;
        protected int _size;
        private void initialize()
        {
            for (int i = 0; i < _size; i++)
            {
                _s[i] = default(Type);
            }
        }
        private void overflowError()
        {
            Console.WriteLine("Stack Overflow Error");
            Environment.Exit(-1);
        }
        private void emptyError()
        {
            Console.WriteLine("Stack Empty Error");
            Environment.Exit(-1);
        }
        public Stack() :
            this(MAX)
        {
        }
        public Stack(int n)
        {
            _s = new Type[n];
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
        public bool isEmpty()
        {
            if (_top == -1) return true;
            else return false;
        }

        public override string ToString()
        {
            String s = "[";
            for (int i = 0; i <= _top; i++)
            {
                if ( i == _top)
                {
                    s = s + _s[i];
                }
                else
                {
                    s = s + _s[i] + ",";
                }     
            }
            s = s + "]";
            return s;
        }
    }
    class TestStack
    {
        static void Main(string[] args)
        {
            Stack<int> a = new Stack<int>(10);
            Stack<int> b = new Stack<int>(20);
            Stack<double> c = new Stack<double>(10);
            Stack<String> d = new Stack<String>(10);
            a.push(1);
            a.push(2);
            a.push(3);
            a.push(4);
            b.push(30);
            b.push(20);
            b.push(10);
            b.push(0);
            c.push(1.3);
            c.push(2.4);
            c.push(3.2);
            d.push("kim");
            d.push("lee");
            d.push("park");
            d.push("kown");
            Console.WriteLine(a.pop());
            Console.WriteLine(a.pop());
            Console.WriteLine(b.pop());
            Console.WriteLine(b.pop());
            Console.WriteLine(c.pop());
            Console.WriteLine(c.peek());
            Console.WriteLine(d.peek());
            Console.WriteLine(d.pop());
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            String x = "a = " + a;
            Console.WriteLine(x);

        }
    }
}
