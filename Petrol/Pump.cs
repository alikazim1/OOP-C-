using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrol
{
    class Pump
    {
        public int display;

        public void fill(int l)
        {
            display = l;
            Console.WriteLine($"Pump: Display is set {display}");
        }

        public int GetDisplay() { return display; }

        public void Reset()
        {
            display = 0;
            Console.WriteLine($"Pump: Display is set {display}");
        }




    }
}
