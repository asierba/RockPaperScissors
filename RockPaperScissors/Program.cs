namespace RockPaperScissors
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var arguments = ArgumentParser.Parse(args);

            Game.Play(arguments.NumberOfTurns);
        }
    }
}