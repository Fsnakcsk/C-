using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec05
{
    class Program
    {
        static void Main(string[] args)
        {
            char c;
            int i;
            double f;
            String answer;

            Console.WriteLine("Type achar, an integer, a floating number and a string : ");

            String s = "";
            s = Console.ReadLine();



            char[] separators = new char[1];
            separators[0] = ' ';
            String[] st = s.Split(separators);

            for(int x = 0; x < st.Length; x++)
            {
                Console.WriteLine(st[x]);
            }

            String tmp;
            tmp = st[0];
//          c = tmp.ElementAt(0);  // 문자열중에 멘 처음의 것을 가져온다.(그래서 문자니까 그대로 가져온 것임)
            c = tmp[0];            // 혹은 이렇게 해도 위의 문법과 똑같다.

            tmp = st[1];
            i = int.Parse(tmp);    // 정수를 만들어 준다.  c에서는 atoi("123") int로 바꿔준다.

            tmp = st[2];
            f = double.Parse(tmp); // 술수를 만들어 준다.  c에서는 atof("12.34) double로 바꿔준다.

            answer = st[3];

            Console.WriteLine("c = " + c);
            Console.WriteLine("i = " + i);
            Console.WriteLine("f = " + f);
            Console.WriteLine("s = " + answer);


        }
    }
}
