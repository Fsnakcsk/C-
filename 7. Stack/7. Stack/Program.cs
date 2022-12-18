using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Stack
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
            if (_top == -1)     emptyError();    // pop 범위보다 작을 경우 애러 
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
    class Program
    {
        static void Main(string[] args)
        {
            Stack a = new Stack(1000);
            Stack b = new Stack(4);

            a.push(10);
            a.push(20);
            int x = a.pop();
            a.push(30);
            a.push(40);

            b.push(100);
            b.push(200);
            b.push(300);
            b.push(400);
            int y = b.pop();

            Console.WriteLine("x = {0}, y = {1}", x, y);

//----------- < 스텍을 다시 초기화 > ------------------------------------------------------------------------------------------------

            b.reset();   // b.clear(); 초기화 한다.
            b.push(1000);
            b.push(2000);
            b.push(3000);
            b.push(4000);

            //---------- <스텍이 비어 있는지 확인> --------------------------------------------------------------------------

            if (b.isEmpty())  // 스텍이 비어 있냐 
            {
                Console.WriteLine("empty"); // 비어 있다.
            }
            else
            {
                Console.WriteLine("not empty"); // 아니다.
            }

//------ < 스텍에 데이터가 몇개 있느냐 > ---------------------------------------------------------------------

            Console.WriteLine("count of a {0} \ncount of b {1}", a.getCount(), b.getCount());

//------ < 스텍에 데이터 멘 위의 값을 홀터본다 > -------------------------------------------------------------

            Console.WriteLine("count of a {0} \ncount of b {1}", a.peek(), b.peek());

//------ < 스텍에 모든 값을 출력 > ---------------------------------------------------------------------

            a.print();
            b.print();
        }
    }
}
