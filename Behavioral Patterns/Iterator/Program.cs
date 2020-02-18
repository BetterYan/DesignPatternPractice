using System;

namespace Iterator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //In .NET, it use the term enumerator instead
            //IEnumerator<T> the iterator interface
            //A class that implements IEnumerable<T> is required to have a method called GetEnumerator() that return s an IEnumerator<T>
            //The easiest way is to use the existing collection class(array,List<T>,etc
            Test.Execute();
        }
    }
}