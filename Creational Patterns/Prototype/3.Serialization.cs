using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Serialization
{
    public static class Extensions
    {
        public static T DeepCopy<T>(this T self)
        {
            using var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            var copy = formatter.Deserialize(stream);
            return (T)copy;
        }
    }

    public static class SerializationApproach
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

        public static class Test
        {
            public static void Execute()
            {
                Console.WriteLine(nameof(SerializationApproach));
                var john = new Person("John Smith", new Address("London Road", 123));
                var jane = john.DeepCopy();
                jane.Name = "Jane Smith";
                jane.Address.HouseNumber = 321;
                Console.WriteLine(john);
                Console.WriteLine(jane);
            }
        }
    }
}