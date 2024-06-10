using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;
using static LowerTri.LTM;

namespace LowerTri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LTM a = new LTM();
            LTM b = new LTM();
            LTM c = new LTM(2);
            Console.WriteLine($"a:\n{a.ToString()}\n\n");
            Console.WriteLine($"b:\n{b.ToString()}\n");
            Console.WriteLine($"a[1,2]= {a.getElem(1, 2)}\n");
            Console.WriteLine($"a[2,1]= {a.getElem(2, 1)}\n\n");
            Console.WriteLine($"a+b:\n{LTM.add(a, b).ToString()}\n\n");
            Console.WriteLine($"a*b:\n{LTM.mul(a, b).ToString()}\n\n");
            Console.ReadLine();
            try
            {
                Console.WriteLine($"invalid sum:");
                Console.WriteLine(LTM.add(c, a).ToString() + "\n\n");
            }
            catch (LTM.DimensionMismatchException)
            {
                Console.WriteLine("exception caught\n\n");
            }
            try
            {
                Console.WriteLine($"invalid mul:");
                Console.WriteLine(LTM.mul(c, b).ToString() + "\n\n");
            }
            catch (LTM.DimensionMismatchException)
            {
                Console.WriteLine("exception caught\n\n");
            }
        }
    }
}
