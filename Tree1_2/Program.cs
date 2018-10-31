using System;
//2. Convert a BST into a doubly linkedlist.
namespace Tree1_2
{
    public class Node
    {
        public int data;
        public Node left, right;

        public Node()
        {
            data = 0;
            left = right = null;
        }
        public Node(int val)
        {
            data = val;
            left = right = null;
        }
    }

    public class Tree
    {
        public Node root;

        public Tree()
        {
            root = null;
        }

        //public Node BSTtoDoublyLList(Node node)
        //{
        //    if (node == null)
        //        return null;

        //    if (node.left != null)
        //    {
        //        Node left = BSTtoDoublyLList(node.left);
        //        while (left.right != null)
        //        {
        //            left = left.right;
        //        }
        //        left.right = node;
        //        node.left = left;
        //    }

        //    if (node.right != null)
        //    {
        //        var right = BSTtoDoublyLList(node.right);
        //        while (right.left != null)
        //        {
        //            right = right.left;
        //        }
        //        right.left = node;
        //        node.right = right;
        //    }
        //    return node;
        //}

        // head --> Pointer to head node of created doubly linked list 
        public Node head;

        // Initialize previously visited node as NULL. 
        //This is static so that the same value is accessible in all recursive calls 
        public static Node prev = null;

        // A simple recursive function to convert a given Binary tree to Doubly Linked List 
        // root --> Root of Binary Tree 
        public void BinaryTree2DoubleLinkedList(Node root)
        {
            if (root == null)
                return;

            // Recursively convert left subtree 
            BinaryTree2DoubleLinkedList(root.left);

            // Now convert this node 
            if (prev == null)
                head = root;
            else
            {
                root.left = prev;
                prev.right = root;
            }
            prev = root;

            // Finally convert right subtree 
            BinaryTree2DoubleLinkedList(root.right);
        }

    }
        class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(50);
            root.left = new Node(25);
            root.right = new Node(70);
            root.left.left = new Node(10);
            root.left.right = new Node(40);
            root.left.right.left = new Node(35);
            root.right.left = new Node(60);
            
            root.right.left.right = new Node(65);
            root.right.left.right.left = new Node(62);

            root.right.right = new Node(80);
            root.right.right.right = new Node(90);

            Tree bt = new Tree();

            bt.BinaryTree2DoubleLinkedList(root);
            String dat, datr;
            root = bt.head;
            while (root != null)
            {
                if (root.left == null)
                    dat = "null";
                else
                    dat = root.left.data.ToString();

                if (root.right == null)
                    datr = "null";
                else
                    datr = root.right.data.ToString();

                Console.WriteLine(dat + " <= " + root.data + " => " + datr);
                root = root.right;
            }
        }
    }
}
