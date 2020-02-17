using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Adapter
{
    // Step1: We create an adapter here.
    public partial class LineToPointAdapter : Collection<Point>
    {
        public LineToPointAdapter(Line line)
        {
            var left = Math.Min(line.Start.X, line.End.X);
            var right = Math.Max(line.Start.X, line.End.X);
            var top = Math.Min(line.Start.Y, line.End.Y);
            var bottom = Math.Max(line.Start.Y, line.End.Y);

            for (int x = left; x <= right; x++)
            {
                for (int y = top; y <= bottom; y++)
                {
                    Add(new Point(x, y));
                }
            }
        }
    }

    // Step2: We can use the adapter to draw
    public static partial class Test
    {
        public static void Execute()
        {
            var rect = new VectorRectangle(10, 4, 15, 5);
            foreach (var line in rect)
            {
                var adapter = new LineToPointAdapter(line);
                adapter.ToList().ForEach(Draw.DrawPoint);
            }
        }
    }
}