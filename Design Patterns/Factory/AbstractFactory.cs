using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Factory
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Tea");
        }
    }

    internal class Coffe : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("Coffe");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine("Preparing Tea");
            return new Tea();
        }
    }

    internal class CoffeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine("Preparing Coffe");
            return new Coffe();
        }
    }

    public class HotDrinkMachine
    {
        //THIS VIOLATES OPEN CLOSED PRINCIPLE
        public enum AvailableDrink
        {
            Coffe,
            Tea
        }

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories = new();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink availableDrink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IHotDrinkFactory)Activator.CreateInstance(
                    Type.GetType("Design_Patterns.Factory." + Enum.GetName(typeof(AvailableDrink), availableDrink) + "Factory")
                );

                factories.Add(availableDrink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }
}
