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

		public bool HasConnectFour(int lastDropColumnNumber, int lastDropRowNumber)
		{
			List<SequenceDirection> searchDirections = new List<SequenceDirection>() { SequenceDirection.Up(), SequenceDirection.Right(), SequenceDirection.UpRight(), SequenceDirection.UpLeft() };

			// This is the shortest version:
			return searchDirections.Any(direction => HasFourAdjacentColours(lastDropColumnNumber, lastDropRowNumber, direction));

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

		private bool HasFourAdjacentColours(int currentColumnNumber, int currentRowNumber, SequenceDirection direction)
		{
			GridSequence sequence = new GridSequence(gameBoard, direction, new GridPoint(currentColumnNumber - 1, currentRowNumber - 1));

			foreach (var nextFourGridPoints in sequence.GetNextFourPoints())
			{
				if (NextFourPointsAreSameColour(nextFourGridPoints))
					return true;
			}
			
			return false;
		}

		private bool NextFourPointsAreSameColour(List<GridPoint> nextFourPoints)
		{
			var colours = new List<DiscColour>();

			foreach(var point in nextFourPoints)
				colours.Add(gameBoard.GetDiscAt(point.X + 1, point.Y + 1));

			return colours.All(x => x == DiscColour.Red) 
				|| colours.All(x => x == DiscColour.Yellow); 
		}
	}
}