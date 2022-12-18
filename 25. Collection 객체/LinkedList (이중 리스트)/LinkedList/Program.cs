using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace LinkedList
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
            return "[" + name + " total: " + total + " grade: " + "]";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Student> list = new LinkedList<Student>();

            list.AddLast(new Student("Kim", 99, 'A'));
            list.AddLast(new Student("park", 10, 'F'));
            list.AddLast(new Student("lee", 70, 'C'));
            list.AddLast(new Student("kwon", 80, 'B'));
            list.AddLast(new Student("ban", 90, 'A'));


            //--------------------------------------------
            //     String -> Student
            foreach (Student s in list)
            {
                Console.WriteLine(s);
            }


            Console.WriteLine("===");


            //--------------------------------------------
            //Java 스타일
            IEnumerator e = list.GetEnumerator();
            while (e.MoveNext())
            {
                Console.WriteLine(e.Current);
            }
        }
    }
}
