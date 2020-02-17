using System;

namespace Builder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TestWithoutBuilder.Execute();
            TestWithSimpleBuilder.Execute();
            TestWithFluentBuilder.Execute();
            Builder.Intent.TestWithIntent.Execute();
            TestWithCompositeBuilder.Execute();
            TestWithBuilderParameter.Execute();
            Inheritance.WorkVersion.TestWithBuilderInheritance.Execute();
        }
    }
}