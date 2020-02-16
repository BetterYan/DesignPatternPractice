using System.Collections.Generic;

namespace OpenClose
{
    public enum Color
    {
        Red,
        Green,
        Blue
    }

    public enum Size
    {
        Small,
        Medium,
        Large,
        Yuge
    }

    public class Product
    {
        public string Name;
        public Color color;
        public Size size;

        public Product(string name, Color color, Size size)
        {
            this.Name = name;
            this.color = color;
            this.size = size;
        }
    }

    // Step1: boss needs a function which can filter by color
    public partial class ProductFilter
    {
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
            foreach (var p in products)
            {
                if (p.color == color)
                {
                    yield return p;
                }
            }
        }
    }

    // Step2: boss needs a function which can filter by size
    public partial class ProductFilter
    {
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            foreach (var p in products)
            {
                if (p.size == size)
                {
                    yield return p;
                }
            }
        }
    }

    // Step3: boss needs a function which can filter by color and size
    public partial class ProductFilter
    {
        //We feel bad here. This is also a very common scenario in real world.
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Color color, Size size)
        {
            foreach (var p in products)
            {
                if (p.size == size && p.color == color)
                {
                    yield return p;
                }
            }
        }
    }

    // Step4:
    // We want to make it open for filter specification extensions, but close for product filter
    // We conceptually separate our filtering process into two parts: a filter and a specification
    public abstract partial class ISpecification<T>
    {
        // [2020-02-16] interface doesn't support static operator now.
        public abstract bool IsSatisfied(T item);
    }

    public interface IFilter<T>
    {
        public IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    // Step5: We can get a common filter base on step4
    public class BetterFilter<T> : IFilter<T>
    {
        public IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec)
        {
            foreach (var i in items)
            {
                if (spec.IsSatisfied(i))
                {
                    yield return i;
                }
            }
        }
    }

    // Step6: It's open to add new specification like below
    // Open to add size specification
    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;

        public SizeSpecification(Size size)
        {
            this.size = size;
        }

        public override bool IsSatisfied(Product p)
        {
            return p.size == this.size;
        }
    }

    // Open to add color specification
    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;

        public ColorSpecification(Color color)
        {
            this.color = color;
        }

        public override bool IsSatisfied(Product p)
        {
            return p.color == this.color;
        }
    }

    //Open to add "And" logic
    public class AndSpecification<T> : ISpecification<T>
    {
        private readonly ISpecification<T> first, second;

        public AndSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public override bool IsSatisfied(T item)
        {
            return first.IsSatisfied(item) && second.IsSatisfied(item);
        }
    }

    //salt function
    public abstract partial class ISpecification<T>
    {
        public static ISpecification<T> operator &(ISpecification<T> first, ISpecification<T> second)
        {
            return new AndSpecification<T>(first, second);
        }
    }

    //open to add extension method
    public static class Extension
    {
        public static ISpecification<T> Add<T>(this ISpecification<T> first, ISpecification<T> second)
        {
            return new AndSpecification<T>(first, second);
        }
    }
}