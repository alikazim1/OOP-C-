using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish
{
    class Contest
    {
        public Club club;
        public string Location { get; }


        public List<Angler> anglers = new();

        public Contest(string place, Club club) { Location = place; this.club = club; }

        public void Register(string anglerName)
        {
            Angler? angler = club.Member(anglerName);

            if (null != angler && null == Participant(anglerName))
                anglers.Add(angler);
        }

        public bool AllCatfish()
        {
            foreach (Angler a in anglers)
            {
                if (!a.CatFish(this)) return false;
            }
            return true;
        }
        public double Point()
        {
            double s = 0.0;
            foreach (Angler a in anglers)
            {
                s += a.Points(this);
            }
            return s;
        }

        private Angler? Participant(string name)
        {
            foreach (Angler a in anglers)
            {
                if (a.Name == name) return a;
            }
            return null;
        }
    }

}
