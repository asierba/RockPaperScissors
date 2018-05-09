using System.Drawing;
using Colorful;

namespace RockPaperScissors.UI
{
    public class ConsoleInterface : IUserInterface
    {
        public void Display(object text, bool newLine = true)
        {
            if (newLine)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }
        }

        public void DisplayImportant(object text)
        {
            Console.WriteLine(text, Color.MediumBlue);
        }

        public string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}