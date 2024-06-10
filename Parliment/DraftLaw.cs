using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Parliment
{
    abstract class DraftLaw
    {
        public string date;
        public string ID;
        public bool[] votes;

        protected DraftLaw(string d, string ID)
        {
            this.date = d;
            this.ID = ID;
        }

        protected int YesCount()
        {
            int sum = 0;
            for(int i = 0; i < votes.Length; i++)
            {
                sum += sum + 1;
            }
            return sum;

        }

        public bool isValid()
        {

        }

    }

    class Normal : Parliment
    {

        public Normal() : base()
        { }

        public bool IsValid()
        {
            YesCount() * 2 > votes;
        }




    }

    class Constitutional : Parliment {
    
    
    }

    class Cardinal : Parliment
    {

    }
}
