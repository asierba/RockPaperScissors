using System.Linq;
using RockPaperScissors.Moves;
using static RockPaperScissors.Moves.AllPossibleMoves;

namespace RockPaperScissors
{
    public interface IRandomGenerator
    {
        int GetNext(int min, int max);
    }

    public static class RandomGeneratorExtensions
    {
        public static IMove RandomMove(this IRandomGenerator randomGenerator)
        {
            var index = randomGenerator.GetNext(0, PossibleMoves.Count - 1);
            return PossibleMoves.ElementAt(index);
        }
    }
}