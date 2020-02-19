using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    //step1: we have something at first
    public interface ILog
    {
        void Info(string msg);

        void Warn(string msg);
    }

    public class BankAccount
    {
        private ILog log;
        private int balance;

        public BankAccount(ILog log)
        {
            this.log = log;
            //use proxy approach;
            this.log = new OptionalLog(log);
        }

        public void Deposit(int amount)
        {
            balance += amount;
            log.Info($"Deposit {amount}, balance is now {balance}");
        }
    }

    public class ConsoleLog : ILog
    {
        public void Info(string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        public void Warn(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}