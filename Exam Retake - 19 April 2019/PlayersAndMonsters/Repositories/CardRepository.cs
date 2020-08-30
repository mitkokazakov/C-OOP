using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    class CardRepository : ICardRepository
    {
        private List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards;

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.CardCannotBeNull);
            }
            if (this.cards.Contains(card))
            {
                throw new ArgumentException(ExceptionMessages.CardAlreadyExist);
            }
            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            ICard card = this.cards.FirstOrDefault(c => c.Name == name);

            return card;
        }

        public bool Remove(ICard card)
        {
            return this.cards.Remove(card);
        }
    }
}
