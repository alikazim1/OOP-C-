using BagTuple;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using static BagTuple.Bag;
namespace BagTuple
{
    class Program
    {
        public static void Main(string[] args)
        {



            int n = 7;
            Bag bag = new Bag();

            do
            {
                try
                {
                    

                    Console.WriteLine("╔═════════════════════════════╗");
                    Console.WriteLine("║           Bag Menu          ║");
                    Console.WriteLine("╠═════════════════════════════╣");
                    Console.WriteLine("║ 0. Exit                     ║");
                    Console.WriteLine("║ 1. Insert                   ║");
                    Console.WriteLine("║ 2. Remove                   ║");
                    Console.WriteLine("║ 3. Get Frequency            ║");
                    Console.WriteLine("║ 4. Single Element Occurrence║");
                    Console.WriteLine("║ 5. Print                    ║");
                    Console.WriteLine("╚═════════════════════════════╝");

                    


                    
                    try
                    {
                        n = int.Parse(Console.ReadLine());
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Enter only integers");
                    }




                    switch (n)
                    {
                        case 0:
                            break;
                        case 1:
                            Console.WriteLine("Enter Element:");
                            int element = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Frequency:");
                            int frequency = int.Parse(Console.ReadLine());
                            Tuple<int, int> tup = new Tuple<int, int>(element, frequency);
                            bag.add(tup);
                            bag.print();
                            break;
                        case 2:
                            Console.WriteLine("Enter the Element: ");
                            int elem = int.Parse(Console.ReadLine());
                            bag.remove(elem);
                            bag.print();
                            break;
                        case 3:
                            Console.WriteLine("Enter the Element: ");
                            int element2 = int.Parse(Console.ReadLine());
                            int f = bag.freq(element2);
                            Console.WriteLine($"The frequency of {element2} is {f}");
                            break;
                        case 4:
                            int freq = bag.singleFreq();
                            Console.WriteLine($"{freq}");
                            break;
                        case 5:
                            bag.print();
                            break;
                        default:
                            Console.WriteLine("Enter from 0-5");
                            break;

                    }
                }
                catch (ElementNotInBag) { Console.WriteLine("Element is not in the bag"); }
                catch (BagEmptyException) { Console.WriteLine("The bag is empty"); }
                catch (System.FormatException) { Console.WriteLine("Input is not in correct format"); }

            }
            while (n != 0);



            Console.WriteLine("Good bye");
            

        }
    }
}
