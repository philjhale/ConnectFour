using ConnectFour.Application.Views;

namespace ConnectFour.Application
{
	public class GameBuilder
	{
		private IGameBoardView gameBoardView;
		private readonly GameSettings settings;

		public GameBuilder(GameSettings settings)
		{
			this.settings = settings;
		}

		public GameBuilder WithView(IGameBoardView gameBoardView)
		{
			this.gameBoardView = gameBoardView;

			return this;
		}

		public Game Build()
		{
			var gameBoard = new GameBoard(settings.NumberOfColumns, settings.NumberOfRows);
			
			if (gameBoardView == null)
				gameBoardView = new ConsoleGameBoardView();

			return new Game(gameBoardView, gameBoard, settings.Players);
		}
	}
}