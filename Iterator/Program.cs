using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
/// </summary>
namespace Iterator
{
    public class Node<T>
    {
        public T Value;
        public Node<T> Left, Right;
        public Node<T> Parent;

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
                // todo!
            }
        }

        class Program
    {
        //static void Main(string[] args)
        //{
        //}
    }
}
