using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            /*           
            *           StringBuilder는 밑에 예제처럼 하는 것이 아니다.
            * -------------------------------------------------------------------------
            * 
            //          String와 달리 new StringBuilder("") 해야함
                        StringBuilder b = new StringBuilder("hello");

                        Console.WriteLine(b);
                        Console.WriteLine(b.Length);

            //          String와 달리 StringBuilder는 인덱스[]에 값을 넣거나 바꿀 수 있다.
                        b[2] = 'x';
                        Console.WriteLine(b);

            ----------------------------------------------------------------------------
            */
            /*
                        String s = "hello";
                        long start = DateTime.Now.Ticks;
                        for (int i = 0; i < 20000; i++) 
                            s = s + "hello";

                        for (int i = 0; i < 11; i++)
                        {
                            if(i % 2 == 0)
                            {
                                s = s.Replace('o', 'a');
                            }
                            else
                            {
                                s = s.Replace('a', 'o');
                            }
                        }

                        s = s.Remove(20, s.Length - 20);
                        long end = DateTime.Now.Ticks;
                        Console.WriteLine("s: {0}, delay time: {1}", s, end - start);
            */

            StringBuilder sb = new StringBuilder("hello");
            long start = DateTime.Now.Ticks;
            for (int i = 0; i < 20000; i++) sb = sb.Append("hello");
            for(int i=0; i<11; i++)
            {
                if(i%2 == 0)
                {
                    sb = sb.Replace('o', 'a');
                }
                else
                {
                    sb = sb.Replace('a', 'o');
                }
            }
            sb = sb.Remove(20, sb.Length - 20);
            long end = DateTime.Now.Ticks;
            Console.WriteLine("sb: {0}, delay time: {1}", sb, end - start);
        }
    }
}
