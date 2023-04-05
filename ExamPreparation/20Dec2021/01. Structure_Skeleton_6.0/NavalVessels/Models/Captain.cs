using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private readonly List<IVessel> vessels;

        public Captain(string fullName)
        {
            FullName = fullName;
            vessels = new List<IVessel>();
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }

        public int CombatExperience { get; private set; }

        public ICollection<IVessel> Vessels => this.vessels;

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");

            if (vessels.Count > 0)
            {
                foreach (var vessel in vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }
            return sb.ToString().Trim();

        }

    }

}
