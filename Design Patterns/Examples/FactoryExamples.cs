using Design_Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Design_Patterns.Factory.ObjectTracking_BulkReplacement;

public static class FactoryExamples
{
    public static void TestSimpleFactoryMethod()
    {
        var point = Point.NewPolarPoint(1.0, MathF.PI / 2);
        Console.WriteLine(point.ToString());
    }

    public static async Task TestAsyncFactory()
    {
        Foo x = await Foo.CreateAsync();
    }

    public static void TestSimpleFactory()
    {
        var point = PointFactory.NewCartesianPoint(1.0, MathF.PI / 2);
    }

    public static void TestTracking()
    {
        var factory = new TrackingThemeFactory();
        var theme1 = factory.CreateTheme(false);
        var theme2 = factory.CreateTheme(true);
        Console.Write(factory.Info.ToString());

        var factory2 = new ReplacableThemeFactory();
        var magicTheme = factory2.CreateTheme(true);
        Console.WriteLine(magicTheme.Value.BrgColor);
        factory2.ReplaceTheme(false);
        Console.WriteLine(magicTheme.Value.BrgColor);
    }

    public static void TestInnerFactory()
    {
        var point = InnerPoint.Factory.NewPolarPoint(1.0, MathF.PI / 2);
        Console.WriteLine(point.ToString());
    }
}