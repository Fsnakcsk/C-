using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec06
{

    class Stack
    {
        static int MAX = 2;
        private int[] _s;
        private int _top;
        private int _size;

        private void initialize()
        {
            for (int i = 0; i < _size; i++)
            {
                _s[i] = 0;
            }
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
            _s = new int[n];
            _size = n;
            _top = -1;
            initialize();
        }

        public void push(int item)
        {
            if (_top >= _size - 1)
            {
                int[] newS = new int[2 * _size];
                for(int i = 0; i< _size; i++)
                {
                    newS[i] = _s[i];
                }
                _s = newS;
                _size = 2 * _size;
            }
            _top++;
            _s[_top] = item;
        }

        public int pop()
        {
            if (_top == -1) emptyError();
            int value = _s[_top];
            _top--;
            return (value);
        }

        public int peek()
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
    }
    class LineBuffer
    {
        public static int ID_QUIT = 1;
        public static int ID_PLUS = 2;
        public static int ID_MINUS = 3;
        public static int ID_MULTIPLY = 4;
        public static int ID_DIVIDE = 5;
        public static int ID_EOD = 6;
        public static int ID_OPERAND = 7;

        static int BUFSIZ = 256;

        private int _position;
        private char[] _text;
        private int _tokenValue;
        public LineBuffer(String text)
        {
            _text = new char[BUFSIZ];

            for (int i = 0; i < text.Length; i++)
            {
                _text[i] = text.ElementAt(i);
            }
            _text[text.Length] = '\0';

            _position = 0;
            _tokenValue = 0;
        }
        public int getTokenValue()
        {
            return _tokenValue;
        }
        public int getNextToken()
        {
            // skip blanks
            while (_text[_position] == ' ') _position++;

            if (_text[_position] == '\0') return ID_EOD;
            if (_text[_position] == '+')
            {
                _position++;
                return ID_PLUS;
            }
            if (_text[_position] == '*')
            {
                _position++;
                return ID_MULTIPLY;
            }
            if (_text[_position] == '/')
            {
                _position++;
                return ID_DIVIDE;
            }
            if ((_text[_position] == '-' && _text[_position + 1] == ' ') ||
                (_text[_position] == '-' && _text[_position + 1] == '\0'))
            {
                _position++;
                return ID_MINUS;
            }
            String buffer = "";
            int i = 0;

            if (_text[_position] == '-')
            {
                buffer = buffer + "-";
                i++;
                _position++;
            }
            while (_text[_position] >= '0' && _text[_position] <= '9')
            {
                buffer = buffer + _text[_position];
                i++;
                _position++;
            }

            _tokenValue = int.Parse(buffer);

            if (_text[_position] != ' ' && _text[_position] != '\0')
                return ID_QUIT;
            return ID_OPERAND;
        }
    }
    class PostfixEvaluator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type postfix expression: (ex) 1 2 3 + + ");
            Stack operands = new Stack();
            while (true)
            {
                String aLine;

                aLine = Console.ReadLine();

                LineBuffer buffer = new LineBuffer(aLine);

                while (true)
                {
                    int value = 0;
                    int tokenID = buffer.getNextToken();
                    value = buffer.getTokenValue();
                    if (tokenID == LineBuffer.ID_QUIT)
                    { // "quit"
                        Environment.Exit(0);
                    }
                    else if (tokenID == LineBuffer.ID_PLUS)
                    { // operator "+"
                        int a = operands.pop();
                        int b = operands.pop();
                        operands.push(a + b);
                    }
                    else if (tokenID == LineBuffer.ID_MINUS)
                    { // operator "-"
                        int a = operands.pop();
                        int b = operands.pop();
                        operands.push(b - a);
                    }
                    else if (tokenID == LineBuffer.ID_MULTIPLY)
                    { // operator "*"
                        int a = operands.pop();
                        int b = operands.pop();
                        operands.push(a * b);
                    }
                    else if (tokenID == LineBuffer.ID_DIVIDE)
                    { // operator "/"
                        int a = operands.pop();
                        int b = operands.pop();
                        operands.push(b / a);
                    }
                    else if (tokenID == LineBuffer.ID_EOD)
                    { // end of data
                        int data = operands.pop();
                        if (operands.isEmpty())
                        {
                            Console.WriteLine("= " + data);
                        }
                        else
                        {
                            Console.WriteLine("incorrect expression");
                        }
                        operands.reset();
                        break;
                    }
                    else
                    { // LineBuffer.ID_OPERAND
                        operands.push(value);
                    }
                }
            }
        }
    }
}
