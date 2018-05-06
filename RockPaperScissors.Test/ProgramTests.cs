using System;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace RockPaperScissors.Test
{
    public class ProgramTests
    {
        private const string Paper = "P";
        private const string Rock = "R";
        private const string Scissors = "S";
        private readonly StringWriter _output;

        public ProgramTests()
        {
            _output = new StringWriter();
            Console.SetOut(_output);
        }
        
        [Theory]
        [InlineData(Rock, Scissors, "Player1Wins")]
        [InlineData(Rock, Paper, "Player2Wins")]
        [InlineData(Paper, Rock, "Player1Wins")]
        [InlineData(Paper, Scissors, "Player2Wins")]
        [InlineData(Scissors, Paper, "Player1Wins")]
        [InlineData(Scissors, Rock, "Player2Wins")]
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