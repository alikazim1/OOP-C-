using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondAssignment
{

    #region
   public interface IMood
    {
        void ChangeFish(Fish f);
        void ChangeBird(Bird b);
        void ChangeDog(Dog d);
    }

    #endregion



    #region
   public class Good : IMood
   {
        public void ChangeFish(Fish f)
        {
            f.CheerUp(1);

        }

        public void ChangeBird(Bird b)
        {
            b.CheerUp(2);
        }

        public void ChangeDog(Dog d)
        {
            d.CheerUp(3);
        }
   }


   public class Ordinary : IMood
   {
        public void ChangeFish(Fish f)
        {
            f.CheerUp(3);

        }

        public void ChangeBird(Bird b)
        {
            b.CheerUp(1);
        }

        public void ChangeDog(Dog d)
        {
            // --
        }
   }

   public class Bad : IMood
   {

        public void ChangeFish(Fish f)
        {
            f.MakeSadder(5);
        }

        public void ChangeBird(Bird b)
        {
            b.MakeSadder(3);
        }

        public void ChangeDog(Dog d)
        {
            d.MakeSadder(10);
        }




   }

    #endregion







}

