using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double BSarmorThickness = 300;

        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, BSarmorThickness)
        {
            SonarMode = false;
        }

        public bool SonarMode { get; private set; }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < BSarmorThickness)
            {
                this.ArmorThickness = BSarmorThickness;
            }
        }

        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                SonarMode = false;
            }
            else
            {
                SonarMode = true;
            }
        }

        public override string ToString()
        {
            string result = String.Empty;
            if (SonarMode)
            {
                result = "ON";
            }
            else
            {
                result = "OFF";
            }

            return base.ToString() + $"{Environment.NewLine}*Sonar mode: {result}";
        }
    }
}
