using Design_Patterns.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ObserverExamples
{
    public static void TestObserverViaEvent()
    {
        var person = new Person();

        person.FallsIll += CallADoctor;
        person.CatchACold();
        person.FallsIll -= CallADoctor;
    }

    public static void TestWeakEvents()
    {
        var btn = new Button();
         var window = new Window(btn);
        btn.Fire();

        var wr = new WeakReference(window);
        Console.WriteLine("Setting window to null");
        window = null; //GC won't collect because button is still "alive"

        FireGC();
        Console.WriteLine($"Is the window alive after GC? {wr.IsAlive}");
    }

    private static void CallADoctor(object? sender, FallsIllEventArgs args)
    {
        Console.WriteLine($"CallingDoctor to {args.Address}");
    }

    private static void FireGC()
    {
        Console.Write("Starting GC");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        Console.WriteLine("GC is Done");
    }
}