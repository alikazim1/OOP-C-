using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    abstract class SetRepr : ICloneable
    {
        public int EnumeratorCount { get; protected set; }
        public SetRepr() { EnumeratorCount = 0; }

        public abstract void SetEmpty();
        public abstract void Insert(int e);
        public abstract void Remove(int e);
        public abstract int Select();
        public abstract bool Empty();
        public abstract bool In(int e); 
        public abstract object Clone();
        public abstract MyEnumerator CreateEnumerator();


    }
}
