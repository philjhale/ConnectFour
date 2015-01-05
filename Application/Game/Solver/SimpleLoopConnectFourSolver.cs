namespace ConnectFour.Application.Game.Solver
{
	public class SimpleLoopConnectFourSolver : IConnectFourSolver
	{
		private readonly GameBoard gameBoard;

		public SimpleLoopConnectFourSolver(GameBoard gameBoard)
		{
			this.gameBoard = gameBoard;
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
			DiscColour firstColour = gameBoard.GetDiscAt(columnToSearch, 1);

			if (firstColour == DiscColour.None)
				return false;

			int adjacentSameColourCount = 1;
			for(int y = 2; y <= gameBoard.TotalRows; y++)
			{
				var thisColour = gameBoard.GetDiscAt(columnToSearch, y);

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
				firstColour = gameBoard.GetDiscAt(firstColourPosition, rowToSearch);
			} while (firstColour == DiscColour.None && firstColourPosition <= gameBoard.TotalColumns);

			// Look for four in a row
			int adjacentSameColourCount = 1;
			for(int x = firstColourPosition + 1; x <= gameBoard.TotalColumns; x++)
			{
				var thisColour = gameBoard.GetDiscAt(x, rowToSearch);

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