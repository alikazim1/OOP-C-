using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrol
{
    class Cash
    {
        private Petrolstation station = null;

        //const: 
        public Cash(Petrolstation station)
        {
            this.station = station;
        }

        public double pay(int i)
        {
            double l = station.pump[i].GetDisplay();
            station.pump[i].Reset();
            Console.WriteLine($"Cash Paying: {station.GetUnit() * l}");
            return station.GetUnit() * l;
        }


    }
}
