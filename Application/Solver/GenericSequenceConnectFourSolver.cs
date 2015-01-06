using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectFour.Application.Solver
{
	public class GenericSequenceConnectFourSolver : IConnectFourSolver
	{
		private readonly GameBoard gameBoard;

		public GenericSequenceConnectFourSolver(GameBoard gameBoard)
		{
			this.gameBoard = gameBoard;
		}

		public bool HasConnectFour(int lastDropPositionX, int lastDropPositionY)
		{
			List<Func<GridPoint, GridPoint>> searchDirections = new List<Func<GridPoint, GridPoint>>() { GoUp, GoRight, GoUpRight, GoUpLeft };

			// This is the shortest version:
			return searchDirections.Any(direction => HasFourAdjacentColoursInLine(lastDropPositionX, lastDropPositionY, direction));

			// Or like this:
			//foreach (var sequence in searchDirections)
			//{
			//	if (HasFourAdjacentColoursInLine(lastDropPositionX, lastDropPositionY, sequence))
			//		return true;
			//}

			
			// This is possibly the easiest to read:
			//// Search vertical
			//if (HasFourAdjacentColoursInLine(lastDropPositionX, lastDropPositionY, GoUp))
			//	return true;

			//// Search horizontal
			//if (HasFourAdjacentColoursInLine(lastDropPositionX, lastDropPositionY, GoRight))
			//	return true;

			//// Search diagonal
			//if (HasFourAdjacentColoursInLine(lastDropPositionX, lastDropPositionY, GoUpRight))
			//	return true;

			//if (HasFourAdjacentColoursInLine(lastDropPositionX, lastDropPositionY, GoUpLeft))
			//	return true;
		}

		private bool HasFourAdjacentColoursInLine(int currentX, int currentY, Func<GridPoint, GridPoint> nextInSequence)
		{
			DiscColour firstColour = DiscColour.None;
			GridPoint startOfSequence = FindFirstPointInLine(nextInSequence, currentX, currentY);

			int adjacentSameColourCount = 0;
			var currentPosition = startOfSequence;

			while(IsInBoundsOfGrid(currentPosition))
			{
				var thisColour = gameBoard.GetDiscAt(currentPosition.X, currentPosition.Y);

				// First in sequence found
				if(firstColour == DiscColour.None && thisColour != DiscColour.None)
				{
					firstColour = thisColour;
					adjacentSameColourCount++;
				}
				// Next in sequence found
				else if(firstColour == thisColour && thisColour != DiscColour.None)
				{
					adjacentSameColourCount++;
				}
				// New sequence found
				else if(thisColour != DiscColour.None)
				{
					firstColour = thisColour;
					adjacentSameColourCount = 1;
				}

				if (adjacentSameColourCount >= 4)
					return true;	

				currentPosition = nextInSequence.Invoke(currentPosition);
			}
			
			return false;
		}

		private bool IsInBoundsOfGrid(GridPoint currentPosition)
		{
			return currentPosition.X <= gameBoard.TotalColumns && currentPosition.X > 0 
			       && currentPosition.Y <= gameBoard.TotalRows && currentPosition.Y > 0;
		}

		private GridPoint FindFirstPointInLine(Func<GridPoint, GridPoint> nextInSequence, int currentX, int currentY)
		{
			GridPoint positiveDirection = nextInSequence.Invoke(new GridPoint(0, 0));
			GridPoint reverseDirection = ReverseSequence(positiveDirection);
			GridPoint firstPointInLine = new GridPoint(currentX, currentY);
			GridPoint nextPoint = firstPointInLine;

			// Work backwards from the current point
			while (nextPoint.X > 0 && nextPoint.Y > 0)
			{
				firstPointInLine = nextPoint;
				nextPoint = new GridPoint(firstPointInLine.X + reverseDirection.X, firstPointInLine.Y + reverseDirection.Y);
			}

			return firstPointInLine;
		}

		private GridPoint GoUp(GridPoint currentPoint)
		{
			return new GridPoint(currentPoint.X, currentPoint.Y + 1);
		}

		private GridPoint GoRight(GridPoint currentPoint)
		{
			return new GridPoint(currentPoint.X + 1, currentPoint.Y);
		}

		private GridPoint GoUpRight(GridPoint currentPoint)
		{
			return new GridPoint(currentPoint.X + 1, currentPoint.Y + 1);
		}

		private GridPoint GoUpLeft(GridPoint currentPoint)
		{
			return new GridPoint(currentPoint.X + 1, currentPoint.Y - 1);
		}

		private GridPoint ReverseSequence(GridPoint nextInSequence)
		{
			return new GridPoint(-nextInSequence.X, -nextInSequence.Y);
		}
	}

	class GridPoint
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public GridPoint(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}