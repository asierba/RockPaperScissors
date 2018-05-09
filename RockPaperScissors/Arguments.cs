using RockPaperScissors.Players;

namespace RockPaperScissors
{
    public class Arguments
    {
        public Arguments(int numberOfTurns, PlayerType playerType1, PlayerType playerType2)
        {
            NumberOfTurns = numberOfTurns;
            PlayerType1 = playerType1;
            PlayerType2 = playerType2;
        }

        public int NumberOfTurns { get; }
        public PlayerType PlayerType1 { get; }
        public PlayerType PlayerType2 { get; }
    }
}