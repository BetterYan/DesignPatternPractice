using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitution
{
    // Step1: We have something a t first
    public partial class Rectangle
    {
        // the setter is problematic
        public int Width { get; set; }

        public int Height { get; set; }

        public Rectangle()
        {
        }

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Area => this.Width * this.Height;
    }

    // Step2: We want to create a new thing, and we think it's a child case of Rectangle.
    public class Square : Rectangle
    {
        public Square(int side)
        {
            this.Width = this.Height = side;
        }

        // the setter is problematic
        public new int Width
        {
            set { base.Width = base.Height = value; }
        }

        public new int Height
        {
            set { base.Width = base.Height = value; }
        }
    }

    //Step3: It brokes the LSP rule
    public static class Test
    {
        public static void TestCondition1(Rectangle r)
        {
            Console.WriteLine("This is the condition with setter");
            r.Height = 10;
            var expect = r.Height * r.Width;
            Console.WriteLine($"Expect area of {expect}, got {r.Area}");
        }

        public static void TestCondition2(Rectangle r)
        {
            Console.WriteLine("This is the condition without setter");
            if (r is Square)
            {
                r.SetSize(10, 10);
            }
            else
            {
                r.SetSize(2, 10);
            }
            var expect = r.Height * r.Width;
            Console.WriteLine($"Expect area of {expect}, got {r.Area}");
        }

        public static void TestWithRectangle()
        {
            Console.WriteLine("Test With Parent");
            var rectangle = new Rectangle(2, 3);
            TestCondition1(rectangle);
            TestCondition2(rectangle);
        }

        // The behaviors inside the Suqare class break its operation. It's
        public static void TestWithSquare()
        {
            Console.WriteLine("Test With Child");
            var square = new Square(5);
            TestCondition1(square);
            TestCondition2(square);
        }
    }

    //Step4: We should avoid the situation where setting the height via a setter also stealthily changes the width
    public partial class Rectangle
    {
        public void SetSize(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}