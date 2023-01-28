using Design_Patterns.Null_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NullObjectExamples
{
    public static void TestNullObject()
    {
        var log = new ConsoleLog();
        var nullLog = new NullLog();
        var ba = new BankAccount(nullLog);
        ba.Desposit(100);
    }
}