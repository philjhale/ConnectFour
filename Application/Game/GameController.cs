using ConnectFour.Application.Views;

namespace ConnectFour.Application.Game
{
	public class GameController
	{
		private readonly Board board;
		private readonly Players players;
		private readonly IBoardView boardView;
		
		public GameController(IBoardView boardView, Board board)
		{
			this.board = board;
			this.boardView = boardView;
			
			var humanPlayer = new ConsolePlayer("Console player", DiscColour.Red);
			var computerPlayer = new AutomatedPlayer("Dr Robotnic", DiscColour.Yellow);
			players = new Players(humanPlayer, computerPlayer);
		}

		public void Play()
		{
			boardView.ShowMessage("Welcome to connect four");

			while(true)
			{
				boardView.Refresh();

				Player player = players.Next();

				boardView.ShowMessage(string.Format("{0}'s turn. Type column number [1-{1}]", player.Name, board.TotalColumns));
				
				board.DropDisc(PlayerInputValidator.GetValidColumn(player, board), player.DiscColour);

				if (board.HasConnectFour())
				{
					boardView.Refresh();
					boardView.ShowMessage(string.Format("{0} has won!!! Press any key to exit...", player.Name));

					break;
				}
			}
		}
	}
}