using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Repositories.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private IRepository<IPlanet> planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string CreatePlanet(string name, double budget)
        {

            if (planets.FindByName(name) != null)
            {
                return string.Format(OutputMessages.ExistingPlanet, name);
            }

            planets.AddItem(new Planet(name, budget));

            return string.Format(OutputMessages.NewPlanet, name);

        }

        public string AddUnit(string unitName, string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            if (planet == default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (unitName != nameof(AnonymousImpactUnit) &&
                unitName != nameof(SpaceForces) &&
                unitName != nameof(StormTroopers))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitName));
            }

            if (planet.Army.Any(x => x.GetType().Name == unitName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitName, planetName));
            }

            IMilitaryUnit unit;

            if (unitName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else if (unitName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else
            {
                unit = new AnonymousImpactUnit();
            }

            planet.Spend(unit.Cost);
            planet.AddUnit(unit);

            return string.Format(OutputMessages.UnitAdded, unitName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName != nameof(SpaceMissiles) &&
                weaponTypeName != nameof(BioChemicalWeapon) &&
                weaponTypeName != nameof(NuclearWeapon))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weap;

            if (weaponTypeName == nameof(SpaceMissiles))
            {
                weap = new SpaceMissiles(destructionLevel);
            }
            else if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weap = new BioChemicalWeapon(destructionLevel);
            }
            else
            {
                weap = new NuclearWeapon(destructionLevel);
            }

            planet.Spend(weap.Price);
            planet.AddWeapon(weap);


            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }
        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NoUnitsFound));
            }

            foreach (var unit in planet.Army)
            {
                unit.IncreaseEndurance();
            }

            planet.Spend(1.25);

            return string.Format(OutputMessages.ForcesUpgraded,planetName);
        }
        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet one = planets.FindByName(planetOne);
            IPlanet two = planets.FindByName(planetTwo);
            IPlanet winner;
            IPlanet looser;

            if (one.MilitaryPower > two.MilitaryPower)
            {
                winner = one;
                looser = two;
            }
            else if (one.MilitaryPower < two.MilitaryPower)
            {
                winner = two;
                looser = one;
            }
            else
            {
                if (one.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)) && 
                !two.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
                {
                    winner = one;
                    looser = two;
                }
                else if (!one.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)) &&
                two.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
                {
                    winner = two;
                    looser = one;
                }
                else
                {
                    one.Spend(one.Budget * 0.5);
                    two.Spend(two.Budget * 0.5);

                    return OutputMessages.NoWinner;
                }
            }

            double additionalForcesProfit = looser.Army.Sum(x => x.Cost) + looser.Weapons.Sum(x => x.Price);
            winner.Spend(winner.Budget * 0.5);
            looser.Spend(looser.Budget * 0.5);

            winner.Profit(looser.Budget);
            winner.Profit(additionalForcesProfit);
            planets.RemoveItem(looser.Name);

            return string.Format(OutputMessages.WinnigTheWar, winner.Name, looser.Name);

        }

        public string ForcesReport()
        {
            IOrderedEnumerable<IPlanet> orderdPlanets = planets.Models
                .OrderByDescending(p => p.MilitaryPower)
                .ThenBy(p => p.Name);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in orderdPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }


    }
}
