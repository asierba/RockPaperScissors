using RockPaperScissors.Players;

namespace RockPaperScissors
{
    public static class GameFactory
    {
        public static Game Create(string[] args, IRandomGenerator randomGenerator)
        {
            var arguments = ArgumentParser.Parse(args);

            var playerFactory = new PlayerFactory(randomGenerator);
            var player1 = playerFactory.Create(arguments.Player1, "Player 1");
            var player2 = playerFactory.Create(arguments.Player2, "Player 2");
            return new Game(player1, player2, arguments.NumberOfTurns);
        }
    }
}