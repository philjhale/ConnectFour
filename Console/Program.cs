using ConnectFour.Application.Game;
using ConnectFour.Application.Views;

namespace ConnectFour.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			// TODO Encapsulate this into a Game object and GameSettings object
			var board = new GameBoard();
			var boardView = new ConsoleGameBoardView(board);
			var game = new Game(boardView, board);

			game.Play();

			System.Console.ReadKey();
		}
	}
}
