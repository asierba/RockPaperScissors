using System;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace RockPaperScissors.Test
{
    public class SingleRoundTests
    {
        private readonly StringWriter _output;

        public SingleRoundTests()
        {
            _output = new StringWriter();
            Console.SetOut(_output);
        }
        
        [Theory]
        [InlineData("P", "R", "Player 1 wins")]
        [InlineData("R", "S", "Player 1 wins")]
        [InlineData("S", "R", "Player 2 wins")]
        [InlineData("P", "S", "Player 2 wins")] 
        [InlineData("S", "S", "Draw")] 
        [InlineData("R", "R", "Draw")] 
        [InlineData("P", "P", "Draw")] 
        public void SingleGame(string player1Move, string player2Move, string result)
        {
            MockConsoleInput(
                player1Move, 
                player2Move);
            
            Program.Main(new string[] {});
            
            Assert.Equal($@"Player 1 input (P,R,S):
Player 2 input (P,R,S):
{result}
", _output.ToString());
        }

        private static void MockConsoleInput(params string[] inputs)
        {
            var input = string.Join(Environment.NewLine, inputs);
            Console.SetIn(new StringReader(input));
        }
    }
}