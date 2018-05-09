using System.Collections.Generic;

namespace RockPaperScissors.Moves
{
    public static class AllPossibleMoves
    {
        public static List<IMove> PossibleMoves => 
            new List<IMove> {new Paper(), new Rock(), new Scissors()};
    }
}