using System;

namespace RockPaperScissors.Moves
{
    internal class InvalidMove : IMove
    {
        public string Key => throw new NotImplementedException();
        public bool Beats(IMove other)
        {
            throw new NotImplementedException();
        }
    }
}