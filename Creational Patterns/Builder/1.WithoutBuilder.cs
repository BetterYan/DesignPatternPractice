using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>(0);
        private const int indentSize = 2;

        public HtmlElement()
        {
        }

        public HtmlElement(string name, string text)
        {
            this.Name = name;
            this.Text = text;
        }

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

    // This is an example.
    // Builder pattern is used when the construction of the object is an untrivial process.
    // Simple object should use a constructor whitout a builder at all.
    public static class TestWithoutBuilder
    {
        public static void Execute()
        {
            Console.WriteLine(nameof(TestWithoutBuilder));
            var words = new[] { "hello", "world" };
            var tag = new HtmlElement("ul", null);
            foreach (var word in words)
            {
                tag.Elements.Add(new HtmlElement("li", word));
            }
            Console.WriteLine(tag);
        }
    }
}