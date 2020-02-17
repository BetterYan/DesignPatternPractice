using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public partial class FluentBuilder
    {
        public static implicit operator HtmlElement(FluentBuilder builder)
        {
            return builder.root;
        }
    }
}

namespace Builder.Intent
{
    //Tell user that we should use builder with code
    internal class HtmlElement
    {
        private string Name, Text;
        private List<HtmlElement> Elements = new List<HtmlElement>(0);
        private const int indentSize = 2;

        //Hide the Ctor
        private HtmlElement()
        {
        }

        private HtmlElement(string name, string text)
        {
            this.Name = name;
            this.Text = text;
        }

        //factory method
        public static FluentBuilder Create(string name) => new FluentBuilder(name);

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"<{Name}>");
            if (!string.IsNullOrEmpty(Text))
            {
                sb.Append(Text);
            }
            foreach (var item in Elements)
            {
                sb.Append(item.ToString());
            }
            sb.Append($"</{Name}>");
            return sb.ToString();
        }
    }

    public static class TestWithIntent
    {
        public static void Execute()
        {
            Console.WriteLine(nameof(TestWithIntent));
            var builder = HtmlElement.Create("ul")
                .AddChild("li", "hello")
                .AddChild("li", "world")
                ;
            Console.WriteLine(builder.ToString());
        }
    }
}