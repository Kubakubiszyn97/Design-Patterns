using Design_Patterns.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class InterpreterExamples
{
    public static void TestLexInterprerter()
    {
        string input = "(13+4)-(12+1)";
        var tokens = InterpreterHelpers.Lex(input);

        Console.WriteLine(string.Join("\t", tokens));
        var parsed = InterpreterHelpers.Parse(tokens);
        Console.WriteLine($"{input} = {parsed.Value}");
    } 
}
