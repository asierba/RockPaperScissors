using System.Linq;
using RockPaperScissors.Moves;
using RockPaperScissors.UI;
using static RockPaperScissors.Moves.AllPossibleMoves;


namespace RockPaperScissors.Players
{
    public class TacticalPlayer : IPlayer
    {
        private readonly IUserInterface _userInterface;
        private IMove _nextMove;

        public TacticalPlayer(IRandomGenerator randomGenerator, IUserInterface userInterface)
        {
            _userInterface = userInterface;
            _nextMove = randomGenerator.RandomMove();
        }

        public IMove GetMove()
        {
            var currentMove = _nextMove;
            _userInterface.Display(currentMove);
            _nextMove = PossibleMoves.Single(x => x.Beats(currentMove));
            return currentMove;
        }
    }
}