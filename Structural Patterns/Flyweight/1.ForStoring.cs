using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight.ForStoring
{
    public class User
    {
        public string FullName { get; }

        public User(string fullName)
        {
            FullName = fullName;
        }
    }

    public class FlyweightUser
    {
        private static List<string> strings = new List<string>();
        private int[] names;

        public FlyweightUser(string fullName)
        {
            int getOrAdd(string s)
            {
                int idx = strings.IndexOf(s);
                if (idx != -1)
                {
                    return idx;
                }
                else
                {
                    strings.Add(s);
                    return strings.Count - 1;
                }
            }
            names = fullName.Split(' ').Select(getOrAdd).ToArray();
        }

        public string FullName => string.Join(" ", names.Select(i => strings[i]));
    }

    public static class Test
    {
        public static string RandomString()
        {
            var rand = new Random();
            return new string(Enumerable.Range(0, 10)
                .Select(i => (char)('a' + rand.Next(26))).ToArray());
        }

        public static (string[], string[]) PrepareNames()
        {
            var firstName = new string[100];
            for (int i = 0; i < 100; i++)
            {
                firstName[0] = RandomString();
            }
            var secondName = new string[100];
            for (int i = 0; i < 100; i++)
            {
                secondName[0] = RandomString();
            }
            return (firstName, secondName);
        }

        public static void Execute()
        {
            var users = new List<User>();
            var flyweightUsers = new List<FlyweightUser>();
            var names = PrepareNames();
            foreach (var first in names.Item1)
            {
                foreach (var second in names.Item2)
                {
                    users.Add(new User($"{first} {second}"));
                    flyweightUsers.Add(new FlyweightUser($"{first} {second}"));
                }
            }
            GC.Collect();
            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}