using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NavalVessels.Core;

public class Controller : IController
{
    private VesselRepository vessels;
    private readonly List<ICaptain> captains;

    public Controller()
    {
        vessels= new VesselRepository();
        captains = new List<ICaptain>();
    }
    public string HireCaptain(string fullName)
    {
        ICaptain captain = new Captain(fullName);

        if (captains.Contains(captain))
        {
            return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
        }

        captains.Add(captain);
        return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
    }
    public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
    {
        if (vessels.FindByName(name) != null)
        {
            return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
        }

        if (vesselType != nameof(Battleship) && vesselType != nameof(Submarine))
        {
            return OutputMessages.InvalidVesselType;
        }

        IVessel vessel = null;

        if (vesselType == nameof(Battleship))
        {
            vessel = new Battleship(name, mainWeaponCaliber, speed);
        }
        else
        {
            vessel = new Submarine(name, mainWeaponCaliber, speed);
        }

        vessels.Add(vessel);

        return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
    }

    public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
    {
        var captain = captains.FirstOrDefault(n => n.FullName == selectedCaptainName);
        var vessel = vessels.FindByName(selectedVesselName);

        if (captain == null)
        {
            return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
        }
        if (vessel == null)
        {
            return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
        }
        if (vessel.Captain != null)
        {
            return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
        }

        vessel.Captain = captain;
        captain.AddVessel(vessel);

        return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
    }
    public string CaptainReport(string captainFullName)
    {
        var captain = captains.FirstOrDefault(c => c.FullName == captainFullName);

        return captain.Report();
    }
    public string VesselReport(string vesselName)
        => vessels.FindByName(vesselName).ToString();

    public string ToggleSpecialMode(string vesselName)
    {
        var vessel = vessels.FindByName(vesselName);

        if (vessel == null)
        {
            return string.Format(OutputMessages.VesselNotFound, vesselName);
        }

        if (vessel.GetType().Name == nameof(Battleship))
        {
            Battleship bship = vessel as Battleship;
            bship.ToggleSonarMode();
            return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
        }
        else
        {
            Submarine sub = vessel as Submarine;
            sub.ToggleSubmergeMode();
            return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
        }
    }
    public string ServiceVessel(string vesselName)
    {
        var vessel = vessels.FindByName(vesselName);

        if (vessel == null)
        {
            return string.Format(OutputMessages.VesselNotFound, vesselName);
        }

        vessel.RepairVessel();
        return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
    }
    public string AttackVessels(string attackingVesselName, string defendingVesselName)
    {
        var vesselA = vessels.FindByName(attackingVesselName);
        var vesselD = vessels.FindByName(defendingVesselName);

        if (vesselA == null)
        {
            return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
        }
        else if (vesselA == null)
        {
            return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
        }

        if (vesselA.ArmorThickness == 0)
        {
            return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
        }
        else if (vesselA.ArmorThickness == 0)
        {
            return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
        }

        vesselA.Attack(vesselD);
        vesselA.Captain.IncreaseCombatExperience();
        vesselD.Captain.IncreaseCombatExperience();

        return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, vesselD.ArmorThickness);

    }



}
