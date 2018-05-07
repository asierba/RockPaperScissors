namespace RockPaperScissors.Moves
{
    internal interface IMove
    {
        string Key { get; }
        bool Beats(IMove other);
    }
}