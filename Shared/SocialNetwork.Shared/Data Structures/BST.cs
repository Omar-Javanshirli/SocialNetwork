using System;
using System.Xml.Linq;

namespace SocialNetwork.Shared.Data_Structures
{
    public class Node<T> where T : IComparable<T>
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
    }

    public class BST<T> where T : IComparable<T>
    {
        public Node<T> Tree { get; set; }

        public Node<T> Add(Node<T> tree, T data)
        {
            if (tree == null)
            {
                Node<T> root = new Node<T>()
                {
                    Left = null,
                    Right = null,
                    Data = data,
                };
                return root;
            }

            if (data.CompareTo(tree.Data) > 0)
            {
                tree.Right = Add(tree.Right, data);
                return tree;
            }

            tree.Left = Add(tree.Left, data);
            return tree;
        }

        public bool Any(Node<T> tree, T data)
        {
            if (tree == null) return false;
            if (data.CompareTo(tree.Data) == 0) return true;

            if (Any(tree.Right, data) == true) return true;
            if (Any(tree.Left, data) == true) return true;

            return false;
        }

        public T MaxElement(Node<T> tree)
        {
            while (tree.Right != null)
                tree = tree.Right;

            return tree.Data;
        }

        public T MinElement(Node<T> tree)
        {
            while (tree.Left != null)
                tree = tree.Left;

            return tree.Data;
        }

        public Node<T> Delete(Node<T> tree, T data)
        {
            if (tree == null) return null;

            if (data.CompareTo(tree.Data) == 0)
            {
                if (tree.Left == null && tree.Right == null)
                    return null;

                if (tree.Right != null)
                {
                    tree.Data = MinElement(tree.Right);
                    tree.Right = Delete(tree.Right, MinElement(tree.Right));
                    return tree;
                }

                tree.Data = MaxElement(tree.Left);
                tree.Left = Delete(tree.Left, MaxElement(tree.Left));
            }

            if (data.CompareTo(tree.Data) < 0)
            {
                tree.Right = Delete(tree.Right, data);
                return tree;
            }

            tree.Left = Delete(tree.Left, data);
            return tree;
        }
    }
}
