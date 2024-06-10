﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class ArraySet : SetRepr, ICloneable
    {
        private bool[] vect;
        private int size;

        public ArraySet(int n) : base()
        {
        
            vect = new bool[n+1];
            for(int i = 0; i < n; i++)
            {
                vect[i] = false;
            }
            size = 0;
        
        }

        public ArraySet(ArraySet source) : base()
        {
            vect = new bool[source.vect.Length];
            source.vect.CopyTo(vect, 0);
            size = source.size;
        }

        public override object Clone()
        {
            ArraySet copy = new ArraySet(size)
            {
                vect = new bool[vect.Length]
            };
            copy.size = size;
            return copy;
        }

        public override void SetEmpty()
        {
            for(int i = 0; i < vect.Length; i++) { vect[i] = false;
                size = 0;
            }
        }

        public override void Insert(int e)
        {
            if (e < 0 ||e >= vect.Length) throw new Set.IllegalElementException(e);
            if (!vect[e])
            {
                vect[e] = true;
                size++;
            }
        }

        public override void Remove(int e)
        {
            if (e < 0 || e >= vect.Length) throw new Set.IllegalElementException(e);
            if (vect[e])
            {
                vect[e] = false;
                size--;
            }
        }

        public override int Select()
        {
            int e;
            for (e = 0; !vect[e]; e++) ;
            
                return e;
            
        }


        public override bool Empty()
        {
            return size == 0; 
        }

        public override bool In(int e)
        {
            if (e < 0 || e >= vect.Length) throw new Set.IllegalElementException(e);
            return vect[e];
        }


        public class ArraySetEnor : MyEnumerator
        {
            private readonly ArraySet s;
            private int ind;

            public ArraySetEnor(ArraySet h) { s = h; }


            public void FindNext()
            {
                for (++ind; ind < s.vect.Length && !s.vect[ind]; ++ind) ;
            }

            public override void First()
            {
                ind = -1; FindNext();
                if(ind < s.vect.Length)
                {
                    ++s.EnumeratorCount;
                }
               
            }

            public override void Next()
            {
                FindNext();
                if(ind == s.vect.Length)
                {
                    --s.EnumeratorCount;
                }
            }

            public override bool End()
            {
                return ind == s.vect.Length;
            }
            public override int Current()
            {
                return ind;
            }


            public override void Finish()
            {
                ind = s.vect.Length; --s.EnumeratorCount;
            }


        }

        public override MyEnumerator CreateEnumerator()
        {
            return new ArraySetEnor(this);
        }















































































































    }
}
