using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.ClassicVisitor
{
    public abstract class Expression
    {
        public abstract void Accept(IExpressionVisitor visitor);
    }

    public class DoubleExpression : Expression
    {
        public double value { get; }

        public DoubleExpression(double value)
        {
            this.value = value;
        }

        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
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

        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface IExpressionVisitor
    {
        void Visit(DoubleExpression de);

        void Visit(AdditionExpression ae);
    }

    public class ExpressionPrinter : IExpressionVisitor
    {
        private StringBuilder sb = new StringBuilder();

        public void Visit(DoubleExpression de)
        {
            sb.Append(de.value);
        }

        public void Visit(AdditionExpression ae)
        {
            sb.Append("(");
            ae.left.Accept(this);
            sb.Append("+");
            ae.right.Accept(this);
            sb.Append(")");
        }
    }
}