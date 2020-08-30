using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int damagePointsMagicCard = 5;
        private const int healthPointsMagicCard = 80;

        public MagicCard(string name) : base(name, damagePointsMagicCard, healthPointsMagicCard)
        {

        }
    }
}
