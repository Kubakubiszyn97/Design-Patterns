using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Decorator.DefaultMembers
{
    public interface ICreature
    {
        int Age { get; set; }
    }

    public interface IBird : ICreature
    {
        void Fly()
        {
            if (Age >= 10)
                Console.WriteLine("Flying");
        }
    }

    public interface ILizard : ICreature
    {
        void Crawl()
        {
            if (Age < 10)
                Console.WriteLine("Crawling");
        }
    }

    public class Organism { }

    public class Dragon : Organism, ILizard, IBird
    {
        public int Age { get; set; }
    }

    //Expanding class without modifing Dragon Class
    //inheritance
    //SmartDragon(Dragon)
    //extension methods (less intrusive)
    //C#8 default interface methods
}
