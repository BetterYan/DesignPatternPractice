using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Scenario
{
    //background knowledge. This can be explained with stack vs heap.
    internal static class Basicknowledge
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
                Console.WriteLine(nameof(Basicknowledge));
                var john = new Person("John Smith", new Address("London Road", 123));
                var jane = john;
                jane.Name = "Jane Smith"; // We know john's name is changed also.
                jane.Address.HouseNumber = 321; // We know john's house number is changed.
                Console.WriteLine(john);
                Console.WriteLine(jane);
            }
        }
    }
}