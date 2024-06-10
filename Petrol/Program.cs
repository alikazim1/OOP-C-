using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Petrolstation station = new Petrolstation(480);
            Driver driver = new Driver();
            driver.refuel(station, 1, 25);

        }
    }
}
