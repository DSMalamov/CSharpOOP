using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private readonly List<IVessel> vessels;

        public VesselRepository()
        {
            vessels = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => this.vessels;

        public void Add(IVessel model)
        {
            vessels.Add(model);
        }

        public IVessel FindByName(string name)
            => vessels.FirstOrDefault(x => x.Name == name);

        public bool Remove(IVessel model)
        {
            if (vessels.Contains(model))
            {
                vessels.Remove(model);
                return true;
            }

            return false;
            
        }
    }
}
