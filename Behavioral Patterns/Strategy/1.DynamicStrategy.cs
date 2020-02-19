using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.DynamicStrategy
{
    public enum OutputFormat
    {
        Markdown,
        Html
    }

    public interface IListStrategy
    {
        void Start(StringBuilder sb);

        void AddListItem(StringBuilder sb, string item);

        void End(StringBuilder sb);
    }

    public class TextProcessor
    {
        private StringBuilder sb = new StringBuilder();
        private IListStrategy listStrategy;

        public void AppendList(IEnumerable<string> items)
        {
            listStrategy.Start(sb);
            foreach (var item in items)
            {
                listStrategy.AddListItem(sb, item);
            }
            listStrategy.End(sb);
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }

    public class HtmlListStrategy : IListStrategy
    {
        public void Start(StringBuilder sb) => sb.Append("<ul>");

        public void End(StringBuilder sb) => sb.AppendLine("</ul>");

        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($"    <li>{item}</li>");
        }
    }
}