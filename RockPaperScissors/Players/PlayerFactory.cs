using System;

namespace RockPaperScissors.Players
{
    public class PlayerFactory
    {
        private readonly IRandomGenerator _randomGenerator;

        public PlayerFactory(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }

        public IPlayer Create(PlayerType playerType, string playerName)
        {
            switch (playerType)
            {
                case PlayerType.Human:
                    return new HumanPlayer(playerName);
                case PlayerType.Random:
                    return new RandomPlayer(_randomGenerator);
                case PlayerType.Tactical:
                    return  new TacticalPlayer(_randomGenerator);
                default:
                    throw new ArgumentException("not recognized player type");
            }

        }
    }
}