using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public interface IUndo
    {
        void Undo();
    }

    public partial class BankAccountCommand : IUndo
    {
        public void Undo()
        {
            if (!succeeded)
            {
                return;
            }
            switch (action)
            {
                case Action.Deposit:
                    account.Withdraw(amount);
                    break;

                case Action.Withdraw:
                    account.Deposit(amount);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public static partial class Test
    {
        public static void WithUndo()
        {
            var ba = new BankAccount();
            Console.WriteLine(ba);
            var cmd = new BankAccountCommand(ba, BankAccountCommand.Action.Deposit, 100);
            cmd.Call();
            Console.WriteLine(ba);
            cmd.Undo();
            Console.WriteLine(ba);
        }
    }
}