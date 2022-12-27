using Design_Patterns.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CompositeExamples
{
    public static void TestComposite()
    {
        var drawing = new GraphicObject { Name = "My drawing" };
        drawing.Children.Add(new Square { Color = "Red" });
        drawing.Children.Add(new Circle { Color = "Yellow" });


        var group = new GraphicObject();
        group.Children.Add(new Circle() { Color = "Blue"});
        group.Children.Add(new Square() { Color = "BLue"});

        drawing.Children.Add(group);

        Console.WriteLine(drawing.ToString());
    }

}