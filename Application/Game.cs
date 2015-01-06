using System;
using System.Collections.Generic;
using ConnectFour.Application.Views;

namespace ConnectFour.Application
{
	public class Game
	{
		private readonly GameBoard board;
		private readonly Players players;
		private readonly IGameBoardView view;
		
		public Game(IGameBoardView view, GameBoard board, List<Player> players)
		{
			if (view == null) throw new ArgumentNullException("Parameter cannot be null", "view");
			if (board == null) throw new ArgumentNullException("Parameter cannot be null", "board");
			if (players == null || players.Count < 2) throw new ArgumentException("Two players are required", "players");

			this.board = board;
			this.view = view;
			
			this.players = new Players(players);
		}

		public void Play()
		{
			view.ShowMessage("Welcome to connect four");

			while(true)
			{
				view.Refresh(board);

				Player player = players.Next();

				view.ShowMessage(string.Format("{0}'s turn. Type column number [1-{1}]", player.Name, board.TotalColumns));
				
				board.DropDisc(PlayerInputValidator.GetValidColumn(player, board), player.DiscColour);

				if (board.HasConnectFour())
				{
					view.Refresh(board);
					view.ShowMessage(string.Format("{0} has won!!! Press any key to exit...", player.Name));

					break;
				}
			}
		}
	}
}