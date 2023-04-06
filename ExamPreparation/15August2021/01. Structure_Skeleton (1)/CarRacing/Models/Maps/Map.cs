using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            if (true)
            {

            }
            double racerOneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * RacingFactor(racerOne);
            double racerTwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * RacingFactor(racerTwo);
            racerOne.Race();
            racerTwo.Race();
            IRacer winner = null;
            
            if (racerOneChance > racerTwoChance)
            {
                winner = racerOne;
            }
            else
            {
                winner = racerTwo;
            }

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
        }

        private double RacingFactor(IRacer racer)
        {
            double factor = 0;

            if (racer.RacingBehavior == "strict")
            {
                factor = 1.2;
            }
            else if (racer.RacingBehavior == "aggressive")
            {
                factor= 1.1;
            }

            return factor;
        }
    }
}
