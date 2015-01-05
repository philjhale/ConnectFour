namespace ConnectFour.Application.Game.Solver
{
	public class SimpleLoopConnectFourSolver : IConnectFourSolver
	{
		private readonly Board board;

		public SimpleLoopConnectFourSolver(Board board)
		{
			this.board = board;
		}

		public bool HasConnectFour(int lastDropPositionX, int lastDropPositionY)
		{
			if (lastDropPositionX == -1 || lastDropPositionY == -1)
				return false;

			if(HasVerticalConnectFourFromPosition(lastDropPositionX))
				return true;

			if(HasHorizontalConnectFourFromPosition(lastDropPositionY))
				return true;
			
			if(HasDiagonalConnectFourFromPosition(lastDropPositionX, lastDropPositionY))
				return true;

			return false;
		}

		private bool HasVerticalConnectFourFromPosition(int columnToSearch)
		{
			DiscColour firstColour = board.GetDiscAt(columnToSearch, 1);

			if (firstColour == DiscColour.None)
				return false;

			int adjacentSameColourCount = 1;
			for(int y = 2; y <= board.TotalRows; y++)
			{
				var thisColour = board.GetDiscAt(columnToSearch, y);

				if (firstColour == thisColour && thisColour != DiscColour.None)
				{
					adjacentSameColourCount++;
				}
				else
				{
					firstColour = thisColour;
					adjacentSameColourCount = 0;
				}

				if (adjacentSameColourCount >= 4)
					return true;	
			}
			
			return false;
		}

		private bool HasHorizontalConnectFourFromPosition(int rowToSearch)
		{
			DiscColour firstColour;
			int firstColourPosition = 0;

			// Scan row looking for first disc
			do
			{
				firstColourPosition++;
				firstColour = board.GetDiscAt(firstColourPosition, rowToSearch);
			} while (firstColour == DiscColour.None && firstColourPosition <= board.TotalColumns);

			// Look for four in a row
			int adjacentSameColourCount = 1;
			for(int x = firstColourPosition + 1; x <= board.TotalColumns; x++)
			{
				var thisColour = board.GetDiscAt(x, rowToSearch);

				if (firstColour == thisColour && thisColour != DiscColour.None)
				{
					adjacentSameColourCount++;
				}
				else
				{
					firstColour = thisColour;
					adjacentSameColourCount = 0;
				}

				if (adjacentSameColourCount >= 4)
					return true;	
			}
			
			return false;
		}

		private bool HasDiagonalConnectFourFromPosition(int lastDropX, int lastDropY)
		{
			// Find furtherest bottom extent. E.g. Travel digonally down and left so you can search up and right in a line

			// Do the same but bottom right

			return false;
		}
	}
}