using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int damagePointsTrapCard = 120;
        private const int healthPointsTrapCard = 5;

        public TrapCard(string name) : base(name, damagePointsTrapCard, healthPointsTrapCard)
        {
        }
    }
}
