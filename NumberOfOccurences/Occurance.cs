using System;
namespace NumberOfOccurances
{
    public class Occurance
    {
        public int number;
        public int count;

        public override string ToString()
        {
            return "(" + number.ToString() + count.ToString() + ")";
        }
    }
}