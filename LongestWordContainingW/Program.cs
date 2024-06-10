using System;
using TextFile;
namespace LongestWordContainingW
{
    class Program
    {
        public static void Main(string[] args)
        {
            int max = 0;
            String maxWord = "";
            WordEnum WE = new WordEnum("C:\\Users\\alika\\source\\repos\\LongestWordContainingW\\input.txt");

            try
            {
                for (WE.First(); !WE.End(); WE.Next())
                {
                    // Console.WriteLine(maxWord = WE.Current().word);
                    if (WE.Current().containsW && max < WE.Current().length)
                    {
                        max = WE.Current().length;
                        maxWord = WE.Current().word;
                    }
                }

                Console.WriteLine(maxWord);

            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("File was not found");
            }
        }
    }
}
