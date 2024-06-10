using System.IO;
using System.Numerics;
using System.Collections.Generic;
using System;
using TextFile;

namespace HihestValley
{
    internal class Program
    {
        private bool fileRead(out List<int> vec, String fileName)
        {
            vec = new List<int>();
            
            try
            {
                TextFileReader f = new TextFileReader(fileName);
                while (f.ReadInt(out int e))
                {
                    vec.Add(e);
                }
                return true;


            }
            catch
            {
                return false;
            }
        }


        private static bool condMaxSearch(List<int> x, out int max, out int ind)
        {

            max = 0;
            bool l = false;
            ind = 0;
            for (int i = 1; i < x.Count - 1; i++)
            {
                if (l && x[i] <= x[i - 1] && x[i] <= x[i + 1])
                {
                    if (x[i] > max)
                    {
                        max = x[i];
                        ind = i;
                    }

                }
                else if (!l && x[i] <= x[i - 1] && x[i] <= x[i + 1])
                {
                    max = x[i];
                    ind = i;
                    l = true;
                }


            }
            return l;



        }

        



        static void Main(string[] args)
        {
            Console.Write("File name: ");
            string fileName = Console.ReadLine();
            List<int> vec = new List<int>();
            if(fileRead(out vec, fileName))
            {
                int max, ind;
                if(condMaxSearch(vec, out max, out ind))
                {
                    Console.WriteLine($"Highest valley is {max} high.");

                }
                else
                {
                    Console.WriteLine("There is no highest valley");

                }
                
            }
            else { Console.WriteLine("wrong file name"); }
        }


    }


}