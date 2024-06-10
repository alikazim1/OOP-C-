using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish
{
    internal class Catch
    {
        public Fish Fish { get; }
        public Contest Contest { get; }

        public double weight;

        public Catch(Fish f, double weight, Contest c) { Fish = f; this.weight = weight; Contest = c; }
        public double Value() { return weight * Fish.Mult(); }
    }
}
