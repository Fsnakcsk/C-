using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec25
{
    class IntStack
    {
        static int MAX = 100;
        // Attributes
        private int[] s;
        private int top;
        private int arraySize;
        // Operations
        private void emptyError()
        {
            Console.WriteLine("IntStack empty error occurs.");
            Environment.Exit(-1);
        }
        public IntStack()
            : this(MAX)
        {
        }
        public IntStack(int n)
        {
            s = new int[n];
            arraySize = n;
            top = -1;
        }
        public void push(int item)
        {
            if (top >= (arraySize - 1))
            {
                int[] newS;
                newS = new int[2 * arraySize];
                for (int i = 0; i < arraySize; i++)
                {
                    newS[i] = s[i];
                }
                s = newS;
                arraySize = 2 * arraySize;
            }
            top++;
            s[top] = item;
        }
        public int pop()
        {
            if (top == -1) emptyError();
            int value = s[top];
            top--;
            return (value);
        }
        public int peek()
        {
            if (top == -1) emptyError();
            return s[top];
        }
        public void reset()
        {
            top = -1;
        }
        public bool isEmpty()
        {
            if (top == -1) return true;
            else return false;
        }
        public int size()
        {
            if (top == -1) return 0;
            else return top + 1;
        }
        public int getAt(int i)
        {
            return s[i];
        }
    }
    class TreeNode
    {
        private String data;
        private LinkedList<TreeNode> children;
        public TreeNode(String s)
        {
            data = s;
            children = new LinkedList<TreeNode>();
        }
        public String getData()
        {
            return data;
        }
        public void depthFirstTraverse()
        {
            Console.WriteLine(data);

            ListIterator<TreeNode> i = children.listIterator();
            while (i.hasNext())
            {
                TreeNode child = i.next();
                child.depthFirstTraverse();
            }
        }
        public void depthFirstEnumeration(LinkedList<String> pEnumeration)
        {
            pEnumeration.addLast(data);
            ListIterator<TreeNode> i = children.listIterator();
            while (i.hasNext())
            {
                TreeNode child = i.next();
                child.depthFirstEnumeration(pEnumeration);
            }
        }
        public TreeNode find(String s)
        {
            if (data.Equals(s)) return this;

            ListIterator<TreeNode> i = children.listIterator();
            while (i.hasNext())
            {
                TreeNode child = i.next();
                TreeNode foundNode = child.find(s);
                if (foundNode != null) return foundNode;
            }
            return null;
        }
        public void addChild(String s)
        {
            TreeNode pNewNode = new TreeNode(s);
            children.addLast(pNewNode);
        }
        public int showTree(bool isFirstChild, int level, int xPos, int gap, IntStack pStack)
        {
            if (isFirstChild == true && level > 0)
            {
                Console.Write("-+-");
            }
            else if (level > 0)
            {
                Console.Write(" +-");
            }
            Console.Write(data);
            if (level == 0)
            {
                xPos = xPos + data.Length;
                pStack.push(data.Length + 1);
            }
            else if (children.size() > 1)
            {
                xPos = xPos + data.Length + 3;
                pStack.push(data.Length + 2 + gap);
            }
            else
            {
                xPos = xPos + data.Length;
                pStack.push(data.Length + 1 + gap);
            }
            int maxWidth = 0;
            bool firstNodeFlag1 = true;
            bool firstNodeFlag2 = true;
            bool alreadyPoped = false;
            int nCount = children.size();
            ListIterator<TreeNode> iterator = children.listIterator();
            while (iterator.hasNext())
            {
                int childWidth;
                TreeNode child = iterator.next();
                nCount--;
                if (firstNodeFlag1 == true)
                {
                    firstNodeFlag1 = false;
                }
                else
                {
                    int i;
                    for (i = 0; i < pStack.size(); i++)
                    {
                        int n = pStack.getAt(i);
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write(" ");
                        }
                        Console.Write("|");
                    }
                    Console.WriteLine();
                    int nBlanks = xPos;
                    for (i = 0; i < pStack.size() - 1; i++)
                    {
                        int n = pStack.getAt(i);
                        for (int j = 0; j < n; j++)
                        {
                            Console.Write(" ");
                            nBlanks--;
                        }
                        Console.Write("|");
                        nBlanks--;
                    }
                    for (i = 0; i < nBlanks; i++)
                    {
                        Console.Write(" ");
                    }
                }
                int moreGap = 0;
                if (child.children.size() > 1 && nCount == 0)
                {
                    moreGap = pStack.pop() + 1;
                    alreadyPoped = true;
                }
                childWidth = child.showTree(firstNodeFlag2, level + 1, xPos, moreGap, pStack);
                firstNodeFlag2 = false;
                if (maxWidth < childWidth) maxWidth = childWidth;
            }
            if (firstNodeFlag1) Console.WriteLine();
            if (alreadyPoped == false) pStack.pop();
            return maxWidth;
        }
    }
    class Tree
    {
        private TreeNode root;
        public Tree()
        {
            root = null;
        }
        public void setRoot(String s)
        {
            root = new TreeNode(s);
        }
        public void depthFirstTraverse()
        {
            if (root == null)
            {
                Console.WriteLine("No node to visit");
                return;
            }
            root.depthFirstTraverse();
        }
        public LinkedList<String> depthFirstEnumeration()
        {
            if (root == null) return null;
            LinkedList<String> pEnumeration = new LinkedList<String>();
            root.depthFirstEnumeration(pEnumeration);
            return pEnumeration;
        }
        public bool addNewChild(String parent, String child)
        {
            if (root == null) return false;
            TreeNode pNode = root.find(parent);
            if (pNode == null) return false;
            pNode.addChild(child);
            return true;
        }
        public void showTree()
        {
            if (root == null)
            {
                Console.WriteLine("No data in the tree!");
                return;
            }
            IntStack pStack = new IntStack();
            root.showTree(true, 0, 0, 0, pStack);
        }
    }
    class TestTree
    {
        static void Main(string[] args)
        {
            Tree aTree = new Tree();
            String rootName;
            Console.Write("Type the name of the root node of this tree: ");
            rootName = Console.ReadLine();
            aTree.setRoot(rootName);
            while (true)
            {
                String parent, child;

                Console.WriteLine(">>");
                Console.Write("Type a parent name: ");
                parent = Console.ReadLine();
                Console.Write("Type a child name: ");
                child = Console.ReadLine();
                if (aTree.addNewChild(parent, child) == false) break;
            }

            Console.WriteLine("- depth first traverse -");
            aTree.depthFirstTraverse();

            Console.WriteLine("- depth first traverse using enumeration -");
            LinkedList<String> pList = aTree.depthFirstEnumeration();

            ListIterator<String> i = pList.listIterator();
            while (i.hasNext())
            {
                String s = i.next();
                Console.WriteLine(s);
            }

            Console.WriteLine("=== the tree you made looks like as follows ===");
            aTree.showTree();
        }
    }
}
