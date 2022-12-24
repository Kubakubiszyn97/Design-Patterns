using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Design_Patterns.Singleton;

public class SingletonExamples
{
    public static void TestSingleton()
    {
        var dataBase = SingletonDatabase.Instance;
        var pop = dataBase.GetPopulation("Tokyo");
        Console.WriteLine(pop);
    }

    public static void TestMonostate()
    {
        var ceo = new CEO();
        ceo.Name = "Adam Smith";
        ceo.Age = 55;

        var ceo2 = new CEO();

        Console.WriteLine(ceo.Name);
        Console.WriteLine(ceo2.Name);
    }

    public static void TestPerThreadSingleton()
    {
        var t1 = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("t1: " + PerThreadSingleton.Instance.Id);

        });

        var t2 = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("t2: " + PerThreadSingleton.Instance.Id);
            Console.WriteLine("t2: " + PerThreadSingleton.Instance.Id);

        });

        Task.WaitAll(t1, t2);
    }

    public static void TestAmbientContext()
    {
        var house = new Building();
        
        using (new BuildingContext(3000))
        {
            //ground floor, height = 3000
            house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
            house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 5000)));

            //1st floor, height = 3500;
            using (new BuildingContext(3500))
            {
                house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
                house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 5000)));
            }

            house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
        }

        Console.WriteLine(house.Walls[0].Height);
        Console.WriteLine(house.Walls[2].Height);
        Console.WriteLine(house.Walls[4].Height);
    }
}
