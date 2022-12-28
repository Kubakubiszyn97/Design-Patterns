using Design_Patterns.Composite;
using Design_Patterns.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CompositeExamples
{
    public static void TestCompositeShapes()
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


    public static void TestNeuralNetworks()
    {
        var neuron1 = new Neuron();
        var neuron2 = new Neuron();

        var layer1 = new NeuronLayer();
        var layer2 = new NeuronLayer();
        neuron1.ConnectTo(layer1);
        layer1.ConnectTo(layer2);
        layer2.ConnectTo(neuron2);
    }
}