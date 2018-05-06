namespace RockPaperScissors.Moves
{
    internal class Scissors : IMove
    {
        public bool Beats(IMove other)
        {            
            return other.GetType() == typeof(Paper);
        }
    }
}