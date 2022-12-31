using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Decorator
{
    public interface IBird
    {
        public int Weight { get; set; }

        void Fly();
    }

    public class Bird : IBird
    {
        public int Weight { get; set; }

        public void Fly()
        {
            Console.WriteLine($"Flying with weight {Weight}");
        }
    }

    public interface ILizard
    {
        public int Weight { get; set; }

        void Crawl();
    }

    public class Lizard : ILizard
    {
        public int Weight { get; set; }

        public void Crawl()
        {
            Console.WriteLine($"Crawling with weight {Weight}");
        }
    }

    public class Dragon : IBird, ILizard
    {
        Bird bird = new Bird();
        Lizard lizard = new Lizard();
        private int weight;

        public int Weight 
        { 
            get => weight;
            set
            {
                weight = value;
                bird.Weight = value;
                lizard.Weight = value;
            } 
        }

        public void Crawl()
        {
            lizard.Crawl();
        }

        public void Fly()
        {
            bird.Fly();
        }
    }
}
