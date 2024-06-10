using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrol
{
    class Petrolstation
    {
        private double unit;
        public List<Pump> pump = new List<Pump>(); 
        public List<Cash> cash = new List<Cash>();

        //cons
        public Petrolstation(double unit)
        {
            this.unit = unit;
            for (int i = 0; i < 6; i++)
            {
                pump.Add(new Pump());
            }
            for (int i = 0; i < 2; i++)
            {
                cash.Add(new Cash(this));
            }
        }
        public double GetUnit()
        {
            return unit;
        }
       

      
    }
}
