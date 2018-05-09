using RockPaperScissors.UI;

namespace RockPaperScissors
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var randomGenerator = new RandomGenerator();
            var consoleInterface = new ConsoleInterface();
            
            var game = GameFactory.Create(args, randomGenerator, consoleInterface);
            game.Play();
        }
    }
}