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
    class BinaryTree
    {
        TreeNode root;
        public BinaryTree()
        {
            root = null;
        }
        public BinaryTree(int root)
        {
            setRoot(root);
        }
        public void setRoot(int root)
        {
            this.root = new TreeNode(root);
        }
        public void add(int x)
        {
            if (root == null)
            {
                setRoot(x);
            }
            else
            {
                root.add(x);
            }
        }
        public int getCount() // 갯수를 알아 온다.
        {
            if(root == null)
            {
                return 0;
            }
            else
            {
                return root.getCount();
            }
        }
        public int getDepth() // 깊이를 알아온다.
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return root.getDepth();
            }
        }
        public void inorder() // 중위순회
        {
            if (root == null)
            {
                Console.WriteLine("No data");
                return;
            }
            else
            {
                root.inorder();
            }
        }
        public void preorder() // 중위순회
        {
            if (root == null)
            {
                Console.WriteLine("No data");
                return;
            }
            else
            {
                root.preorder();
            }
        }
        public void postorder() // 후위순회
        {
            if (root == null)
            {
                Console.WriteLine("No data");
                return;
            }
            else
            {
                root.postorder();
            }
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.setRoot(4);

            tree.add(3);
            tree.add(7);
            tree.add(1);
            tree.add(6);
            tree.add(9);
            tree.add(8);

            Console.WriteLine(tree.getCount());
            Console.WriteLine("===");
            tree.inorder();

            Console.WriteLine("===");
            tree.preorder();

            Console.WriteLine("===");
            tree.postorder();

            tree.add(2);
            tree.add(5);

            Console.WriteLine("===");
            tree.inorder();
        }
    }
}
