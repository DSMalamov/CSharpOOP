using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int battertCapasity;
        private List<int> interfaceStandards;

        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model= model;
            BatteryCapacity= batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;
            interfaceStandards = new List<int>();
            BatteryLevel = batteryCapacity;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }

                model = value;
            }
        }

        public int BatteryCapacity
        {
            get => battertCapasity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }

                battertCapasity = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards.AsReadOnly();

        public void Eating(int minutes)
        {
            BatteryLevel += ConvertionCapacityIndex * minutes;

            if (BatteryLevel > BatteryCapacity)
            {
                BatteryLevel = BatteryCapacity;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }

            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);
            BatteryLevel -= supplement.BatteryUsage;
            BatteryCapacity -= supplement.BatteryUsage;
                
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");

            sb.Append("--Supplements installed: ");

            if (InterfaceStandards.Count == 0)
            {
                sb.Append("none");
            }
            else
            {
                sb.AppendLine(string.Join(" ", interfaceStandards));
            }


            return sb.ToString().Trim();
            
        }
    }
}
