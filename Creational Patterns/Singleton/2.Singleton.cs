using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.Normal
{
    public class Database
    {
        private Database()
        {
        }

        //static is thread safe in the appdomain.
        public static Database Instance { get; } = new Database();
    }
}

namespace Singleton.Lazy
{
    public class Database
    {
        //Lazy<T> is thread safe by default
        private static Lazy<Database> _instance = new Lazy<Database>(() => new Database());

        private Database()
        {
        }

        public static Database Instance => _instance.Value;
    }
}

namespace Singleton.Trouble
{
    //This will be a problem in real life, because we can't inject the depency intot the singleton.
    //We need to extract the interface and make the high-level configurable.
    public interface IDatabase
    {
        int GetPopulation(string country);
    }

    public class Database : IDatabase
    {
        private Dictionary<string, int> capitals;
        private static int instanceCount;
        public static int Count => instanceCount;

        private Database()
        {
            //Fake something instead of real situation here.
            capitals = new Dictionary<string, int>() {
                { "China",12},
                { "Japan",3},
                { "USA",8},
            };
        }

        public int GetPopulation(string country)
        {
            return capitals[country];
        }

        private static Lazy<Database> instance = new Lazy<Database>(() =>
          {
              instanceCount++;
              return new Database();
          });

        public static IDatabase Instance => instance.Value;
    }

    public class RecordFinder
    {
        private IDatabase database;

        public RecordFinder(IDatabase database)
        {
            this.database = database;
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += database.GetPopulation(name);
            }
            return result;
        }
    }

    //We can set another dumpy database implementation
    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string country)
        {
            return new Dictionary<string, int>
            {
                ["a"] = 1,
                ["b"] = 2
            }[country];
        }
    }
}