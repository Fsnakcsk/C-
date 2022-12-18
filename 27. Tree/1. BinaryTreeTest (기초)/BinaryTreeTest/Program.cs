using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTest
{
    class TreeNode
    {
        public TreeNode lchild;
        public int data;
        public TreeNode rchild;

        public TreeNode(int x)
        {
            data = x;
            lchild = rchild = null;
        }
        public int getCount() // 갯수를 알아 온다.
        {
            int n1 = 0;
            int n2 = 0;

            if (lchild != null) n1 = lchild.getCount();
            if (rchild != null) n2 = rchild.getCount();

            return n1 + n2 + 1;
        }
        public int getDepth() // 깊이를 알아온다.
        {
            int n1 = 0;
            int n2 = 0;

            if (lchild != null) n1 = lchild.getDepth();
            if (rchild != null) n2 = rchild.getDepth();

            if (n1 > n2)
            {
                return n1 + 1;
            }
            else
            {
                return n2 + 1;
            }
        }
        public void inorder() // 중위순회
        {
            if (lchild != null) lchild.inorder();
            Console.WriteLine(data);
            if (rchild != null) rchild.inorder();
        }
        public void preorder() // 중위순회
        {
            Console.WriteLine(data);
            if (lchild != null) lchild.preorder();
            if (rchild != null) rchild.preorder();
        }
        public void postorder() // 후위순회
        {
            if (lchild != null) lchild.postorder();
            if (rchild != null) rchild.postorder();
            Console.WriteLine(data);
        }
        public void add(int x)
        {
            if(x < data)
            {
                if (lchild != null) lchild.add(x);
                else lchild = new TreeNode(x);
            }
            else // x >= data
            {
                if (rchild != null) rchild.add(x);
                else rchild = new TreeNode(x);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root;
            root = new TreeNode(4);

            /*
            root.lchild = new TreeNode(3);
            root.rchild = new TreeNode(7);
            root.lchild.lchild = new TreeNode(1);
            root.rchild.lchild = new TreeNode(6);
            root.rchild.rchild = ne w TreeNode(9);
            root.rchild.rchild.lchild = new TreeNode(8);
            */

            root.add(3);
            root.add(7);
            root.add(1);
            root.add(6);
            root.add(9);
            root.add(8);

            Console.WriteLine(root.getCount());
            Console.WriteLine("===");
            root.inorder();
            Console.WriteLine("===");

            Console.WriteLine("===");
            root.preorder();
            Console.WriteLine("===");

            Console.WriteLine("===");
            root.postorder();
            Console.WriteLine("===");

            root.add(2);
            root.add(5);

            Console.WriteLine("===");
            root.inorder();
        }
    }
}
