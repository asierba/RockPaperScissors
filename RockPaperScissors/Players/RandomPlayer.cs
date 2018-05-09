using RockPaperScissors.Moves;
using RockPaperScissors.UI;

namespace RockPaperScissors.Players
{
    public class RandomPlayer : IPlayer
    {
        private readonly string _playerName;
        private readonly IRandomGenerator _randomGenerator;
        private readonly IUserInterface _userInterface;

        public RandomPlayer(string playerName, IRandomGenerator randomGenerator, IUserInterface userInterface)
        {
            _playerName = $"{playerName} (Random CPU)";
            _randomGenerator = randomGenerator;
            _userInterface = userInterface;
        }
        
        public IMove GetMove()
        {
            var move = _randomGenerator.RandomMove();
            _userInterface.Display($"{_playerName}:{move.Key}");
            return move;
        }
    }
}