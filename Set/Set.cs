using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class Set : ICloneable
    {   public class EmptySetException : Exception { }
        public class UnderTraversalException : Exception { }
        public class  IllegalElementException : Exception
        {
            public int e;
            public IllegalElementException(int n) { e = n; }
        }
        private SetRepr repr;

        public Set(int n = 0)
        {
            if (0 == n) repr = new SequenceSet();
            else repr = new ArraySet(n);
        }

        public Set(Set other)
        {
            if (other.repr is SequenceSet seqrepr) repr = new SequenceSet(seqrepr);
            else if (other.repr is ArraySet arrayrepr) repr = new ArraySet(arrayrep);
        }

        public void SetEmpty()
        {
            repr.SetEmpty();
        }
        public void Insert(int e)
        {   if (repr.EnumeratorCount != 0) throw new UnderTraversalException();
            repr.Insert(e);
        }

        public int Select()
        {
           if(Empty()) throw new EmptySetException();
           return repr.Select();
        }

        public bool Empty() { return repr.IsEmpty(); }
        public bool In(int e) { return repr.In(e); }

        public MyEnumerator CreateEnumerator()
        {
            return repr.CreateEnumerator(); 
        }




    }
}
