using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int LRInterfaceStandard = 20082;
        private const int LRBatteryUsage = 5000;
        public LaserRadar()
            : base(LRInterfaceStandard, LRBatteryUsage)
        {
        }
    }
}
