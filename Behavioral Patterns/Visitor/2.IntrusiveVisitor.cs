using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.IntrusiveVisitor
{
    //we modified tha base abstract class, throw away the OCP and SRP
    public abstract class Expression
    {
        //adding a new operation
        public abstract void Print(StringBuilder sb);
    }

    //we do hard work, add new function implementation one by one
    public class DoubleExpression : Expression
    {
        private double value;

        public DoubleExpression(double value)
        {
            this.value = value;
        }

        public override void Print(StringBuilder sb)
        {
            //something here
        }
    }

    //etc......
}