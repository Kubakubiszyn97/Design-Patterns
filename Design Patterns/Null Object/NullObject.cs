using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Null_Object
{
    public interface ILog
    {
        void Info(string msg);
        void Warn(string msg);
    }

    public class ConsoleLog : ILog
    {
        public void Info(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Warn(string msg)
        {
            Console.WriteLine("WARNING!" + msg);
        }
    }

    public class NullLog : ILog
    {
        public NullLog()
        {
        }

        public void Info(string msg)
        {
        }

        public void Warn(string msg)
        {
        }
    }

    public class BankAccount
    {
        private ILog log;
        private int balance;

        public BankAccount(ILog log)
        {
            this.log = log;
        }

        public void Desposit(int amount)
        {
            balance += amount;
            log.Info($"Deposit {amount}, balance is now {balance}");
        }
    }
}
