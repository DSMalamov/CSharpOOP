using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int HBenergy = 100;
        public HappyBunny(string name)
            : base(name, HBenergy)
        {
        }

        public override void Work()
        {
            Energy -= 10;
        }
    }
}
