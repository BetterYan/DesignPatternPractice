using System;

namespace Interpreter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Interpreter is uncommon nowdays in design pattern
            //It usually used in language design area, or making tools for static code analysis. Lex/Yacc,ANTLR are good examples.
            var input = "(13+4)-(12+1)";
            var tokens = Lexing.Lex(input);
            Console.WriteLine(string.Join(" ", tokens));
            var parsed = BinaryOperation.Parse(tokens);
            Console.WriteLine(parsed.Value);
        }
    }
}