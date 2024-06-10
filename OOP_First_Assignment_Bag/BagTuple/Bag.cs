using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace BagTuple
{
    public class Bag
    {
        #region Exceptions 
        public class ElementNotInBag : Exception { };
        public class BagEmptyException : Exception { };
        public class ArgumentNullException : Exception { }; 
        #endregion
        



        #region Attributes
        List<Tuple<int, int>> elements;
        //Tuple<int, int> tup;
        #endregion


        #region Constructor
        public Bag()
        {
            elements = new List<Tuple<int, int>>();            
        }
        #endregion


        #region Methods
        public void add(Tuple<int, int> tup) 
        {   
            
            
            if (elements.Any(x => x.Item1 == tup.Item1))
            {
                Tuple<int, int> previous = elements.Find(x => x.Item1 == tup.Item1);
                Tuple<int, int> existing = new Tuple<int, int>(previous.Item1, previous.Item2 + tup.Item2);
                elements.Remove(previous);
                elements.Add(existing);              
                
            }            
            else if (!elements.Any(x => x.Item1 == tup.Item1))//tup != null
            { elements.Add(tup); }
            else
            {
                throw new ArgumentNullException();
            }
           
        }

        public int getElem(int num)
        {
            Tuple<int,int> t =  elements.Find(x => x.Item1 == num);
            return t.Item2;
        }

        public void remove(int t)
        {   
            if(elements.Any(e => e.Item1 == t)) 
            {
            Tuple<int,int> tmp = elements.Find(x=>x.Item1 == t);
            elements.Remove(tmp);
            }
            else
            {
                throw new ElementNotInBag();
            }
        }

        public int freq(int f)
        {
            if (elements.Any(e => e.Item1 == f))
            {
                Tuple<int, int> a = elements.Find(x => x.Item1 == f);
                int fre = a.Item2;
                return fre;
            }
            else if (elements.Count==0)
            {
                throw new BagEmptyException();
            }
            else
            {
                throw new ElementNotInBag();
            }
        }

        
        public int singleFreq()
        {   
            if (elements.All(x=>x.Item1 == 0 && x.Item2 == 0))
            {
                throw new BagEmptyException();
            }
            else
            {
                return elements.Count(x => x.Item2 == 1);
            }
        }


        public void print()
        {   
            if(elements.All(x=>x.Item1 == 0 && x.Item2 == 0)) 
            {
                throw new BagEmptyException();
            }
            else
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    Console.WriteLine(elements[i].ToString());
                }
            }

            
        }
        #endregion
    }
}
