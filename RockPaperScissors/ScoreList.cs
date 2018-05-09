using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissors
{
    public class ScoreList
    {
        private readonly IEnumerable<Score> _scores;

        public ScoreList(IEnumerable<Score> scores)
        {
            _scores = scores;
        }

        public ScoreList Add(Score score)
        {
            return new ScoreList(_scores.Concat(new[]{score}));
        }

        public override string ToString()
        {
            var scores = _scores.ToArray();
            var numOfTurns = scores.Count();
            var timesPlayer1Wins = scores.Count(x => x == Score.Player1Wins);
            var timesPlayer2Wins = scores.Count(x => x == Score.Player2Wins);
            var timesDraw = scores.Count(x => x == Score.Draw);
            var finalScore = GetFinalScore(timesPlayer1Wins, timesPlayer2Wins);

            return $@"Final score after {numOfTurns} turns:
{finalScore}!!
 - {timesPlayer1Wins} times Player1Wins 
 - {timesPlayer2Wins} times Player2Wins
 - {timesDraw} times Draw";
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