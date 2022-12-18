using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkdeListTest
{
    class ListNode
    {
        public int value;
        public ListNode next;
        public ListNode(int v)
        {
            value = v;
            next = null;
        }
    }
    class Program
    {
        static void print(int[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i] + " ");
            }
            Console.WriteLine();
        }
        static void print(ListNode x)
        {
            ListNode tmp = x;
            while(tmp != null)
            {
                Console.Write(tmp.value + " ");
                tmp = tmp.next;
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] x = new int[100];

            print(x);

            ListNode y = new ListNode(5);
            y.next = new ListNode(8);
            y.next.next = new ListNode(7);
            y.next.next.next = new ListNode(2);

            print(x);

        }
    }
}
