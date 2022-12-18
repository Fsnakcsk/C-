using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 경기도
{
    class 광주시
    {
        public static string whereAreYou()
        {
            return "경기도/광주시/여기";
        }
    }
}

namespace 전라남도
{
    class 광주시
    {
        public static string whereAreYou()
        {
            return "전라남도/광주시/여기)";
        }
    }
}
namespace 서울시
{
    class 종로구
    {// public는 공공의 듯, 외부에서 공공적으로 사용할 수 있다.
        public static string whereAreYou()
        {
            return "서울시/종로구/사직동";
        }
    }
}

namespace 부산시
{   //class는 박스라고 생각하고 가시성이라는 게 박상안에 있는 것을 외부에서 사용이 가능하냐
    // visibility(가시성) 
    class 동래구
    {                                        // public는 공공의 듯, 외부에서 공공적으로 사용할 수 있다.
        public static string whereAreYou() 
        {
            return "부산시/동래구/사직동";
        }
        public static int add(int x, int y)
        {
            return x + y + 100;
        }
    }
    class Program
    {
                                       // function overlading ### 똑같은 함수를 다른 클래스에 붙여주고 만둘 수 있는 기능이다 ###
        static int add(int x, int y)
        {
            return x + y;
        }

        static double add(double x, double y) // 이렇게 C# 에서는 똑같은 이름을 쓸 수가 있다.
        {
            return x + y;
        }

        static int add(int x, int y, int z)
        {
            return x + y + z;
        }

        static string whereAreYou()
        {
            return "부산시/Program/사직동";
        }
        static void Main(string[] args)
        {
            int ans1;
            double ans2;
            int ans3;

            ans1 = add(10, 20);
            Console.WriteLine(ans1);

            ans2 = add(1.5, 8.2);
            Console.WriteLine(ans2);

            ans3 = add(10, 20, 30);
            Console.WriteLine(ans3);

            ans1 = 동래구.add(10, 20);
            Console.WriteLine(ans1);

            Console.WriteLine(whereAreYou());                // 부산시 (namespace) / Program / whereAreYou() : namespace와 class 똑같아 그래서 생략
            Console.WriteLine(동래구.whereAreYou());         // 부산시 (namespace) / 동래구  / whereAreYou() : namespace이 똑같지만 class가 달라 그래서 class 명시해야 함
            Console.WriteLine(서울시.종로구.whereAreYou());  // 서울시 (namespace) / 종로구  / whereAreYou() : full name를 이용한다
            Console.WriteLine(경기도.광주시.whereAreYou());
            Console.WriteLine(전라남도.광주시.whereAreYou());

        }
    }
}
