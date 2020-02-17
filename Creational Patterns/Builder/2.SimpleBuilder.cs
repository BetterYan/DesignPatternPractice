using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public partial class HtmlBuilder
    {
        protected readonly string rootName;
        protected HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        public void AddChild(string childName, string childText)
        {
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
        }

        public override string ToString() => root.ToString();
    }

    public static class TestWithSimpleBuilder
    {
        public static void Execute()
        {
            Console.WriteLine(nameof(TestWithSimpleBuilder));
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            Console.WriteLine(builder);
        }
    }
}