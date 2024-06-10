using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Healthy
{
    class InFile
    {
        public class EmptyRowException : Exception { }
        public struct player
        {
            public string name;
            public bool below;

            
        }

        private readonly TextFileReader reader;

        public InFile(string fname)
        {
            reader = new TextFileReader(fname);
        }

        public bool Read(out player e)
        {
            if (reader.ReadLine(out string line))
            {
                if (line == "") throw new EmptyRowException();
                char[] separators = new char[] { ' ', '\t' };
                string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                e.name = "";
                int i = 0;
                foreach (string str in tokens)
                {
                    if (str[2] == ':') break;
                    e.name += str + " ";
                    ++i;
                }

                bool l1 = false;
                for (++i; i < tokens.Length; i += 2)
                {
                    if (l1 = (int.Parse(tokens[i]) >= 100)) break;
                }

                bool l2 = false;
                for (i += 2; i < tokens.Length; i += 2)
                {
                    if (l2 = (int.Parse(tokens[i]) < 100)) break;
                }
                e.below = l1 && l2;

                return true;
            }
            else
            {
                e.name = ""; e.below = false;
                return false;
            }
        }




    }
}
