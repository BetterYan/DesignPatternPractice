using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class BankAccount
    {
        private int balance;
        private List<Memento> changes = new List<Memento>();
        private int current;

        public BankAccount(int balance)
        {
            this.balance = balance;
            changes.Add(new Memento(balance));
        }

        public Memento Deposit(int amount)
        {
            balance += amount;
            var m = new Memento(balance);
            changes.Add(m);
            current++;
            return m;
        }

        public void Restore(Memento m)
        {
            if (m != null)
            {
                balance = m.Balance;
                changes.Add(m);
                current = changes.Count - 1;
            }
        }

        public Memento Undo()
        {
            if (current > 0)
            {
                var m = changes[--current];
                balance = m.Balance;
                return m;
            }
            return null;
        }

        public Memento Redo()
        {
            if (current + 1 < changes.Count)
            {
                var m = changes[++current];
                balance = m.Balance;
                return m;
            }
            return null;
        }

        public override string ToString()
        {
            return balance.ToString();
        }
    }

    public class Memento
    {
        public Memento(int balance)
        {
            Balance = balance;
        }

        public int Balance { get; }
    }

    public static class Test
    {
        public static void Execute()
        {
            var ba = new BankAccount(100);
            var m1 = ba.Deposit(50);
            var m2 = ba.Deposit(25);
            Console.WriteLine(ba);
            ba.Restore(m1);
            Console.WriteLine(ba);
            ba.Restore(m2);
            Console.WriteLine(ba);

            Console.WriteLine("-----------");
            ba.Deposit(50);
            ba.Deposit(25);
            Console.WriteLine(ba);
            ba.Undo();
            Console.WriteLine(ba);
            ba.Redo();
            Console.WriteLine(ba);
        }
    }
}