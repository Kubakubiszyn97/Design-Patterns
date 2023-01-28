using Design_Patterns.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StateExamples
{
    private static Dictionary<State, List<(Trigger, State)>> rules
        = new Dictionary<State, List<(Trigger, State)>>
    {
        [State.OffHook] = new List<(Trigger, State)>
        {
            (Trigger.CallDialed, State.Connecting)
        },
        [State.Connecting] = new List<(Trigger, State)>
        {
            (Trigger.HungUp, State.OffHook),
            (Trigger.CallConnected, State.Connected)
        },
        [State.Connected] = new List<(Trigger, State)>
        {
            (Trigger.LeftMessage, State.OffHook),
            (Trigger.HungUp, State.OffHook),
            (Trigger.PlacedOnHold, State.OnHold)
        },
        [State.OnHold] = new List<(Trigger, State)>
        {
            (Trigger.TakenOffHold, State.Connected),
            (Trigger.HungUp, State.OffHook)
        }
     };

    public static void TestStateMachine()
    {
        var state = State.OffHook;
        while (true)
        {
            Console.WriteLine($"The phone is currently {state}");
            Console.WriteLine("Select a trigger");

            for (var i = 0; i < rules[state].Count; i++)
            {
                var (t, _) = rules[state][i];
                Console.WriteLine($"{i}. {t}");
            }

            int input = int.Parse(Console.ReadLine());

            var (_, s) = rules[state][input];
            state = s;
        }
    }

    public static void TestSwitchBasedStateMachine()
    {
        string code = "1234";
        var state = LockState.Locked;
        var entry = new StringBuilder();

        while (true)
        {
            switch (state)
            {
                case LockState.Locked:
                    entry.Append(Console.ReadKey().KeyChar);

                    if (entry.ToString() == code)
                    {
                        state = LockState.Unlocked;
                        break;
                    }

                    if (!code.StartsWith(entry.ToString()))
                    {
                        // the code is blatantly wrong
                        //goto case State.Failed;
                        state = LockState.Failed;
                    }
                    break;
                case LockState.Failed:
                    Console.CursorLeft = 0;
                    Console.WriteLine("FAILED");
                    entry.Clear();
                    state = LockState.Locked;
                    break;
                case LockState.Unlocked:
                    Console.CursorLeft = 0;
                    Console.WriteLine("UNLOCKED");
                    return;
            }
        }
    }

    public static void TestSwitchExpression()
    {
        Chest chest = Chest.Locked;
        Console.WriteLine($"Chest is {chest}");

        // unlock with key
        chest = SwitchExpression.Manipulate(chest, Design_Patterns.State.Action.Open, true);
        Console.WriteLine($"Chest is now {chest}");

        // close it!
        chest = SwitchExpression.Manipulate(chest, Design_Patterns.State.Action.Close, false);
        Console.WriteLine($"Chest is now {chest}");

        // close it again!
        chest = SwitchExpression.Manipulate(chest, Design_Patterns.State.Action.Close, false);
        Console.WriteLine($"Chest is now {chest}");
    }
}