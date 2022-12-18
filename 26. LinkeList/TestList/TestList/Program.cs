using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestList
{
    class ListNode
    {
        public int data;
        public ListNode pNext;
        public ListNode(int x)
        {
            data = x;
            pNext = null;
        }
        public ListNode(int x, ListNode next)
        {
            data = x;
            pNext = next;
        }
    }
    class LinkedList
    {
        ListNode pHead;
        int nCount;
        public LinkedList()
        {
            pHead = null;
            nCount = 0;
        }
        public void AddFirst(int x)
        {
            ListNode pNode = new ListNode(x,pHead);
            nCount++;
            pHead = pNode;
        }
        public void AddLast(int x)
        {   
            ListNode pNode = new ListNode(x);
            nCount++;

            if (pHead == null)
            {
                pHead = pNode;
                return;
            }

            ListNode p = pHead;
            while (p.pNext != null)
            {
                p = p.pNext;
            }
            p.pNext = pNode;
        }
        public void Add(int index, int data)
        {
            if(index < 0 || index > nCount)
            {
                Console.WriteLine("index out of bound error");
                return;
            }
            int count = 1;
            ListNode pFollow = pHead;
            ListNode pTraverse = pHead.pNext;
            while (pTraverse != null)
            {
                if (index == count) break;
                count++;
                pFollow = pTraverse;
                pTraverse = pTraverse.pNext;
            }
            ListNode pNode = new ListNode(data, pTraverse);
            nCount++;
            pFollow.pNext = pNode;

        }
        public bool remove(int data)
        {
            // 비어 있으면 삭제 불가
            if (nCount == 0)
            {
                Console.WriteLine("The list is empty data removed");
                return false;
            }

            // 멘 앞에 값을 삭제
            if (pHead.data == data)
            {
                pHead = pHead.pNext;
                nCount--;
                return true;
            }

            // 준간에 있는 노드를 삭제
            ListNode pFollow = pHead;
            ListNode pTraverse = pHead.pNext;
            while (pTraverse != null)
            {
                if(pTraverse.data == data)
                {
                    pFollow.pNext = pTraverse.pNext;
                    nCount--;
                    return true;
                }
                pFollow = pTraverse;
                pTraverse = pTraverse.pNext;
            }
            // 끝까지 방문했지만 값을 찾지못해 끝나는 경우
            Console.WriteLine(data + " is not found");
            return false;
        }
        public override String ToString()
        {
            String s = "[ ";
            ListNode p = pHead;
            while(p != null)
            {
                if (p.pNext != null)
                {
                    s = s + p.data + ",";
                }
                else
                {
                    s = s + p.data;
                }
                p = p.pNext;
            }
            s = s + " ]";
            return s;
        }
    }
    class Enumerator
    {
        ListNode ptr;
        int current;

        public int Current
        {
            get
            {
                return current;
            }
        }
        public Enumerator(ListNode pHead)
        {
            ptr = pHead;
        }
        public bool MoveNext()
        {
            if (ptr == null) return false;
            current = ptr.data;
            ptr = ptr.pNext;
            return true;
        }
        public Enumerator GetEnumerator()
        {
            return new Enumerator(pHead);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list;
            list = new LinkedList();

            list.remove(5);

            // 앞에 삽입
            list.AddLast(7);
            list.AddLast(3);
            list.AddLast(6);
            list.AddLast(2);
            Console.WriteLine(list);

            // 앞에 삽입
            list.AddLast(7);
            list.AddLast(5);
            list.AddLast(1);
            Console.WriteLine(list);

            list.remove(7);  // 멘 앞에 값을 빼기
            list.remove(6);  // 중간 빼기
            list.remove(10); // 없는 경우
            Console.WriteLine(list);

            list.Add(3, 1000);
            list.Add(1, 100000);
            Console.WriteLine(list);

            Enumerator e = list.GetEnumerator();
            while (e.MoveNext())
            {
                Console.WriteLine(e.Current);
            }
        }
    }
}
