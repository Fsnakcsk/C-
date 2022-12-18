using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.@string
{
    class Program
    {
        static void Main(string[] args)
        {
            String a = "Hello";
            String b = new String('x', 5); // x가 5개 어루어진 문자열을 만들어라!
            String c = "wrold";
            String d = b;
            String e = "";
//          String f;     // 절재 이렇게 하면 안 됨

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);

//------------------------------------------------------------
//          <String.Empty>           String e = ""; 와 같다

            e = String.Empty;
            Console.WriteLine(e); // 똑같이 비어 있어

//------------------------------------------------------------
//          특정위치의 문자를 무엇인지를 확인할 수 있다.

            char x = a[1];
            Console.WriteLine(x); // Java에서는 a,charAt(1);
            // a[1] = 'x'  이렇게 특정위치에 값을 넣을 수 없다,

//------------------------------------------------------------
//          <~.Length> 길이, 크기 확인

            int n = a.Length;
            Console.WriteLine(n);

//------------------------------------------------------------
//          < (String)~.Clone() > 복제, 복사

            String p = (String)a.Clone(); //Clone는 String로 바꾸니까 앞에 (String)쓰는 거임
            Console.WriteLine(p);

//------------------------------------------------------------
//          교체

            a = a.Replace('e', 'o');
            Console.WriteLine(a);

//------------------------------------------------------------
//          <Replace> 교체

            a = a.Replace('e', 'o');
            Console.WriteLine(a);

//------------------------------------------------------------
//          <Index> 문자가 위치(인덱스) 어딘지 확인

            int m = c.IndexOf("l");
            Console.WriteLine(m);

//------------------------------------------------------------
//          <String.Format> 두개의 문자열을 합한다.

            String f = String.Format("{0} and {1}",a,c);
            Console.WriteLine(m);

//------------------------------------------------------------
//          <Concat(Object, Object)> 연결하기

            String o = "-123";
            Console.WriteLine("1) {0}", String.Concat(o));
            Console.WriteLine("2) {0}", String.Concat(o, o));
            Console.WriteLine("3) {0}", String.Concat(o, o, o));
            Console.WriteLine("4) {0}", String.Concat(o, o, o, o));


//          <Concat(String, String)> 연결하기
            Console.WriteLine("1) {0}", String.Concat(a, b, c));


//------------------------------------------------------------


//------------------------------------------------------------
//          비교  (a와 b의 문자가 같으냐)

            if (a.Equals(b))       //문자가 같으냐
            {
                Console.WriteLine("same");       // 같다
            }
            else
            {
                Console.WriteLine("different");  // 다르다
            }

//-----------------
//          <if (~.Equals("")) ~와 ""> 가 같으냐

            if (a.Equals("Hello")) 
            {
                Console.WriteLine("same");       // 같다
            }
            else
            {
                Console.WriteLine("different");  // 다르다
            }

//-----------------
//          <if (a.CompareTo(b) >, < 0)> ~와 ㅇ떤 것 더 크냐

            if (a.CompareTo(b) > 0)
            {
                Console.WriteLine(a + " > " + b);
            }
            else if(a.CompareTo(b) < 0)
            {
                Console.WriteLine(a + " < " + b);
            }
            else
            {
                Console.WriteLine("same"); // 같다
            }

//------------------------------------------------------------
            b = a = "Hi professor Kim! ";
            c = a + b;
            d = d + " How are you ?";

            Console.WriteLine("a" + a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);

            Console.WriteLine(d.Length);// 길이. 크기
            
        }
    }
}
