using Design_Patterns.ChainOfResponsibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ChainOfResponsibilityExamples
{
    public static void TestCreatureModifiers()
    {
        var goblin = new Creature("Goblin", 2, 2);
        Console.WriteLine(goblin);
        
        var root = new CreatureModifier(goblin);

        //Uncomment to prevent adding bonuses;
        //root.Add(new NoBonusesModifier(goblin));

        Console.WriteLine("Lets double attack");
        root.Add(new DoubleAttackModifier(goblin));

        Console.WriteLine("Lets increase goblin's defense");
        root.Add(new IncreasedDefenseModifier(goblin));

        root.Handle();
        Console.WriteLine(goblin);
    }
}
