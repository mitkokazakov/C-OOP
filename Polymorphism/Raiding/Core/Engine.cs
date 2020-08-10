using Raiding.Models;
using Raiding.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Raiding.Core
{
    public class Engine
    {
        private ICollection<IBaseHero> raidGroup;

        public Engine()
        {
            this.raidGroup = new List<IBaseHero>();
        }

        public void Run()
        {
            IBaseHero hero = null;
            int validHeroes = 0;

            int n = int.Parse(Console.ReadLine());

            while (validHeroes != n)
            {
                string name = Console.ReadLine();
                string heroType = Console.ReadLine();

                hero = TakeHero(hero, name, heroType,ref validHeroes);
            }

            int bossPower = int.Parse(Console.ReadLine());

            if (this.raidGroup.Sum(h => h.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private  IBaseHero TakeHero(IBaseHero hero, string name, string heroType, ref int validHeroes)
        {
            if (heroType == "Druid")
            {
                hero = new Druid(name);
                Console.WriteLine(hero.CastAbility());
                this.raidGroup.Add(hero);
                validHeroes++;
                
            }
            else if (heroType == "Paladin")
            {
                hero = new Paladin(name);
                Console.WriteLine(hero.CastAbility());
                this.raidGroup.Add(hero);
                validHeroes++;
            }
            else if (heroType == "Rogue")
            {
                hero = new Rogue(name);
                Console.WriteLine(hero.CastAbility());
                this.raidGroup.Add(hero);
                validHeroes++;
            }
            else if (heroType == "Warrior")
            {
                hero = new Warrior(name);
                Console.WriteLine(hero.CastAbility());
                this.raidGroup.Add(hero);
                validHeroes++;
            }
            else
            {
                Console.WriteLine("Invalid hero!");
            }

            
            return hero;
        }
    }
}
