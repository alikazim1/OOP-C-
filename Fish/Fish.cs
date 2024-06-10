﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fish
{
    abstract class Fish
    {
        public abstract int Mult();
        public virtual bool IsBream() { return false; }
        public virtual bool IsCarp() { return false; }
        public virtual bool IsCatfish() { return false; }
    }

    class Bream : Fish
    {
        private static Bream? instance;
        private Bream() { }
        public static Bream Instance()
        {
            if (null == instance) instance = new Bream();
            return instance;
        }
        public override int Mult() { return 1; }
        public override bool IsBream() { return true; }
    }

    class Carp : Fish
    {
        private static Carp? instance;
        private Carp() { }
        public static Carp Instance()
        {
            if (null == instance) instance = new Carp();
            return instance;
        }
        public override int Mult() { return 2; }
        public override bool IsCarp() { return true; }
    }

    class Catfish : Fish
    {
        private static Catfish? instance;
        private Catfish() { }
        public static Catfish Instance()
        {
            if (null == instance) instance = new Catfish();
            return instance;
        }
        public override int Mult() { return 4; }
        public override bool IsCatfish() { return true; }
    }
}
