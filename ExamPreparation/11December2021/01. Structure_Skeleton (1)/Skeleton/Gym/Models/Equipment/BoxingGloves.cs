using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double BGweight = 227;
        private const decimal BGPrice = 120;

        public BoxingGloves() 
            : base(BGweight, BGPrice)
        {
        }
    }
}
