using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Proxy
{
    public class Property<T> where T : new()
    {
        private T value;

        public T Value 
        {
            get => value;
            set
            {
                if (Equals(this.value, value)) return;
                Console.WriteLine($"Assigning value to {value}");
                this.value = value;
            }
        }

        public Property() : this(Activator.CreateInstance<T>())
        {
        }

        public Property(T value)
        {
            this.value = value;
        }

        public static implicit operator T(Property<T> property)
        {
            return property.value; //int n = p_int;
        }

        public static implicit operator Property<T>(T value)
        {
            return new Property<T>(value); //Property<int> p = 123;
        }
    }
}
