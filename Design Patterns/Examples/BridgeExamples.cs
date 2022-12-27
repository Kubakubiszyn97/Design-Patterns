using Design_Patterns.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BridgeExamples
{
    public static void TestBride()
    {
        IRenderer renderer = new RasterRenderer();
        var circle = new Circle(renderer, 5);

        circle.Draw();
        circle.Resize(2);
        circle.Draw();
    }
}
