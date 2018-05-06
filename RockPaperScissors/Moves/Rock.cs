namespace RockPaperScissors.Moves
{
    internal class Rock : IMove
    {
        public bool Beats(IMove other)
        {
            return other.GetType() == typeof(Scissors);
        }
    }
}