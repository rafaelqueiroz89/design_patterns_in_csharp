using System;
using System.Text;

/// <summary>
/// Need to define a new operation on an entire class hierarchy
///     Eg: make a document model printable to HTML/Markdown
///     
/// You do not want to keep modifying every class in the hierarchy
/// It is a pattern where a component (visitor) is allowed to traverse the entire inheritance
/// hierarchy. Implemented by propagating a single visit() method throughout the entire hierarchy.
/// 
/// Dispatch: which function to call? 
///     Single dispatch: depends on the name of the request and type of receiver
///     Double dispatch: depends on name of request and type of 2 receivers *type of visitor, type of element being visited).
///     Each accept() simply calls visitor.Visit(this)ç
/// </summary>.
/// 
namespace Visitor
{
    public abstract class ExpressionVisitor
    {
        public abstract void Accept(Value value);
        public abstract void Accept(AdditionExpression ae);
        public abstract void Accept(MultiplicationExpression me);
    }

    public abstract class Expression
    {
        public abstract void Visit(ExpressionVisitor ev);
    }

    public class Value : Expression
    {
        public readonly int TheValue;

        public Value(int value)
        {
            TheValue = value;
        }

        public override void Visit(ExpressionVisitor ev)
        {
            ev.Accept(this);
        }
    }

    public class AdditionExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public AdditionExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Visit(ExpressionVisitor ev)
        {
            ev.Accept(this);
        }
    }

    public class MultiplicationExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public MultiplicationExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Visit(ExpressionVisitor ev)
        {
            ev.Accept(this);
        }
    }

    public class ExpressionPrinter : ExpressionVisitor
    {
        private StringBuilder sb = new StringBuilder();

        public override void Accept(Value value)
        {
            sb.Append(value.TheValue);
        }

        public override void Accept(AdditionExpression ae)
        {
            sb.Append("(");
            ae.LHS.Visit(this);
            sb.Append("+");
            ae.RHS.Visit(this);
            sb.Append(")");
        }

        public override void Accept(MultiplicationExpression me)
        {
            me.LHS.Visit(this);
            sb.Append("*");
            me.RHS.Visit(this);
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }

    public class Visitor
    {
        public static void Main()
        {
            var simple = new AdditionExpression(new Value(2), new Value(3));
            var ep = new ExpressionPrinter();
            ep.Accept(simple);
            Console.WriteLine(ep.ToString());
        }
    }
}
