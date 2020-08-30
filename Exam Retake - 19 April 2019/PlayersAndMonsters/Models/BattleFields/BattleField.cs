using PlayersAndMonsters.Common;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            List<ICard> attackerCards = new List<ICard>();
            List<ICard> enemyCards = new List<ICard>();

            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.PlayerDead);
            }

            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health += 40;
                attackerCards = (List<ICard>)attackPlayer.CardRepository.Cards;

                foreach (var card in attackerCards)
                {
                    card.DamagePoints += 30;
                }

                //attackerCards.Select(c => c.DamagePoints += 30);
            }
            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += 40;
                enemyCards = (List<ICard>)enemyPlayer.CardRepository.Cards;

                foreach (var card in enemyCards)
                {
                    card.DamagePoints += 30;
                }
                //enemyCards.Select(c => c.DamagePoints += 30);
            }

            attackerCards = (List<ICard>)attackPlayer.CardRepository.Cards;
            enemyCards = (List<ICard>)enemyPlayer.CardRepository.Cards;

            attackPlayer.Health += attackerCards.Sum(c => c.HealthPoints);
            enemyPlayer.Health += enemyCards.Sum(c => c.HealthPoints);

            int attackerDamagePoints = attackerCards.Sum(c => c.DamagePoints);
            int enemyDamagePoints = enemyCards.Sum(c => c.DamagePoints);

            while(true)
            {
               
                enemyPlayer.TakeDamage(attackerDamagePoints);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyDamagePoints);

                if (attackPlayer.IsDead)
                {
                    break;
                }

            }
        }
    }
}
