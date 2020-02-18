using System;

namespace Proxy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Proxy is similar as the decorator.
            //But its goal is to preserve exactly the APIs and offering certain internal enhancements.
            //Proxy is an unusual pattern. There're lots of implementations for different purposes
            PropertyProxy.Test.Execute();
        }
    }
}