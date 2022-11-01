namespace TicTacToe;

public struct Cord
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Cord(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class TicTacToeGame
{
    private Dictionary<int, Cord> cordNumbers = new Dictionary<int, Cord>()
    {
        { 1, new Cord(0, 0) },
        { 2, new Cord(0, 1) },
        { 3, new Cord(0, 2) },
        { 4, new Cord(1, 0) },
        { 5, new Cord(1, 1) },
        { 6, new Cord(1, 2) },
        { 7, new Cord(2, 0) },
        { 8, new Cord(2, 1) },
        { 9, new Cord(2, 2) },
    };

    private readonly char[,] _field = new char[3, 3]
    {
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' },
    };

    private char _currentMoveChar = 'x';

    private void DrawField()
    {
        for (var i = 0; i < _field.GetLength(0); i++)
        {
            Console.Write("|");

            for (var j = 0; j < _field.GetLength(1); j++)
            {
                Console.Write($" {_field[i, j]} |");
            }

            Console.Write("\n");
        }
    }

    public void StartGame()
    {
        DrawField();

        for (var i = 0; i < _field.Length; i++)
        {
            bool numberParsedAndCorrect = false,
                cordNumberExist = false,
                cordNumberEmpty = false;

            while (!numberParsedAndCorrect || !cordNumberEmpty || !cordNumberExist)
            {
                Console.Write($"Enter position where to put your {_currentMoveChar}: ");

                numberParsedAndCorrect = int.TryParse(Console.ReadLine(), out var enteredNumber);

                if (!numberParsedAndCorrect) continue;

                cordNumberExist = cordNumbers.TryGetValue(enteredNumber, out var cord);

                if (!cordNumberExist) continue;

                cordNumberEmpty = _field[cord.X, cord.Y] == ' ';

                if (!cordNumberEmpty) continue;

                _field[cord.X, cord.Y] = _currentMoveChar;
            }

            DrawField();

            bool gameIsFinished = CheckGameConditions(_currentMoveChar, i);

            if (gameIsFinished)
            {
                break;
            }

            _currentMoveChar = _currentMoveChar == 'x' ? 'o' : 'x';
        }
    }

    private bool CheckIfUserHasWon(char currentMoveChar)
    {
        /*
         m m m
         x x x
         x x x         
         */

        if (_field[0, 0] == currentMoveChar &&
            _field[0, 1] == currentMoveChar &&
            _field[0, 2] == currentMoveChar) return true;
        /*
         x x x
         m m m
         x x x         
         */

        if (_field[1, 0] == currentMoveChar &&
                 _field[1, 1] == currentMoveChar &&
                 _field[1, 2] == currentMoveChar) return true;
        
        /*
         x x x
         x x x
         m m m         
         */
        
        if (_field[2, 0] == currentMoveChar &&
                 _field[2, 1] == currentMoveChar &&
                 _field[2, 2] == currentMoveChar) return true;
        
        /*
         m x x
         m x x
         m x x         
         */
        
        if (_field[0, 0] == currentMoveChar &&
            _field[1, 0] == currentMoveChar &&
            _field[2, 0] == currentMoveChar) return true;
        
        /*
         x m x
         x m x
         x m x         
         */
        
        if (_field[0, 1] == currentMoveChar &&
            _field[1, 1] == currentMoveChar &&
            _field[2, 1] == currentMoveChar) return true;
        
        /*
         x x m
         x x m
         x x m       
         */
        
        if (_field[0, 2] == currentMoveChar &&
            _field[1, 2] == currentMoveChar &&
            _field[2, 2] == currentMoveChar) return true;
        
        /*
         m x x
         x m x
         x x m       
         */
        
        if (_field[0, 0] == currentMoveChar &&
            _field[1, 1] == currentMoveChar &&
            _field[2, 2] == currentMoveChar) return true;

        /*
         x x m
         x m x
         m x x       
         */
        return _field[0, 2] == currentMoveChar &&
               _field[1, 1] == currentMoveChar &&
               _field[2, 0] == currentMoveChar;
    }

    private bool CheckGameConditions(char currentMoveChar, int move)
    {
        // check all win combinations
        var userWon = CheckIfUserHasWon(currentMoveChar);

        if (userWon)
        {
            Console.WriteLine($"User who played {currentMoveChar} has won.");
            return true;
        }

        if (move == 8)
        {
            Console.WriteLine("Tie");
            return true;
        };

        return false;
    }
}