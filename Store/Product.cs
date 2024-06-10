using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class Product
    {
        public Product(string name, int price)
        {
            this.name = name;
            this.price = price;
        }
        public string name;
        public int price;
    }
}
