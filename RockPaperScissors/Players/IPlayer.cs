using RockPaperScissors.Moves;

namespace RockPaperScissors.Players
{
    public interface IPlayer
    {
        IMove GetMove();
    }
}