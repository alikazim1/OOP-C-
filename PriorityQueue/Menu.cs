using System;
using System.Xml.Linq;

namespace PriorityQueue
{
    class Menu
    {
        private PrQueue pq = new PrQueue();
        public void Run()
        {
            int v;
            do
            {
                v = GetMenuPoint();
                switch (v)
                {
                    case 1:
                        PutIn();
                        Write();
                        break;
                    case 2:
                        RemoveMax();
                        Write();
                        break;
                    case 3:
                        GetMax();
                        Write();
                        break;
                    case 4:
                        CheckEmpty();
                        Write();
                        break;
                    case 5:
                        Write();
                        break;
                    default:
                        Console.WriteLine("Goodbye!");
                        break;
                }
            } while (v != 0);
        }
        private static int GetMenuPoint()
        {
            int v;
            do
            {
                Console.WriteLine("\n********************************");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Put in");
                Console.WriteLine("2. Rem max");
                Console.WriteLine("3. Get max");
                Console.WriteLine("4. Is empty");
                Console.WriteLine("5. Print");
                Console.WriteLine("****************************************");

                try
                {
                    v = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException) { v = -1; }
            } while (v < 0 || v > 5);
            return v;
        }
        private void PutIn()
        {
            Element e = new Element();
            Console.WriteLine("Element to put in");
            e.Read();
            pq.Add(e);
        }
        private void RemoveMax()
        {
            Element e;
            try
            {
                e = pq.RemMax();
                Console.WriteLine("Removed element:\n ({0}, {1})", e.pr, e.data);
            }
            catch (PrQueue.PrQueueEmpty)
            {
                Console.WriteLine("Couldn't remove! PrQueue is empty!\n");
            }
        }
        private void GetMax()
        {
            Element e;
            try
            {
                e = pq.GetMax();
                Console.WriteLine("Max element:\n ({0}, {1})", e.pr, e.data);
            }
            catch (PrQueue.PrQueueEmpty)
            {
                Console.WriteLine("Couldn't remove! PrQueue is empty!\n");
            }
        }
        private void CheckEmpty()
        {
            if (pq.isEmpty())
                Console.WriteLine("The PrQueue is empty.");
            else
                Console.WriteLine("The PrQueue is not empty.");
        }
        private void Write()
        {
            Console.WriteLine(pq);
        }

    }
}

