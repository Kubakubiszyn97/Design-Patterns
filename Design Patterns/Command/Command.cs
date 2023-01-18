using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Command
{
    public class BankAccount
    {
        private int balance;
        private int overdraftLimit = -500;

        public void Deposit(int amount)
        {
            balance += amount;
            Console.WriteLine($"Depisoted {amount}, balance is now {balance}");
        }

        public bool Withdraw(int amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
                Console.WriteLine($"withdrew {amount}, balance is now {balance}");
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"balance = {balance}";
        }
    }

    public interface ICommand
    {
        void Call();

        void Undo();
    }

    public class BankAccountCommand : ICommand
    {
        private BankAccount account;
        private int amount;
        private Action action;
        private bool succeded;
        
        public enum Action
        {
            Deposit, Withdraw
        }

        public BankAccountCommand(BankAccount account, int amount, Action action)
        {
            this.account = account;
            this.amount = amount;
            this.action = action;
        }

        public void Call()
        {
            switch (action)
            {
                case Action.Deposit:
                    account.Deposit(amount);
                    succeded = true;
                    break;
                case Action.Withdraw:
                    succeded = account.Withdraw(amount);
                    break;
            }
        }

        public void Undo()
        {
            if (!succeded) return;
            switch (action)
            {
                case Action.Deposit:
                    account.Withdraw(amount);
                    break;
                case Action.Withdraw:
                    account.Deposit(amount);
                    break;
            }
        }
    }
}
