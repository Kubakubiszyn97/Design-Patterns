using Design_Patterns.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Examples
{
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
    }
}
