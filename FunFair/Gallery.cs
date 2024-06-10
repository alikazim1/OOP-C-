using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFair
{
   public class Gallery
    {
        public string location;
        public Prize prize;
        public List<Guest> guests;

        public Gallery(string n)
        {
            this.location = n;
            this.guests = new List<Guest>();
        }

        public void Register(Guest g)
        {
            this.guests.Add(g);
        }

        public string Best()
        {
            int max = 0;
            int curr = 0;
            string name = " ";
            for (int i = 0; i < guests.Count; i++)
            {
                curr = guests[i].Result(this);
                if (max < curr)
                {
                    max = curr;
                    name = guests[i].name;
                }
            }
            return name;
        }
    }
}
