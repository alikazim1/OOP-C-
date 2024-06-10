using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frequency
{
    public class Bag
    {   //Exceptions: 
        public class NegativeSizeException : Exception { }
        public class EmptyBagException : Exception { }
        public class IllegalElementException : Exception { }

        //representation of a bag: 
        protected int[] vec;
        protected int max; //the most frequent int of the bag (list)

        //creating empty bag: //constructor
        public Bag(int m)
        {
            if (m < 0) throw new NegativeSizeException();
            vec = new int[m + 1];
            for (int i = 0; i <= m; i++) vec[i] = 0;
            max = 0;
        }

        //Erasing the bag: 
        public void Erase()
        {
            for (int i = 0; i < vec.Length; i++) { vec[i] = 0; }
            max = 0;

        }

        //putting ints into the bag: 
        public void PutIn(int e)
        {
            if (e < 0 || e >= vec.Length) throw new IllegalElementException();
            if (++vec[e] > vec[max]) max = e;
        }

        //retriving the most freq element of the bag: 
        public int MostFreq()
        { return max; }



    }
}
