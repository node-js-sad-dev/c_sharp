namespace ChineseSticksGame;

public struct HistoryMove
{
    public Player Player { get; private set; }
    public int SticksAmount { get; private set; }

    public HistoryMove(Player player, int sticksAmount)
    {
        Player = player;
        SticksAmount = sticksAmount;
    }
}

public enum Player
{
    Computer,
    User
}

public class ChineseSticksGame
{
    private int _sticksAmount;
    private Player _currentPlayer;

    private readonly List<HistoryMove> _history;

    public ChineseSticksGame(int sticksAmount)
    {
        _sticksAmount = sticksAmount;
        _currentPlayer = Player.User;
        _history = new List<HistoryMove>();
    }

    private void LogGameHistory()
    {
        Console.WriteLine();
        
        foreach (var historyMove in _history)
        {
            string player = historyMove.Player == Player.Computer ? "Computer" : "User";
            Console.WriteLine($"{player.PadRight(20)}{historyMove.SticksAmount}");
        }

        Console.WriteLine();
    }

    public void StartGame()
    {
        bool gameFinished = false;

        while (!gameFinished)
        {
            int sticksToRemove = 0;

            switch (_currentPlayer)
            {
                case Player.Computer:
                    Random r = new Random();

                    sticksToRemove = r.Next(1, 4);

                    Console.WriteLine($"Computer decided to take {sticksToRemove}.");
                    
                    break;
                case Player.User:
                    bool parsed = false, numberIsInCorrectRange = false;

                    while (!parsed || !numberIsInCorrectRange)
                    {
                        Console.Write("Enter amount of sticks to remove: ");
                        parsed = int.TryParse(Console.ReadLine(), out sticksToRemove);

                        if (!parsed)
                        {
                            Console.WriteLine("You entered incorrect number, please try again.");
                            continue;
                        }

                        if (sticksToRemove is < 1 or > 3)
                        {
                            Console.WriteLine("Entered number should be between 1 and 3 (included), please try again.");
                            continue;
                        }

                        numberIsInCorrectRange = true;
                    }

                    Console.WriteLine($"You have taken {sticksToRemove}.");
                    break;
            }

            _sticksAmount -= sticksToRemove;
            _history.Add(new HistoryMove(_currentPlayer, sticksToRemove));

            if (_sticksAmount <= 0) gameFinished = true;
            else
            {
                _currentPlayer = _currentPlayer == Player.Computer ? Player.User : Player.Computer;
                Console.WriteLine($"Sticks in game left {_sticksAmount}. Press any key to continue game.");
                Console.ReadLine();
            }
        }

        string lastPlayer = _currentPlayer == Player.Computer ? "Computer" : "User";

        LogGameHistory();
        
        Console.WriteLine($"{lastPlayer} lost.");
    }
}