using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Creature
{
    abstract class Creature
    {
        public string Name { get; }
        protected int power;
        public void ModifyPower(int e) { power += e; }
        public bool Alive() { return power > 0; }

        protected Creature(string name, int e = 0) { Name = name; power = e; }

        public void Race(ref List<IGround> courts)
        {
            for (int j = 0; j < courts.Count && Alive(); j++)
            {
                courts[j] = Traverse(courts[j]);
            }
        }
        protected abstract IGround Traverse(IGround court);
    }



    //class of dunebeetles
    class DuneBeetle : Creature
    {
        public DuneBeetle(string str, int e = 0) : base(str, e) { }
        protected override IGround Traverse(IGround court)
        {
            return court.Change(this);
        }
    }
    
    class Squelchy : Creature
    {
        public Squelchy(string str, int e = 0) : base(str, e) { }
        protected override IGround Traverse(IGround court)
        {
            return court.Change(this);
        }

    }

    class Greenfinch : Creature
    {
        public Greenfinch(string str, int e = 0) : base(str, e) { }
        protected override IGround Traverse(IGround court)
        {
            return court.Change(this);
        }

    }


























}
