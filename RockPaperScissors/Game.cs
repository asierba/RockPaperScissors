using System;
using System.Collections.Generic;
using System.Linq;
using RockPaperScissors.Moves;
using RockPaperScissors.Players;

namespace RockPaperScissors
{
    internal class Game
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private readonly int _numberOfTurns;

        public Game(IPlayer player1, IPlayer player2, int numberOfTurns)
        {
            _player1 = player1;
            _player2 = player2;
            _numberOfTurns = numberOfTurns;
        }
        
        public void Play()
        {
            var scores = PlayTurns(_numberOfTurns);
            DisplayFinalScore(scores);
        }

        private IEnumerable<Score> PlayTurns(int numbeOfTurns) => 
            PlayTurns(numbeOfTurns, Enumerable.Empty<Score>());

        private IEnumerable<Score> PlayTurns(int numbeOfTurns, IEnumerable<Score> scores)
        {
            var player1Move = _player1.GetMove();
            var player2Move = _player2.GetMove();

            var score = CalculateScore(player1Move, player2Move);

            var newScores = scores.Concat(new[] {score});
            DisplayScore(score);

            if (numbeOfTurns == 1)
                return newScores;

            return PlayTurns(numbeOfTurns-1, newScores);
        }

        private static Score CalculateScore(IMove player1Move, IMove player2Move)
        {
            if (player1Move.Beats(player2Move))
                return Score.Player1Wins;

            if (player2Move.Beats(player1Move))
                return Score.Player2Wins;

            return Score.Draw;
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