using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec19
{
    class ListNode<Type>
    {
        private Type data;
        private ListNode<Type> pPrev;
        private ListNode<Type> pNext;
        public ListNode()
        {
            data = default(Type);
            pPrev = this;
            pNext = this;
        }
        public ListNode(Type x)
        {
            data = x;
            pPrev = this;
            pNext = this;
        }
        public Type getData()
        {
            return data;
        }
        public void setData(Type x)
        {
            data = x;
        }
        public ListNode<Type> getNext()
        {
            return pNext;
        }
        void setNext(ListNode<Type> p)
        {
            pNext = p;
        }
        public ListNode<Type> getPrev()
        {
            return pPrev; 
        }
        public void setPrev(ListNode<Type> p)
        {
            pPrev = p;
        }
        public void insert(ListNode<Type> pNode)
        {
            // this node is inserted before pNode
            // pNode must be understood as a chain
            pPrev = pNode.pPrev;
            pNext = pNode;
            pNode.pPrev.pNext = this;
            pNode.pPrev = this;
        }
        public void append(ListNode<Type> pNode)
        {
            // this node is appended just after pNode
            // pNode must be understood as a chain
            pPrev = pNode;
            pNext = pNode.pNext;
            pNode.pNext.pPrev = this;
            pNode.pNext = this;
        }
        public void remove()
        {
            this.pNext.pPrev = this.pPrev;
            this.pPrev.pNext = this.pNext;
        }
    };

    class LinkedList<Type>
    {
        protected ListNode<Type> pHead;
        protected int nCount;
        public LinkedList()
        {
            pHead = null;
            nCount = 0;
        }
        public bool isEmpty()
        {
            if (pHead == null) return true;
            else return false;
        }
        public int size()
        {
            return nCount;
        }
        public void addFirst(Type data)
        {
            addLast(data);
            pHead = pHead.getPrev();
        }
        public void addLast(Type data)
        {
            ListNode<Type> pNewNode = new ListNode<Type>(data);
            nCount++;
            if (pHead == null)
            {
                pHead = pNewNode;
                return;
            }
            pNewNode.insert(pHead);
        }
        public void add(int index, Type data)
        {
            if (index < 0 || index > nCount)
            {
                Console.WriteLine("index out of bound error - add(index,data) failed.");
                return;
            }
            if (index == 0)
            {
                addFirst(data);
                return;
            }
            int count = 1;
            ListNode<Type> pFollow = pHead;
            ListNode<Type> pTraverse = pHead.getNext();
            while (pTraverse != null)
            {
                if (index == count) break;
                count++;
                pFollow = pTraverse;
                pTraverse = pTraverse.getNext();
            }
            ListNode<Type> pNewNode = new ListNode<Type>(data);
            nCount++;
            pNewNode.append(pFollow);
        }
        public bool remove(Type data)
        {
            if (isEmpty() == true)
            {
                Console.WriteLine("The list is empty. No data removed.");
                return false;
            }
            if (pHead != null && pHead.getData().Equals(data))
            {
                ListNode<Type> pNextNode = pHead.getNext();
                pHead.remove();
                nCount--;
                if (pNextNode == pHead) pHead = null;
                else pHead = pNextNode;
                return true;
            }
            ListNode<Type> pFollow = pHead;
            ListNode<Type> pTraverse = pHead.getNext();
            while (pTraverse != pHead)
            {
                if (pTraverse.getData().Equals(data))
                {
                    pTraverse.remove();
                    nCount--;
                    return true;
                }
                pFollow = pTraverse;
                pTraverse = pTraverse.getNext();
            }
            Console.WriteLine(data + " is not found. No data removed.");
            return false;
        }
        public ListIterator<Type> listIterator()
        {
            return new ListIterator<Type>(pHead);
        }
        public override String ToString()
        {
            if (isEmpty() == true)
            {
                return "<>";
            }
            String tmp = "< ";
            ListNode<Type> pNode = pHead;
            for (int i = 0; i < nCount; i++)
            {
                tmp = tmp + pNode.getData();
                if (i < nCount - 1)
                {
                    tmp = tmp + ", ";
                }
                else
                {
                    tmp = tmp + " >";
                }
                pNode = pNode.getNext();
            }
            return tmp;
        }
    }

    class ListIterator<Type>
    {
        ListNode<Type> pHead;
        ListNode<Type> ptr;
        public ListIterator(ListNode<Type> pHead)
        {
            this.pHead = pHead;
            ptr = null;
        }
        public bool hasNext()
        {
            if (ptr == null)
            {
                if (pHead == null)
                    return false;
                ptr = pHead;
                return true;
            }
            if (ptr == pHead)
                return false;
            else
                return true;
        }
        public Type next()
        {
            Type data = ptr.getData();
            ptr = ptr.getNext();
            return data;
        }
    }
    class TestLinkedList
    {
        //Lec18에서 복사
    }
}
