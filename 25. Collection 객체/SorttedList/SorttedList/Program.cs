using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Collection
{
    class Student
    {
        String name;
        int total;
        char grade; //성적
        public Student(String name, int total, char grade)
        {
            this.name = name;
            this.total = total;
            this.grade = grade;
        }
        public override string ToString()
        {
            return "[" + name + " total: " + total + " grade: " + grade + "]";
        }
        public char getGrade()
        {
            return grade;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SortedList list = new SortedList();

            list.Add("Kim", new Student("Kim", 99, 'A'));
            list.Add("park", new Student("park", 10, 'F'));
            list.Add("lee", new Student("lee", 70, 'C'));
            list.Add("kwon", new Student("kwon", 80, 'B'));
            list.Add("ban", new Student("ban", 90, 'A'));


            //--------------------------------------------
            //학점만 출력
            Console.WriteLine(list["kwon"]);
            Student st = (Student)list["kwon"];
            Console.WriteLine("kwon의 학점: " + st.getGrade());
            Console.WriteLine("===");
            //--------------------------------------------

            foreach (DictionaryEntry s in list)
            {
                Console.WriteLine(s.Key + ":" + s.Value);
            }


            Console.WriteLine("===");
            //--------------------------------------------
            //Java 스타일

            IEnumerator e = list.GetEnumerator();
            while (e.MoveNext())
            {
                DictionaryEntry s = (DictionaryEntry)e.Curre nt;
                Console.WriteLine(s.Key + ":" + s.Value);
            }
        }
    }
}
