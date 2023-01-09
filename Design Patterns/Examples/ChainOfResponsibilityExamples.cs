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

    public static void TestBrokerChain()
    {
        var game = new Game();
        var goblin = new Monster(game, "Mariusz", 3, 3);
        Console.WriteLine($"{goblin.Name} has attack: {goblin.Attack}, and defense: {goblin.Defense}");

        using (new DoubleAttack(game, goblin))
        {
            using (new DoubleDefense(game, goblin))
            {
                Console.WriteLine($"{goblin.Name} has attack: {goblin.Attack}, and defense: {goblin.Defense}");
            }
        }

        Console.WriteLine($"{goblin.Name} has attack: {goblin.Attack}, and defense: {goblin.Defense}");
    }
}
