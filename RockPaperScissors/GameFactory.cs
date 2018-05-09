using RockPaperScissors.Players;
using RockPaperScissors.UI;

namespace RockPaperScissors
{
    public static class GameFactory
    {
        public static Game Create(string[] args, IRandomGenerator randomGenerator, IUserInterface userInterface)
        {
            var arguments = ArgumentParser.Parse(args);

            var playerFactory = new PlayerFactory(randomGenerator, userInterface);
            var player1 = playerFactory.Create(arguments.PlayerType1, "Player 1");
            var player2 = playerFactory.Create(arguments.PlayerType2, "Player 2");
            return new Game(player1, player2, arguments.NumberOfTurns, userInterface);
        }
    }
}