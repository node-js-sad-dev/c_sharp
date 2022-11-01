using System;

namespace GuessTheNumber
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter game mode (ComputerGuess or UserGuess): ");
            var gameModeString = Console.ReadLine();

            GameMode gameMode = gameModeString switch
            {
                "ComputerGuess" => GameMode.ComputerGuess,
                "UserGuess" => GameMode.UserGuess,
                _ => throw new Exception("Enter correct game mode and try again")
            };

            GuessTheNumber guessTheNumber = new GuessTheNumber(gameMode);
            
            guessTheNumber.StartGame();
        }
    }
}