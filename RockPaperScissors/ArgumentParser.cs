using System.Collections.Generic;
using System.Linq;
using RockPaperScissors.Players;

namespace RockPaperScissors
{
    public static class ArgumentParser
    {
        private const int DefaultNumbeOfTurns = 3;
        private const PlayerType DefaultPlayerType = PlayerType.Human;
        
        public static Arguments Parse(string[] args)
        {
            var numberOfTurns = ConvertToNumberOfTurns(GetArg(args, "--turns"), DefaultNumbeOfTurns);
            var playerType1 = ConvertToPlayerType(GetArg(args, "--player1"), DefaultPlayerType);
            var playerType2 = ConvertToPlayerType(GetArg(args, "--player2"), DefaultPlayerType);
            return new Arguments(numberOfTurns, playerType1, playerType2);
        }

        private static int ConvertToNumberOfTurns(string numberOfTurnsAsString, int defaultValue)
        {
            if (!int.TryParse(numberOfTurnsAsString, out var numberOfTurns))
                return defaultValue;

            var validNumberOfTurns = numberOfTurns >= 1;
            if (!validNumberOfTurns)
                return defaultValue;

            return numberOfTurns;
        }

        private static PlayerType ConvertToPlayerType(string playerType, PlayerType defaultPlayerType)
        {
            switch (playerType)
            {
                case "human": return PlayerType.Human;
                case "random": return PlayerType.Random;
                case "tactical": return PlayerType.Tactical;
                default: return defaultPlayerType;
            }
        }

        private static string GetArg(IEnumerable<string> args, string argName)
        {
            return args
                .SkipWhile(x => x != argName)
                .Skip(1).FirstOrDefault();
        }
    }
}