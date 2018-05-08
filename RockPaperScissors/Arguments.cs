using System.Collections.Generic;

namespace RockPaperScissors
{
    public class Arguments
    {
        public Arguments(int numberOfTurns, string player1, string player2)
        {
            NumberOfTurns = numberOfTurns;
            Player1 = player1;
            Player2 = player2;
        }

        public int NumberOfTurns { get; }
        public string Player1 { get; }
        public string Player2 { get; }
    }
}