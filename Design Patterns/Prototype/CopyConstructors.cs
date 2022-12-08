using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Prototype
{
    public class Person : IPrototype<Person>
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            this.Names = names;
            this.Address = address;
        }

        public Person(Person other)
        {
            Names = other.Names.ToArray();
            Address = new Address(other.Address);
        }

        public override string? ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)} : {Address}";
        }

        public Person DeepCopy()
        {
            return new Person(Names.ToArray(), Address.DeepCopy());
        }
    }

    public class Address : IPrototype<Address>
    {
        public string Street;
        public int HouseNumber;

        public Address(string street, int houseNumber)
        {
            this.Street = street;
            this.HouseNumber = houseNumber;
        }
        
        public Address(Address other)
        {
            this.Street = other.Street;
            this.HouseNumber = other.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(Street)}: {Street}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public Address DeepCopy()
        {
            return new Address(Street, HouseNumber);
        }
    }
}

