Console.Write("Enter amount of sticks for game (max value 30, min value is 10): ");

bool parsed = int.TryParse(Console.ReadLine(), out int sticksAmount);

if (!parsed) throw new Exception("You entered not valid number");

if (sticksAmount > 30) throw new Exception("Entered number is too big");

if (sticksAmount < 10) throw new Exception("Entered number is too small");

var chineseSticksGame = new ChineseSticksGame.ChineseSticksGame(sticksAmount);

chineseSticksGame.StartGame();