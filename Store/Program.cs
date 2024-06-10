using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Customer c = new Customer("C:\\Users\\alika\\source\\repos\\Store\\customer1.txt");
                Store s = new Store("C:\\Users\\alika\\source\\repos\\Store\\foods.txt", "C:\\Users\\alika\\source\\repos\\Store\\technical.txt");
                c.purchase(s);


                Console.ReadLine();


            }
            catch(System.IO.FileNotFoundException) {
                Console.WriteLine("File Not Found");

            
            }



        }
    }
}