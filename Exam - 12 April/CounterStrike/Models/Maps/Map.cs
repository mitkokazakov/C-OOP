using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            List<IPlayer> terrorists = players.Where(p => p.GetType().Name == "Terrorist" && p.IsAlive == true).ToList();
            List<IPlayer> counterTerrorists = players.Where(p => p.GetType().Name == "CounterTerrorist" && p.IsAlive == true).ToList();

            while (true)
            {
                // Terrorists atack
                foreach (var terrorist in terrorists.Where(t => t.IsAlive == true))
                {
                    foreach (var counterTerrorist in counterTerrorists.Where(ct => ct.IsAlive == true))
                    {
                        
                            counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                        
                    }
                }

                if (!counterTerrorists.Any(ct => ct.IsAlive == true))
                {
                    return "Terrorist wins!";
                    
                }

                //Counter terrorist attack
                foreach (var counterTerrorist in counterTerrorists.Where(ct => ct.IsAlive == true))
                {
                    foreach (var terrorist in terrorists.Where(t => t.IsAlive == true))
                    {
                        
                            terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                        
                    }
                }

                if (!terrorists.Any(ct => ct.IsAlive == true))
                {
                    return "Counter Terrorist wins!";
                   
                }
            }
        }
    }
}
