using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.StaticStrategy
{
    public class TextProcessor<LS> where LS : Strategy.DynamicStrategy.IListStrategy, new()
    {
        private StringBuilder sb = new StringBuilder();
        private DynamicStrategy.IListStrategy listStrategy = new LS();

        public void AppendList(IEnumerable<string> items)
        {
            listStrategy.Start(sb);
            foreach (var item in items)
            {
                listStrategy.AddListItem(sb, item);
            }
            listStrategy.End(sb);
        }
    }
}