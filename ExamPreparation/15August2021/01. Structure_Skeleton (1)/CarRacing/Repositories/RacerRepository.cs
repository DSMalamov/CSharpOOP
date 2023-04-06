using CarRacing.Models.Cars;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly List<IRacer> racers;

        public RacerRepository()
        {
            racers = new List<IRacer>();
        }
        public IReadOnlyCollection<IRacer> Models => this.racers.AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            racers.Add(model);
        }

        public IRacer FindBy(string property)
            => racers.FirstOrDefault(r => r.Username == property);

        public bool Remove(IRacer model)
        {
            if (racers.Contains(model))
            {
                racers.Remove(model);
                return true;
            }

            return false;
        }
    }
}
