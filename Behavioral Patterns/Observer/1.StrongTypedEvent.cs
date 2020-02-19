using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.StrongTyped
{
    //We should think about dependency problems. What about use weak reference?
    //The GC won't release the resource at the right time.
    public class FallsIllEventArgs : EventArgs
    {
        public string Address;
    }

    public class Person
    {
        public event EventHandler<FallsIllEventArgs> FallsIll;

        public void CatchCold()
        {
            FallsIll?.Invoke(this, new FallsIllEventArgs { Address = "123 London Road" });
        }
    }

    public static class Test
    {
        public static void CallDoctor(object sender, FallsIllEventArgs eventArgs)
        {
            Console.WriteLine($"A doctor has been called to {eventArgs.Address}");
        }

        public static void Execute()
        {
            var person = new Person();
            person.FallsIll += CallDoctor;
        }
    }
}