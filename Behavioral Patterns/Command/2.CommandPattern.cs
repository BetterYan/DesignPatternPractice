using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public interface ICommand
    {
        void Call();
    }

    public partial class BankAccountCommand : ICommand
    {
        private BankAccount account;

        public enum Action
        {
            Deposit, Withdraw
        }

        private Action action;
        private int amount;

        public BankAccountCommand(BankAccount account, Action action, int amount)
        {
            this.account = account;
            this.action = action;
            this.amount = amount;
        }

        public bool succeeded;

        public void Call()
        {
            switch (action)
            {
                case Action.Deposit:
                    account.Deposit(amount);
                    succeeded = true;
                    break;

                case Action.Withdraw:
                    succeeded = account.Withdraw(amount);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public static partial class Test
    {
        public static void WithCommandPattern()
        {
            var ba = new BankAccount();
            Console.WriteLine(ba);
            var cmd = new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100);
            cmd.Call();
            Console.WriteLine(ba);
        }
    }
}