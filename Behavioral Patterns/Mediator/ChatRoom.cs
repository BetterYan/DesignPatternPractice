using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Normal
{
    public class Person
    {
        public string Name;
        public ChatRoom Room;
        private List<string> charLog = new List<string>();

        public Person(string name) => Name = name;

        public void Receive(string sender, string message)
        {
            string s = $"{sender}: '{message}'";
            Console.WriteLine($"[{Name}'s chat sessiong] {s}");
            charLog.Add(s);
        }

        public void Say(string message) => Room.Broadcast(Name, message);

        public void PrivateMessage(string who, string message)
        {
            Room.Message(Name, who, message);
        }
    }

    public class ChatRoom
    {
        private List<Person> people = new List<Person>();

        public void Broadcast(string source, string message)
        {
            foreach (var p in people)
            {
                if (p.Name != source)
                {
                    p.Receive(source, message);
                }
            }
        }

        public void Join(Person p)
        {
            var joinMsg = $"{p.Name} joins the chat";
            Broadcast("room", joinMsg);
            p.Room = this;
            people.Add(p);
        }

        public void Message(string source, string destination, string message)
        {
            people.FirstOrDefault(p => p.Name == destination)?.Receive(source, message);
        }
    }

    public static class Test
    {
        public static void Execute()
        {
            var room = new ChatRoom();
            var john = new Person("john");
            var jane = new Person("jane");

            room.Join(john);
            room.Join(jane);

            john.Say("hi room");
            jane.Say("oh, hey john");

            var simon = new Person("Simon");
            room.Join(simon);
            simon.Say("hi everyone!");

            jane.PrivateMessage("Simon", "glad you could join us!");
        }
    }
}