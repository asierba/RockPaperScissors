using System;
using RockPaperScissors.UI;

namespace RockPaperScissors.Players
{
    public class PlayerFactory
    {
        private readonly IRandomGenerator _randomGenerator;
        private readonly IUserInterface _userInterface;

        public PlayerFactory(IRandomGenerator randomGenerator, IUserInterface userInterface)
        {
            _randomGenerator = randomGenerator;
            _userInterface = userInterface;
        }

        public IPlayer Create(PlayerType playerType, string playerName)
        {
            switch (playerType)
            {
                case PlayerType.Human:
                    return new HumanPlayer(playerName, _userInterface);
                case PlayerType.Random:
                    return new RandomPlayer(playerName, _randomGenerator, _userInterface);
                case PlayerType.Tactical:
                    return  new TacticalPlayer(playerName, _randomGenerator, _userInterface);
                default:
                    throw new ArgumentException("not recognized player type");
            }

        }
    }
}