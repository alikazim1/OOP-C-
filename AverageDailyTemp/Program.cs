using System;
using System.IO;
using TextFile;

namespace AverageDailyTemp
{
    class Program
    {
        enum Status
        {
            norm, abnorm
        };


        private static void read(ref Status st, ref int e, ref TextFileReader x)
        {
            if(x.ReadInt(out e))
            {
                st = Status.norm;
            }
            else
            {
                st = Status.abnorm; 
            }
        }



        private static void MenuPrint()
        {
            System.Console.WriteLine("\n 0. Exit \n");
            Console.WriteLine("1. Average Temperature before the first freezing point\n");
            Console.WriteLine("2. Average Temperature after the fist freezing point\n");
            Console.WriteLine("3. Average before and after (including) the first freezing point\n");
            Console.WriteLine("Choose: ");


        }

        private static void Run(int n, TextFileReader f)
        {
            switch(n)
            {
                case 1:
                    Console.WriteLine(Average(f).ToString());
                    break;
                case 2:
                    Console.WriteLine(AverageAfter(f).ToString());
                    break;
                case 3:
                    Tuple<double, double> result = AvgBeforeAndAfterFreezing(f);
                    Console.WriteLine($"{result.Item1} {result.Item2}");
                    break;
            }
        }


        private static double Average(TextFileReader f)
        {
            int sum = 0;
            Status st = Status.norm;
            int c = 0;
            int e = 0;
            read(ref st, ref e, ref f);
            while(st == Status.norm && e >= 0)
            {
                sum += e;
                c++;
                read(ref st, ref e, ref f);


            }
            return sum / c;
        }


        private static double AverageAfter(TextFileReader x)
        {
            Status st = Status.norm;
            int e = 0;
            read(ref st, ref e, ref x);
            while( e >= 0 && st == Status.norm)
            {
                read(ref st, ref e, ref x);


            }
            double s = 0;
            int c = 0;
            read(ref st, ref e, ref x);
            while(st== Status.norm)
            {
                s += e;
                ++c;
                read(ref st, ref e, ref x);


            }
            return s / c;
        }




        private static Tuple<double, double> AvgBeforeAndAfterFreezing(TextFileReader x)
        {
            Status st1 = Status.norm;
            int e1 = 0;
            int sum1 = 0;
            int c1 = 0;
            read(ref st1, ref e1, ref x);
            while(st1 == Status.norm && e1 >= 0)
            {
                sum1 += e1;
                c1++;
                read(ref st1, ref e1, ref x);

            }

            double result1 = sum1 / c1;

            double sum2 = 0;
            double c2 = 0;
            while(st1 == Status.norm)
            {
                sum2 += e1;
                c2++;
                read(ref st1, ref e1, ref x);
            }

            double result2 = sum2 / c2;

            return new Tuple<double, double>(result1, result2);
        }

        public static void Main()
        {
            int n;

            do
            {
                MenuPrint();
                n = int.Parse(Console.ReadLine());
                if (n >= 0 && n < 4)
                {
                    TextFileReader filePath = new TextFileReader("C:\\Users\\alika\\source\\repos\\AverageDailyTemp\\input.txt");
                    try
                    {
                        Run(n, filePath);

                    }
                    catch
                    {
                        Console.WriteLine("File not found");
                    }





                }
                else
                {
                    Console.WriteLine("n should be between 0-4");
                }
            }
            while (n != 0);
           
            


        }







    }
}