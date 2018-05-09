using System;

namespace RockPaperScissors
{
    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random _random;

        public RandomGenerator()
        {
            _random = new Random();
        }
        
        public int GetNext(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}