using System;
using RockPaperScissors.Players;
using Xunit;

namespace RockPaperScissors.Test
{
    public class PlayerFactoryShould
    {
        private readonly PlayerFactory _playerFactory;

        public PlayerFactoryShould()
        {
            var randomNumberGenerator = new RandomGenerator();
            _playerFactory = new PlayerFactory(randomNumberGenerator);
        }
        
        [Theory]
        [InlineData(typeof(HumanPlayer), "human")]
        [InlineData(typeof(RandomPlayer), "random")]
        public void CreateAHumanPlayer(Type expectedType, string playerType)
        {
            var player =  _playerFactory.Create(playerType, "Player 1");
            Assert.IsType(expectedType, player);
        }

        [Fact]
        public void ThrowExceptionWhenNotReconizedPlayer()
        {
            Assert.Throws<ArgumentException>(() =>
                _playerFactory.Create("invalidplayertype", "Player 1"));
        }
    }
}