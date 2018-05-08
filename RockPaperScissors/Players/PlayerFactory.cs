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

        public IPlayer Create(string playerType, string playerName)
        {
            switch (playerType)
            {
                case "human":
                    return new HumanPlayer(playerName);
                case "random":
                    return new RandomPlayer(_randomGenerator);
                default:
                    throw new ArgumentException("not recognized player type");
            }

        }
    }
}