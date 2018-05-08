using System;

namespace RockPaperScissors.Players
{
    public static class PlayerFactory
    {
        public static IPlayer Create(string playerType, string playerName)
        {
            switch (playerType)
            {
                case "human":
                    return new HumanPlayer(playerName);
                case "random":
                    return new RandomPlayer();
                default:
                    throw new ArgumentException("not recognized player type");
            }

        }
    }
}