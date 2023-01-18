using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Command.Composite
{
    public interface ICommand
    {
        void Call();
        void Undo();
        bool Success { get; set; }
    }

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

    public class CompositeBankAccountCommand : List<BankAccountCommand>, ICommand
    {
        public CompositeBankAccountCommand()
        {
        }

        public CompositeBankAccountCommand(IEnumerable<BankAccountCommand> collection) : base(collection)
        {
        }

        public virtual bool Success
        {
            get { return this.All(cmd => cmd.Success); }
            set
            {
                foreach (var cmd in this)
                {
                    cmd.Success = value;
                }
            }
        }

        public virtual void Call()
        {
            ForEach(cmd => cmd.Call());
        }

        public virtual void Undo()
        {
            foreach (var cmd in ((IEnumerable<BankAccountCommand>) this).Reverse())
            {
                if (cmd.Success) cmd.Undo();
            }
        }
    }

    public class MoneyTransferCommand : CompositeBankAccountCommand
    {
        public MoneyTransferCommand(BankAccount from, BankAccount to, int amount)
        {
            AddRange(new[]
            {
                new BankAccountCommand(from, 100, Action.Withdraw),
                new BankAccountCommand(to, 100, Action.Deposit),
               
            });
        }

        public override void Call()
        {
            BankAccountCommand last = null;
            foreach (var cmd in this)
            {
                if (last == null || last.Success)
                {
                    cmd.Call();
                    last = cmd;
                }
                else
                {
                    cmd.Undo();
                    break;
                }
            }
        }
    }

    //Todo make it generic to work with previous example
    public class BankAccountCommand : ICommand
    {
        private BankAccount account;
        private int amount;
        private Action action;
        public bool Success { get; set; }

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
                    Success = true;
                    break;
                case Action.Withdraw:
                    Success = account.Withdraw(amount);
                    break;
            }
        }

        public void Undo()
        {
            if (!Success) return;
            switch (action)
            {
                case Action.Deposit:
                    account.Withdraw(amount);
                    break;
                case Action.Withdraw:
                    account.Deposit(amount);
                    break;
            }
        }}
    }
