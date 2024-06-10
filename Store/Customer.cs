using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Store
{
    class Customer
    {
        public string name;
        private List<string> list = new List<string>();
        public List<Product> cart = new List<Product>();

        public Customer(string filename)
        {
            TextFileReader reader = new TextFileReader(filename);
            reader.ReadString(out string str);
            name = str;
            while (reader.ReadString(out str))
            {
                list.Add(str);
            }
        }

        public void purchase(Store store)
        {
            Console.WriteLine($"{name} has bought the following products: ");

            foreach (string productName in list)
            {
                if (LinSearch(productName, store.foods, out Product product))
                {
                    store.foods.stock.Remove(product);
                    cart.Add(product);
                    Console.WriteLine($"{product.name} {product.price}");
                }
            }
            foreach (string productName in list)
            {
                if (MinSearch(productName, store.technical, out Product product))
                {
                    store.technical.stock.Remove(product);
                    cart.Add(product);
                    Console.WriteLine($"{product.name} {product.price}");
                }
            }
        }

        private static bool LinSearch(string name, Department d, out Product product)
        {
            bool l = false;
            product = null;
            foreach (Product p in d.stock)
            {
                if ((l = (p.name == name)))
                {
                    product = p; break;
                }
            }
            return l;
        }

        private static bool MinSearch(string name, Department d, out Product product)
        {
            bool l = false;
            product = null;
            int min = 0;
            foreach (Product p in d.stock)
            {
                if (p.name != name) continue;
                if (l)
                {
                    if (min > p.price)
                    {
                        min = p.price;
                        product = p;
                    }
                }
                else
                {
                    l = true;
                    min = p.price;
                    product = p;
                }
            }
            return l;
        }
    }
}
