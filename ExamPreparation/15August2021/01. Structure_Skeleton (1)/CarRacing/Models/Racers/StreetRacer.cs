using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int SRdrivingExperience = 10;
        private const string SRracingBehavior = "aggressive";
        public StreetRacer(string username, ICar car) 
            : base(username, SRracingBehavior, SRdrivingExperience, car)
        {
        }

        public override void Race()
        {
            this.DrivingExperience += 5;
            base.Race();
        }
    }
}
