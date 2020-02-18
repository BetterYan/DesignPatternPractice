using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight.ForFormating
{
    public class FormattedText
    {
        private string plainText;
        private bool[] capitalize;

        public FormattedText(string plainText)
        {
            this.plainText = plainText;
            capitalize = new bool[plainText.Length];
        }

        public void Capitalize(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                capitalize[i] = true;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                var c = plainText[i];
                sb.Append(capitalize[i] ? char.ToUpper(c) : c);
            }
            return sb.ToString();
        }
    }

    //We would like to avoid to store duplicate information

    public class BetterFormattedText
    {
        private string plainText;
        private List<TextRange> formatting = new List<TextRange>();

        public BetterFormattedText(string plainText)
        {
            this.plainText = plainText;
        }

        public TextRange SetRange(int start, int end)
        {
            var range = new TextRange { Start = start, End = end };
            formatting.Add(range);
            return range;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < plainText.Length; i++)
            {
                var c = plainText[i];
                foreach (var range in formatting)
                {
                    if (range.Covers(i) && range.Capitalize)
                    {
                        c = char.ToUpperInvariant(c);
                    }
                }
                sb.Append(c);
            }
            return sb.ToString();
        }

        public class TextRange
        {
            public int Start, End;
            public bool Capitalize = true;

            public bool Covers(int position)
            {
                return position >= Start && position <= End;
            }
        }
    }

    public static class Test
    {
        public static void Execute()
        {
            var text = "This is a brave world.";
            var format = new FormattedText(text);
            format.Capitalize(5, 8);
            Console.WriteLine(format);
            var betterformat = new BetterFormattedText(text);
            betterformat.SetRange(5, 8);
            Console.WriteLine(betterformat);
        }
    }
}