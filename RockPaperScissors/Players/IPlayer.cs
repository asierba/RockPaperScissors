using RockPaperScissors.Moves;

namespace RockPaperScissors.Players
{
    internal interface IPlayer
    {
        IMove GetMove();
    }
}