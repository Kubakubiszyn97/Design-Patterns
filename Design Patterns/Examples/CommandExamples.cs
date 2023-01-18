using Simple = Design_Patterns.Command;
using Composite = Design_Patterns.Command.Composite;

public class CommandExamples
{
    public static void TestSimpleCommandExample()
    {
        var ba = new Simple.BankAccount();
        var commands = new List<Simple.BankAccountCommand>()
        {
            new Simple.BankAccountCommand(ba, 100, Design_Patterns.Command.Action.Deposit),
            new Simple.BankAccountCommand(ba, 200, Design_Patterns.Command.Action.Withdraw)
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
    }

    public static void TestCompositeCommand()
    {
        var ba = new Composite.BankAccount();
        var deposit = new Composite.BankAccountCommand(ba, 100, Design_Patterns.Command.Action.Deposit);
        var withdraw = new Composite.BankAccountCommand(ba, 200, Design_Patterns.Command.Action.Withdraw);

        var composite = new Composite.CompositeBankAccountCommand(new[] { deposit, withdraw });
        composite.Call();
        Console.WriteLine(ba);

        composite.Undo();
        Console.WriteLine(ba);

        //MoneyTransfer - this requires sequential commands check when calling
        
        var from = new Composite.BankAccount();
        from.Deposit(100);

        var to = new Composite.BankAccount();

        var mtc = new Composite.MoneyTransferCommand(from, to, 100);
        mtc.Call();

        Console.WriteLine(from);
        Console.WriteLine(to);
    }
}
