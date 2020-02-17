using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories.Scenario
{
    //Step1: We want a point in Cartesian(X-Y) space
    public partial class Point
    {
        private double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    //Step2: We want the point which is from polar coordinates.
    public partial class Point
    {
        //We already have two double args ctor, so the implementation doesn't work
        //public Point(double r, double theta)
        //{
        //    x = r * Math.Cos(theta);
        //    y = r * Math.Sin(theta);
        //}
    }

    //Step3: We introduce another parameter
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    public partial class Point
    {
        //It's an ugly implementation
        public Point(double a, double b, CoordinateSystem c)
        {
            switch (c)
            {
                case CoordinateSystem.Polar:
                    this.x = a * Math.Cos(b);
                    this.y = b * Math.Sin(b);
                    break;

                case CoordinateSystem.Cartesian:
                    this.x = a;
                    this.y = b;
                    break;
            }
        }
    }
}