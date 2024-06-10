using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LongestWordContainingW
{
    public class WordEnum
    {

        public StreamReader ST;
        public Word currentWord;
        public bool end;
        public char ch;
        public String delimeter = " \t\n\r";

        public WordEnum(string file) 
        {
            this.ST = new StreamReader(file);
            this.currentWord = new Word();
        
        }

        //First Next Current End

        public void First()
        {
            ch = (char)ST.Read();
            Next();
        }

        public void Next()
        {
            while (ST.Peek() >= 0 && delimeter.Contains(ch))
            {
                ch = (char)ST.Read(); // wipe all empty spaces occuring before and during the reading 
            }

            end = ST.Peek() < 0;

            if (!end) 
            {
                 currentWord.word = "";
				currentWord.containsW = false;
				currentWord.length = 1;
                while(ST.Peek() >= 0 && !delimeter.Contains(ch)){
                    currentWord.word += ch;
                    currentWord.length++;
                    currentWord.containsW = currentWord.containsW || ch == 'w' || ch == 'W';
                    

                    ch = (char)ST.Read();
                }
            }
        }

        public Word Current()
        {
            return currentWord;
        }

        public bool End()
        {
            return end;
        }
    }
}
