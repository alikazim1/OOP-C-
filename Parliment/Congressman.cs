using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Parliment
{
    class Congressman
    {
        
        public string name;
        Parliment p;

        public Congressman(string n)
        {
            name = n;
        }

        public void Vote(bool vote, string ID)
        {
            if(p== null)
            {
                p.Vote(this, vote, ID);
            }
            
        }
    }
}
