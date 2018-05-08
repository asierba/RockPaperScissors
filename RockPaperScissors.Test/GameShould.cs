using System;
using System.IO;
using Xunit;

namespace RockPaperScissors.Test
{
    public class GameShould
    {
        private const string Paper = "P";
        private const string Rock = "R";
        private const string Scissors = "S";
        private readonly StringWriter _output;

        public GameShould()
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
        public void AskForUserInputAndDisplayScoreForEachTurm(string player1Move, string player2Move, Score expectedScore)
        {
            const string numberOfRounds = "1";
            
            MockConsoleInput(
                player1Move, 
                player2Move);

            Program.Main(new[] {numberOfRounds});
            
            
            Assert.Contains(
$@"Player 1 input (P,R,S):
Player 2 input (P,R,S):
{expectedScore}
", _output.ToString());
        }

        [Fact]
        public void IgnoreInvalidUserInputAndRequestItAgain()
        {
            const string numberOfRounds = "1";

            MockConsoleInput(
                "Invalid", 
                Scissors, 
                Paper);
            
            Program.Main(new[] {numberOfRounds});
            
            Assert.Contains(
@"Player 1 input (P,R,S):
Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player1Wins", _output.ToString());
            
        }

        [Fact]
        public void DisplayFinalScore()
        {
            const string numberOfRounds = "3";
            
            MockConsoleInput(
                Scissors, 
                Paper,
                
                Paper, 
                Paper,
                
                Scissors, 
                Paper);
            
            Program.Main(new[] {numberOfRounds});
            
            Assert.Contains(
@"Final score after 3 turns:
Player1Wins!!
 - 2 times Player1Wins 
 - 0 times Player2Wins
 - 1 times Draw
", _output.ToString());
            
        }

        [Fact]
        public void DisplayFinalScoreAsDrawWhenNobodyWins()
        {
            const string numberOfRounds = "3";
            
            MockConsoleInput(
                Scissors, 
                Paper,
                
                Paper, 
                Paper,
                
                Paper, 
                Scissors);
            
            Program.Main(new[] {numberOfRounds});
            
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

Final score after 3 turns:
Draw!!
 - 1 times Player1Wins 
 - 1 times Player2Wins
 - 1 times Draw
", _output.ToString());
            
        }

        [Fact]
        public void ConsistOf3TurnsByDefault()
        {
            MockConsoleInput(
                Scissors, 
                Paper,
                
                Paper, 
                Paper,
                
                Scissors, 
                Paper);
            
            Program.Main(new string[] {});
            
            Assert.Contains(
                "Final score after 3 turns:", 
                _output.ToString());
            
        }

        [Fact]
        public void PlayAFullGame()
        {
            const string numberOfRunds = "5";
            
            MockConsoleInput(
                Scissors, 
                Paper,
                
                Paper, 
                Paper,
                
                Scissors, 
                Paper,
                
                Rock, 
                Paper,
                
                Rock,
                Rock);
            
            Program.Main(new[] {numberOfRunds});
            
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
Player 1 input (P,R,S):
Player 2 input (P,R,S):
Player2Wins
Player 1 input (P,R,S):
Player 2 input (P,R,S):
Draw

Final score after 5 turns:
Player1Wins!!
 - 2 times Player1Wins 
 - 1 times Player2Wins
 - 2 times Draw
", _output.ToString());
            
        }

        private static void MockConsoleInput(params string[] inputs)
        {
            var input = string.Join(Environment.NewLine, inputs);
            Console.SetIn(new StringReader(input));
        }
    }
}