using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunFair
{
    public abstract class Prize
    {
        public ISize size;
        public Gallery gallery;

        //const
        public Prize(Gallery g, ISize s)
        {
            this.size = s;
            this.gallery = g;
        }

        public virtual int Value()
        {
            return Point() * size.Mult();
        }

        public abstract int Point();
        

    }

    class Ball : Prize
    {
        public Ball(Gallery gallery, ISize size) : base(gallery, size) { }
        public override int Point()
        {
            return 1;
        }




    }

    public class Doll : Prize
    {
        public Doll(Gallery g, ISize s) : base(g, s) { }

        public override int Point()
        {
            return 2;
        }
    }

    public class Teddy : Prize
    {
        public Teddy(Gallery g, ISize s) : base(g, s) { }

        public override int Point()
        {
            return 3;
        }

    }
}
