using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var numbeOfTurns = GetNumbeOfTurns(args);

            Game.Play(numbeOfTurns);
        }

        private static int GetNumbeOfTurns(IReadOnlyList<string> args)
        {
            const int defaultNumbeOfTurns = 3;

            return args.Count > 0 ? 
                Convert.ToInt32(args[1]) 
                : defaultNumbeOfTurns;
        }
    }
}