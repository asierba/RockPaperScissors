using System;
using RockPaperScissors.Moves;

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
            var move = _randomGenerator.RandomMove();

            Console.WriteLine(move);

            return move;
        }
    }
}