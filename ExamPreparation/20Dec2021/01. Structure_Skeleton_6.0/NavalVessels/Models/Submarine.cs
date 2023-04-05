using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double SarmorThickness = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, SarmorThickness)
        {
            SubmergeMode = false;
        }

        public bool SubmergeMode {get; private set;}

        public override void RepairVessel()
        {
            if (ArmorThickness < SarmorThickness)
            {
                ArmorThickness = SarmorThickness;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (SubmergeMode)
            {
                SubmergeMode = false;
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
            else
            {
                SubmergeMode = true;
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
        }

        public override string ToString()
        {
            string result = String.Empty;

            if (SubmergeMode)
            {
                result = "ON";
            }
            else
            {
                result = "OFF";
            }

            return base.ToString() + $"{Environment.NewLine}*Submerge mode: {result}";
        }
    }
}
