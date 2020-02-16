using System;
using System.Collections.Generic;

namespace OpenClose
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var products = new List<Product>();
            products.Add(new Product("A", Color.Blue, Size.Large));
            products.Add(new Product("B", Color.Green, Size.Medium));
            products.Add(new Product("C", Color.Red, Size.Large));
            products.Add(new Product("D", Color.Blue, Size.Small));
            products.Add(new Product("E", Color.Green, Size.Yuge));

            var filter = new BetterFilter<Product>();
            Print(filter.Filter(products, new ColorSpecification(Color.Green) & new SizeSpecification(Size.Medium)));
            Console.WriteLine("------");
            Print(filter.Filter(products, new ColorSpecification(Color.Green).Add(new SizeSpecification(Size.Medium))));
        }

        private static void Print(IEnumerable<Product> products)
        {
            foreach (var p in products)
            {
                Console.WriteLine(p.Name);
            }
        }
    }
}