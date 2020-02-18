using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
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
            Addition, Subtraction
        }

        public Type MyType;
        public IElement Left, Right;

        public int Value
        {
            get
            {
                switch (MyType)
                {
                    case Type.Addition:
                        return Left.Value + Right.Value;

                    case Type.Subtraction:
                        return Left.Value - Right.Value;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public static IElement Parse(IReadOnlyList<Token> tokens)
        {
            var result = new BinaryOperation();
            bool haveLHS = false;
            for (int i = 0; i < tokens.Count; i++)
            {
                var token = tokens[i];
                switch (token.MyType)
                {
                    case Token.Type.Integer:
                        var integer = new Integer(int.Parse(token.Text));
                        if (!haveLHS)
                        {
                            result.Left = integer;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = integer;
                        }
                        break;

                    case Token.Type.Plus:
                        result.MyType = BinaryOperation.Type.Addition;
                        break;

                    case Token.Type.Minus:
                        result.MyType = BinaryOperation.Type.Subtraction;
                        break;

                    case Token.Type.Lparen:
                        int j = i;
                        for (; j < tokens.Count; j++)
                        {
                            if (tokens[j].MyType == Token.Type.Rparen)
                            {
                                break;
                            }
                        }
                        var subexpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
                        var element = Parse(subexpression);
                        if (!haveLHS)
                        {
                            result.Left = element;
                            haveLHS = true;
                        }
                        else
                        {
                            result.Right = element;
                        }
                        i = j;
                        break;

                    case Token.Type.Rparen:
                        break;

                    default:
                        break;
                }
            }
            return result;
        }
    }
}