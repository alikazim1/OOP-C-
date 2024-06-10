using System;
using System.Security.Cryptography.X509Certificates;
using TextFile;
namespace PointCircle
{
    class program
    {
        static void Main()
        {
            try
            {
                TextFileReader reader = new TextFileReader("C:\\Users\\alika\\source\\repos\\PointCircle\\input.txt");
                reader.ReadDouble(out double a); // a and b are center
                reader.ReadDouble(out double b);
                reader.ReadDouble(out double c); // c is radius

                Point p = new Point(a, b);
                Circle k = new Circle(p, c);

                reader.ReadInt(out int n);
                Point[] x = new Point[n];

                for (int i = 0; i < n; i++)
                {
                    reader.ReadDouble(out a);
                    reader.ReadDouble(out b);
                    x[i] = new Point(a, b);
                }

                int count = 0;
                foreach(Point e in  x)
                {
                    if(k.Contains(e)) count++;
                }

                Console.WriteLine($"There are {count} points inside of circle");
                Console.ReadLine();


            }
            catch (Circle.WrongRadiusException) { Console.WriteLine("Wrong radius."); }
            catch(System.IO.FileNotFoundException) { Console.WriteLine("File not found"); }


        }
        
    }
}