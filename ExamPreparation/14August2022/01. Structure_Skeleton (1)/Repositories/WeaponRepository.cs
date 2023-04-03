using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons= new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => weapons;

        public IWeapon FindByName(string name)
            => weapons.FirstOrDefault(w => w.GetType().Name == name);

        public void AddItem(IWeapon model)
            => weapons.Add(model);


        public bool RemoveItem(string name)
        {
            var weapon = weapons.FirstOrDefault(x => x.GetType().Name == name);

            if (weapon != null)
            {
                weapons.Remove(weapon);
                return true;
            }
            
            return false;
        }
    }
}
