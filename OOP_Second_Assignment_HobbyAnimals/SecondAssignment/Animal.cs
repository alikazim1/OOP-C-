using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondAssignment
{
    public abstract class Animal
    {
        public string Name { get; }
        public int Exhilaration { get; protected set; }

        public bool IsAlive()
        {
            return Exhilaration > 0;
        }


        public Animal(string name, int exhilaration)
        {
            Name = name;
            Exhilaration = exhilaration;
        }

        public virtual void CheerUp(int e)
        {
            Exhilaration += e;
        }

        public virtual void MakeSadder(int e)
        {
            Exhilaration -= e;
        }

        public abstract void Moodify(IMood m);



    }

    //Visitor Design Patter: Moodify is expecting mood object as input parameter as a visitor and call 
    // the methods which corrosponds to the animals. 
   public class Fish : Animal
    {
        public Fish(string name, int exhilaration) : base(name, exhilaration) { }

        public override void Moodify(IMood m)
        {
            m.ChangeFish(this);
        }
    }

    public class Bird : Animal
    {
        public Bird(string name, int exhilaration) : base(name, exhilaration) { }

        public override void Moodify(IMood m)
        {
            m.ChangeBird(this);
        }
    }

   public class Dog : Animal
    {
        public Dog(string name, int exhilaration) : base(name, exhilaration) { }

        public override void Moodify(IMood m)
        {
            m.ChangeDog(this);
        }
    }




}