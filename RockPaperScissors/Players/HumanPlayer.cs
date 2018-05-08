using System;
using System.Linq;
using RockPaperScissors.Moves;

namespace RockPaperScissors.Players
{
    internal class HumanPlayer : IPlayer
    {
        private static readonly IMove[] PossibleMoves = {new Paper(), new Rock(), new Scissors()};
        
        private readonly string _playerName;

        public HumanPlayer(string playerName)
        {
            _playerName = playerName;
        }

        public IMove GetMove()
        {
            var keys = string.Join(',', PossibleMoves.Select(x => x.Key));
            Console.WriteLine($"{_playerName} input ({keys}):");
            var playerInput = Console.ReadLine();

            var move = CreatePlayerMove(playerInput);

            if (move.GetType() == typeof(InvalidMove))
                return GetMove();
            
            return move;
        }
        
        private static IMove CreatePlayerMove(string playerMove)
        {
            return PossibleMoves.SingleOrDefault(x => x.Key == playerMove) 
                   ?? new InvalidMove();
        }
    }
}