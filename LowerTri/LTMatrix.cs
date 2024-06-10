using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace LowerTri
{
    public class LTM
    {
        public class InvalidIndexException : Exception { };
        public class OutOfTriangleException : Exception { };
        public class DimensionMismatchException : Exception { };

        private List<double> v;
        private int n;

        private int ind(int i, int j)
        {
            return j + i * (i + 1) / 2; ///indexing from zero
        }
        private double calcSizeFromLength(int length)
        {
            return (-1 + Math.Sqrt(1 + 8 * length)) / 2; /// root of (x^2+x-2*length=0) as x*(x+1)/2=length
        }
        private bool inLowerTrng(int i, int j)
        {
            return (j <= i);
        }


        public LTM() /// basic 3x3 matrix
        {
            n = 3;
            v = new List<double>() { 1, 2, 3, 4, 5, 6 };
        }
        public LTM(int size) /// zero matrix with given size
        {
            n = size;
            v = new List<double>();
            int length = size * (size + 1) / 2;
            for (int i = 0; i < length; i++)
            {
                v.Add(0);
            }
        }
        public LTM(String fileName) /// matrix read from a file
        {
            try
            {
                TextFileReader f = new TextFileReader(fileName);
                v = new List<double>();
                while (f.ReadInt(out int e))
                {
                    v.Add(e);
                }
                double size = calcSizeFromLength(v.Count);
                if (size == Math.Floor(size))
                {
                    n = Convert.ToInt32(size);
                }
                else
                {
                    n = 0;
                    v.Clear();
                }
            }
            catch
            {
                n = 0;
                v.Clear();
            }
        }


        public LTM(LTM m) /// matrix read from a file
        {
            n = m.n;
            v = m.v;
        }

        public int GetSize()
        {
            return n;
        }

        public double getElem(int i, int j)  /// Get matrix element by indices
        {
            if (inLowerTrng(i, j)) /// indices pointing to the lower triangle
            {
                return v[ind(i, j)];
            }
            else if (j >= i) /// other valid indices
            {
                return 0;
            }
            else /// invalid indices
            {
                throw new InvalidIndexException();
            }
        }

        /// Setter
        void setElem(int i, int j, double e)
        {
            if ( j <= i) /// indices of the lower part
            {
                v[ind(i, j)] = e; /// vector indexing starts at 0
            }
            else
                throw new OutOfTriangleException();
        }

        /// Static methods

        public static LTM add(LTM a, LTM b)
        {
            if (a.GetSize() == b.GetSize())
            {
                LTM sum = new LTM(b.GetSize());
                for (int i = 0; i < a.v.Count; i++)
                {
                    sum.v[i] = a.v[i] + b.v[i];
                }
                return sum;
            }
            else
            {
                throw new DimensionMismatchException();
            }
        }

        public static LTM mul(LTM a, LTM b)
        {
            if (a.GetSize() == b.GetSize())
            {
                LTM c = new LTM(a.GetSize());
                for (int i = 0; i < a.n; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        double sum = 0;
                        for (int k = j; k <= i; k++)
                        {
                            //c.setElem(i, j, c.getElem(i, j) + a.getElem(i, k) * b.getElem(k, j));
                            sum += a.getElem(i, k) * b.getElem(k, j);
                        }
                        c.setElem(i, j, sum);
                    }
                }
                return c;
            }
            else
            {
                throw new DimensionMismatchException();
            }
        }

        public override String ToString()
        {
            String str = "";
            str += n.ToString() + "x" + n.ToString() + "\n";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    str += getElem(i, j).ToString() + "\t";
                }
                str += "\n";
            }
            return str;
        }
    }
}
