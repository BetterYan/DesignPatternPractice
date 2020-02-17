using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Adapter
{
    // Adapter pattern:
    // We are given an interface, but we want a different one
    // and building an adapter over the interface is what gets us to where we want to be.

    // Step1: We have something at first
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            this.Start = start;
            this.End = end;
        }
    }

    public abstract class VectorObject : Collection<Line> { }

    public class VectorRectangle : VectorObject
    {
        public VectorRectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x, y), new Point(x + width, y)));
            Add(new Line(new Point(x + width, y), new Point(x + width, y + height)));
            Add(new Line(new Point(x + width, y + height), new Point(x, y + height)));
            Add(new Line(new Point(x, y + height), new Point(x, y)));
        }
    }

    // Step2: Boss needs an method can draw vector, but we only have the draw point method.
    public class Draw
    {
        public static void DrawPoint(Point p)
        {
            //draw the point
        }
    }
}