using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Factory
{
    public class InnerPoint
    {
        private double x, y;

        private InnerPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"x: {x}, y: {y}";
        }

        public class Factory
        {
            public static InnerPoint NewCartesianPoint(double x, double y)
            {
                return new InnerPoint(x, y);
            }

            public static InnerPoint NewPolarPoint(double rho, double theta)
            {
                return new InnerPoint(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }
}
