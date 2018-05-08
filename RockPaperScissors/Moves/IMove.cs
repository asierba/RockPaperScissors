namespace RockPaperScissors.Moves
{
    public interface IMove
    {
        string Key { get; }
        bool Beats(IMove other);
    }
}