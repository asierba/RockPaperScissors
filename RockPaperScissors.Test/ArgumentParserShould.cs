using RockPaperScissors.Players;
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
        
        [Theory]
        [InlineData("nonenumeric")]
        [InlineData("-3")]
        [InlineData("0")]
        public void DefaultsNumberOfTurnsTo3_WhenInvalidNumber(string turns)
        {
            var args = new[] { "--turns", turns};
            var result = ArgumentParser.Parse(args);
            Assert.Equal(3, result.NumberOfTurns);
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
        [InlineData("human", PlayerType.Human)]
        [InlineData("random", PlayerType.Random)]
        [InlineData("tactical", PlayerType.Tactical)]
        public void ParsePlayer(string playerTypeArg, PlayerType playerType)
        {
            var args = new[] { "--player1", playerTypeArg, "--player2", playerTypeArg};
            var result = ArgumentParser.Parse(args);
            Assert.Equal(playerType, result.PlayerType1);
            Assert.Equal(playerType, result.PlayerType2);
        }

        [Fact]
        public void DefaultsPlayersToHuman()
        {
            var args = new[] { "--player2"};
            var result = ArgumentParser.Parse(args);
            Assert.Equal(PlayerType.Human, result.PlayerType2);
        }
        
        [Fact]
        public void DefaultsPlayersToHuman_WhenInvalidPlayerType()
        {
            var args = new[] { "--player1", "invalidtype", "--player2", "invalidtype"};
            var result = ArgumentParser.Parse(args);
            Assert.Equal(PlayerType.Human, result.PlayerType1);
            Assert.Equal(PlayerType.Human, result.PlayerType2);
        }
    }
}