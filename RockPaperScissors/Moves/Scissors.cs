namespace RockPaperScissors.Moves
{
    internal class Scissors : IMove
    {
        public string Key => "S";

        public bool Beats(IMove other)
        {            
            return other.GetType() == typeof(Paper);
        }

        public override string ToString()
        {
            return "Scissors";
        }
    }
}