using System;

using TextFile;

namespace CircleAndPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {

                Console.WriteLine("Enter file name: ");
                string filePath = Console.ReadLine();
                TextFileReader reader = new TextFileReader(filePath);

                reader.ReadDouble(out double a);
                reader.ReadDouble(out double b);
                reader.ReadDouble(out double c);

                Point center = new Point(a, b);
                Circle k = new Circle(center, c);


                reader.ReadInt(out int d);
                Point[] x = new Point[d];

                for (int i = 0; i < d; i++)
                {
                    reader.ReadDouble(out a);
                    reader.ReadDouble(out b);
                    x[i] = new Point(a, b);
                }

                int count = 0;

                foreach (Point p in x)
                {
                    if (k.Contains(p)) { count++; }
                }

                Console.WriteLine($"There are total {count} points inside the circle");
                Console.ReadLine();



            }
            catch(Circle.WrongRadiusException) { Console.WriteLine("Wrong Radius!"); }
            catch(System.IO.FileNotFoundException) { Console.WriteLine("File not found"); }


        }
    }
}
