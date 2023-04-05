using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly List<IGym> gyms;
        private EquipmentRepository equipment;
        public Controller()
        {
            gyms = new List<IGym>();
            equipment = new EquipmentRepository();
        }
        
        public string AddGym(string gymType, string gymName)
        {
            if (gymType != nameof(BoxingGym) && gymType != nameof(WeightliftingGym))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            IGym gym = null;

            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }

            gyms.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != nameof(BoxingGloves) && equipmentType != nameof(Kettlebell))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            IEquipment thing = null;

            if (equipmentType == nameof(BoxingGloves))
            {
                thing = new BoxingGloves();
            }
            else 
            {
                thing = new Kettlebell();
            }

            equipment.Add(thing);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var currEquipment = equipment.FindByType(equipmentType);
            var currGym = gyms.FirstOrDefault(n => n.Name == gymName);
            
            if (currEquipment == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            currGym.AddEquipment(currEquipment);
            equipment.Remove(currEquipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gym = gyms.FirstOrDefault(n => n.Name == gymName);

            if (athleteType != nameof(Boxer) && athleteType != nameof(Weightlifter))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            if ((gym.GetType().Name == nameof(BoxingGym) && athleteType == nameof(Weightlifter)) 
                || (gym.GetType().Name == nameof(WeightliftingGym) && athleteType == nameof(Boxer)))
            {
                return OutputMessages.InappropriateGym;
            }

            IAthlete athlete = null;

            if (athleteType == nameof(Boxer))
            {
                athlete =  new Boxer(athleteName, motivation, numberOfMedals);
            }
            else
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }


            gym.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }
        public string TrainAthletes(string gymName)
        {
            var gym = gyms.FirstOrDefault(n => n.Name == gymName);

            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count());
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(n => n.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().Trim();
        }





    }
}
