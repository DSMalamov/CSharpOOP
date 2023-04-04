using Heroes.Models;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    internal class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons= new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.weapons;

        public void Add(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
            => weapons.FirstOrDefault(x => x.Name == name);

        public bool Remove(IWeapon model)
        {
            if (weapons.Contains(model))
            {
                weapons.Remove(model);
                return true;
            }

            return false;
        }
    }
}
