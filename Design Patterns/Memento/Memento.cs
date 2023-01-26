using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Memento
{
    public class Memento
    {
        public int Balance { get; }

        public Memento(int balance)
        {
            Balance = balance;
        }
    }

    public class BankAccount
    {
        int balance;

        public BankAccount(int balance)
        {
            this.balance = balance;
        }

        public Memento Deposit(int amount)
        {
            balance += amount;
            return new Memento(balance);

        }

        public void Restore(Memento m)
        {
            balance = m.Balance;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }
}
