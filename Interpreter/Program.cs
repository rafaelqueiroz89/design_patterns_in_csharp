using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static System.Console;

namespace Program
{
    public interface IElement
    {
        int Value { get; }
    }

    public class Integer : IElement
    {
        public Integer(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public class BinaryOperation : IElement
    {
        public enum Type
        {
            Addition,
            Subtraction
        }

        public Type MyType;
        public IElement Expression;

        public int Value
        {
            get; set;
        }

        public class Token
        {
            public enum Type
            {
                Integer, Plus, Minus, Variable
            }

            public Type MyType;
            public string Text;

            public Token(Type type, string text)
            {
                MyType = type;
                Text = text;
            }

            public override string ToString()
            {
                return $"{Text}";
            }
        }
    }

        public class ExpressionProcessor
        {
            public Dictionary<char, int> Variables = new Dictionary<char, int>();
            private string Input { get; set; }

            public int? Calculate(string input)
            {
                var result = new List<BinaryOperation.Token>();
                Input = input;

                for (int i = 0; i < input.Length; i++)
                {
                    switch (input[i])
                    {
                        case '+':
                            result.Add(new BinaryOperation.Token(BinaryOperation.Token.Type.Plus, "+"));
                            break;
                        case '-':
                            result.Add(new BinaryOperation.Token(BinaryOperation.Token.Type.Minus, "-"));
                            break;
                        default:
                            char c = input[i];
                            if (Char.IsLetter(c))
                            {
                                result.Add(new BinaryOperation.Token(BinaryOperation.Token.Type.Variable, c.ToString()));
                                break;
                            }

                            result.Add(new BinaryOperation.Token(BinaryOperation.Token.Type.Integer, input[i].ToString()));
                            break;
                    }
                }

                string newExp;
                IElement element = ParseVariables(result, out newExp);

                if (newExp == String.Empty && element.Value == 0)
                    return 0;

                if (newExp != String.Empty)
                    return Evaluate(newExp);
                else
                    return Evaluate(input);
            }

            public IElement ParseVariables(IReadOnlyList<BinaryOperation.Token> tokens, out string newExp)
            {
                var result = new BinaryOperation();
                result.Value = 1;
                newExp = String.Empty;
                try
                {
                    for (int i = 0; i < tokens.Count; i++)
                    {
                        var token = tokens[i];

                        // look at the type of token
                        switch (token.MyType)
                        {
                            case BinaryOperation.Token.Type.Variable:
                                bool foundkey = false;

                                if (i != tokens.Count-1)
                                    if (char.IsLetter(tokens[i + 1].Text[0]))
                                        throw new Exception();

                                foreach (var x in Variables)
                                {
                                    if (x.Key.ToString() == token.Text.ToString())
                                    {
                                        foundkey = true;
                                        newExp = Input.Replace(token.Text, x.Value.ToString());
                                        result.Value = x.Value;
                                    }
                                }

                                if (Variables.Count > 0 && foundkey == false)
                                    newExp = String.Empty;
                                break;
                        }
                    }
                }

                catch
                {
                    result.Value = 0;
                    newExp = String.Empty;
                }

                return result;
            }

            public static int Evaluate(String input)
            {
                String expr = "(" + input + ")";
                Stack<String> ops = new Stack<String>();
                Stack<int> vals = new Stack<int>();

                for (int i = 0; i < expr.Length; i++)
                {
                    String s = expr.Substring(i, 1);
                    if (s.Equals("(")) { }
                    else if (s.Equals("+")) ops.Push(s);
                    else if (s.Equals("-")) ops.Push(s);
                    else if (s.Equals(")"))
                    {
                        int count = ops.Count;
                        while (count > 0)
                        {
                            String op = ops.Pop();
                            int v = vals.Pop();
                            if (op.Equals("+")) v = vals.Pop() + v;
                            else if (op.Equals("-")) v = vals.Pop() - v;
                            vals.Push(v);

                            count--;
                        }
                    }
                    else vals.Push(int.Parse(s));
                }
                return vals.Pop();
            }

            public static void Main()
            {
                ExpressionProcessor ex = new ExpressionProcessor();
                var input = "0+2-1";
                ex.Variables.Add('b', 2);
                WriteLine(ex.Calculate(input));
            }
        }
}
