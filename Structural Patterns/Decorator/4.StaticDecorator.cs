using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.StaticDecorator
{
    //The use of Static Decorator in C# is very limited. Because c# doesn't support forwarding constructor.
    public abstract class Shape
    {
        public virtual string AsString() => string.Empty;
    }

    public sealed class Circle : Shape
    {
        private float radius;

        public Circle() : this(0)
        {
        }

        public Circle(float radius)
        {
            this.radius = radius;
        }

        public void Resize(float factor)
        {
            this.radius *= factor;
        }

        public override string AsString() => $"A circle of radius {radius}";
    }

    public class ColoredShape<T> : Shape
        where T : Shape, new()
    {
        private readonly string color;
        private readonly T shape = new T();//the T always have a default value.

        public ColoredShape() : this("black")
        {
        }

        public ColoredShape(string color)
        {
            this.color = color;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }

    public static class Test
    {
        public static void Execute()
        {
            var blueCircle = new ColoredShape<Circle>("blue");
        }
    }
}