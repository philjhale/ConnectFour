using ConnectFour.Application;
using ConnectFour.Application.Game;

namespace ConnectFour.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var gameSettings = new GameSettings(
				numberOfColumns: 6, 
				numberOfRows: 7, 
				playerOne: new ConsolePlayer("Console player", DiscColour.Red),
				playerTwo: new AutomatedPlayer("Dr Robotnic", DiscColour.Yellow)
			);

			var game = GameBuilder.Build(gameSettings);

			game.Play();

			System.Console.ReadKey();
		}
	}
}
