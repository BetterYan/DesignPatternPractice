using System;

namespace Composite
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Composite pattern is about
            //We try to give single object which groups of other objects as an identical interface
            //those interface members work correctly regardless of which class is the underlying one.
            NormalComposite.Test.Execute();
        }
    }
}