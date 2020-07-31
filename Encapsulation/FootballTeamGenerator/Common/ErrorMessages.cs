using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Common
{
    public static class ErrorMessages
    {
        public static string InvalidStatRange = "{0} should be between 0 and 100.";
        public static string InvalidName = "A name should not be empty.";
        public static string MissingPlayer = "Player {0} is not in {1} team.";
        public static string MissingTeam = "Team {0} does not exist.";
    }
}
