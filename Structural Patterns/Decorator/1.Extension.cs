using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Extension
{
    //We want to extend the StringBuilder clss
    public partial class MyStringBuilder
    {
        private StringBuilder builder = new StringBuilder();
        private int indentLevel = 0;

        public MyStringBuilder Indent()
        {
            indentLevel++;
            return this;
        }

        //delegate the calls to StringBuilder
        //it will be a large work. It can be done by code generator.
        public MyStringBuilder Append(string value)
        {
            builder.Append(value);
            return this;
        }
    }

    //Adapter concept can also be applied in Decorator.
    public partial class MyStringBuilder
    {
        // string type is adapter to MyStringBuilder now
        public static implicit operator MyStringBuilder(string s)
        {
            var sb = new MyStringBuilder();
            sb.builder.Append(s);
            return sb;
        }

        public static MyStringBuilder operator +(MyStringBuilder sb, string s)
        {
            sb.Append(s);
            return sb;
        }
    }
}