using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CollectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add("Kim");
            list.Add("park");
            list.Add("lee");
            list.Add("kwon");
            list.Add("ban");

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("===");

            //--------------------------------------------

            foreach(String s in list)
            {
                Console.WriteLine(s);
            }

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
