using Program;
using System;
using System.Collections.Generic;
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
                Integer, Plus, Minus, Lparen, Rparen, Variable
            }

            public Type MyType;
            public string Text;

            public Token(Type type, string text)
            {
                MyType = type;
                Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
            }

            public override string ToString()
            {
                return $"{Text}";
            }
        }

        public class ExpressionProcessor
        {
            public static Dictionary<char, int> Variables = new Dictionary<char, int>();

            public static int? Calculate(string input)
            {
                var result = new List<Token>();

                for (int i = 0; i < input.Length; i++)
                {
                    switch (input[i])
                    {
                        case '+':
                            result.Add(new Token(Token.Type.Plus, "+"));
                            break;
                        case '-':
                            result.Add(new Token(Token.Type.Minus, "-"));
                            break;
                        case '(':
                            result.Add(new Token(Token.Type.Lparen, "("));
                            break;
                        case ')':
                            result.Add(new Token(Token.Type.Rparen, ")"));
                            break;
                        default:
                            char c = input[i];
                            if (Char.IsLetter(c))
                            {
                                result.Add(new Token(Token.Type.Variable, c.ToString()));
                                break;
                            }

                            var sb = new StringBuilder(input[i].ToString());
                            for (int j = i + 1; j < input.Length; ++j)
                            {
                                if (char.IsDigit(input[j]))
                                {
                                    sb.Append(input[j]);
                                    ++i;
                                }
                                else
                                {
                                    result.Add(new Token(Token.Type.Integer, sb.ToString()));
                                    break;
                                }
                            }
                            break;
                    }
                }

                return Parse(result).Value;
            }

            public static IElement Parse(IReadOnlyList<Token> tokens)
            {
                var result = new BinaryOperation();
                try
                {

                    for (int i = 0; i < tokens.Count; i++)
                    {
                        var token = tokens[i];

                        // look at the type of token
                        switch (token.MyType)
                        {
                            case Token.Type.Variable:
                                bool foundkey = false;
                                foreach (var x in Variables)
                                {
                                    if (x.Key.ToString() == token.Text.ToString())
                                    {
                                        foundkey = true;
                                        result.Value += x.Value;
                                    }
                                }

                                if (Variables.Count > 0 && foundkey == false)
                                    result.Value = 0;
                                break;
                            case Token.Type.Lparen:
                                int j = i;
                                for (; j < tokens.Count; ++j)
                                    if (tokens[j].MyType == Token.Type.Rparen)
                                        break; // found it!
                                               // process subexpression w/o opening (
                                var subexpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
                                MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
                                sc.Language = "VBScript";

                                result.Value = Convert.ToInt32((sc.Eval(string.Join("", subexpression))));
                                break;
                        }
                    }
                }

                catch
                {
                    result.Value = 0;
                }
                return result;
            }


            public static void Main()
            {
                var input = "(1+b+1)";
                Variables.Add('b', 1);
                WriteLine(Calculate(input));
            }
        }
    }
}
