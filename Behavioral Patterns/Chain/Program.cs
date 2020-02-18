using System;

namespace Chain
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MethodChain.Test.Execute();
            Console.WriteLine("----------------------");
            BrokerChain.Test.Execute();
        }
    }
}