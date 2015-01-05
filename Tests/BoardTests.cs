using ConnectFour.Application.Game;
using NUnit.Framework;

namespace ConnectFour.Tests
{
	[TestFixture]
    public class BoardTests
    {
		Board board;

		[SetUp]
		public void SetUp()
		{
			board = new Board();	
		}

		[Test]
		public void HasConnectFour_ThreeVertical_ReturnsFalse()
		{
			board.DropDisc(1, DiscColour.Red);
			board.DropDisc(1, DiscColour.Red);
			board.DropDisc(1, DiscColour.Red);

			Assert.IsFalse(board.HasConnectFour());
		}

		[Test]
		public void HasConnectFour_FourVertical_ReturnsTrue()
		{
			board.DropDisc(1, DiscColour.Red);
			board.DropDisc(1, DiscColour.Red);
			board.DropDisc(1, DiscColour.Red);
			board.DropDisc(1, DiscColour.Red);

			Assert.IsTrue(board.HasConnectFour());
		}

		[Test]
		public void HasConnectFour_ThreeHorizontalStartingFromPosition1_ReturnsFalse()
		{
			board.DropDisc(1, DiscColour.Red);
			board.DropDisc(2, DiscColour.Red);
			board.DropDisc(3, DiscColour.Red);

			Assert.IsFalse(board.HasConnectFour());
		}

		[Test]
		public void HasConnectFour_FourHorizontalStartingFromPosition1_ReturnsTrue()
		{
			board.DropDisc(1, DiscColour.Red);
			board.DropDisc(2, DiscColour.Red);
			board.DropDisc(3, DiscColour.Red);
			board.DropDisc(4, DiscColour.Red);

			Assert.IsTrue(board.HasConnectFour());
		}

		[Test]
		public void HasConnectFour_ThreeHorizontalStartingFromPosition2_ReturnsFalse()
		{
			board.DropDisc(2, DiscColour.Red);
			board.DropDisc(3, DiscColour.Red);
			board.DropDisc(4, DiscColour.Red);

			Assert.IsFalse(board.HasConnectFour());
		}

		[Test]
		public void HasConnectFour_FourHorizontalStartingFromPosition2_ReturnsTrue()
		{
			board.DropDisc(2, DiscColour.Red);
			board.DropDisc(3, DiscColour.Red);
			board.DropDisc(4, DiscColour.Red);
			board.DropDisc(5, DiscColour.Red);

			Assert.IsTrue(board.HasConnectFour());
		}


		/*
		 * -	-	-	-	Y
		 * -	-	-	R	R	
		 * -	-	R	R	Y
		 * -	R	Y	R	Y
		 * Y	Y	R	Y	R
		 */
		[Test]
		public void HasConnectFour_ThreeDiagonalBottomLeftToTopRight_ReturnsFalse()
		{
			board.DropDisc(1, DiscColour.Yellow);
			board.DropDisc(2, DiscColour.Yellow);
			board.DropDisc(3, DiscColour.Red);
			board.DropDisc(4, DiscColour.Yellow);
			board.DropDisc(5, DiscColour.Red);

			board.DropDisc(2, DiscColour.Red);
			board.DropDisc(3, DiscColour.Yellow);
			board.DropDisc(4, DiscColour.Red);
			board.DropDisc(5, DiscColour.Yellow);

			board.DropDisc(3, DiscColour.Red);
			board.DropDisc(4, DiscColour.Red);
			board.DropDisc(5, DiscColour.Yellow);

			board.DropDisc(4, DiscColour.Red);
			board.DropDisc(5, DiscColour.Red);

			board.DropDisc(5, DiscColour.Yellow);

			Assert.IsFalse(board.HasConnectFour());
		}

		/*
		 * -	-	-	-	R
		 * -	-	-	R	Y	
		 * -	-	R	R	Y
		 * -	R	Y	R	Y
		 * Y	Y	R	Y	R
		 */
		[Test]
		public void HasConnectFour_FourDiagonalBottomLeftToTopRight_ReturnsTrue()
		{
			board.DropDisc(1, DiscColour.Yellow);
			board.DropDisc(2, DiscColour.Yellow);
			board.DropDisc(3, DiscColour.Red);
			board.DropDisc(4, DiscColour.Yellow);
			board.DropDisc(5, DiscColour.Red);

			board.DropDisc(2, DiscColour.Red);
			board.DropDisc(3, DiscColour.Yellow);
			board.DropDisc(4, DiscColour.Red);
			board.DropDisc(5, DiscColour.Yellow);

			board.DropDisc(3, DiscColour.Red);
			board.DropDisc(4, DiscColour.Red);
			board.DropDisc(5, DiscColour.Yellow);

			board.DropDisc(4, DiscColour.Red);
			board.DropDisc(5, DiscColour.Yellow);

			board.DropDisc(5, DiscColour.Yellow);

			Assert.IsTrue(board.HasConnectFour());
		}

		/*
		 * -	-	-	-	-
		 * -	-	-	-	-	
		 * Y	Y	-	-	-
		 * R	R	Y	-	-
		 * Y	Y	R	Y	-
		 */
		[Test]
		public void HasConnectFour_ThreeDiagonalBottomRightToTopLeft_ReturnsFalse()
		{
			board.DropDisc(1, DiscColour.Yellow);
			board.DropDisc(2, DiscColour.Yellow);
			board.DropDisc(3, DiscColour.Red);
			board.DropDisc(4, DiscColour.Yellow);

			board.DropDisc(1, DiscColour.Red);
			board.DropDisc(2, DiscColour.Red);
			board.DropDisc(3, DiscColour.Yellow);

			board.DropDisc(1, DiscColour.Yellow);
			board.DropDisc(2, DiscColour.Yellow);

			Assert.IsFalse(board.HasConnectFour());
		}

		/*
		 * -	-	-	-	-
		 * Y	-	-	-	-	
		 * Y	Y	-	-	-
		 * R	R	Y	-	-
		 * Y	Y	R	Y	-
		 */
		[Test]
		public void HasConnectFour_FourDiagonalBottomRightToTopLeft_ReturnsTrue()
		{
			board.DropDisc(1, DiscColour.Yellow);
			board.DropDisc(2, DiscColour.Yellow);
			board.DropDisc(3, DiscColour.Red);
			board.DropDisc(4, DiscColour.Yellow);

			board.DropDisc(1, DiscColour.Red);
			board.DropDisc(2, DiscColour.Red);
			board.DropDisc(3, DiscColour.Yellow);

			board.DropDisc(1, DiscColour.Yellow);
			board.DropDisc(2, DiscColour.Yellow);

			board.DropDisc(1, DiscColour.Yellow);

			Assert.IsTrue(board.HasConnectFour());
		}
    }
}
