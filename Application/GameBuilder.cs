using ConnectFour.Application.Game;
using ConnectFour.Application.Views;

namespace ConnectFour.Application
{
	public class GameBuilder
	{
		public static Game.Game Build(GameSettings settings)
		{
			var board = new GameBoard(settings.NumberOfColumns, settings.NumberOfRows);
			var boardView = new ConsoleGameBoardView(board);
			var game = new Game.Game(boardView, board, settings.Players);

			return game;
		}
	}
}