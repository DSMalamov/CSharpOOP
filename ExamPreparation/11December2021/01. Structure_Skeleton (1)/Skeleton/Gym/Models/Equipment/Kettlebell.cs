using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const double Kweight = 10000;
        private const decimal KPrice = 80;

        public Kettlebell() 
            : base(Kweight, KPrice)
        {
        }
    }
}
