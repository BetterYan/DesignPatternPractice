using System;

namespace Flyweight
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //A flyweight(token,cookie) is a temporary component that acts as a smart reference to something.
            //It is used in situations where you have a very large number of objects.
            //It can minimize the amount of memory that is dedicated to storing all these values.

            //start with debug(F5)
            //compare the difference of the memory with vs memory snapshot window
            ForStoring.Test.Execute();//The result is not the same as I thought. Am I missing something?

            ForFormating.Test.Execute();
        }
    }
}