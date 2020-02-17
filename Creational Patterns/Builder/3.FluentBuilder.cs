using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public partial class FluentBuilder
    {
        protected readonly string rootName;
        protected HtmlElement root = new HtmlElement();

        public FluentBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        public FluentBuilder AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            //Chain Method
            return this;
        }

        public HtmlElement Build() => root;

        public override string ToString() => root.ToString();
    }

    public static class TestWithFluentBuilder
    {
        public static void Execute()
        {
            Console.WriteLine(nameof(TestWithFluentBuilder));
            var builder = new FluentBuilder("ul");
            builder.AddChild("li", "hello").AddChild("li", "world");
            Console.WriteLine(builder);
        }
    }
}