namespace RockPaperScissors.Moves
{
    internal class Paper : IMove
    {
        public string Key => "P";

        public bool Beats(IMove other)
        {
            return other.GetType() == typeof(Rock);
        }

        public override string ToString()
        {
            return "Paper";
        }
    }
}