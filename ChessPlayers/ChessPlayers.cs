using System.Text;
using System.Linq;

namespace ChessPlayers;

public class ChessPlayers
{
    private List<ChessPlayer> _chessPlayers = null;

    public void ReadPlayersFromFile(string pathToFile)
    {
        _chessPlayers = File.ReadAllLines(pathToFile).Select(ChessPlayer.ParsePlayerFromString).ToList();
    }

    public List<ChessPlayer> AllPlayersFromUSASortedByBirthASC()
    {
        if (_chessPlayers == null) throw new Exception("Read players from file first");

        return _chessPlayers
            .Where(player => player.Country == "USA" && player.Rating > 2700)
            .OrderBy(player => player.BYear)
            .ToList();
    }

    public static string ListOfPlayersToString(List<ChessPlayer> chessPlayers)
    {
        var stringBuilder = new StringBuilder();

        foreach (var chessPlayer in chessPlayers)
        {
            stringBuilder.Append($"{chessPlayer}\n");
        }

        return stringBuilder.ToString();
    }

    public override string ToString()
    {
        return ListOfPlayersToString(_chessPlayers);
    }
}