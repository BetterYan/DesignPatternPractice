using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive;
using System.Reactive.Linq;

namespace Observer.EventStreams
{
    //.NET introduce two interface IObserver<T> and IOBservable<T>. For convenience, it should be used with System.Reactive.
    //So, we should use ObservableCollection<T> in WPF situation for ease.
    public class Event
    {
    }

    public class FallsIllEvent : Event
    {
        public string Address;
    }

    public class Person : IObservable<Event>
    {
        private readonly HashSet<Subscription> subscriptions = new HashSet<Subscription>();

        public IDisposable Subscribe(IObserver<Event> observer)
        {
            var subscription = new Subscription(this, observer);
            subscriptions.Add(subscription);
            return subscription;
        }

        public void CatchACold()
        {
            foreach (var sub in subscriptions)
            {
                sub.Observer.OnNext(new FallsIllEvent { Address = "123 London Road" });
            }
        }

        private class Subscription : IDisposable
        {
            private Person person;
            public IObserver<Event> Observer;

            public Subscription(Person person, IObserver<Event> observer)
            {
                this.person = person;
                Observer = observer;
            }

            public void Dispose()
            {
                person.subscriptions.Remove(this);
            }
        }
    }

    public static class Test
    {
        public static void Execute()
        {
            var person = new Person();
            person.OfType<FallsIllEvent>()
                .Subscribe(ages => Console.WriteLine($"A doctor has been called to {AssemblyLoadEventArgs.Empty}"));
            person.CatchACold();
        }
    }
}