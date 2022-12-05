using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Factory
{
    public class HotDrinkMachineOCP
    {
        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachineOCP()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory", string.Empty),
                        (IHotDrinkFactory) Activator.CreateInstance(t)
                        ));
                }
            }
        }

        public void GetAvailableDrinks()
        {
            Console.WriteLine("AVAILABLE DRINKS");
            for (int index = 0; index < factories.Count; index++)
            {
                Tuple<string, IHotDrinkFactory>? tuple = factories[index];
                Console.WriteLine($"{index}: {tuple.Item1}");
            }
        }

        public IHotDrink MakeDrink(int drinkNumber)
        {
            var factory = factories[drinkNumber];
            return factory.Item2.Prepare(100);
        }
    }
}
