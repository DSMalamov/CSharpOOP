using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int SAInterfaceStandard = 10045;
        private const int SABatteryUsage = 10000;
        public SpecializedArm() 
            : base(SAInterfaceStandard, SABatteryUsage)
        {
        }
    }
}
