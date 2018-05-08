using RockPaperScissors.Players;

namespace RockPaperScissors
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var randomGenerator = new RandomGenerator();

            var game = GameFactory.Create(args, randomGenerator);
            game.Play();
        }
    }
}