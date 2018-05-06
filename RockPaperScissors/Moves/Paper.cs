namespace RockPaperScissors.Moves
{
    internal class Paper : IMove
    {
        public bool Beats(IMove other)
        {
            return other.GetType() == typeof(Rock);
        }
    }
}