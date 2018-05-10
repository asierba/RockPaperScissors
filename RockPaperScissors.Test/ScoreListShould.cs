using Xunit;

namespace RockPaperScissors.Test
{
    public class ScoreListShould
    {
        [Fact]
        public void CalculateFinalScoreBasedOnMostFrequentWinner()
        {
            var scores = new []
            {
                Score.Player1Wins,
                Score.Draw,
                Score.Player1Wins
            };
            var scoreList = new ScoreList(scores);
            
            Assert.Equal(
@"Final score after 3 turns:
Player1Wins!!
 - 2 times Player1Wins 
 - 0 times Player2Wins
 - 1 times Draw", scoreList.ToString());
        }
        
        [Fact]
        public void CalculateFinalScoreAsDrawWhenNumberOfWinsAreTheEqual()
        {
            var scores = new []
            {
                Score.Player1Wins,
                Score.Draw,
                Score.Player2Wins,
                Score.Player1Wins,
                Score.Player2Wins
            };
            var scoreList = new ScoreList(scores);
            
            Assert.Equal(
@"Final score after 5 turns:
Draw!!
 - 2 times Player1Wins 
 - 2 times Player2Wins
 - 1 times Draw", scoreList.ToString());
            
        }
    }
}