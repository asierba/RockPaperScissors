using System.Collections.Generic;
using System.Linq;
using RockPaperScissors.Moves;

namespace RockPaperScissors.Test.Helpers
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
            return AllPossibleMoves.PossibleMoves.FindIndex(x => x.Key == move);
        }
    }
}