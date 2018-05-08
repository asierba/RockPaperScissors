using RockPaperScissors.Players;

namespace RockPaperScissors
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var arguments = ArgumentParser.Parse(args);

            var player1 = PlayerFactory.Create(arguments.Player1, "Player 1");
            var player2 = PlayerFactory.Create(arguments.Player1, "Player 2");
            var game = new Game(player1, player2, arguments.NumberOfTurns);
            game.Play();
        }
    }
}