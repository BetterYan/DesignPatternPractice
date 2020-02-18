using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class Token
    {
        public enum Type
        {
            Integer, Plus, Minus, Lparen, Rparen
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
            return $"`{Text}`";
        }
    }

    public class Lexing
    {
        public static List<Token> Lex(string input)
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
                        var sb = new StringBuilder(input[i].ToString());
                        for (int j = i + 1; j < input.Length; j++)
                        {
                            if (char.IsDigit(input[j]))
                            {
                                sb.Append(input[j]);
                                i++;
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

            return result;
        }
    }
}