using System;
namespace NumberOfOccurances
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Occurances by Ali Kazim");

            try
            {
                string file = "C:\\Users\\alika\\source\\repos\\NumberOfOccurences\\input.txt";
                Infile t = new Infile(file);
                for (t.First(); !t.End(); t.Next())
                {
                    Console.WriteLine($"{t.Current().number},{t.Current().count}");
                }



            }
            catch(System.IO.FileNotFoundException) { Console.WriteLine("File not found"); }
        }
    }
}