using System.Text;

namespace GuessTheNumber;

public enum GameMode
{
    ComputerGuess,
    UserGuess
}

public enum MoveResult
{
    GameWon,
    NumberToGuessBigger,
    NumberToGuessLess
}

public class GuessTheNumber
{
    private readonly GameMode _gameMode;

    private int _numberToGuess;

    private const int TriesCount = 10;

    public GuessTheNumber(GameMode gameMode)
    {
        _gameMode = gameMode;
    }

    private void ConsoleDisplayBar(int from, int to)
    {
        Console.WriteLine($"Your number is in this range {from} {to}");
        Console.WriteLine($"0                       50                     100");

        from /= 2;
        to /= 2;

        StringBuilder stringBuilder = new StringBuilder();

        for (var i = 0; i < from; i++)
        {
            stringBuilder.Append('-');
        }

        stringBuilder.Append('|');

        for (var i = from + 1; i < to; i++)
        {
            stringBuilder.Append('-');
        }

        stringBuilder.Append('|');

        if (to < 49)
        {
            for (var i = to + 1; i < 50; i++)
            {
                stringBuilder.Append('-');
            }
        }

        Console.WriteLine(stringBuilder.ToString());
    }

    private MoveResult makeMove(int move)
    {
        if (move == _numberToGuess) return MoveResult.GameWon;
        if (move > _numberToGuess) return MoveResult.NumberToGuessLess;
        if (move < _numberToGuess) return MoveResult.NumberToGuessBigger;

        throw new Exception("Something went wrong");
    }

    private void ComputerGuessGame()
    {
        Console.Write("Enter number computer need to guess: ");
        var numberEntered = int.TryParse(Console.ReadLine(), out _numberToGuess);

        if (!numberEntered) throw new Exception("Enter correct number from 1 to 99 and try again");

        if (_numberToGuess is < 1 or > 99)
            throw new Exception("Number must be in range from 1 to 100");

        ConsoleDisplayBar(0, 99);

        int fromMeasure = 0, toMeasure = 100;

        // computer logic

        bool gameWon = false;

        Console.WriteLine("Computer start to guess...");

        for (var i = 0; i < TriesCount; i++)
        {
            int computerMove = (fromMeasure + toMeasure) / 2;

            MoveResult moveResult = makeMove(computerMove);

            Console.WriteLine($"Computer number is {computerMove}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            switch (moveResult)
            {
                case MoveResult.GameWon:
                    gameWon = true;
                    break;
                case MoveResult.NumberToGuessBigger:
                    fromMeasure = computerMove;
                    break;
                case MoveResult.NumberToGuessLess:
                    toMeasure = computerMove;
                    break;
                default:
                    throw new Exception("Something went wrong");
            }

            if (gameWon) break;

            ConsoleDisplayBar(fromMeasure, toMeasure);
        }

        Console.WriteLine(gameWon
            ? $"Computer won, number needed to guess was {_numberToGuess}"
            : $"Computer lost, number needed to guess was {_numberToGuess}");
    }

    private void UserGuessGame()
    {
        var random = new Random();
        _numberToGuess = random.Next(1, 100);
        
        ConsoleDisplayBar(0, 99);

        bool gameWon = false;
        
        int fromMeasure = 0, toMeasure = 100;

        for (var i = 0; i < TriesCount; i++)
        {
            int number = -1;
            bool parsed = false;

            while (!parsed)
            {
                Console.Write("Enter your number: ");
                parsed = int.TryParse(Console.ReadLine(), out number);

                if (number is < 0 or > 100) parsed = false;
            }

            MoveResult moveResult = makeMove(number);
            
            switch (moveResult)
            {
                case MoveResult.GameWon:
                    gameWon = true;
                    break;
                case MoveResult.NumberToGuessBigger:
                    fromMeasure = number;
                    break;
                case MoveResult.NumberToGuessLess:
                    toMeasure = number;
                    break;
                default:
                    throw new Exception("Something went wrong");
            }
            
            if (gameWon) break;

            ConsoleDisplayBar(fromMeasure, toMeasure);
        }
        
        Console.WriteLine(gameWon
            ? $"You won, number needed to guess was {_numberToGuess}"
            : $"You lost, number needed to guess was {_numberToGuess}");
    }

    public void StartGame()
    {
        switch (_gameMode)
        {
            // user enter numberToGuess
            case GameMode.ComputerGuess:
                ComputerGuessGame();
                break;
            // computer generate number and then user guess it
            case GameMode.UserGuess:
                UserGuessGame();
                break;
            default:
                throw new Exception("Incorrect game mode");
        }
    }
}