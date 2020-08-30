using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;
            ICardRepository cards = new CardRepository();

            if (type == "Beginner")
            {
                player = new Beginner(cards,username);
            }
            else if (type == "Advanced")
            {
                player = new Advanced(cards, username);
            }

            return player;
        }
    }
}
