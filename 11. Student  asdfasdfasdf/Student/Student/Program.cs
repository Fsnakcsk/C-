using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //피일을 사용하려면 여기서 명시를 해야 된다.

namespace Student
{
    class StudentTest
    {
        String name;
        int kor;
        int eng;
        int math;
        int total;
        double ave;
        public StudentTest()
        {
        }
        public void setData(String[] st)
        {
            name = st[0];
            kor = int.Parse(st[1]);
            eng = int.Parse(st[2]);
            math = int.Parse(st[3]);
        }    
        public void calculateTotal()
        {
            total = kor + eng + math;
        }
        public void calculateAverage()
        {
            ave = total / 3.0;
        }
        public void print()
        {
            s[i].print();
            String format = String.Format("{0,8}{1,8}{2,8}{3,8}{4,8}{5,8:F1}",
                s[i].name, s[i].kor, s[i].eng, s[i].math, s[i].total, s[i].ave);
            Console.WriteLine(format);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {

//---------------------------------------------------------------------------------------------------
//          파일 생성 과정

            int n;
            StudentTest[] s;   // class를 가리키는 포인터
            FileStream file;   // 파일 생성
            file = new FileStream("data.txt", FileMode.Open, FileAccess.Read); //파일 열기
            StreamReader reader = new StreamReader(file); //  파일로부터 리더를 만든다.

//---------------------------------------------------------------------------------------------------

            String buffer = reader.ReadLine(); //  첫 번째 줄 5를 읽어와(문자)
            n = int.Parse(buffer);             //  5를 int로 바꾼다.
//---------------------------------------------------------------------------------------------------
            Console.WriteLine(n);

            s = new StudentTest[n];

            for (int i = 0; i < n; i++)
            {
                buffer = reader.ReadLine(); // ???????????????????????????????????????????????????????????????????
//----------------------------------------------------------
                char[] separator = new char[1];
                separator[0] = ' ';
                String[] st = buffer.Split(separator);
//----------------------------------------------------------
                s[i] = new StudentTest();
                s[i].setData(st);
              
            }

            reader.Close();

            for (int i = 0; i < n; i++)
            {
                s[i].calculateTotal();
                s[i].calculateAverage();
            }

            Console.WriteLine("    성명     국어    영어    수학    합계   평균");
            for (int i = 0; i < n; i++)
            {
                s[i].print();
            }
            Console.WriteLine("=========================================================");



            file.Close();
        }
    }
}
