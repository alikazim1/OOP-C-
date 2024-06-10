using System;
using System.Collections.Generic;
using System.IO;
using TextFile;
namespace SecondAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TextFileReader reader = new TextFileReader("C:\\Users\\alika\\source\\repos\\SecondAssignment\\input.txt");

            reader.ReadLine(out string line);

            int n = int.Parse(line);

            List<Animal> animals = new List<Animal>();

            for(int i = 0; i < n; i++)
            {
                if(reader.ReadLine(out line))
                {
                    string[] tokens = line.Split(new char[] {' ','\t'}, StringSplitOptions.RemoveEmptyEntries);
                    char ch = char.Parse(tokens[0]);
                    string name = tokens[1];
                    int p = int.Parse(tokens[2]);

                    switch(ch)
                    {
                        case 'F':
                            animals.Add(new Fish(name, p)); break;
                        case 'B':
                            animals.Add(new Bird(name, p)); break;
                        case 'D':
                            animals.Add(new Dog(name, p)); break;
                    }
                }
            }


            //  reading the moods:
            reader.ReadLine(out string moodsLine);
            IMood currentMood = null;

            foreach(char mood in moodsLine)
            {
                switch (mood)
                {
                    case 'g':
                        currentMood = new Good();
                        break;
                    case 'o':
                        currentMood = new Ordinary();
                        break;
                    case 'b':
                        currentMood = new Bad();
                        break;
                }



            }


            //finding the Animal(s) with the lowest exh:
            int minExh = int.MaxValue;
            List<String> LowestExhAnimals = new List<string>();


            //Min search: 
            
            foreach(var animal in animals)
            {
                if(animal.IsAlive() && animal.Exhilaration < minExh)
                {
                    minExh = animal.Exhilaration;
                    // clear the list of animals with the lowest exh level so far
                    LowestExhAnimals.Clear();
                    LowestExhAnimals.Add(animal.Name);
                }
                else if(animal.IsAlive() && animal.Exhilaration == minExh)
                {
                    LowestExhAnimals.Add(animal.Name);
                }
            }

            //output the results:
            if(LowestExhAnimals.Count > 0)
            {
                Console.WriteLine("Animal(s) with the lowest exhilaration level:");
                foreach(var name in LowestExhAnimals)
                {
                    Console.WriteLine(name);
                }
            }
            else
            {
                Console.WriteLine("No animals with exhilaration level greater than 0.");
            }

        }
    }
}
