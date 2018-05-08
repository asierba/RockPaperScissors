using RockPaperScissors.Players;

namespace RockPaperScissors
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var arguments = ArgumentParser.Parse(args);

            var player1 = new HumanPlayer("Player 1");
            var player2 = new HumanPlayer("Player 2");
            var game = new Game(player1, player2);
            game.Play(arguments.NumberOfTurns);
        }
    }
}