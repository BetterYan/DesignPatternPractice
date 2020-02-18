using System;

namespace Command
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //If we call the API directly, it doesn't leave any information which can be recorded and rollback if needed.
            //Command Pattern is a data class which describe what to do and how to do the task.
            Test.WithCommandPattern();
            Console.WriteLine("--------------------");
            Test.WithUndo();
            Console.WriteLine("--------------------");
            FunctionalCommand.Test.Execute();
        }
    }
}