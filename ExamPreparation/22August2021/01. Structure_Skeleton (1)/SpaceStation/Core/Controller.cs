using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int exploretPlanetsCount = 0;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            if (type != nameof(Biologist) && type != nameof(Geodesist) && type != nameof(Meteorologist))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            IAstronaut astronaut = null;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else
            {
                astronaut = new Meteorologist(astronautName);
            }

            astronauts.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);

        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
            
        }
        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronauts.Remove(astronaut);

            return string.Format(OutputMessages.AstronautRetired,astronautName);

        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> astForMission = new List<IAstronaut>();

            foreach (var astronaut in this.astronauts.Models)
            {
                if (astronaut.Oxygen > 60)
                {
                    astForMission.Add(astronaut);
                }
            }

            if (astForMission.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            var planet = planets.FindByName(planetName);

            IMission mission = new Mission();
            mission.Explore(planet, astForMission);
            exploretPlanetsCount++;

            return string.Format(OutputMessages.PlanetExplored, planetName, astForMission.Where(a => a.CanBreath == false).Count());
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploretPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");

                if (astronaut.Bag.Items.Count > 0)
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
                else
                {
                    sb.AppendLine("Bag items: none");
                }
            }

            return sb.ToString().Trim();
        }

    }
}
