using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.DynamicVisitor
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

    public class ExpressionPrinter
    {
        public void Print(AdditionExpression ae, StringBuilder sb)
        {
            sb.Append("(");
            //ae is defined as Express, use dynamic
            //dynamic defer the dispatch decisions until runtime
            //A few problems:
            //1. There is a fairly significant performance penalty related to this type of dispatching
            //2. If a needed method is missing, you will get a runtime error
            //3. You can run into serious problems with inheritance.
            Print((dynamic)ae.left, sb);
            sb.Append("+");
            Print((dynamic)ae.right, sb);
            sb.Append(")");
        }
    }
}