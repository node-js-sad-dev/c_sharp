namespace GuessTheWordGame;

public class GuessTheWordGame
{
    private char[] word;
    private char[] userGuess;

    private int triesCount;
    
    private void DrawWord()
    {
        Console.WriteLine($"Word you need to guess has {userGuess.Length} letters.");
        Console.WriteLine(string.Join("", userGuess));
        Console.WriteLine("");
    }

    public void StartGame()
    {
        string[] fileWithWords =
            File.ReadAllLines($"../../../Resources/WordsStock.txt");

        Random random = new Random();

        int indexOfWord = random.Next(0, fileWithWords.Length);

        word = fileWithWords[indexOfWord].ToCharArray();

        userGuess = new char[word.Length];
        triesCount = word.Length * 5;

        for (var i = 0; i < word.Length; i++)
        {
            userGuess[i] = '-';
        }

        // game loop

        bool gameWon = false,
            gameFinished = false;

        while (!gameFinished) 
        {
            Console.WriteLine($"You have {triesCount} tries left");

            Console.Write("Enter your symbol you guess is in word: ");

            char symbol = char.Parse(Console.ReadLine() ?? string.Empty);

            CheckIfSymbolIsInWord(symbol);

            gameWon = CheckIfGameWon();

            DrawWord();

            triesCount--;

            gameFinished = triesCount == 0 || gameWon;
        }

        Console.WriteLine(gameWon ? "You have won" : $"You loose, the word you needed to guess was {string.Join("", word)}");
    }

    private bool CheckIfGameWon()
    {
        return userGuess.Contains('-') == false;
    }

    private void CheckIfSymbolIsInWord(char symbol)
    {
        for (var i = 0; i < word.Length; i++)
        {
            if (word[i] == symbol) userGuess[i] = symbol;
        }
    }
}