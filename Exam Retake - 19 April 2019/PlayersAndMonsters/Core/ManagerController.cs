namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository players;
        private ICardRepository cards;
        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;

        public ManagerController()
        {
            this.players = new PlayerRepository();
            this.cards = new CardRepository();
            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player;

            player = this.playerFactory.CreatePlayer(type,username);

            this.players.Add(player);

            string result = String.Format(ConstantMessages.SuccessfullyAddedPlayer,type,username);

            return result;
        }

        public string AddCard(string type, string name)
        {
            ICard card;

            card = this.cardFactory.CreateCard(type, name);

            this.cards.Add(card);

            string result = String.Format(ConstantMessages.SuccessfullyAddedCard, type, name);

            return result;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            ICard card;
            IPlayer player;

            card = this.cards.Find(cardName);

            player = this.players.Find(username);

            player.CardRepository.Add(card);

            string result = String.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);

            return result;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = this.players.Find(attackUser);
            IPlayer enemyPlayer = this.players.Find(enemyUser);

            BattleField battleField = new BattleField();

            battleField.Fight(attackPlayer,enemyPlayer);

            string result = String.Format(ConstantMessages.FightInfo,attackPlayer.Health,enemyPlayer.Health);

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var player in this.players.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                sb.AppendLine("###");
            }

            

            return sb.ToString().TrimEnd();
        }
    }
}
