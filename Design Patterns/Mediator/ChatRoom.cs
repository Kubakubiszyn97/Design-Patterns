using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Mediator
{
    public class Person
    {
        public string Name;
        public ChatRoom Room;
        private List<string> chatLog = new List<string>();

        public Person(string name)
        {
            Name = name;
        }

        public void Say(string message)
        {
            Room.Broadcast(Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            Room.Message(Name, who, message);
        }

        public void Recieve(string sender, string message)
        {
            string s = $"{sender}: '{message}";
            chatLog.Add(s);
            Console.WriteLine($"[{Name}'s chat session: {s}]");
        }
    }

    public class ChatRoom
    {
        private List<Person> people = new();

        public void Join(Person p)
        {
            string joinMsg = $"{p.Name} joins the chat";
            Broadcast("room", joinMsg);

            p.Room = this;
            people.Add(p);
        }

        public void Broadcast(string source, string message)
        {
            foreach(var p in people)
                if (p.Name != source)
                {
                    p.Recieve(source, message);
                }
        }

        public void Message(string source, string destination, string message)
        {
            people.FirstOrDefault(p => p.Name == destination)
                ?.Recieve(source, message);
        }
    }
}
