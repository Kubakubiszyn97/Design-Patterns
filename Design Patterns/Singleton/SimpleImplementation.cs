using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Singleton
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;

        private IDictionary<string, int> capitals;
        private SingletonDatabase()
        {
            Console.WriteLine("Initializing Database");

            capitals = File.ReadAllLines("Resources/Capitals.txt")
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                 );
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
