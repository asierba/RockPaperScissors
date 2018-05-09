using System;

namespace RockPaperScissors.UI
{
    public class ConsoleInterface : IUserInterface
    {
        public void Display(object text)
        {
            Console.WriteLine(text);
        }

        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}