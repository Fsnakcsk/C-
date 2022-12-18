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
            return "[" + name + " total: " + total + " grade: " + grade + "]";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue list = new Queue();

            list.Enqueue(new Student("Kim", 99, 'A'));
            list.Enqueue(new Student("park", 10, 'F'));
            list.Enqueue(new Student("lee", 70, 'C'));
            list.Enqueue(new Student("kwon", 80, 'B'));
            list.Enqueue(new Student("ban", 90, 'A'));

            Student st = (Student)list.Dequeue();
            st = (Student)list.Dequeue();
            Console.WriteLine(st);
            Console.WriteLine("===");
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
