using System;

namespace Decorator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //If we want to extend the class's functionality wrote by others, and we can't modify the source code.
            //Decorator pattern allows us to enhance existing types without either modifying the original types or
            //causing an explosion of the number of derived types.
            DynamicDecoratorComposition.Test.Execute();
        }
    }
}