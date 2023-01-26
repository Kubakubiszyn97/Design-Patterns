﻿using Design_Patterns.Memento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MementoExamples
{
    public static void TestMemento()
    {
        var ba = new BankAccount(100);
        var m1 = ba.Deposit(50);
        var m2 = ba.Deposit(25);
        Console.WriteLine(ba);

        ba.Restore(m1);
        Console.WriteLine(ba);

        ba.Restore(m2);
        Console.WriteLine(ba);
    }
}