namespace ChessPlayers;

public class ChessPlayer
{
    public uint Rank { get; private set; }
    public string Name { get; private set; }
    public string Title { get; private set; }
    public string Country { get; private set; }
    public uint Rating { get; private set; }
    public uint Games { get; private set; }
    public uint BYear { get; private set; }

    public static ChessPlayer ParsePlayerFromString(string playerString)
    {
        string[] playerInfo = playerString.Split(",");

        return new ChessPlayer(
            playerInfo[0],
            $"{playerInfo[1]} {playerInfo[2]}",
            playerInfo[3],
            playerInfo[4],
            playerInfo[5],
            playerInfo[6],
            playerInfo[7]);
    }

    private ChessPlayer(
        string rank,
        string name,
        string title,
        string country,
        string rating,
        string games,
        string bYear)
    {
        try
        {
            Rank = uint.Parse(rank);
            Name = name;
            Title = title;
            Country = country;
            Rating = uint.Parse(rating);
            Games = uint.Parse(games);
            BYear = uint.Parse(bYear);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override string ToString()
    {
        return $"{Rank}; Name: {Name}; Country: {Country}; Rating: {Rating}; Games: {Games}; BYear: {BYear}";
    }
}