using System;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace RockPaperScissors.Test
{
    public class SingleRoundTests
    {
        private const string Paper = "P";
        private const string Rock = "R";
        private const string Scissors = "S";
        private readonly StringWriter _output;

        public SingleRoundTests()
        {
            _output = new StringWriter();
            Console.SetOut(_output);
        }
        
        [Theory]
        [InlineData(Rock, Scissors, "Player 1 wins")]
        [InlineData(Rock, Paper, "Player 2 wins")]
        [InlineData(Paper, Rock, "Player 1 wins")]
        [InlineData(Paper, Scissors, "Player 2 wins")]
        [InlineData(Scissors, Paper, "Player 1 wins")]
        [InlineData(Scissors, Rock, "Player 2 wins")]
        [InlineData(Rock, Rock, "Draw")] 
        [InlineData(Paper, Paper, "Draw")] 
        [InlineData(Scissors, Scissors, "Draw")] 
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