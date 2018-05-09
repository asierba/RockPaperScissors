using System;
using System.Linq;
using RockPaperScissors.Moves;
using static RockPaperScissors.Moves.AllPossibleMoves;


namespace RockPaperScissors.Players
{
    public class TacticalPlayer : IPlayer
    {
        private IMove _nextMove;

        public TacticalPlayer(IRandomGenerator randomGenerator)
        {
            _nextMove = randomGenerator.RandomMove();
        }

        public IMove GetMove()
        {
            var currentMove = _nextMove;
            _nextMove = PossibleMoves.Single(x => x.Beats(currentMove));
            
            Console.WriteLine(currentMove);

            return currentMove;
        }
    }
}