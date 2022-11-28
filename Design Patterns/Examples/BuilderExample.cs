using Design_Patterns.Builder;
using Functional = Design_Patterns.Builder.Functional;
using Faceted = Design_Patterns.Builder.FaacetedBuilder;
using Fluent = Design_Patterns.Builder.FluentBuilderRecursiveGenerics;
using Design_Patterns.Builder.Functional;

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
        Fluent.Person person = Fluent.Person.New
            .Called("Kubus")
            .WorksAsA("Hitman")
            .Build();

        Console.WriteLine(person.ToString());
    }

    public static void TestFunctionalBuilder()
    {
        Functional.Person person = new Functional.PersonBuilder()
            .Called("Diabeł z piekła")
            .WorksAs("Programmer")
            .Build();

        Console.WriteLine(person.Name);
        Console.WriteLine(person.Position);
    }

    public static void TestStepwiseBuilder()
    {
        var car = CarBuilder.Create()
            .OfType(CarType.Sedan)
            .WithWheels(16)
            .Build();
        
        Console.Write(car.ToString());
    }

    public static void TestFacetedBuilder()
    {
        Faceted.PersonBuilder pb = new Faceted.PersonBuilder();
        Faceted.Person person = pb
            .Lives.At("Cieplinskiego")
                  .WithPostCode("35-505")
                  .In("Rzeszów")
            .Works.At("NASA")
                  .AsA("Janitor")
                  .Earning(100);

        Console.Write(person.StreetAddress);
    }
}
