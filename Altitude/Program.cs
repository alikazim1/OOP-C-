using System;
using TextFile;
namespace Altitude
{
    class Program
    {

        public static void Main(string[] args)
        {

            TextFileReader f = new TextFileReader("C:\\Users\\alika\\source\\repos\\Altitude\\input.txt");


            //vars
            int first, second;
            int c = 0;
            int d = 0;
            bool l = f.ReadInt(out first);
            l = f.ReadInt(out second);

            Console.WriteLine("hi");

            for (; l; first = second, l = f.ReadInt(out second))
            {
                if(first < second) { c++; }
                d++;
                //Console.WriteLine("bye");

            }
            

            Console.WriteLine($"The Percentage of elevation during the whole journey: {System.Math.Round(c*100.0/d,2)}");






        }


    }
}