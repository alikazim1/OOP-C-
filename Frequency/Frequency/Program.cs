using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TextFile;
using System.Threading.Tasks;

namespace Frequency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filename = "C:\\Users\\alika\\source\\repos\\Frequency\\Frequency\\input25.txt";
                TextFileReader reader = new TextFileReader(filename);

                reader.ReadInt(out int m);

                Bag b = new Bag(m);
                while(reader.ReadInt(out int e))
                {
                    try
                    {
                        b.PutIn(e);
                    }
                    catch(Bag.IllegalElementException) {
                        Console.WriteLine($"The element must be in [0..{m}].");
                    }
                }
                Console.WriteLine($"The most frequent element: {b.MostFreq()}");
                Console.ReadLine();

            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("The input file doesnt exist.");
            }
            catch(Bag.NegativeSizeException)
            {
                Console.WriteLine("The upper limit cannot be negative");
            }
            catch(Bag.EmptyBagException)
            {
                Console.WriteLine("The bag is empty.");
            }
        }
    }
}
