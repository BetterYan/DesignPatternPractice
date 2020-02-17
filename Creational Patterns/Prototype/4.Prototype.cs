using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prototype.Serialization;

namespace Prototype
{
    public static class PrototypeApproach
    {
        [Serializable]
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

        [Serializable]
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

        public class EmployeeFactory
        {
            private static Person main = new Person(null, new Address("East Load", 123));
            private static Person aux = new Person(null, new Address("Weat Load", 321));

            public static Person NewMainOfficeEmployee(string name, int houseNumber) => NewEmployee(main, name, houseNumber);

            public static Person NewAuxOfficeEmployee(string name, int houseNumber) => NewEmployee(aux, name, houseNumber);

            private static Person NewEmployee(Person proto, string name, int houseNumber)
            {
                var copy = proto.DeepCopy();
                copy.Name = name;
                copy.Address.HouseNumber = houseNumber;
                return copy;
            }
        }

        public static class Test
        {
            public static void Execute()
            {
                Console.WriteLine(nameof(PrototypeApproach));
                var john = EmployeeFactory.NewMainOfficeEmployee("John Smith", 123);
                var jane = EmployeeFactory.NewAuxOfficeEmployee("Jane Smith", 321);
                Console.WriteLine(john);
                Console.WriteLine(jane);
            }
        }
    }
}