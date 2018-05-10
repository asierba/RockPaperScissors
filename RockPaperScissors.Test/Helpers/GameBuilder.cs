using RockPaperScissors.UI;

namespace RockPaperScissors.Test.Helpers
{
    public class GameBuilder
    {
        private int _numberOfTurns = 3;
        private string _playerType1 = "human";
        private string _playerType2  = "human";
        private IRandomGenerator _randomGenerator = new RandomGenerator();
        private readonly ConsoleInterface _consoleInterface = new ConsoleInterface();

        public static GameBuilder AGame => new GameBuilder();

        public GameBuilder WithNumberOfTurns(int numberOfTurns)
        {
            _numberOfTurns = numberOfTurns;
            return this;
        }

        public GameBuilder WithPlayer1(string playerType1)
        {
            _playerType1 = playerType1;
            return this;
        }

        public GameBuilder WithPlayer2(string playerType2)
        {
            _playerType2 = playerType2;
            return this;
        }

        public GameBuilder WithRandomMoves(string[] randomMoves)
        {
            _randomGenerator = new StubRandomGenerator(randomMoves);
            return this;
        }

        public Game Build()
        {
            var args = new[] {"--turns", _numberOfTurns.ToString(), "--player1", _playerType1, "--player2", _playerType2};
            return GameFactory.Create(args, _randomGenerator, _consoleInterface);
        }
    }
}