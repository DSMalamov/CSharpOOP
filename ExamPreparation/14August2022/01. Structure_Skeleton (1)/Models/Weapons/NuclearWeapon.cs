using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class NuclearWeapon : Weapon
    {
        private const double Nprice = 15;

        public NuclearWeapon(int destructionLevel) 
            : base(destructionLevel, Nprice)
        {
        }
    }
}
