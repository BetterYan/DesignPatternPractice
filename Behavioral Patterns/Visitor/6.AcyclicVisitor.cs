using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.AcyclicVisitor
{
    public interface IVisitor<T>
    {
        void Visit(T obj);
    }

    public interface IVisitor { };

    public abstract class Expression
    {
        public virtual void Accept(IVisitor visitor)
        {
            if (visitor is IVisitor<Expression> typed)
            {
                typed.Visit(this);
            }
        }
    }

    public class DoubleExpression : Expression
    {
        //something
    }

    public class AdditionExpression : Expression
    {
        //something
    }

    public class ExpressionPrinter : IVisitor,
        IVisitor<Expression>,
        IVisitor<DoubleExpression>,
        IVisitor<AdditionExpression>
    {
        public void Visit(DoubleExpression obj)
        {
            //something
        }

        public void Visit(AdditionExpression obj)
        {
            //something
        }

        public void Visit(Expression obj)
        {
            //something
        }
    }
}