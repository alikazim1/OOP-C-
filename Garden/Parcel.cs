using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden
{
    class Parcel
    {
        private int plantingDate;
        private Plant plant;

        public void planting(Plant p, int d)
        {
            plant = p;
            plantingDate = d;
        }

        public Plant GetPlant()
        {
            return plant;
        }

        public int GetPlantDate()
        {
            return plantingDate;
        }

    }
}
