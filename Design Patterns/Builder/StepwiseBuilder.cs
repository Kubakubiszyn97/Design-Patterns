using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Builder
{
    public enum CarType
    {
        Sedan,
        Crossover
    }

    public class Car
    {
        public CarType Type;
        public int WheelSize;

        public override string ToString()
        {
            return $"{nameof(Type)}: {Type}, {nameof(WheelSize)}: {WheelSize}";
        }
    }

    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }

    public interface ISpecifyWheelSize
    {
        IBuildCar WithWheels(int size);
    }

    public interface IBuildCar
    {
        public Car Build();
    }

    public class CarBuilder
    {
        private class Impl :
            ISpecifyCarType,
            ISpecifyWheelSize,
            IBuildCar
        {
            private Car car = new Car();

            public Car Build()
            {
                return car;
            }

            public ISpecifyWheelSize OfType(CarType type)
            {
                car.Type = type;
                return this;
            }

            public IBuildCar WithWheels(int size)
            {
                switch (car.Type)
                {
                    case CarType.Sedan when size < 15 || size > 17:
                    case CarType.Crossover when size < 17 || size > 20:
                        throw new ArgumentException($"Wrong size of wheel for {car.Type}");
                }
                
                car.WheelSize = size;
                return this;
            }
        }

        public static ISpecifyCarType Create()
        {
            return new Impl();
        }
    }
}
