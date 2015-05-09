using System;
using System.Collections.Generic;
using System.Diagnostics;
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
			return searchDirections.Any(direction => HasFourAdjacentColours(lastDropPositionX, lastDropPositionY, direction));

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

			//return false;
		}

		private bool HasFourAdjacentColours(int currentX, int currentY, Func<GridPoint, GridPoint> getNextPointInSequence)
		{
			GridPoint startOfSequence = GetFirstPointInSequence(getNextPointInSequence, currentX, currentY);

			var currentPosition = startOfSequence;
			var nextFourPoints = GetNextFourInSequence(currentPosition, getNextPointInSequence);

			while(IsInBoundsOfBoard(nextFourPoints.Last()))
			{
				if (NextFourPointsAreSameColour(nextFourPoints))
					return true;

				currentPosition = getNextPointInSequence.Invoke(currentPosition);
				nextFourPoints = GetNextFourInSequence(currentPosition, getNextPointInSequence);
			}
			
			return false;
		}

		private bool NextFourPointsAreSameColour(List<GridPoint> nextFourPoints)
		{
			var colours = new List<DiscColour>();

			foreach(var point in nextFourPoints)
			{
				colours.Add(gameBoard.GetDiscAt(point.X, point.Y));
			}

			return colours.All(x => x == DiscColour.Red) 
				|| colours.All(x => x == DiscColour.Yellow); 
		}

		private List<GridPoint> GetNextFourInSequence(GridPoint currentPoint, Func<GridPoint, GridPoint> getNextPointInSequence)
		{
			var points = new List<GridPoint>();

			points.Add(currentPoint);
			for(int i = 0; i < 3; i++)
			{
				currentPoint = getNextPointInSequence.Invoke(currentPoint);
				points.Add(currentPoint);
			}

			return points;
		}

		private bool IsInBoundsOfBoard(GridPoint currentPosition)
		{
			return currentPosition.X <= gameBoard.TotalColumns && currentPosition.X > 0 
			       && currentPosition.Y <= gameBoard.TotalRows && currentPosition.Y > 0;
		}

		private GridPoint GetFirstPointInSequence(Func<GridPoint, GridPoint> getNextPointInSequence, int currentX, int currentY)
		{
			GridPoint forwardDirection = getNextPointInSequence.Invoke(new GridPoint(0, 0));
			GridPoint reverseDirection = ReverseSequence(forwardDirection);
			GridPoint currentPointInSequence = new GridPoint(currentX, currentY);
			GridPoint previousPoint = currentPointInSequence;

			// Work backwards from the current point
			while (IsInBoundsOfBoard(previousPoint))
			{
				currentPointInSequence = previousPoint;
				previousPoint = new GridPoint(currentPointInSequence.X + reverseDirection.X, currentPointInSequence.Y + reverseDirection.Y);
			}

			return currentPointInSequence;
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
			return new GridPoint(currentPoint.X - 1, currentPoint.Y + 1);
		}

		private GridPoint ReverseSequence(GridPoint nextInSequence)
		{
			return new GridPoint(-nextInSequence.X, -nextInSequence.Y);
		}
	}

	[DebuggerDisplay("X = {X}, Y = {Y}")]
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