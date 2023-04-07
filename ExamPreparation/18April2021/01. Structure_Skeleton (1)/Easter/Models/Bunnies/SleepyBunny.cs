using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int SBenergy = 50;
        public SleepyBunny(string name)
            : base(name, SBenergy)
        {
        }

        public override void Work()
        {
            Energy -= 15;
        }
    }
}
