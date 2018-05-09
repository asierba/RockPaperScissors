using RockPaperScissors.Moves;
using RockPaperScissors.UI;

namespace RockPaperScissors.Players
{
    public class RandomPlayer : IPlayer
    {
        private readonly IRandomGenerator _randomGenerator;
        private readonly IUserInterface _userInterface;

        public RandomPlayer(IRandomGenerator randomGenerator, IUserInterface userInterface)
        {
            _randomGenerator = randomGenerator;
            _userInterface = userInterface;
        }
        
        public IMove GetMove()
        {
            var move = _randomGenerator.RandomMove();
            _userInterface.Display(move);
            return move;
        }
    }
}