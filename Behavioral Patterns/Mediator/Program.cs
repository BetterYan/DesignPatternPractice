using System;

namespace Mediator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Normal.Test.Execute();
            Console.WriteLine("-----------------");
            WithEvent.Test.Execute();
        }
    }
}