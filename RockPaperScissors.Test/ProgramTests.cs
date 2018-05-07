using System;
using System.IO;
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
        public void GameOfSinlgeTurnAsksForInputDisplaysScore(string player1Move, string player2Move, Score expectedScore)
        {
            const string numberOfRunds = "1";
            
            MockConsoleInput(
                player1Move, 
                player2Move);

            Program.Main(new[] {numberOfRunds});
            
            
            Assert.Contains(
$@"Player 1 input (P,R,S):
Player 2 input (P,R,S):
{expectedScore}
", _output.ToString());
        }

        [Fact]
        public void InvalidInputGetsIgnoredAndRequestedAgain()
        {
            const string numberOfRunds = "1";

            MockConsoleInput(
                "Invalid", 
                Scissors, 
                Paper);
            
            Program.Main(new[] {numberOfRunds});
            
            Assert.Contains(
@"Player 1 input (P,R,S):
Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player1Wins", _output.ToString());
            
        }

        [Fact]
        public void GameOf3TurnsAsksForInput3TimesAndDisplaysFinalScore()
        {
            MockConsoleInput(
                Scissors, 
                Paper,
                
                Paper, 
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
Draw
Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player1Wins

Results:
Player1Wins!!
 - 2 times Player1Wins 
 - 0 times Player2Wins
 - 1 times Draw
", _output.ToString());
            
        }

        [Fact]
        public void GameOf3TurnsWhereNobodyWinsIsADraw()
        {
            MockConsoleInput(
                Scissors, 
                Paper,
                
                Paper, 
                Paper,
                
                Paper, 
                Scissors);
            
            Program.Main(new string[] {});
            
            Assert.Equal(
                @"Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player1Wins
Player 1 input (P,R,S):
Player 2 input (P,R,S):
Draw
Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player2Wins

Results:
Draw!!
 - 1 times Player1Wins 
 - 1 times Player2Wins
 - 1 times Draw
", _output.ToString());
            
        }

        private static void MockConsoleInput(params string[] inputs)
        {
            var input = string.Join(Environment.NewLine, inputs);
            Console.SetIn(new StringReader(input));
        }
    }
}