using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.CopyApproach
{
    //but, we want to create something from the special one just like prototype approach in car industry.
    internal static class ICloneableApproach
    {
        public class Person : ICloneable
        {
            public string Name;
            public readonly Address Address; //readonly does not work for protecting the value inside it;

            public Person(string name, Address address)
            {
                this.Name = name;
                this.Address = address;
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.Append($"{Name}-{Address.StreetName}-{Address.HouseNumber}");
                return sb.ToString();
            }

            public object Clone()
            {
                return (Person)MemberwiseClone();
            }
        }

        public class Address
        {
            public string StreetName;
            public int HouseNumber;

            public Address(string streetName, int houseNumber)
            {
                this.StreetName = streetName;
                this.HouseNumber = houseNumber;
            }
        }

        public static class Test
        {
            public static void Execute()
            {
                Console.WriteLine(nameof(ICloneableApproach));
                var john = new Person("John Smith", new Address("London Road", 123));
                var jane = (Person)john.Clone();
                jane.Name = "Jane Smith"; // john's name doesn't change.
                jane.Address.HouseNumber = 321; // We know john's house number is changed.
                Console.WriteLine(john);
                Console.WriteLine(jane);
            }
        }
    }

    internal static class DeepCopyByOurselves
    {
        public interface IDeepCopyable<T>
        {
            T DeepCopy();
        }

        public class Person : IDeepCopyable<Person>
        {
            public string[] Names;
            public Address Address;

            public Person(string[] names, Address address)
            {
                this.Names = names;
                this.Address = address;
            }

            public Person()
            {
            }

            public Person DeepCopy()
            {
                var copy = new Person();
                copy.Names = Names;
                copy.Address = Address.DeepCopy();
                return copy;
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                foreach (var item in Names)
                {
                    sb.Append(item);
                }
                sb.Append($"-{Address.StreetName}-{Address.HouseNumber}");
                return sb.ToString();
            }
        }

        public class Address : IDeepCopyable<Address>
        {
            public string StreetName;
            public int HouseNumber;

            public Address(string streetName, int houseNumber)
            {
                this.StreetName = streetName;
                this.HouseNumber = houseNumber;
            }

            public Address DeepCopy()
            {
                return new Address(StreetName, HouseNumber);
            }
        }

        public static class Test
        {
            public static void Execute()
            {
                Console.WriteLine(nameof(DeepCopyByOurselves));
                var john = new Person(new[] { "John", " Smith" }, new Address("London Road", 123));
                var jane = john.DeepCopy();
                jane.Names = new[] { "Jane", " Smith" };
                jane.Address.HouseNumber = 321;
                Console.WriteLine(john);
                Console.WriteLine(jane);
            }
        }
    }

    internal static class CopyWithCtor
    {
        public class Person
        {
            public string Name;
            public readonly Address Address; //readonly does not work for protecting the value inside it;

            public Person(string name, Address address)
            {
                this.Name = name;
                this.Address = address;
            }

            public Person(Person person)
            {
                this.Name = person.Name;
                this.Address = new Address(person.Address);
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                sb.Append($"{Name}-{Address.StreetName}-{Address.HouseNumber}");
                return sb.ToString();
            }
        }

        public class Address
        {
            public string StreetName;
            public int HouseNumber;

            public Address(Address address)
            {
                this.StreetName = address.StreetName;
                this.HouseNumber = address.HouseNumber;
            }

            public Address(string streetName, int houseNumber)
            {
                this.StreetName = streetName;
                this.HouseNumber = houseNumber;
            }
        }

        public static class Test
        {
            public static void Execute()
            {
                Console.WriteLine(nameof(CopyWithCtor));
                var john = new Person("John Smith", new Address("London Road", 123));
                var jane = new Person(john);
                jane.Name = "Jane Smith";
                jane.Address.HouseNumber = 321;
                Console.WriteLine(john);
                Console.WriteLine(jane);
            }
        }
    }
}