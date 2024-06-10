using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleAndPoint
{
    internal class Circle
    {
        private readonly Point center;
        private readonly double radius;

        public class WrongRadiusException : Exception { }

        public Circle(Point c, double r)
        {
            center = c;
            radius = r;
        }

        public bool Contains(Point p)
        {
            return (center.Distance(p) <= radius);
        }



    }
}
