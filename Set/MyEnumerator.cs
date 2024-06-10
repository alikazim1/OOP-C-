using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    abstract class MyEnumerator : IEnumerable
    {
        public abstract void First();
        public abstract void Next();
        public abstract bool End();
        public abstract int Current();
        public abstract void Finish();

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (First(); !End(); Next())
            {
                yield return Current();
            }
        }
    }
}
