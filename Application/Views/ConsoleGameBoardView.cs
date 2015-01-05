using System;
using ConnectFour.Application.Game;

namespace ConnectFour.Application.Views
{
	public class ConsoleGameBoardView : IGameBoardView
	{
		private readonly GameBoard gameBoard;

		public ConsoleGameBoardView(GameBoard gameBoard)
		{
			this.gameBoard = gameBoard;
		}

		public void ShowMessage(string message)
		{
			Console.WriteLine(message);
		}

		public void Refresh()
		{
			for(int x = 1; x <= gameBoard.TotalColumns ; x++)
			{
				Console.Write("{0}\t", x);
			}
			Console.WriteLine();

			// Loop through each row starting at top left
			for(int y = gameBoard.TotalRows; y > 0 ; y--)
			{
				for(int x = 1; x <= gameBoard.TotalColumns ; x++)
				{
					if (gameBoard.DoesDiscExistAt(x, y))
						Console.Write(GetDiscColourAsString(gameBoard.GetDiscAt(x, y)));
					else
						Console.Write("-");

					Console.Write("\t");
				}
				Console.WriteLine("");
			}

			Console.WriteLine("");
			Console.WriteLine("");
		}

		private string GetDiscColourAsString(DiscColour disc)
		{
			switch(disc)
			{
				case DiscColour.Red: return "R";
				case DiscColour.Yellow: return "Y";
				default: return "-";
			}
		}
	}
}