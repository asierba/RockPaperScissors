using System.Collections.Generic;
using RockPaperScissors.Moves;

namespace RockPaperScissors.Players
{
    public static class AllPossibleMoves
    {
        public static List<IMove> PossibleMoves => 
            new List<IMove> {new Paper(), new Rock(), new Scissors()};
    }
}