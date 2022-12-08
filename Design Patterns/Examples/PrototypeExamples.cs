using Design_Patterns.Prototype;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PrototypeExamples
{
    public static void TestCopyConstructors()
    {
        var jane = new Person(new[] { "Jane", "Smith" }, new Address("Elm Street", 12));
        var john = new Person(jane);
        john.Names[0] = "John";
        john.Address.HouseNumber = 21;

        Console.WriteLine(jane);
        Console.WriteLine(john);
    }

    public static void TestPrototypeInheritance()
    {
        var john = new PrototypeEmployee();
        john.Salary = 200;
        john.Name = "John";
        john.Address = new Address("Street 1", 25);

        var copy = john.DeepCopy();
        copy.Name = "Jane";
        copy.Address.HouseNumber++;
        copy.Salary = 100;

        var e = john.DeepCopy<PrototypeEmployee>();
        var p = john.DeepCopy<PrototypePerson>();

        Console.WriteLine(john);
        Console.WriteLine(copy);


    }
}
