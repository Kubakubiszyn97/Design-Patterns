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
}
