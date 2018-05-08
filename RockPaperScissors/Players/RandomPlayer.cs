using System;
using System.Linq;
using RockPaperScissors.Moves;
using static RockPaperScissors.Players.AllPossibleMoves;

namespace RockPaperScissors.Players
{
    public class RandomPlayer : IPlayer
    {
        private readonly IRandomGenerator _randomGenerator;

        public RandomPlayer(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }
        
        public IMove GetMove()
        {
            var possibleMoves = PossibleMoves;
            var index = _randomGenerator.GetNext(0, possibleMoves.Count-1);
            var move = possibleMoves.ElementAt(index);
            
            Console.WriteLine(move);

            return move;
        }
    }
}