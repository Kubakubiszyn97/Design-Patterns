using static Design_Patterns.Builder.FluentBuilderRecursiveGenerics;
using Design_Patterns.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class BuilderExamples
    {
        public static void TestSimpleBuilder()
        {
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");

            Console.WriteLine(builder.ToString());
        }

        public static void TestFluentRecursiveBuilder()
        {
            Person person = Person.New
                .Called("Kubus")
                .WorksAsA("Hitman")
                .Build();

            Console.WriteLine(person.ToString());
        }
    }
