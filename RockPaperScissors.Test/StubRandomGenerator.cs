using System.Collections.Generic;
using System.Linq;
using static RockPaperScissors.Players.AllPossibleMoves;

namespace RockPaperScissors.Test
{
    public class StubRandomGenerator : IRandomGenerator
    {
        private readonly Stack<string> _sequenceOfMoves;

        public StubRandomGenerator(IEnumerable<string> sequenceOfMoves)
        {
            _sequenceOfMoves = new Stack<string>(sequenceOfMoves.Reverse());
        }

        public int GetNext(int min, int max)
        {
            var move = _sequenceOfMoves.Pop();
            return PossibleMoves.FindIndex(x => x.Key == move);
        }
    }
}