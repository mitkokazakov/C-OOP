using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Common
{
    public static class ExceptionMessages
    {
        public static string InvalidPlayerName = "Player's username cannot be null or an empty string.";

        public static string InvalidPLayerHealth = "Player's health bonus cannot be less than zero.";

        public static string InvalidDamagePoints = "Damage points cannot be less than zero.";

        public static string InvalidCardName = "Card's name cannot be null or an empty string.";

        public static string InvalidCardDamagePoints = "Card's damage points cannot be less than zero.";

        public static string InvalidCardHealthPoints = "Card's HP cannot be less than zero.";

        public static string PlayerDead = "Player is dead!";

        public static string PlayerCannotBeNull = "Player cannot be null";

        public static string PlayerAlreadyExist = "Player {username} already exists!";

        public static string CardCannotBeNull = "Card cannot be null!";

        public static string CardAlreadyExist = "Card {name} already exists!";


    }
}
