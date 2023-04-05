using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private ICaptain captain;
        private string name;
        private List<string> targets;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber= mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            targets = new List<string>();
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value; 
            }
        }


        public ICaptain Captain 
        {
            get => captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                captain = value;
            } 
        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; set; }

        public double Speed { get; set; }

        public ICollection<string> Targets => this.targets;

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;
            targets.Add(target.Name);

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;

            }
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($"*Type: {GetType().Name}");
            sb.AppendLine($"*Armor thickness: {ArmorThickness}");
            sb.AppendLine($"*Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($"*Speed: {Speed} knots");

            if (Targets.Count == 0)
            {
                sb.AppendLine("*Targets: None");
            }
            else
            {
                sb.AppendLine($"*Targets: {string.Join(", ", targets)}");
            }

            return sb.ToString().Trim();
        }
    }
}
