using System;
using ConnectFour.Application.Exceptions;
using ConnectFour.Application.Game.Solver;

namespace ConnectFour.Application.Game
{
	public class GameBoard
	{
		// Think of the grid like a graph with 0, 0 at the bottom left and TotalColumns (x), TotalColumns (y) at the top right
		private readonly DiscColour[,] grid;
		private readonly IConnectFourSolver solver;
		private int lastDroppedX = -1;
		private int lastDroppedY = -1;

		public GameBoard()
		{
			solver = new GenericSequenceConnectFourSolver(this);
			// Hard coded for now but could be passed in
			TotalRows = 7;
			TotalColumns = 6;
			grid = new DiscColour[TotalColumns, TotalRows]; 

			SetAllToNone();
		}

		private void SetAllToNone()
		{
			for (int x = 1; x <= TotalColumns; x++)
			{
				for (int y = 1; y <= TotalRows; y++)
				{
					SetDiscDropPosition(x, y, DiscColour.None);
				}
			}
		}

		public int TotalColumns		{ get; private set; } // x
		public int TotalRows		{ get; private set; } // y


		public DiscColour GetDiscAt(int columnNumber, int rowNumber)
		{
			return grid[columnNumber - 1, rowNumber - 1];
		}

		public bool DoesDiscExistAt(int columnNumber, int rowNumber)
		{
			return GetDiscAt(columnNumber, rowNumber) != DiscColour.None;
		}

		/// <exception cref="DiscCannotBeDroppedException"></exception>
		public void DropDisc(int columnNumber, DiscColour disc)
		{
			if (columnNumber < 1 || columnNumber > TotalColumns)
				throw new DiscCannotBeDroppedException(string.Format("Column number out of range: {0}", columnNumber));

			if (!CanBeDroppedInto(columnNumber))
				throw new DiscCannotBeDroppedException(string.Format("Column {0} is full", columnNumber));

			SetDiscDropPosition(columnNumber, GetFirstRowWithoutADisc(columnNumber), disc);
		}

		public bool CanBeDroppedInto(int columnNumber)
		{
			try
			{
				return !DoesDiscExistAt(columnNumber, TotalRows);
			}
			// TODO Should be more explicit here
			catch(Exception)
			{
				return false;
			}
		}

		/// <exception cref="DiscCannotBeDroppedException"></exception>
		private int GetFirstRowWithoutADisc(int columnNumber)
		{
			for(int y = 1; y <= TotalRows; y++)
			{
				if (!DoesDiscExistAt(columnNumber, y))
					return y;
			}

			// TODO Perhaps not the best exception to throw here
			throw new DiscCannotBeDroppedException(string.Format("Column {0} is full", columnNumber));
		}

		private void SetDiscDropPosition(int columnNumber, int rowNumber, DiscColour disc)
		{
			grid[columnNumber - 1, rowNumber - 1] = disc;
			lastDroppedX = columnNumber;
			lastDroppedY = rowNumber;
		}

		public bool HasConnectFour()
		{
			return solver.HasConnectFour(lastDroppedX, lastDroppedY);
		}
	}
}