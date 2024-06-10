using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.AccessControl;
using TextFile;
using static SeqInputFile.Program;

namespace SeqInputFile
{
    class Program
    {


        //okay enumerator on the sequential input file
        enum Status
        {
            norm, abnorm
        };


        private static void read(ref Status st, ref int e, TextFileReader file)
        {
            if(file.ReadInt(out e))
            {
                st = Status.norm;
            }
            else
            {
                st = Status.abnorm;
            }
        }

        private static string fileName()
        {
            return "C:\\Users\\alika\\source\\repos\\SeqInputFile\\input.txt";
        }


        private static double Average(TextFileReader file)
        {
            int sum = 0;
            int count = 0;
            Status status = Status.norm;
            int e = 0;

            read(ref status, ref e, file);

            while(e >= 0 && status == Status.norm)
            {
                sum += e;
                count++;
                read(ref status, ref e, file);
            }
            return sum / count;


        }


        private static double AvgAfterFreezing(TextFileReader file)
        {

            double sum = 0;
            int count = 0;
            Status status = Status.norm;
            int e = 0;
            read(ref status, ref e, file);
            while(e >=0 && status == Status.norm)
            {
                read(ref status, ref e, file);
            }

            read(ref status, ref e, file);// in this statement the ref e outputs the middle number which is less than zero: do not read it.
            while(status != Status.abnorm)
            {
                sum += e;
                count++;
                read(ref status, ref e, file);
            }
            return sum / count; 

        }

        private static Tuple<double,double> AvgBeforeAndAfter(TextFileReader x)
        {
            double sum1 = 0;
            int count1 = 0;
            int e1 = 0;
            Status st1 = Status.norm;

            read(ref st1, ref e1, x);
            while(e1 >= 0)
            {
                sum1 += e1;
                count1++;
                read(ref st1, ref e1, x);
            }

            sum1 += e1;
            count1++;

            double sum2 = e1;
            int count2 = 1;
           // Status st2 = Status.norm;
            int e2 = 0;
            read(ref st1, ref e2, x);
            while( st1 != Status.abnorm)
            {
                sum2 += e2;
                count2++;
                read(ref st1, ref e2, x);
            }

            double item1 = sum1/count1;
            double item2 = sum2/count2;
            Tuple<double, double> result = new Tuple<double, double>(item1, item2);
            return result;

            
        }


        private static void Execute(int n, TextFileReader f)
        {
            switch(n)
            {
                case 1:
                    Console.WriteLine(Average(f).ToString());
                    break;

                case 2:
                    Console.WriteLine(AvgAfterFreezing(f).ToString());
                    break;
                case 3:
                    Tuple<double, double> tup = AvgBeforeAndAfter(f);
                    Console.WriteLine($"{tup.Item1},{tup.Item2}");
                    break;



            }
        }


        private static void Menu()
        {
            Console.WriteLine("\n0. Exit\n");
            Console.WriteLine("1. Avg before first freezing point\n");
            Console.WriteLine("2. Avg after firsts freezing point\n");
            Console.WriteLine("3. Avg bef and aft including the freezing point\n");
            Console.WriteLine("Choose:b ");
        }



        static void Main(string[] args)
        {
            int menuItem;
            do
            {
                Menu();
                menuItem = int.Parse(Console.ReadLine()!);
                if (menuItem > 0 && menuItem < 4)
                {
                    try
                    {
                        TextFileReader file = new(fileName());
                        Execute(menuItem, file);
                    }
                    catch
                    {
                        Console.WriteLine("Wrong file name!");
                    }
                }
            } while (menuItem != 0);
        }


































    }
}
