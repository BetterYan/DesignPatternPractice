using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class BankAccount
    {
        private int balance;
        private int overdraftLimit = -500;

        public void Deposit(int amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited {amount}, balance is now {balance}");
        }

        public bool Withdraw(int amount)
        {
            if (balance - amount >= overdraftLimit)
            {
                balance -= amount;
                Console.WriteLine($"Withdraw {amount}, balance is now {balance}");
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }
}