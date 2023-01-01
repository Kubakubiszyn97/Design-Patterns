using Design_Patterns.Flyweight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FlyweightExamples
{
    public static void TestTextFormating()
    {
        var ft = new FormatedText("This is a brave new world");
        ft.Capitalize(10, 15);

        Console.WriteLine(ft);

        var bft = new BetterFormatedText("This is a brave new world");
        bft.GetRange(10, 15).Capitalize = true;
        Console.WriteLine(bft.ToString());
    }
}