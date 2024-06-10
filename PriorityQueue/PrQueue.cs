using System;
using System.Collections.Generic;

namespace PriorityQueue
{
    class Element
    {
        public int pr;
        public string data;

        public Element() { data = ""; }
        public Element(int p, string str)
        {
            pr = p;
            data = str;
        }

        public override string ToString()
        {
            return "(" + pr.ToString() + ", " + data + ")";
        }

        public void Read()
        {
            Console.WriteLine("Data: ");
            data = Console.ReadLine();
            bool ok;
            do
            {
                Console.WriteLine("Priority: ");
                try
                {
                    pr = int.Parse(Console.ReadLine());
                    ok = true;
                }
                catch (System.FormatException)
                {
                    ok = false;
                }
            } while (!ok);
        }
    }
    class PrQueue
    {
        private List<Element> seq = new List<Element>();
        public class PrQueueEmpty : Exception { }

        public bool isEmpty()
        {
            return seq.Count == 0;
        }

        public void Add(Element a)
        {
            seq.Add(a);
        }

        public Element GetMax()
        {
            if (seq.Count == 0) throw new PrQueueEmpty();
            int ind = MaxSelect();
            return seq[ind];
        }

        public Element RemMax()
        {
            if (seq.Count == 0) throw new PrQueueEmpty();
            int ind = MaxSelect();
            Element best = seq[ind];
            seq.RemoveAt(ind);
            return best;
        }

        public int GetCapacity() { return seq.Capacity; }

        public override string ToString()
        {
            string ret = "";
            foreach (Element e in seq)
            {
                ret += e;
            }
            return ret;
        }

        private int MaxSelect()
        {
            int ind = 0;
            int maxkey = seq[0].pr;
            for (int i = 1; i < seq.Count; ++i)
            {
                if (seq[i].pr > maxkey)
                {
                    ind = i;
                    maxkey = seq[i].pr;
                }
            }
            return ind;
        }
    }
}

