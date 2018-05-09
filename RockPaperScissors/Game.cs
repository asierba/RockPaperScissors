using System;
using System.Linq;
using RockPaperScissors.Moves;
using RockPaperScissors.Players;

namespace RockPaperScissors
{
    public class Game
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

        private ScoreList PlayTurns(int numbeOfTurns) => 
            PlayTurns(numbeOfTurns, new ScoreList(Enumerable.Empty<Score>()));

        private ScoreList PlayTurns(int numbeOfTurns, ScoreList scoreList)
        {
            var player1Move = _player1.GetMove();
            var player2Move = _player2.GetMove();

            var score = CalculateScore(player1Move, player2Move);

            var newScoreList = scoreList.Add(score);
            DisplayScore(score);

            if (numbeOfTurns == 1)
                return newScoreList;

            return PlayTurns(numbeOfTurns-1, newScoreList);
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

        private static void DisplayFinalScore(ScoreList scores)
        {
            Console.WriteLine(scores);
        }
    }
}