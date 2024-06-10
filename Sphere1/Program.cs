using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sphere1
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(1,1,1);
            Sphere g = new Sphere(new Point(3, 3, 3), 8);
            Point p2 = new Point(11,11,11);

            Console.WriteLine("p.Distance(p) = {0}", p.Distance(p));
            Console.WriteLine("p.Distance(p2) = {0}", p.Distance(p2));
            Console.WriteLine("g.Contains(p) = {0}", g.Contains(p));
            Console.WriteLine("g.Contains(p2) = {0}", g.Contains(p2));
            Console.ReadLine();




        }
    }
    

    class Point
    {
        private readonly double x, y, z;

        //const
        public Point(double a, double b, double c) {
        x=a; y=b; z=c;
        
        }

        //method Distance: Return the distance between two points.
        public double Distance(Point p)
        {
            return Math.Sqrt(Math.Pow(x-p.x,2) + Math.Pow(y-p.y,2) + Math.Pow(z-p.z,2));
        }

    }


    class Sphere
    {
        public class IllegalRadiusException : Exception { }

        private readonly Point center;
        private readonly double radius;

        //const: 
        public Sphere(Point c, double r) { 
            
            center = c; radius = r;
        if(radius < 0.0)  throw new IllegalRadiusException();
        } 

        //contains: method
        public bool Contains(Point p)
        {
            return p.Distance(center) <= radius;
        }
        











    }
















}

