using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Models
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        public Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;

        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HeroNameNull);
                }

                name = value;
            }
        }

        public int Health
        {
            get => health;
            private set
            {
                if (value < 0)
                {
                    throw new AggregateException(ExceptionMessages.HeroHealthBelowZero);
                }

                health = value;
            }
        }

        public int Armour
        {
            get => armour;
            private set
            {
                if (value < 0)
                {
                    throw new AggregateException(ExceptionMessages.HeroArmourBelowZero);
                }

                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => this.weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.WeaponNull);
                }

                weapon = value;
            }
        }

        public bool IsAlive => CalculateIsAlive();

        public void AddWeapon(IWeapon weapon)
        {
            if (Weapon == null)
            {
                this.Weapon = weapon;
            }
            
        }

        public void TakeDamage(int points)
        {
            int value = points;

            if (this.Armour > value)
            {
                Armour -= value;
                value = 0;
            }
            else
            {
                value -= Armour;
                Armour = 0;
            }

            if (value > 0 )
            {
                if (Health > value)
                {
                    Health -= value;
                }
                else
                {
                    Health = 0;
                }
            }
            
        }

        private bool CalculateIsAlive()
        {
            if (this.Health > 0)
            {
                return true;
            }

            return false;
        }
    }
}
