using ConnectFour.Application;

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

			new GameBuilder(gameSettings).Build().Play();

			System.Console.ReadKey();
		}
	}
}
