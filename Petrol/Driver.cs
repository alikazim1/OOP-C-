using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrol
{
    class Driver
    {
        Random RandomGenerator = new Random();  
        public void refuel(Petrolstation p, int i, int l)
        {
            p.pump[i].fill(l);
            int c = ChooseCash(p);
            Console.WriteLine($"Diver: filling {l} liters at cashdesk {c}");
            p.cash[c].pay(i);
            Console.ReadLine();


        }
        private int ChooseCash(Petrolstation p)
        {
            
            return (RandomGenerator.Next() % 2) ; //it will always return 0 or 1
        }
    }
}
