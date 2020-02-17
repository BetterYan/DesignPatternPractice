using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Adapter.Surrogate
{
    //This is also known as property adapter
    //The very common application of the adapter design pattern is to get your class to provide additional properties
    //that serve only one purpose: to take exsting fields or properties and expose them in some useful way,
    //quite often as projections to a different data type.

    //For example:
    //We have an IDictonary member, but we can't use an XmlSerializer because Microsoft didn't implement "due to shcedule constrains".
    //Then we can use an adapter.

    public class Foo
    {
        [XmlIgnore]
        public Dictionary<string, string> Capitals { get; set; } = new Dictionary<string, string>();

        public (string, string)[] CapitalsSerializable
        {
            get
            {
                return Capitals.Keys.Select(country => (country, Capitals[country])).ToArray();
            }
            set
            {
                Capitals = value.ToDictionary(x => x.Item1, x => x.Item2);
            }
        }
    }

    public static class Test
    {
        public static void Execute()
        {
            var foo = new Foo();
            foo.Capitals.Add("A", "a");
            foo.Capitals.Add("B", "b");
            foo.Capitals.Add("C", "c");
            foo.Capitals.Add("D", "d");
            foo.Capitals.Add("E", "e");
            using var stream = new MemoryStream();
            var xs = new XmlSerializer(typeof(Foo));
            xs.Serialize(stream, foo);
            stream.Seek(0, SeekOrigin.Begin);
            using var sr = new StreamReader(stream);
            Console.WriteLine(sr.ReadToEnd());
        }
    }
}