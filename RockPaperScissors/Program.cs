using System;
using RockPaperScissors.Moves;

namespace RockPaperScissors
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var player1Move = GetPlayer1Move();
            var player2Move = GetPlayer2Move();

            var score = CalculateScore(player1Move, player2Move);

            ShowResult(score);
        }

        private static IMove GetPlayer1Move()
        {
            Console.WriteLine("Player 1 input (P,R,S):");
            var playerMove = Console.ReadLine();
            
            return CreatePlayerMove(playerMove);
        }

        private static IMove GetPlayer2Move()
        {
            Console.WriteLine("Player 2 input (P,R,S):");
            var playerMove = Console.ReadLine();
            
            return CreatePlayerMove(playerMove);
        }

        private static IMove CreatePlayerMove(string playerMove)
        {
            if (playerMove == "P")
                return new Paper();
            if (playerMove == "R")
                return new Rock();
            if (playerMove == "S")
                return new Scissors();

            throw new ArgumentException("invalid input");
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