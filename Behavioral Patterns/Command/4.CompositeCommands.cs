using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public abstract class CompositeBankAccountCommand : List<BankAccountCommand>, ICommand, IUndo
    {
        public virtual void Call()
        {
            var ok = true;
            foreach (var cmd in this)
            {
                if (ok)
                {
                    cmd.Call();
                    ok = cmd.succeeded;
                }
                else
                {
                    cmd.succeeded = false;
                }
            }
        }

        public virtual void Undo()
        {
            foreach (var cmd in ((IEnumerable<BankAccountCommand>)this).Reverse())
            {
                cmd.Undo();
            }
        }
    }

    public class MoneyTransferCommand : CompositeBankAccountCommand
    {
        public MoneyTransferCommand(BankAccount from, BankAccount to, int amount)
        {
            AddRange(new[] {
                new BankAccountCommand(from,BankAccountCommand.Action.Withdraw,amount),
                new BankAccountCommand(to,BankAccountCommand.Action.Deposit,amount)
                });
        }
    }
}