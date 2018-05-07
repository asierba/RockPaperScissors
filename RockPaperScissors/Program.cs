using System;
using System.Linq;
using RockPaperScissors.Moves;

namespace RockPaperScissors
{
    public static class Program
    {
        static readonly IMove[] PossibleMoves = {new Paper(), new Rock(), new Scissors()};

        public static void Main(string[] args)
        {
            var player1Move = GetMove("Player 1");
            var player2Move = GetMove("Player 2");

            var score = CalculateScore(player1Move, player2Move);

            ShowResult(score);
        }

        private static IMove GetMove(string playerName)
        {
            var keys = string.Join(',', PossibleMoves.Select(x => x.Key));
            Console.WriteLine($"{playerName} input ({keys}):");
            var playerMove = Console.ReadLine();
            
            return CreatePlayerMove(playerMove);
        }

        private static IMove CreatePlayerMove(string playerMove)
        {
            return PossibleMoves.Single(x => x.Key == playerMove);
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