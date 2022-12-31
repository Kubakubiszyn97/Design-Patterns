using Design_Patterns.Decorator;
using DefaultMembers = Design_Patterns.Decorator.DefaultMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DecoratorExamples
{
    public static void TestCustomStringBuilder()
    {
        var cb = new CodeBuilder();
        cb.AppendLine("class Foo")
           .AppendLine("{")
           .AppendLine("}");

        Console.WriteLine(cb.ToString());
    }

    public static void TestAdapterDecotrator()
    {
        MyStringBuilder s = "hello";
        s += "world";
        Console.WriteLine(s);
    }

    public static void TestMultipleInheritance()
    {
        var d = new Dragon();
        d.Weight = 123;
        d.Fly();
        d.Crawl();
    }

    public static void TestMultipleInheritanceDefaultMembers()
    {
        DefaultMembers.Dragon d = new DefaultMembers.Dragon() { Age = 5 };

        //Default members require explicit converions
        if (d is DefaultMembers.IBird bird)
            bird.Fly();

        if (d is DefaultMembers.ILizard lizard)
            lizard.Crawl();
    }

    public static void TestDynamicDecorator()
    {
        var square = new Square(1.23f);
        Console.WriteLine(square.AsString());

        var redSquare = new ColoredShape(square, "red");
        Console.WriteLine(redSquare.AsString());

        var redHalfTransparentSquare = new TransparentShape(redSquare, 0.5f);
        Console.WriteLine(redHalfTransparentSquare.AsString());
    }
}