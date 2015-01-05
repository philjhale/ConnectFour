using System;
using ConnectFour.Application.Game;

namespace ConnectFour.Application.Views
{
	public class ConsoleBoardView : IBoardView
	{
		private readonly Board board;

		public ConsoleBoardView(Board board)
		{
			this.board = board;
		}

		public void ShowMessage(string message)
		{
			Console.WriteLine(message);
		}

		public void Refresh()
		{
			for(int x = 1; x <= board.TotalColumns ; x++)
			{
				Console.Write("{0}\t", x);
			}
			Console.WriteLine();

			// Loop through each row starting at top left
			for(int y = board.TotalRows; y > 0 ; y--)
			{
				for(int x = 1; x <= board.TotalColumns ; x++)
				{
					if (board.DoesDiscExistAt(x, y))
						Console.Write(GetDiscColourAsString(board.GetDiscAt(x, y)));
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