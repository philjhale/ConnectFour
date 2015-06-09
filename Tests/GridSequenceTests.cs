using System.Collections.Generic;
using System.Linq;
using ConnectFour.Application;
using ConnectFour.Application.Solver;
using NUnit.Framework;

namespace ConnectFour.Tests
{
	[TestFixture]
	public class GridSequenceTests
	{
		GameBoard board;

		[SetUp]
		public void SetUp()
		{
			 board = new GameBoard(7, 6);
		}

		[Test]
		public void GetNextFourInRange_FourRedFromBottomLeft_WorksAndShit()
		{
			board.DropDisc(1, DiscColour.Red);
			board.DropDisc(2, DiscColour.Red);
			board.DropDisc(3, DiscColour.Red);
			board.DropDisc(4, DiscColour.Red);
			var sequence = new GridSequence(board, SequenceDirection.Right(), new GridPoint(0, 0));

			var nextFour = sequence.GetNextFourPoints().GetEnumerator();
			nextFour.MoveNext();
			Assert.That(nextFour.Current[0].X, Is.EqualTo(0));
			Assert.That(nextFour.Current[1].X, Is.EqualTo(1));
			Assert.That(nextFour.Current[2].X, Is.EqualTo(2));
			Assert.That(nextFour.Current[3].X, Is.EqualTo(3));
		}

		[Test]
		public void GetNextFourInRange_FourRedInLeftMostColumn_WorksAndShit()
		{
			board.DropDisc(1, DiscColour.Red);
			board.DropDisc(1, DiscColour.Red);
			board.DropDisc(1, DiscColour.Red);
			board.DropDisc(1, DiscColour.Red);
			var sequence = new GridSequence(board, SequenceDirection.Up(), new GridPoint(0, 0));

			var nextFour = sequence.GetNextFourPoints().GetEnumerator();
			nextFour.MoveNext();
			Assert.That(nextFour.Current[0].Y, Is.EqualTo(0));
			Assert.That(nextFour.Current[1].Y, Is.EqualTo(1));
			Assert.That(nextFour.Current[2].Y, Is.EqualTo(2));
			Assert.That(nextFour.Current[3].Y, Is.EqualTo(3));
		}
	}
}