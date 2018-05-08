using Xunit;

namespace RockPaperScissors.Test
{
    public class ArgumentParserShould
    {
        [Theory]
        [InlineData("2", 2)]
        [InlineData("10", 10)]
        public void ParseNumberOfTurns(string turns, int expectedTurns)
        {
            var args = new[] { "--turns", turns};
            var result = ArgumentParser.Parse(args);
            Assert.Equal(expectedTurns, result.NumberOfTurns);
        }

        [Fact]
        public void DefaultsNumberOfTurnsTo3_WhenNoArgs()
        {
            var args = new string[] {};
            var result = ArgumentParser.Parse(args);
            Assert.Equal(3, result.NumberOfTurns);
        }
        
        [Fact]
        public void DefaultsNumberOfTurnsTo3_WhenNoTurns()
        {
            var args = new[] { "--turns"};
            var result = ArgumentParser.Parse(args);
            Assert.Equal(3, result.NumberOfTurns);
        }
        
        [Fact]
        public void DefaultsNumberOfTurnsTo3_WhenOtherArgs()
        {
            var args = new[] { "--player1", "human"};
            var result = ArgumentParser.Parse(args);
            Assert.Equal(3, result.NumberOfTurns);
        }

        [Theory]
        [InlineData("human")]
        [InlineData("random")]
        [InlineData("tactical")]
        public void ParsePlayer(string playerType)
        {
            var args = new[] { "--player1", playerType};
            var result = ArgumentParser.Parse(args);
            Assert.Equal(playerType, result.Player1);
        }

        [Fact]
        public void DefaultsPlayersToHuman()
        {
            var args = new[] { "--player2"};
            var result = ArgumentParser.Parse(args);
            Assert.Equal("human", result.Player2);
        }
    }
}