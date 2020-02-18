using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.PropertyProxy
{
    public class Property<T> where T : new()
    {
        private T value;
        private readonly string name;

        public T Value
        {
            get => value;
            set
            {
                if (Equals(this.value, value))
                {
                    return;
                }
                Console.WriteLine($"Assigning {value} to {name}");
                this.value = value;
            }
        }

        public Property() : this(default(T))
        {
        }

        public Property(T value, string name = "")
        {
            this.name = name;
            this.value = value;
        }

        public static implicit operator T(Property<T> property)
        {
            return property.value;
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value);
        }
    }

    public class Creature
    {
        public Property<int> agility = new Property<int>(10, nameof(agility));

        //C# doesn't allow to override the = operator
        //We have to do some trick
        public int Agility
        {
            get => agility;
            set => agility.Value = value;
        }
    }

    public static class Test
    {
        public static void Execute()
        {
            var c = new Creature();
            Console.WriteLine("Without trick");
            c.agility = 20;//nothing happens
            Console.WriteLine("With trick");
            c.Agility = 30;
        }
    }
}