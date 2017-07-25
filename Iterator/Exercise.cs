using System.Collections.Generic;
using System.Linq;
using static System.Console;

/// <summary>
/// This design pattern is simply used to show how the Iterator of loops works, and who makes it happen.
/// An Iterator is a class that facilitates the traversal. It keeps a reference to the current element
/// Knows how to move to a different element.
/// 
/// Iterator is an implict construct
/// .Net builds a state machine around the "yield return" statements.
/// 
/// If you need to Iterate something you don't need to Interface your class with IEnumerable, all you need is
/// to implement a method called GetEnumerator() with MoveNext() and the Current parameter.
/// 
/// Iteration works through duck typing! - you need a GetEnumerator() that yields a type that has 
/// Current and MoveNext()
/// </summary>
namespace Iterator
{
    public class Node<T>
    {
        private T Value;
        private Node<T> Left, Right;
        private Node<T> Parent;

        public Node(T value)
        {
            Value = value;
        }

        public Node(T value, Node<T> left, Node<T> right)
        {
            Value = value;
            Left = left;
            Right = right;

            left.Parent = right.Parent = this;
        }

        public IEnumerable<T> PreOrder
        {
            get
            {
                foreach (var node in PreOrderFunc(this))
                {
                    yield return node.Value;
                }
            }
        }

        private IEnumerable<Node<T>> PreOrderFunc(Node<T> current)
        {
            if (current.Left != null || current.Right != null)
                if (current.Parent == null)
                    yield return current;

            if (current.Parent != null && current.Left != null)
                yield return current;

            if (current.Left != null)
            {
                foreach (var left in PreOrderFunc(current.Left))
                {
                    yield return left;
                }
            }

            if (current.Right != null)
            {
                foreach (var right in PreOrderFunc(current.Right))
                {
                    yield return right;
                }
            }

            if (current.Left == null || current.Right == null)
                if (current.Parent != null)
                    yield return current;
 

        }
    }

    class Exercise
    {
        public static void Main()
        {
            //first tree
            //    A
            //   / \
            //  B   C
            //     / \ 
            //    D   E

            //second tree
            //    A
            //   / \
            //  B   E
            // / \ 
            //C   D

            //preorder: ABCDE


            var tree1 = new Node<char>('a', new Node<char>('b'), new Node<char>('c', new Node<char>('d'), new Node<char>('e')));
            var tree2 = new Node<char>('a', new Node<char>('b', new Node<char>('c'), new Node<char>('d')), new Node<char>('e'));

            WriteLine("Tree 1: " + "\n" + string.Join(",", tree1.PreOrder)); ;
            WriteLine("\n");
            WriteLine("Tree 2: " + "\n" + string.Join(",", tree2.PreOrder));
        }
    }
}

