namespace RockPaperScissors.Moves
{
    internal class Rock : IMove
    {
        public string Key => "R";

        public bool Beats(IMove other)
        {
            return other.GetType() == typeof(Scissors);
        }

        public override string ToString()
        {
            return "Rock";
        }
    }
}