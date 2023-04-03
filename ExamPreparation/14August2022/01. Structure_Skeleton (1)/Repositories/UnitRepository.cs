using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> units;
        public UnitRepository()
        {
            units= new List<IMilitaryUnit>();
        }
        public IReadOnlyCollection<IMilitaryUnit> Models => units;

        public void AddItem(IMilitaryUnit model)
        {
            units.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
            => units.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            var unit = units.FirstOrDefault(x => x.GetType().Name == name);

            if (unit != null)
            {
                units.Remove(unit);
                return true;
            }

            return false;
        }
    }
}
