using System;

namespace RockPaperScissors
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Player 1 input (P,R,S):");
            var player1Move = Console.ReadLine();
            Console.WriteLine("Player 2 input (P,R,S):");
            var player2Move = Console.ReadLine();

            var result = GetResult(player1Move, player2Move);

            Console.WriteLine(result);
        }

        private static string GetResult(string player1Move, string player2Move)
        {
            if (player1Move == player2Move)
                return "Draw";
            
            if (player1Move == "S" && player2Move == "R")
            {
                return "Player 2 wins";
            }

            if (player1Move == "P" && player2Move == "S")
            {
                return "Player 2 wins";
            }

            return "Player 1 wins";
        }
    }
}