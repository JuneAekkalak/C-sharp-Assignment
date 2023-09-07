using System;

enum GuessResult
{
    Correct = 0,
    Incorrect = 1,
    Duplicate = 2
}

class HangmanService
{
    private string[] words = { "Softsquaregroup", "Traveller" };
    private string? selectedWord;
    private char[]? guessedLetters;
    private int remainingTry;

    public void Restart()
    {
        Random random = new Random();
        selectedWord = words[random.Next(words.Length)];
        if (selectedWord != null)
        {
            guessedLetters = new char[selectedWord.Length];
            Array.Fill(guessedLetters, '_');
        }
        remainingTry = 10;
    }

    public string GetDisplay()
    {
        return new string(guessedLetters);
    }

    public GuessResult Input(char character)
    {
        if (selectedWord == null)
        {
            throw new InvalidOperationException("Game not started. Call Restart() first.");
        }

        if (IsGuessed(character))
        {
            return GuessResult.Duplicate;
        }

        bool isCorrectGuess = false;
        for (int i = 0; i < selectedWord.Length; i++)
        {
            if (selectedWord[i] == character)
            {
                guessedLetters![i] = character;
                isCorrectGuess = true;
            }
        }

        if (isCorrectGuess)
        {
            if (new string(guessedLetters) == selectedWord)
            {
                return GuessResult.Correct; 
            }
            return GuessResult.Correct;
        }
        else
        {
            remainingTry--;
            return GuessResult.Incorrect;
        }
    }

    public int GetRemainingTry()
    {
        return remainingTry;
    }

    private bool IsGuessed(char character)
    {
        if (selectedWord != null && guessedLetters != null)
        {
            return Array.IndexOf(guessedLetters, character) >= 0;
        }
        return false; 
    }

    public string GetSelectedWord()
    {
        if (selectedWord != null && guessedLetters != null)
        {
            return selectedWord;
        }

        throw new InvalidOperationException("Cannot retrieve selected word at this time.");
    }

}

class Program
{
    static void DisplayGameStatus(HangmanService hangman)
    {
        Console.WriteLine(hangman.GetDisplay());
        Console.WriteLine($"Remaining tries: {hangman.GetRemainingTry()}");

        if (hangman.GetDisplay() == hangman.GetSelectedWord())
        {
            Console.WriteLine("Congratulations, you've win!");
        }
    }

    static void Main(string[] args)
    {
        HangmanService hangman = new HangmanService();
        hangman.Restart();

        Console.WriteLine("Welcome to Hangman!");
        DisplayGameStatus(hangman);

        while (true)
        {
            Console.Write("Please enter character: ");
            string input = Console.ReadLine() ?? "";

            if (input.Length == 0)
            {
                hangman.Restart();
                Console.Clear();
                Console.WriteLine("New game started!");
                DisplayGameStatus(hangman);
                continue;
            }

            char character = input[0];

            GuessResult result = hangman.Input(character);

            if (result == GuessResult.Correct)
            {
                Console.WriteLine("Correct!");
                DisplayGameStatus(hangman);

                if (hangman.GetDisplay() == hangman.GetSelectedWord())
                {
                    Console.WriteLine("Congratulations, you've win!");
                    break;
                }
            }
            else if (result == GuessResult.Incorrect)
            {
                Console.WriteLine($"Sorry, you ’re wrong. Remaining .... ");
                DisplayGameStatus(hangman);

                if (hangman.GetRemainingTry() == 0)
                {
                    Console.WriteLine("Game Over!");
                    break;
                }
            }
            else if (result == GuessResult.Duplicate)
            {
                Console.WriteLine("You have already tried this character.");
            }
        }
    }
}
