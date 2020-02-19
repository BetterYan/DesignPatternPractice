using System;

namespace Memento
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //We can record a list of every single change with command design pattern
            //Sometimes we only need to roll back the system to a particular state
            //We can use memento pattern
            Test.Execute();
            var i = 0;
        }
    }
}