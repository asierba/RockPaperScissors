using System.Linq;
using RockPaperScissors.Moves;
using RockPaperScissors.UI;
using static RockPaperScissors.Moves.AllPossibleMoves;


namespace RockPaperScissors.Players
{
    public class TacticalPlayer : IPlayer
    {
        private readonly string _playerName;
        private readonly IUserInterface _userInterface;
        private IMove _nextMove;

        public TacticalPlayer(string playerName, IRandomGenerator randomGenerator, IUserInterface userInterface)
        {
            _playerName = $"{playerName} (Tactical CPU)";
            _userInterface = userInterface;
            _nextMove = randomGenerator.RandomMove();
        }

        public IMove GetMove()
        {
            var currentMove = _nextMove;
            _userInterface.Display($"{_playerName}:{currentMove.Key}");
            _nextMove = PossibleMoves.Single(x => x.Beats(currentMove));
            return currentMove;
        }
    }
}