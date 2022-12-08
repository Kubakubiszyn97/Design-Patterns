using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Prototype
{
    public interface IDeepCopyable<T>
        where T : new()
    {
        void CopyTo(T target);

        public T DeepCopy()
        {
            T t = new T();
            CopyTo(t);
            return t;
        }
    }

    public class PrototypeAddress : IDeepCopyable<PrototypeAddress>
    {
        public string StreetName;
        public int HouseNumber;

        public PrototypeAddress()
        {
        }

        public PrototypeAddress(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public void CopyTo(PrototypeAddress target)
        {
            target.StreetName = StreetName;
            target.HouseNumber = HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }
    }

    public class PrototypePerson : IDeepCopyable<PrototypePerson>
    {
        public string Name;
        public Address Address;

        public PrototypePerson()
        {

        }

        public PrototypePerson(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public void CopyTo(PrototypePerson target)
        {
            target.Name = Name;
            target.Address = Address.DeepCopy();
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Address)}: {Address}";
        }
    }

    public class PrototypeEmployee : PrototypePerson, IDeepCopyable<PrototypeEmployee>
    {
        public int Salary;

        public PrototypeEmployee()
        {

        }

        public PrototypeEmployee(string name, Address address, int salary) : base(name, address)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
        }

        public void CopyTo(PrototypeEmployee target)
        {
            base.CopyTo(target);
            target.Salary = Salary;
        }
    }
}
