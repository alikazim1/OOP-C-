using Fish;
using System.Collections.Generic;

namespace Fish
{
    class Angler
    {
        public string Name { get; }
        public List<Catch> Catches { get; }

        public Angler(string name) { Name = name; Catches = new List<Catch>(); }

        public void Catch(Fish fish, double weight, Contest contest)
        {
            Catches.Add(new Catch(fish, weight, contest));
        }

        public bool CatFish(Contest contest)
        {
            foreach (Catch c in Catches)
            {
                if (c.Fish.IsCatfish() && c.Contest == contest) return true;
            }
            return false;
        }

        public double Points(Contest contest)
        {
            double s = 0;
            foreach (Catch c in Catches)
            {
                if (c.Contest == contest) s += c.Value();
            }
            return s;
        }
    }
}
