using System.Linq;
using RockPaperScissors.Moves;
using RockPaperScissors.Players;
using RockPaperScissors.UI;

namespace RockPaperScissors
{
    public class Game
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private readonly int _numberOfTurns;
        private readonly IUserInterface _userInterface;

        public Game(IPlayer player1, IPlayer player2, int numberOfTurns, IUserInterface userInterface)
        {
            _player1 = player1;
            _player2 = player2;
            _numberOfTurns = numberOfTurns;
            _userInterface = userInterface;
        }
        
        public void Play()
        {
            var scores = PlayTurns(_numberOfTurns);
            _userInterface.Display(scores);
        }

        private ScoreList PlayTurns(int numbeOfTurns) => 
            PlayTurns(numbeOfTurns, new ScoreList(Enumerable.Empty<Score>()));

        private ScoreList PlayTurns(int numbeOfTurns, ScoreList scoreList)
        {
            var player1Move = _player1.GetMove();
            var player2Move = _player2.GetMove();

            var score = CalculateScore(player1Move, player2Move);

            var newScoreList = scoreList.Add(score);
            _userInterface.Display(score);

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
    }
}