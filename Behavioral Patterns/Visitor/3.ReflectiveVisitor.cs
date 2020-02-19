using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.ReflectiveVisitor
{
    #region Something We have in Scenario.cs

    public abstract class Expression
    {
    }

    public class DoubleExpression : Expression
    {
        public double value { get; }

        public DoubleExpression(double value)
        {
            this.value = value;
        }
    }

    public class AdditionExpression : Expression
    {
        public Expression left, right;

        public AdditionExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }
    }

    #endregion Something We have in Scenario.cs

    public static class ExpressionPrinter
    {
        public static void Print(DoubleExpression e, StringBuilder sb)
        {
            sb.Append(e.value);
        }

        public static void Print(AdditionExpression ae, StringBuilder sb)
        {
            sb.Append("(");
            Print(ae.left, sb);
            sb.Append("+");
            Print(ae.right, sb);
            sb.Append(")");
        }

        //more polymorphic
        public static void Print(Expression e, StringBuilder sb)
        {
            if (e is DoubleExpression de)
            {
                sb.Append(de.value);
            }
            else if (e is AdditionExpression ae)
            {
                sb.Append("(");
                Print(ae.left, sb);
                sb.Append("+");
                Print(ae.right, sb);
                sb.Append(")");
            }
            //more else if here
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}