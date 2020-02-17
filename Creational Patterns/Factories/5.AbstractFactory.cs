using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.AbstractFactory
{
    //This comes from old complicated system.
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This tea tastes good.");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This coffee tastes good.");
        }
    }

    internal interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine("I am a good coffee maker.");
            return new Coffee();
        }
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine("I am a good tea maker.");
            return new Tea();
        }
    }

    // we can also have a drink factoy with string args
    public class DrinkFactory
    {
        public static IHotDrink MakeDrink(string type)
        {
            switch (type.ToLower())
            {
                case "tea":
                    return new TeaFactory().Prepare(200);

                case "coffee":
                    return new CoffeeFactory().Prepare(200);

                default:
                    throw new ArgumentException(nameof(type));
            }
        }
    }
}