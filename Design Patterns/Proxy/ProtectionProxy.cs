using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Proxy
{
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car is beeing driven");
        }
    }

    public class Driver
    {
        public int Age { get; set; }

        public Driver(int age)
        {
            Age = age;
        }
    }

    public class Creature
    {
        //In case of public Property<int> Agility calling Agility.10 fom higher level, it would cause constuctor call instead of assigning value;
        private Property<int> agility = new();

        public int Agility
        {
            get => agility.Value;
            set => agility.Value = value;
        }
    }

    public class CarProxy : ICar
    {
        private Driver driver;
        private Car car = new Car();

        public CarProxy(Driver driver)
        {
            this.driver = driver;
        }

        public void Drive()
        {
            if (driver.Age >= 16)
                car.Drive();
            else
            {
                Console.WriteLine("too Young");
            }
        }   
    }
}
