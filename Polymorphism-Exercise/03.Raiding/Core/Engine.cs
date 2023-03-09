using _03.Raiding.Core.Interface;
using _03.Raiding.Factory.Interface;
using _03.Raiding.Models;
using _03.Raiding.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Raiding.Core;

public class Engine : IEngine
{
    private readonly ICollection<IBaseHero> heroes;
    private readonly IFactory heroFactory;

    public Engine(IFactory heroFactory)
    {
        heroes = new List<IBaseHero>();
        this.heroFactory = heroFactory;
    }
    public void Run()
    {
        int n = int.Parse(Console.ReadLine());

        CreateHero(n);

        int bossPower = int.Parse(Console.ReadLine());
        int teamPower = heroes.Sum(n => n.Power);

        foreach (var item in heroes)
        {
            Console.WriteLine(item.CastAbility());
        }

        if (teamPower >= bossPower)
        {
            Console.WriteLine("Victory!");
        }
        else
        {
            Console.WriteLine("Defeat...");
        }


    }

    private void CreateHero(int n)
    {
        while (heroes.Count < n)
        {
            string name = Console.ReadLine();
            string heroType = Console.ReadLine();

            try
            {
                heroes.Add(heroFactory.Create(heroType, name));
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
