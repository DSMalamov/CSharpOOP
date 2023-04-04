using Heroes.Core.Contracts;
using Heroes.Models;
using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Core
{
    public class Controller : IController
    {
        private HeroRepository heroes;
        private WeaponRepository weapons;

        public Controller()
        {
            heroes = new HeroRepository();
            weapons = new WeaponRepository();
        }
        public string CreateHero(string type, string name, int health, int armour)
        {
            if (heroes.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyExist, name));
            }
            if (type != nameof(Knight) && type != nameof(Barbarian))
            {
                throw new InvalidOperationException(OutputMessages.HeroTypeIsInvalid);
            }

            IHero hero = null;

            if (type == nameof(Knight))
            {
                hero = new Knight(name, health, armour);
                heroes.Add(hero);
                return string.Format(OutputMessages.SuccessfullyAddedKnight, name);
            }
            else
            {
                hero = new Barbarian(name, health, armour);
                heroes.Add(hero);
                return string.Format(OutputMessages.SuccessfullyAddedBarbarian, name);
            }

        }
        public string CreateWeapon(string type, string name, int durability)
        {
            if (weapons.FindByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponAlreadyExists, name));
            }
            if (type != nameof(Mace) && type != nameof(Claymore))
            {
                throw new InvalidOperationException(OutputMessages.WeaponTypeIsInvalid);
            }

            IWeapon weapon = null;

            if (type == nameof(Mace))
            {
                weapon = new Mace(name, durability);
                weapons.Add(weapon);
            }
            else
            {
                weapon = new Claymore(name, durability);
                weapons.Add(weapon);
            }

            return string.Format(OutputMessages.WeaponAddedSuccessfully, type.ToLower(), name);
        }

        public string AddWeaponToHero(string weaponName, string heroName)
        {

            if (heroes.FindByName(heroName) == null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroDoesNotExist, heroName));
            }

            if (weapons.FindByName(weaponName) == null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.WeaponDoesNotExist, weaponName));
            }

            IHero hero = heroes.FindByName(heroName);
            IWeapon weapon = weapons.FindByName(weaponName);

            if (hero.Weapon != null)
            {
                throw new InvalidOperationException(string.Format(OutputMessages.HeroAlreadyHasWeapon, heroName));
            }

            hero.AddWeapon(weapon);
            weapons.Remove(weapon);
            return string.Format(OutputMessages.WeaponAddedToHero, heroName, weapon.GetType().Name.ToLower());
        }
        public string StartBattle()
        {
            ICollection<IHero> players = heroes.Models.Where(h => h.IsAlive && h.Weapon != null).ToList();
            IMap map = new Map();
            string result = map.Fight(players);

            return result;
            
        }

        public string HeroReport()
        {
            var orderdHeroes = heroes.Models
                .OrderBy(h => h.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(h => h.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var hero in orderdHeroes)
            {
                sb.AppendLine($"{hero.GetType().Name}: {hero.Name}");
                sb.AppendLine($"--Health: {hero.Health}");
                sb.AppendLine($"--Armour: {hero.Armour}");

                if (hero.Weapon == null)
                {
                    sb.AppendLine("--Weapon: Unarmed");
                }
                else
                {
                    sb.AppendLine($"--Weapon: {hero.Weapon.Name}");
                }
            }

            return sb.ToString().Trim();
        }

    }
}
