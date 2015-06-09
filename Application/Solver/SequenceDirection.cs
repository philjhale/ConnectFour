namespace ConnectFour.Application.Solver
{
	public class SequenceDirection
	{
		private readonly int horizontalIncrement;
		private readonly int verticalIncrement;

		public SequenceDirection() { }

		public SequenceDirection(int horizontalIncrement, int verticalIncrement)
		{
			this.horizontalIncrement = horizontalIncrement;
			this.verticalIncrement = verticalIncrement;
		}

		public GridPoint GetNext(GridPoint currentPoint)
		{
			return new GridPoint(currentPoint.X + horizontalIncrement, currentPoint.Y + verticalIncrement);
		}

		public SequenceDirection ReverseDirection()
		{
			return new SequenceDirection(-horizontalIncrement, -verticalIncrement);
		}

		public static SequenceDirection Up()
		{
			return new SequenceDirection(0, 1);
		}

		public static SequenceDirection Right()
		{
			return new SequenceDirection(1, 0);
		}

		public static SequenceDirection UpRight()
		{
			return new SequenceDirection(1, 1);
		}

		public static SequenceDirection UpLeft()
		{
			return new SequenceDirection(-1, 1);
		}
	}
}
