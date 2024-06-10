using Fish;
using System;
using TextFile;

namespace Fish
{
    class Program
    {
        static void Main()
        {
            Club club = new();
            try
            {
                TextFileReader reader = new("C:\\Users\\alika\\source\\repos\\Fish\\contests.txt");

                reader.ReadLine(out string line);
                char[] separators = new char[] { ' ', '\t' };
                string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tokens.Length; ++i)
                {
                    club.Join(tokens[i]);
                }

                while (reader.ReadString(out string filename))
                {
                    TextFileReader reader1 = new(filename);

                    reader1.ReadLine(out string contestname);

                    Contest contest = club.Organize(contestname);

                    while (reader1.ReadString(out string anglerName))
                    {
                        reader1.ReadString(out string fishname);
                        reader1.ReadDouble(out double weight);

                        Angler? angler = club.Member(anglerName);
                        if (null == angler)
                        {
                            Console.WriteLine($"{anglerName} would compete but is not a member.");
                        }
                        else
                        {
                            contest.Register(anglerName);

                            if (fishname == "bream") angler.Catch(Bream.Instance(), weight, contest);
                            else if (fishname == "carp") angler.Catch(Carp.Instance(), weight, contest);
                            else if (fishname == "catfish") angler.Catch(Catfish.Instance(), weight, contest);
                        }
                    }
                }

                if (club.Best(out Contest? contest1)) Console.WriteLine($"Best contest is: {contest1!.Location}");
                else Console.WriteLine("No such competitiion where everybody has caught catfish.");
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
