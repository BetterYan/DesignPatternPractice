using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.FunctionalCommand
{
    public class BankAccount
    {
        public int Balance;

        public static void Deposit(BankAccount account, int amount)
        {
            account.Balance += amount;
        }

        public static void Withdraw(BankAccount account, int amount)
        {
            if (account.Balance >= amount)
            {
                account.Balance -= amount;
            }
        }

        public override string ToString()
        {
            return Balance.ToString();
        }
    }

    public static class Test
    {
        public static void Execute()
        {
            var ba = new BankAccount();
            var commands = new List<Action>();
            commands.Add(() => BankAccount.Deposit(ba, 100));
            commands.Add(() => BankAccount.Withdraw(ba, 50));
            commands.ForEach(c => c());
            Console.WriteLine(ba);
        }
    }
}