namespace RockPaperScissors.UI
{
    public interface IUserInterface
    {
        void Display(object text, bool newLine = true);
        void DisplayImportant(object text);
        string ReadInput();
    }
}