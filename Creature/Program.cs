using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Creature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextFileReader reader = new TextFileReader("C:\\Users\\alika\\source\\repos\\Creature\\TextFile1.txt");

            //populating creatures: 
            reader.ReadLine(out string line); int n = int.Parse(line);
            List<Creature> creatures = new List<Creature>();
            for (int i = 0; i < n; i++)
            {
                char[] separators = new char[] { ' ', '\t' };
                Creature creature = null;
                if(reader.ReadLine(out line))
                {
                    string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    char ch = char.Parse(tokens[0]);
                    string name  = tokens[1];
                    int p = int.Parse(tokens[2]);

                    switch (ch)
                    {
                        case 'G': creature = new Greenfinch(name,p); break;
                        case 'D': creature = new DuneBeetle(name, p); break;
                        case 'S': creature = new Squelchy(name, p); break;



                    }
                }
                creatures.Add(creature);
            }

            //Populating courts: 
            reader.ReadLine(out line); int m = int.Parse(line);
            List<IGround> courts = new List<IGround>();
            for(int j = 0; j < m; j++)
            {
                reader.ReadChar(out char c);
                switch(c)
                {
                    case 'g': courts.Add(Grass.Instance()); break;
                    case 's': courts.Add(Sand.Instance()); break;
                    case 'm': courts.Add(Marsh.Instance()); break;

                }
            }

            //competition
            try
            {
                for(int i = 0; i < n; ++i)
                {
                    creatures[i].Race(ref courts);
                    if (creatures[i].Alive()) Console.WriteLine(creatures[i].Name);
                    Console.ReadLine();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.ToString());
            }



        }
    }
}
