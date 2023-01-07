using Design_Patterns.ExtensionMethods;
using Design_Patterns.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ProxyExamples
{
    public static void TestProtectionProxy()
    {
        ICar car = new CarProxy(new Driver(17));
        car.Drive();
    }

    public static void TestPropertyProxy()
    {
        var c = new Creature();
        c.Agility = 10;
    }

    public static void TestValueProxy()
    {
        Console.WriteLine(10f * 5.Percent());
        Console.WriteLine(2.Percent() + 3.Percent());
    }

    public static void TestAoSSoA()
    {
        //AoS (Array of structures)
        //Age X Y Age X Y Age X Y - regular way
        var monsters = new Monster[100];
        foreach (var m in monsters)
        {
            m.X++;
        }

        //SoA (Structures of Arrays)
        //THIS is BETTER memorywise
        //Age Age Age
        //X X X
        //Y Y Y
        var monsters2 = new Monsters(100);
        foreach (Monsters.MonsterPxoxy m in monsters2)
        {
            m.x++;
        }
    }

    //Broken for some reason.
    public static void TestLogging()
    {

        var ba = Log<BankAccount>.As<IBankAccount>();
        ba.Deposit(100);
        ba.Withdraw(100);

        Console.WriteLine(ba);
    }
}