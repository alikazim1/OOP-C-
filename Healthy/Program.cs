using System;
using TextFile;
namespace Healthy
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                InFile x = new("C:\\Users\\alika\\source\\repos\\Healthy\\input.txt");
                while (x.Read(out InFile.player e))
                {
                    if (e.below)
                    {
                        Console.WriteLine(e.name);
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("Could not open the textfile");
            }
            catch (InFile.EmptyRowException)
            {
                Console.WriteLine("Could not open the textfile");
            }
        }





    }
}