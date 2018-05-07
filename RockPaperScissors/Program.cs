using System;
using System.Linq;
using RockPaperScissors.Moves;

namespace RockPaperScissors
{
    public static class Program
    {
        private const int DefaultNumbeOfRounds = 3;
        static readonly IMove[] PossibleMoves = {new Paper(), new Rock(), new Scissors()};

        public static void Main(string[] args)
        {
            var numbeOfRounds = args.Length > 0 ? 
                Convert.ToInt32(args[0]) 
                : DefaultNumbeOfRounds;

            do
            {
                var player1Move = GetMove("Player 1");
                var player2Move = GetMove("Player 2");

                var score = CalculateScore(player1Move, player2Move);

                ShowResult(score);
                
                numbeOfRounds--;
            } while (numbeOfRounds > 0);
        }

        private static IMove GetMove(string playerName)
        {
            var keys = string.Join(',', PossibleMoves.Select(x => x.Key));
            Console.WriteLine($"{playerName} input ({keys}):");
            var playerInput = Console.ReadLine();

            var move = CreatePlayerMove(playerInput);

            if (move.GetType() == typeof(InvalidMove))
                return GetMove(playerName);
            
            return move;
        }

        private static IMove CreatePlayerMove(string playerMove)
        {
            return PossibleMoves.SingleOrDefault(x => x.Key == playerMove) 
                   ?? new InvalidMove();
        }

        private static Score CalculateScore(IMove player1Move, IMove player2Move)
        {
            if (player1Move.Beats(player2Move))
                return Score.Player1Wins;

            if (player2Move.Beats(player1Move))
                return Score.Player2Wins;

            return Score.Draw;;
        }

        private static void ShowResult(Score score)
        {
            Console.WriteLine(score);
        }
    }
}