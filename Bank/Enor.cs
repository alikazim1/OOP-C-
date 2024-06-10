using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace Bank
{
    public class Customer
    {
        public string acc;
        public string date;
        public int am;

        public Customer(string ac, string d, int a)
        {
            acc = ac;
            date = d;
            am = a;
        }
        public Customer()
        {
            acc = "";
            date = "";
            am = 0;
        }

        public static void Read(ref Enor.Status st, ref Customer c, ref TextFileReader x)
        {
            c = new Customer();
            bool l = x.ReadString(out c.acc);
            l = l && x.ReadString(out c.date);
            l = l && x.ReadInt(out c.am);
            st = l ? Enor.Status.norm : Enor.Status.abnorm;
        }
    }

    public class Balance
    {
        public string acc;
        public int bal;
        public override string ToString()
        {
            return $"({acc},{bal})";
        }
        public Balance()
        {
            acc = "";
            bal = 0;
        }
        public Balance(string a, int b)
        {
            acc = a;
            bal = b;
        }
    }

    public class Enor
    {
        public enum Status { abnorm, norm };

        private TextFileReader x;
        private Customer e;
        private Status st;
        Balance cur = new Balance();
        bool end;

        public Enor(string fileName)
        {
            x = new TextFileReader(fileName);
        }

        public void First() { Customer.Read(ref st, ref e, ref x); Next(); }
        public void Next()
        {
            end = (Status.abnorm == st);
            if (!end)
            {
                cur.acc = e.acc;
                cur.bal = 0;
                while (Status.norm == st && e.acc == cur.acc)
                {
                    cur.bal += e.am;
                    Customer.Read(ref st, ref e, ref x);
                }
            }
        }
        public Balance Current() { return cur; }
        public bool End() { return end; }

    }

}
