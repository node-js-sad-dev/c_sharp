var chessPlayers = new ChessPlayers.ChessPlayers();

chessPlayers.ReadPlayersFromFile("../../../Resources/ChessPlayers.txt");

var usaPlayers = chessPlayers.AllPlayersFromUSASortedByBirthASC();

Console.WriteLine(ChessPlayers.ChessPlayers.ListOfPlayersToString(usaPlayers));
