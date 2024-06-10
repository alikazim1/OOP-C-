using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFair
{
    public class Guest
    {
        public String name;
        public List<Prize> prizes;

        public Guest(string n)
        {
            name = n;
            prizes = new List<Prize>();
        }

        public void Win(Prize p)
        {
            this.prizes.Add(p);
        }

        public int Result(Gallery g)
        {
            int sum = 0;
            foreach (Prize p in prizes)
            {
                if(p.gallery == g)
                {
                    sum += p.Value();
                }
            }
            return sum;
        }

    }
}
