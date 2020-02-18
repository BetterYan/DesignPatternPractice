using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.DynamicDecoratorComposition
{
    //decorate a decorator with another decorator
    public abstract class Shape
    {
        public virtual string AsString() => string.Empty;
    }

    //sealed class. It's a situation that we can't inherit from the circle.
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

    public class ColoredShape : Shape
    {
        private readonly Shape shape;
        private readonly string color;

        public ColoredShape(Shape shape, string color)
        {
            this.shape = shape;
            this.color = color;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has the color {color}";
        }
    }

    public class TransparentShape : Shape
    {
        private readonly Shape shape;
        private readonly float transparency;

        public TransparentShape(Shape shape, float transparency)
        {
            this.shape = shape;
            this.transparency = transparency;
        }

        public override string AsString()
        {
            return $"{shape.AsString()} has {transparency * 100.0f}% transparency.";
        }
    }

    public static class Test
    {
        public static void Execute()
        {
            var circle = new Circle(2);
            Console.WriteLine(circle.AsString());
            var redSquare = new ColoredShape(circle, "red");
            Console.WriteLine(redSquare.AsString());
            var redHalfTranparentSquare = new TransparentShape(redSquare, 0.5f);
            Console.WriteLine(redHalfTranparentSquare.AsString());
        }
    }
}