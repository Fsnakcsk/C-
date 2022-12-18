using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec22
{

        class Student
        {
            private String ms_name;
            private int m_data;
            static int MALE_MASK = (1 << 0);
            static int PRCH_MASK = (1 << 1);
            static int TALL_MASK = (1 << 2);
            static int CUTE_MASK = (1 << 3);


        public Student()
            {
                ms_name = "";
                m_data = 0;
            }
            public Student(String s)
            {
                ms_name = s;
                m_data = 0;
            }
            //                 이름       성별       부자       키        생김새
            public Student(String s, bool male, bool rich, bool tall, bool cute)
            {
                ms_name = s;
                setMale(male);
                setRich(rich);
                setTall(tall);
                setCute(cute);
            }
            public String getName()
            {
                return ms_name;
            }
            public void setMale(bool flag)
            {
                if (flag) m_data = m_data | MALE_MASK;
                else m_data = m_data & ~MALE_MASK;
            }
            public void setRich(bool flag)
            {
                if (flag) m_data = m_data | PRCH_MASK;
                else m_data = m_data & ~PRCH_MASK;
            }
            public void setTall(bool flag)
            {
                if (flag) m_data = m_data | TALL_MASK;
                else m_data = m_data & ~TALL_MASK;
            }
            public void setCute(bool flag)
            {
                if (flag) m_data = m_data | CUTE_MASK;
                else m_data = m_data & ~CUTE_MASK;
            }
            public bool isMale()
            {
                if ((m_data & MALE_MASK) != 0) return true;
                else return false;
            }
            public bool isRich()
            {
                if ((m_data & PRCH_MASK) != 0) return true;
                else return false;
            }
            public bool isTall()
            {
                if ((m_data & TALL_MASK) != 0) return true;
                else return false;
            }
            public bool isCute()
            {
                if ((m_data & CUTE_MASK) != 0) return true;
                else return false;
            }
            public override String ToString()
            {
                String tmp = "";
                tmp = tmp + ms_name + " is ";
                if (isMale()) tmp = tmp + "a boy and he is ";
                else tmp = tmp + "a girl and she is ";
                if (isRich()) tmp = tmp + "rich, ";
                else tmp = tmp + "poor, ";
                if (isTall()) tmp = tmp + "tall and ";
                else tmp = tmp + "short and ";
                if (isCute()) tmp = tmp + "cute.";
                else tmp = tmp + "ugly.";
                return tmp;
            }
            public void readDataFromConsole()
            {
                String buffer = Console.ReadLine();
                char[] delemeter = new char[1];
                delemeter[0] = ' ';
                String[] data = buffer.Split(delemeter);

                ms_name = data[0];

                if (data[1].Equals("1")) setMale(true);
                else setMale(false);
                if (data[2].Equals("1")) setRich(true);
                else setRich(false);
                if (data[3].Equals("1")) setTall(true);
                else setTall(false);
                if (data[4].Equals("1")) setCute(true);
                else setCute(false);
            }
        }

    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 20;
//          int tmp;

            // swap
            Console.WriteLine(" x = " + x + ", y = " + y);
            x = x ^ y;
            y = x ^ y;
            x = x ^ y;

//          tmp = x;
//          x = y;
//          y = tmp;
            Console.WriteLine(" x = " + x + ", y = " + y);

            /*
            Student x = new Student("kim");
            Student y = new Student("lee", true, false, true, true);
            Student z = new Student("park", false, false, true, false);

            x.setRich(true);  // 부자
            x.setCute(true);  // 잘 생겼냐

            y.setMale(false); // 성별
            y.setRich(true);  // 부자

            z.setTall(false); // 키
            z.setCute(true);  // 잘 생겼냐

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);

            Student[] st = new Student[5];

            Console.WriteLine("Type information for 5 students as \"park 0 1 0 1\"");

            int i;
            for (i = 0; i < 5; i++)
            {
                st[i] = new Student();
                st[i].readDataFromConsole();
            }

            Console.WriteLine("== favorite spouse candidates list ==");
            for (i = 0; i < 5; i++)
            {
                if (st[i].isRich() && st[i].isCute())
                {
                    Console.WriteLine(st[i].getName());
                }
            }
            */
        }
    }
}
