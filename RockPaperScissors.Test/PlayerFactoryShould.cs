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
        [InlineData(typeof(HumanPlayer), PlayerType.Human)]
        [InlineData(typeof(RandomPlayer), PlayerType.Random)]
        public void CreateAHumanPlayer(Type expectedType, PlayerType playerType)
        {
            var player =  _playerFactory.Create(playerType, "Player 1");
            Assert.IsType(expectedType, player);
        }
    }
}