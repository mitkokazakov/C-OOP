using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count => this.Players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.PlayerCannotBeNull);
            }
            if (this.players.Contains(player))
            {
                throw new ArgumentException(ExceptionMessages.PlayerAlreadyExist);
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = this.players.FirstOrDefault(p => p.Username == username);

            return player;
        }

        public bool Remove(IPlayer player)
        {
            return this.players.Remove(player);
        }
    }
}
