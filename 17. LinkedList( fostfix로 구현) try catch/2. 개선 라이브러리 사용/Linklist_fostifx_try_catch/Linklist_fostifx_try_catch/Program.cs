using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixEvalua
{
    class LineBuffer
    { 
        public static int ID_QUIT = 1;
        public static int ID_PLUS = 2;
        public static int ID_MINUS = 3;
        public static int ID_MULTIPLY = 4;
        public static int ID_DIVIDE = 5;
        public static int ID_EOD = 6;
        public static int ID_OPERAND = 7;
        public static int BUFSIZ = 256;


        private char[] text;
        private int postion;
        private int tokenValue;
        public LineBuffer(String s)
        {
            this.text = new char[BUFSIZ];
            for (int i = 0; i < s.Length; i++)
            {
                text[i] = s.ElementAt(i);
            }
            text[s.Length] = '\0';
            postion = 0;
            tokenValue = 0;
        }
        public int getNextToken()
        {
            while (text[postion] == ' ') postion++;

            if (text[postion] == '\0') return ID_EOD;

            if (text[postion] == '+')
            {
                postion++;
                return ID_PLUS;
            }
            if (text[postion] == '*')
            {
                postion++;
                return ID_MULTIPLY;
            }
            if (text[postion] == '/')
            {
                postion++;
                return ID_DIVIDE;
            }
            if ((text[postion] == '-' && text[postion + 1] == ' ') || (text[postion] == '-' && text[postion + 1] == '\0'))
            {
                postion++;
                return ID_MINUS;
            }

            String buffer = "";       
            if (text[postion] == '-')
            {
                buffer = buffer + "-";
                postion++;
            }
            while (text[postion] >= '0' && text[postion] <= '9') 
            {
                buffer = buffer + text[postion];
                postion++;
            }
            tokenValue = int.Parse(buffer);

            if (text[postion] != ' ' && text[postion] != '\0')
            {
                return ID_QUIT;
            }

            return ID_OPERAND;

        }
        public int getTokenValue()
        {
            return tokenValue;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Type postfix expression: (ex) 1 2 3 + +");
            Stack<int> operands = new Stack<int>();

            while (true)
            {
                String aLine = Console.ReadLine();

                LineBuffer buffer = new LineBuffer(aLine);
                while (true)
                {
                    int tokenID = buffer.getNextToken();
                    int value;
                    value = buffer.getTokenValue();

                    try
                    {
                        if (tokenID == LineBuffer.ID_OPERAND)
                        {
                            operands.Push(value);
                        }
                        else if (tokenID == LineBuffer.ID_PLUS)
                        {
                            int a = operands.Pop();
                            int b = operands.Pop();
                            operands.Push(b + a);
                        }
                        else if (tokenID == LineBuffer.ID_MINUS)
                        {
                            int a = operands.Pop();
                            int b = operands.Pop();
                            operands.Push(b - a);
                        }
                        else if (tokenID == LineBuffer.ID_MULTIPLY)
                        {
                            int a = operands.Pop();
                            int b = operands.Pop();
                            operands.Push(b * a);
                        }
                        else if (tokenID == LineBuffer.ID_DIVIDE)
                        {
                            int a = operands.Pop();
                            int b = operands.Pop();
                            operands.Push(b / a);
                        }
                        else if (tokenID == LineBuffer.ID_EOD)
                        {
                            int data = operands.Pop();
                            if (operands.Count == 0)
                            {
                                Console.WriteLine("= " + data);
                            }
                            else
                            {
                                Console.WriteLine("incorrect expression");
                            }
                            operands.Clear();
                            break;
                        }
                        else if (tokenID == LineBuffer.ID_QUIT)
                        {
                            Environment.Exit(-1);
                        }
                    }
                    catch(InvalidOperationException ex)
                    {
                        Console.WriteLine(ex);
                        operands.Clear();
                        break;
                    }
                }
            }
        }
    }
}