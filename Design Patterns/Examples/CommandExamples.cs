using Design_Patterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CommandExamples
{
    public static void TestSimpleCommandExample()
    {
        var ba = new BankAccount();
        var commands = new List<BankAccountCommand>()
        {
            new BankAccountCommand(ba, 100, BankAccountCommand.Action.Deposit),
            new BankAccountCommand(ba, 200, BankAccountCommand.Action.Withdraw)
        };

        Console.WriteLine(ba);
        foreach (var c in commands)
        {
            c.Call();
        }
        Console.WriteLine(ba);

        foreach (var c in Enumerable.Reverse(commands))// Does not mutate list
        {
            c.Undo();
        }
        Console.WriteLine(ba);
    }}