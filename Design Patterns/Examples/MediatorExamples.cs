using Design_Patterns.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MediatorExamples
{
    public static void TestChatRoom()
    {
        var room = new ChatRoom();

        var john = new Person("John");
        var jane = new Person("Jane");

        room.Join(john);
        room.Join(jane);

        john.Say("Hi");
        jane.Say("oh, hi john");

        var simon = new Person("Simon");
        room.Join(simon);
        simon.Say("hi everyone");

        jane.PrivateMessage("Simon", "glad you could join us!");
    }
}

