using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models
{
    public class Claymore : Weapon
    {
        private const int CDamage = 20;
        public Claymore(string name, int durability) 
            : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            //Durability--;

            //if (Durability == 0)
            //{
            //    return 0;
            //}

            if (Durability == 0)
            {
                return 0;
            }
            else
            {
                Durability--;
            }

            return CDamage;
        }
    }
}
