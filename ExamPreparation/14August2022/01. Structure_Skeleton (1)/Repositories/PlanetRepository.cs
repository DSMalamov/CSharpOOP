using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planets;

        public PlanetRepository()
        {
            planets = new List<IPlanet>();  
        }

        public IReadOnlyCollection<IPlanet> Models => planets;

        public void AddItem(IPlanet model)
        {
            planets.Add(model);
        }

        public IPlanet FindByName(string name)
            => planets.FirstOrDefault(x => x.Name == name);

        public bool RemoveItem(string name)
        {
            var planet = planets.FirstOrDefault(x => x.Name == name);

            if (planet != null)
            {
                planets.Remove(planet);
                return true;
            }

            return false;
        }
    }
}
