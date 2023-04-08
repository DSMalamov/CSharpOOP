using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> supplements;

        public SupplementRepository()
        {
            supplements= new List<ISupplement>();
        }

        public void AddNew(ISupplement model)
        {
            supplements.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
            => supplements.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);

        public IReadOnlyCollection<ISupplement> Models()
        {
            return supplements.AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            ISupplement suplement = supplements.FirstOrDefault(s => s.GetType().Name == typeName);

            if (suplement != null)
            {
                supplements.Remove(suplement);
                return true;
            }

            return false;
        }
    }
}
