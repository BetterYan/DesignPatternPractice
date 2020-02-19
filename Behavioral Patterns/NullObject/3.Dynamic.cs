using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpromptuInterface;

namespace NullObject
{
    public class Null<T> : DynamicObject where T : class
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var name = binder.Name;
            result = Activator.CreateInstance(binder.ReturnType);
            return true;
        }

        public static T Instance
        {
            get
            {
                if (!typeof(T).IsInterface)
                {
                    throw new ArgumentException("I must be an interface type");
                }
                return new Null<T>().ActLike<T>();
            }
        }
    }

    //usage
    //var log = Null<ILog>.Instance;
    //var ba = new BankAccount(log);
}