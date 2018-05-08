using System;
using System.Collections.Generic;
using System.Linq;
using RockPaperScissors.Moves;

namespace RockPaperScissors
{
    public static class Game
    {
        static readonly IMove[] PossibleMoves = {new Paper(), new Rock(), new Scissors()};

        public static void Play(int numbeOfTurns)
        {
            var scores = PlayTurns(numbeOfTurns);

            DisplayFinalScore(scores);
        }

        private static IEnumerable<Score> PlayTurns(int numbeOfTurns)
        {
            return PlayTurns(numbeOfTurns, Enumerable.Empty<Score>());
        }
        
        private static IEnumerable<Score> PlayTurns(int numbeOfTurns, IEnumerable<Score> scores)
        {
            var player1Move = GetMove("Player 1");
            var player2Move = GetMove("Player 2");

            var score = CalculateScore(player1Move, player2Move);

            var newScores = scores.Concat(new[] {score});
            DisplayScore(score);

            if (numbeOfTurns == 1)
            {
                return newScores;
            }

            return PlayTurns(numbeOfTurns-1, newScores);
        }
      
        private static IMove GetMove(string playerName)
        {
            var keys = string.Join(',', PossibleMoves.Select(x => x.Key));
            Console.WriteLine($"{playerName} input ({keys}):");
            var playerInput = Console.ReadLine();

            var move = CreatePlayerMove(playerInput);

            if (move.GetType() == typeof(InvalidMove))
                return GetMove(playerName);
            
            return move;
        }

        private static IMove CreatePlayerMove(string playerMove)
        {
            return PossibleMoves.SingleOrDefault(x => x.Key == playerMove) 
                   ?? new InvalidMove();
        }

        private static Score CalculateScore(IMove player1Move, IMove player2Move)
        {
            if (player1Move.Beats(player2Move))
                return Score.Player1Wins;

            if (player2Move.Beats(player1Move))
                return Score.Player2Wins;

            return Score.Draw;;
        }

        private static void DisplayScore(Score score)
        {
            Console.WriteLine(score);
        }

        private static void DisplayFinalScore(IEnumerable<Score> scoresToDisplay)
        {
            var scores = scoresToDisplay.ToArray();
            var numOfTurns = scores.Count();
            var timesPlayer1Wins = scores.Count(x => x == Score.Player1Wins);
            var timesPlayer2Wins = scores.Count(x => x == Score.Player2Wins);
            var timesDraw = scores.Count(x => x == Score.Draw);
            var finalScore = GetFinalScore(timesPlayer1Wins, timesPlayer2Wins);

            Console.WriteLine($@"
Final score after {numOfTurns} turns:
{finalScore}!!
 - {timesPlayer1Wins} times Player1Wins 
 - {timesPlayer2Wins} times Player2Wins
 - {timesDraw} times Draw");
        }

        private static Score GetFinalScore(int timesPlayer1Wins, int timesPlayer2Wins)
        {
            if (timesPlayer1Wins > timesPlayer2Wins)
                return Score.Player1Wins;
            if (timesPlayer2Wins > timesPlayer1Wins)
                return Score.Player2Wins;
            return Score.Draw;
        }
    }
}