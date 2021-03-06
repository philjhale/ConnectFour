﻿using System.Collections.Generic;
using System.Linq;

namespace ConnectFour.Application.Solver
{
	public class GridPointSequence
	{
		private readonly List<GridPoint> gridPoints;
		private readonly GameBoard gameBoard;
		private readonly SequenceDirection forwardDirection;

		public GridPointSequence(GameBoard gameBoard, SequenceDirection forwardDirection, GridPoint currentPoint)
		{
			this.gameBoard = gameBoard;
			this.forwardDirection = forwardDirection;

			gridPoints = GetSequence(currentPoint);
		}

		public IEnumerable<List<GridPoint>> GetNextFourPoints()
		{
			for(int i = 4; i <= gridPoints.Count; i++)
			{
				yield return gridPoints.GetRange(i - 4, 4);
			}
		}

		private List<GridPoint> GetSequence(GridPoint unknownPointInSequence)
		{
			GridPoint firstPoint = GetFirstPointInSequence(unknownPointInSequence);

			return GetSequenceFromPoint(firstPoint, forwardDirection);
		} 

		private GridPoint GetFirstPointInSequence(GridPoint unknownPointInSequence)
		{
			SequenceDirection reverseDirection = forwardDirection.ReverseDirection();
			
			return GetSequenceFromPoint(unknownPointInSequence, reverseDirection).Last();
		}

		private List<GridPoint> GetSequenceFromPoint(GridPoint currentPoint, SequenceDirection direction)
		{
			var nextPoint = currentPoint;
			var sequence = new List<GridPoint>();

			while (IsInBoundsOfBoard(nextPoint))
			{
				sequence.Add(nextPoint);
				nextPoint = direction.GetNext(nextPoint);
			}

			return sequence;
		}

		private bool IsInBoundsOfBoard(GridPoint currentPosition)
		{
			return currentPosition.X < gameBoard.TotalColumns && currentPosition.X >= 0 
			       && currentPosition.Y < gameBoard.TotalRows && currentPosition.Y >= 0;
		}
	}
}
