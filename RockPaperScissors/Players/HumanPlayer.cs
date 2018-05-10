using System.Linq;
using RockPaperScissors.Moves;
using RockPaperScissors.UI;
using static RockPaperScissors.Moves.AllPossibleMoves;

namespace RockPaperScissors.Players
{
    public class HumanPlayer : IPlayer
    {
        private readonly IUserInterface _userInterface;
        private readonly string _askForInputtext;

        public HumanPlayer(string playerName, IUserInterface userInterface)
        {
            _userInterface = userInterface;
            
            var moveKeys = string.Join(',', PossibleMoves.Select(x => x.Key));
            _askForInputtext = $"{playerName} input ({moveKeys}):";
        }

        public IMove GetMove()
        {
            _userInterface.Display(_askForInputtext, newLine: false);
            var playerInput = _userInterface.ReadInput();

            var move = CreatePlayerMove(playerInput);
            if (move.GetType() == typeof(InvalidMove))
                return GetMove();
            
            return move;
        }
        
        private static IMove CreatePlayerMove(string playerMove)
        {
            return PossibleMoves.SingleOrDefault(x => x.Key == playerMove) 
                   ?? new InvalidMove();
        }
    }
}