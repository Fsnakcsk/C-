using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixEvalua
{
    class Stack
    {
        //--------------<필요한 변수>----------------------------------------------------------------------------------------

        static int MAX = 100; // 배열의 크기는 (전역 변수에서 선언하고 관리하기 편함, 배열만들 때 크기를 정하면 관리 힘듬)
        int[] _s;              // 스텍의 만들기;
        int _top;              // 멘 위 위치를 가리키는 변수
        int _size;

        //----------------<초기화>-------------------------------------------------------------------------------------------

        //  housekeeping function
        private void initialize()    // 외부의서 사용하지 않다.
        {
            for (int i = 0; i < _s.Length; i++)
            {
                _s[i] = 0;
            }
        }

        public Stack()
            : this(MAX)       // 이건은 밑의 Public Stack(int n)를 호출하고 MAX값을 전달한다.
        {
        }
        public Stack(int n)
        {
            _s = new int[n];
            _top = -1;         // -1은 변수가 비어 있다라는 듯이다.
            _size = n;         // 배열의 크기 저장 (오버플로)방지 위해
            initialize();      // 초기화 함수
        }

        public void reset()
        {
            _top = -1;         // -1의 위치에 돌아가고 . 단지 처음부터 시작하게 보일뿐 값이 그대로 남아 있음
            initialize();      // 그래서 남은 값을 초기화 함수 다시 호출해서 초기화 하기
        }

        //----------<에러 조치>-------------------------------------------------------------------

        private void overflowError() //voerflowErro 방지를 위한 함수(조치)
        {
            Console.WriteLine("Stack overflow error occur.");
            Environment.Exit(-1);    //프로그램 종료
        }
        private void emptyError()
        {
            Console.WriteLine("Stack mepty error occur.");
            Environment.Exit(-1);    //프로그램 종료
        }

        //----------<함수 구현 부분>---------------------------------------------------------------------------------------

        //      --- 스텍에 값을 넣기 ---
        public void push(int x)
        {
            if (_top >= _size - 1) overflowError(); // overfolow 방지

            _top++;
            _s[_top] = x;
        }

        //    --- 스텍에서 값을 꺼내기 ---
        public int pop()
        {
            if (_top == -1) emptyError();    // pop 범위보다 작을 경우 애러 
            _top--;
            return _s[_top + 1]; //삭제가 아니끼 때문에 top-- 하고 나서 다시 그자리의 값을 반환
        }

        //    --- 스텍의 값을 꺼내기 않고 겂을만 홀터본다.(삭제하징않다)  ---

        public int peek()
        {
            return _s[_top];
        }

        //    --- 스텍 비어 있는지를 확인 ---
        public bool isEmpty()
        {
            if (_top == -1) return true;
            return false;
        }

        //    --- 스텍에서 값이 몇개인지 확인 ---

        public int getCount()
        {
            return _top + 1;
        }

        //    --- 스텍의 모든 값을 출력 --

        public void print()
        {
            Console.Write("[ ");
            for (int i = 0; i <= _top; i++)
            {
                Console.Write(_s[i] + " ");
            }
            Console.WriteLine(" ]");
        }

        //----------- <Main> ----------------------------------------------------------------------------------------------
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
            for(int i = 0; i < s.Length; i++)
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
            if((text[postion] == '-' && text[postion +1] == ' ') || (text[postion] == '-' && text[postion+1] == '\0'))
            {
                postion++;
                return ID_MINUS;
            }

//--------------< 숫자인 경우 >------------------------------------------------------------------------------------------

            String buffer = "";        // 빈 문자열을 만들었다. C보다 편한다. 이렇게 간단하게 ""를 저장하고 나중에 +를 사용해서 합치면 됨
            if(text[postion] == '-') 
            {
                buffer = buffer + "-";
                postion++;
            }
            while(text[postion] >='0' && text[postion] <= '9') //숫자인 경우 0~9의 이외의 것은 숫자가 아닌 이상한것이다.
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
                    } else if (tokenID == LineBuffer.ID_QUIT)
                    {
                        Environment.Exit(-1);
                    }

                }
            }

        }
    }
}
