using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models
{
    public class Map : IMap
    {

        public string Fight(ICollection<IHero> players)
        {
            List<IHero> knights = players.Where(p => p.GetType().Name == nameof(Knight)).ToList();
            List<IHero> barbarians = players.Where(p => p.GetType().Name == nameof(Barbarian)).ToList();

            bool IsKnightsWin = false;

            while (true)
            {
                foreach (var knight in knights)
                {
                    if (knight.IsAlive)
                    {
                        foreach (var barbarian in barbarians)
                        {
                            if (barbarian.IsAlive)
                            {
                                barbarian.TakeDamage(knight.Weapon.DoDamage());
                            }
                            
                        }
                    }

                }

                if (!barbarians.Any(h => h.Health > 0))
                {
                    IsKnightsWin = true;
                    break;
                }

                foreach (var barbarian in barbarians)
                {
                    if (barbarian.IsAlive)
                    {
                        foreach (var knight in knights)
                        {
                            if (knight.IsAlive)
                            {
                                knight.TakeDamage(barbarian.Weapon.DoDamage());
                            }
                            
                        }
                    }

                }

                if (!knights.Any(h => h.Health > 0))
                {
                    break;
                }
            }

            if (IsKnightsWin)
            {
                int DKcount = 0;
                foreach (var knight in knights)
                {
                    if (!knight.IsAlive)
                    {
                        DKcount++;
                    }
                }

                return String.Format(OutputMessages.MapFightKnightsWin, DKcount);
            }

            int count = 0;

            foreach (var barbarian in barbarians)
            {
                if (!barbarian.IsAlive)
                {
                    count++;
                }
            }

            return String.Format(OutputMessages.MapFigthBarbariansWin, count);

        }
    }
}
