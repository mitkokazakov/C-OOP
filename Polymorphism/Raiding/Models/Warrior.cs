using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WARRIOR_POWER = 100;

        public Warrior(string name) : base(name, WARRIOR_POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {base.Name} hit for {WARRIOR_POWER} damage";
        }
    }
}
