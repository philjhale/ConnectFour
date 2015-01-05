using System;
using System.Collections.Generic;
using ConnectFour.Application.Views;

namespace ConnectFour.Application.Game
{
	public class Game
	{
		private readonly GameBoard gameBoard;
		private readonly Players players;
		private readonly IGameBoardView gameBoardView;
		
		public Game(IGameBoardView gameBoardView, GameBoard gameBoard, List<Player> players)
		{
			if (gameBoardView == null) throw new ArgumentNullException("Parameter cannot be null", "gameBoardView");
			if (gameBoard == null) throw new ArgumentNullException("Parameter cannot be null", "gameBoard");
			if (players == null || players.Count < 2) throw new ArgumentException("Two players are required", "players");

			this.gameBoard = gameBoard;
			this.gameBoardView = gameBoardView;
			
			this.players = new Players(players);
		}

		public void Play()
		{
			gameBoardView.ShowMessage("Welcome to connect four");

			while(true)
			{
				gameBoardView.Refresh();

				Player player = players.Next();

				gameBoardView.ShowMessage(string.Format("{0}'s turn. Type column number [1-{1}]", player.Name, gameBoard.TotalColumns));
				
				gameBoard.DropDisc(PlayerInputValidator.GetValidColumn(player, gameBoard), player.DiscColour);

				if (gameBoard.HasConnectFour())
				{
					gameBoardView.Refresh();
					gameBoardView.ShowMessage(string.Format("{0} has won!!! Press any key to exit...", player.Name));

					break;
				}
			}
		}
	}
}