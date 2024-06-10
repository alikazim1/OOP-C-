using System;
namespace PointCircle
{
  public  class Point
    {
        private readonly double x;
        private readonly double y; // private fields of class

        //constr
        public Point(double a, double b)
        {
            x = a;
            y = b;
        }

        //Distance between two points: 

        public double Distance(Point p)
        {
            return Math.Sqrt(Math.Pow(x - p.x, 2)+Math.Pow(y - p.y, 2));
        }


    }


}
