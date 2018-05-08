using System;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors
{
    public static class ArgumentParser
    {
        public static Arguments Parse(string[] args)
        {
            const string defaultNumbeOfTurns = "3";
            const string defaultPlayer = "human";

            var numberOfTurns = Convert.ToInt32(ParseArg(args, "--turns", defaultNumbeOfTurns));
            var player1 = ParseArg(args, "--player1", defaultPlayer);
            var player2 = ParseArg(args, "--player2", defaultPlayer);

            return new Arguments(numberOfTurns, player1, player2);
        }
        
        private static string ParseArg(IEnumerable<string> args, string argName, string defaultValue)
        {
            var value = args
                .SkipWhile(x => x != argName)
                .Skip(1).FirstOrDefault();
            return value ?? defaultValue;
        }
    }
}