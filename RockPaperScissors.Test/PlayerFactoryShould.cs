using System;
using RockPaperScissors.Players;
using Xunit;

namespace RockPaperScissors.Test
{
    public class PlayerFactoryShould
    {
        [Theory]
        [InlineData(typeof(HumanPlayer), "human")]
        [InlineData(typeof(RandomPlayer), "random")]
        public void CreateAHumanPlayer(Type expectedType, string playerType)
        {
            var player =  PlayerFactory.Create(playerType, "Player 1");
            Assert.IsType(expectedType, player);
        }

        [Fact]
        public void ThrowExceptionWhenNotReconizedPlayer()
        {
            Assert.Throws<ArgumentException>(() =>
                PlayerFactory.Create("invalidplayertype", "Player 1"));
        }
    }
}