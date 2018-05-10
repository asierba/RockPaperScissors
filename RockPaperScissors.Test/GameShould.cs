using System;
using System.IO;
using Xunit;
using static RockPaperScissors.Test.Helpers.GameBuilder;

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
        public void CalculateScore(string player1Move, string player2Move, Score expectedScore)
        {
            MockConsoleInput(
                player1Move, 
                player2Move);

            var game = AGame
                .WithNumberOfTurns(1)
                .Build();
            
            game.Play();


            Assert.Contains(
$@"Final score after 1 turns:
{expectedScore}!!", _output.ToString());
        }

        [Fact]
        public void PlayAFullGameOfHumanPlayers()
        {
            MockConsoleInput(
                Scissors, 
                Paper,
                
                Paper, 
                Paper,
                
                Scissors, 
                Paper);

            var game = AGame.Build();
            game.Play();

            Assert.Equal(
@"Player 1 input (P,R,S):Scissors
Player 2 input (P,R,S):Paper
Player1Wins
Player 1 input (P,R,S):Paper
Player 2 input (P,R,S):Paper
Draw
Player 1 input (P,R,S):Scissors
Player 2 input (P,R,S):Paper
Player1Wins

Final score after 3 turns:
Player1Wins!!
 - 2 times Player1Wins 
 - 0 times Player2Wins
 - 1 times Draw
", _output.ToString());
        }

        [Fact]
        public void PlayAFullGameWithTwoRandomCpuPlayers()
        {
            var randomMoves = new []{
                Scissors, 
                Paper,
                
                Paper, 
                Paper,
                
                Rock, 
                Scissors};

            var game = AGame
                .WithPlayer1("random")
                .WithPlayer2("random")
                .WithRandomMoves(randomMoves)
                .Build();
            game.Play();

            Assert.Equal(
                @"Player 1 (Random CPU):S
Scissors
Player 2 (Random CPU):P
Paper
Player1Wins
Player 1 (Random CPU):P
Paper
Player 2 (Random CPU):P
Paper
Draw
Player 1 (Random CPU):R
Rock
Player 2 (Random CPU):S
Scissors
Player1Wins

Final score after 3 turns:
Player1Wins!!
 - 2 times Player1Wins 
 - 0 times Player2Wins
 - 1 times Draw
", _output.ToString());
        }

        [Fact]
        public void PlayAFullGameWithMixOfHumanAndRandomCpuPlayers()
        {
            MockConsoleInput(
                Scissors, 
                Paper, 
                Rock
                );
            var randomMoves = new []{
                Paper,
                Paper,
                Scissors};
          
            var game = AGame
                .WithPlayer1("human")
                .WithPlayer2("random")
                .WithRandomMoves(randomMoves)
                .Build();
            game.Play();


            Assert.Equal(
@"Player 1 input (P,R,S):Scissors
Player 2 (Random CPU):P
Paper
Player1Wins
Player 1 input (P,R,S):Paper
Player 2 (Random CPU):P
Paper
Draw
Player 1 input (P,R,S):Rock
Player 2 (Random CPU):S
Scissors
Player1Wins

Final score after 3 turns:
Player1Wins!!
 - 2 times Player1Wins 
 - 0 times Player2Wins
 - 1 times Draw
", _output.ToString());
        }

        [Fact]
        public void PlayAFullGameOfTwoTacticalPlayers()
        {
            var randomMoves = new []{
                Scissors, 
                Paper};
            
            var game = AGame
                .WithNumberOfTurns(2)
                .WithPlayer1("tactical")
                .WithPlayer2("tactical")
                .WithRandomMoves(randomMoves)
                .Build();
            
            game.Play();

            Assert.Equal(
                @"Player 1 (Tactical CPU):S
Scissors
Player 2 (Tactical CPU):P
Paper
Player1Wins
Player 1 (Tactical CPU):R
Rock
Player 2 (Tactical CPU):S
Scissors
Player1Wins

Final score after 2 turns:
Player1Wins!!
 - 2 times Player1Wins 
 - 0 times Player2Wins
 - 0 times Draw
", _output.ToString());
        }
        
        [Fact]
        public void IgnoreInvalidUserInputAndRequestItAgain()
        {
            MockConsoleInput(
                "Invalid", 
                Scissors, 
                Paper);

            var game = AGame
                .WithNumberOfTurns(1)
                .Build();
            
            game.Play();

            Assert.Contains(
@"Player 1 input (P,R,S):Player 1 input (P,R,S):Scissors
Player 2 input (P,R,S):Paper
Player1Wins", _output.ToString());
            
        }

        private static void MockConsoleInput(params string[] inputs)
        {
            var input = string.Join(Environment.NewLine, inputs);
            Console.SetIn(new StringReader(input));
        }
    }
}