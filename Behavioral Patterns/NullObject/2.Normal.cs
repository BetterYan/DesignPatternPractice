using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    //step2: we don't want log sometimes
    //We can use null object instead of null syntax
    public sealed class NullLog : ILog
    {
        public void Info(string msg)
        {
        }

        public void Warn(string msg)
        {
        }
    }

    //stpe3: we can also use null object virtual proxy
    internal class OptionalLog : ILog
    {
        private ILog impl;
        private static ILog NoLogging = null;

        public OptionalLog(ILog impl)
        {
            this.impl = impl;
        }

        public void Info(string msg)
        {
            impl?.Info(msg);
        }

        public void Warn(string msg)
        {
            impl?.Warn(msg);
        }
    }
}