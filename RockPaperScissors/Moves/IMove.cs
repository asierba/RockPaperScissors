namespace RockPaperScissors.Moves
{
    internal interface IMove
    {
        bool Beats(IMove other);
    }
}