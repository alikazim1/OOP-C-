using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish
{
    internal class Club
    {
        public List<Contest> contests = new();
        public List<Angler> members = new();

        public Contest Organize(string place)
        {
            Contest contest = new(place, this);
            contests.Add(contest);
            return contest;
        }

        public Angler? Member(string name)
        {
            foreach (Angler f in members)
            {
                if (f.Name == name) return f;
            }
            return null;
        }

        public void Join(string name)
        {
            if (null != Member(name)) return;
            members.Add(new Angler(name));
        }

        public bool Best(out Contest? contest)
        {
            bool l = false;
            contest = null;
            double max = 0.0;
            foreach (Contest c in contests)
            {
                if (!c.AllCatfish()) continue;
                double s = c.Point();
                if (l)
                {
                    if (s > max)
                    {
                        contest = c; max = s;
                    }
                }
                else
                {
                    l = true; contest = c; max = s;
                }
            }
            return l;
        }
    }
}
