using System;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- the account numbers and balances of customers who have less than -1000 Euros ---\n\n");
            bool fileError = true;
            do
            {
                try
                {
                    //string fileName = "input.txt";
                    Console.WriteLine("Input file name:");
                    string fileName = Console.ReadLine();
                    Enor t = new Enor(fileName);
                    t.First();
                    while (!t.End())
                    {
                        if (t.Current().bal < -1000)
                        {
                            Console.WriteLine(t.Current());
                        }
                        t.Next();
                    }
                    fileError = false;
                    Console.ReadLine();
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.WriteLine("File not found!\n\n");
                }
            } while (fileError);

        }
    }
}