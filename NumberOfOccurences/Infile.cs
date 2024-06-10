using System;
using System.Runtime.ExceptionServices;
using TextFile;
namespace NumberOfOccurances
{
    public class Infile
    {
        //enum:
        public enum Status { norm, abnorm };

        //fields:
        public int e;
        public Status status;
        public bool end;
        public TextFileReader reader;
        public Occurance occur = new Occurance();

        //const:
        public Infile(string file)
        {
            reader = new TextFileReader(file);
        }

        //Read, First, Next, Current, End
        public void First()
        {
            Read();
            Next();
        }

        public void Read()
        {
            status = reader.ReadInt(out e) ? Status.norm : Status.abnorm;
        }

        public void Next()
        {
            if(status == Status.abnorm)
            {
                end = true;
            }
            else
            {
                end = false;
                occur.number = e;
                occur.count = 0;
                while(occur.number == e && status == Status.norm)
                {
                    occur.count++;
                    Read();
                }
            }

        }

        public Occurance Current()
        {
            return occur;
        }

        public bool End()
        {
            return end;
        }





    }
}