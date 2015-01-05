using ConnectFour.Application.Game;
using ConnectFour.Application.Views;

namespace ConnectFour.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			var board = new Board();
			var boardView = new ConsoleBoardView(board);
			var gameController = new GameController(boardView, board);

			gameController.Play();

			System.Console.ReadKey();
		}
	}
}
