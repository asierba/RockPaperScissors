using System;
using System.IO;
using System.Runtime.CompilerServices;
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
        [InlineData(Rock, Scissors, Score.Player1Wins)]
        [InlineData(Rock, Paper, Score.Player2Wins)]
        [InlineData(Paper, Rock, Score.Player1Wins)]
        [InlineData(Paper, Scissors, Score.Player2Wins)]
        [InlineData(Scissors, Paper, Score.Player1Wins)]
        [InlineData(Scissors, Rock, Score.Player2Wins)]
        [InlineData(Rock, Rock, Score.Draw)] 
        [InlineData(Paper, Paper, Score.Draw)] 
        [InlineData(Scissors, Scissors, Score.Draw)] 
        public void GameOfSinlgeRound(string player1Move, string player2Move, Score score)
        {
            const string numberOfRunds = "1";
            
            MockConsoleInput(
                player1Move, 
                player2Move);

            Program.Main(new[] {numberOfRunds});
            
            Assert.Equal(
$@"Player 1 input (P,R,S):
Player 2 input (P,R,S):
{score}
", _output.ToString());
        }

        private static void MockConsoleInput(params string[] inputs)
        {
            var input = string.Join(Environment.NewLine, inputs);
            Console.SetIn(new StringReader(input));
        }

        [Fact]
        public void InvalidInputGetsIgnoredAndRequestedAgain()
        {
            const string numberOfRunds = "1";

            MockConsoleInput(
                "Invalid", 
                Scissors, 
                Paper);
            
            Program.Main(new string[] {numberOfRunds});
            
            Assert.Equal(
@"Player 1 input (P,R,S):
Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player1Wins
", _output.ToString());
            
        }
        
        [Fact]
        public void GameOf3RoundsByDefault()
        {
            MockConsoleInput(
                Scissors, 
                Paper,
                Scissors, 
                Paper,
                Scissors, 
                Paper);
            
            Program.Main(new string[] {});
            
            Assert.Equal(
@"Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player1Wins
Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player1Wins
Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player1Wins
", _output.ToString());
            
        }
    }
}