using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixEvalua
{ 
    class StackException : Exception
    {// 에러 정보 전달
        private String className;
        private String functionName;
        private String reason;
        public StackException(String cName, String fName, String reason)
        {
            className = cName;
            functionName = fName;
            this.reason = reason;
        }
        public String getClassName()
        {
            return className;
        }
        public String getFunctionName()
        {
            return functionName;
        }
        public String getReason()
        {
            return reason;
        }
    }
    class Stack
    {
        // inner class 
        public class Stackitem
        {
            private int value;
            private Stackitem next;
            public Stackitem(int v)
            {
                value = v;
                next = null;
            }
            public int getValue()
            {
                return value;
            }
            public void setValue(int v)
            {
                value = v;
            }
            public Stackitem getNext()
            {
                return next;
            }
            public void setNext(Stackitem node)
            {
                next = node;
            }
        }        

        private Stackitem top;
        private void initialize()
        {
            top = null;
        }

        public Stack()
        {
            initialize();
        }

        public void reset()
        {
            initialize();
        }

        private void overflowError() 
        {

        }
        private void emptyError()
        {
            Console.WriteLine("Stack empty error occurs.");
            Environment.Exit(-1);
        }


        public void push(int x)
        {
            if (top == null)
            {
                top = new Stackitem(x);
            }
            else
            {
                Stackitem item = new Stackitem(x);
                item.setNext(top); // item.next = top;
                top = item;
            }
        }


        public int pop()
        {
            if (top == null) throw new StackException("Stack","pop()","Stack empty error");
            Stackitem topItem = top;
            top = top.getNext(); // top = top.next;
            return topItem.getValue();
        }


        public int peek()
        {
            if (top == null) emptyError();
            return top.getValue();
        }

        public bool isEmpty()
        {
            if (top == null) return true;
            else return false;
        }

        public int getCount()
        {
            int n = 0;
            Stackitem tmp = top;

            while(tmp != null)
            {
                tmp = tmp.getNext();
            }
            return n;
        }

        public void print()
        {
            Stackitem tmp = top;

            while (tmp != null)
            {
                Console.WriteLine(tmp.getValue() + " ");
                tmp = tmp.getNext();
            }
        }


    }

    class LineBuffer
    { // LineBuffer의 공급자
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

            //--------------< 숫자인 경우 >------------------------------------------------------------------------------------------

            String buffer = "";        // 빈 문자열을 만들었다. C보다 편한다. 이렇게 간단하게 ""를 저장하고 나중에 +를 사용해서 합치면 됨
            if (text[postion] == '-')
            {
                buffer = buffer + "-";
                postion++;
            }
            while (text[postion] >= '0' && text[postion] <= '9') //숫자인 경우 0~9의 이외의 것은 숫자가 아닌 이상한것이다.
            {
                buffer = buffer + text[postion];
                postion++;
            }
            tokenValue = int.Parse(buffer);                    // int로 바꿔서 tokenValue로 넣는다.

            if (text[postion] != ' ' && text[postion] != '\0') // 사용자가 입력을 잘못 입력할까봐 에 대한 조치
            {
                return ID_QUIT;                                // 종료함
            }

            return ID_OPERAND;  // 숫자를 돌려준다.

        }
        public int getTokenValue()
        {
            return tokenValue;
        }



    }

    class Program
    {
        // LineBuffer의 사용자
        static void Main(string[] args)
        {

            Console.WriteLine("Type postfix expression: (ex) 1 2 3 + +");
            Stack operands = new Stack();

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
                            operands.push(value);
                        }
                        else if (tokenID == LineBuffer.ID_PLUS)
                        {
                            int a = operands.pop();
                            int b = operands.pop();
                            operands.push(b + a);
                        }
                        else if (tokenID == LineBuffer.ID_MINUS)
                        {
                            int a = operands.pop();
                            int b = operands.pop();
                            operands.push(b - a);
                        }
                        else if (tokenID == LineBuffer.ID_MULTIPLY)
                        {
                            int a = operands.pop();
                            int b = operands.pop();
                            operands.push(b * a);
                        }
                        else if (tokenID == LineBuffer.ID_DIVIDE)
                        {
                            int a = operands.pop();
                            int b = operands.pop();
                            operands.push(b / a);
                        }
                        else if (tokenID == LineBuffer.ID_EOD)
                        {
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
                        else if (tokenID == LineBuffer.ID_QUIT)
                        {
                            Environment.Exit(-1);
                        }
                    } catch(StackException ex)
                    {
                        Console.WriteLine("A stack exception(" + ex.getReason() + ") was thrown by");
                        Console.WriteLine("the funtion " + ex.getFunctionName() + " of class ");
                        Console.WriteLine(ex.getClassName() + ".");
                        Console.WriteLine("The stack will be reset. Please try again.");
                        operands.reset();
                        break;
                    }
                }
            }
        }
    }
}
