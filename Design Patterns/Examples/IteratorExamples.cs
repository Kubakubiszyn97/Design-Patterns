using Design_Patterns.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IteratorExamples
{
    public static void TestIteratorObject()
    {
        var root = new Node<int>(1,
            new Node<int>(2), new Node<int>(3));

        var it = new InOrderIterator<int>(root);
        while (it.MoveNext())
        {
            Console.Write(it.Current.Value);
            Console.Write(',');
        }
        Console.WriteLine();

        var tree = new BinaryTree<int>(root);
        Console.WriteLine(string.Join(',', tree.InOrder.Select(x => x.Value)));

        //Due To GetEnumeratorMethod in BinaryTree;
        foreach (var node in tree)
        {
            Console.WriteLine(node.Value);
        }
    }
}