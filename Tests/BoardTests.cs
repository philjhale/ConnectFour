using ConnectFour.Application.Game;
using NUnit.Framework;

namespace ConnectFour.Tests
{
	[TestFixture]
    public class BoardTests
    {
		GameBoard gameBoard;

		[SetUp]
		public void SetUp()
		{
			gameBoard = new GameBoard(7, 6);	
		}

		[Test]
		public void HasConnectFour_ThreeVertical_ReturnsFalse()
		{
			gameBoard.DropDisc(1, DiscColour.Red);
			gameBoard.DropDisc(1, DiscColour.Red);
			gameBoard.DropDisc(1, DiscColour.Red);

			Assert.IsFalse(gameBoard.HasConnectFour());
		}

		[Test]
		public void HasConnectFour_FourVertical_ReturnsTrue()
		{
			gameBoard.DropDisc(1, DiscColour.Red);
			gameBoard.DropDisc(1, DiscColour.Red);
			gameBoard.DropDisc(1, DiscColour.Red);
			gameBoard.DropDisc(1, DiscColour.Red);

			Assert.IsTrue(gameBoard.HasConnectFour());
		}

		[Test]
		public void HasConnectFour_ThreeHorizontalStartingFromPosition1_ReturnsFalse()
		{
			gameBoard.DropDisc(1, DiscColour.Red);
			gameBoard.DropDisc(2, DiscColour.Red);
			gameBoard.DropDisc(3, DiscColour.Red);

			Assert.IsFalse(gameBoard.HasConnectFour());
		}

		[Test]
		public void HasConnectFour_FourHorizontalStartingFromPosition1_ReturnsTrue()
		{
			gameBoard.DropDisc(1, DiscColour.Red);
			gameBoard.DropDisc(2, DiscColour.Red);
			gameBoard.DropDisc(3, DiscColour.Red);
			gameBoard.DropDisc(4, DiscColour.Red);

			Assert.IsTrue(gameBoard.HasConnectFour());
		}

		[Test]
		public void HasConnectFour_ThreeHorizontalStartingFromPosition2_ReturnsFalse()
		{
			gameBoard.DropDisc(2, DiscColour.Red);
			gameBoard.DropDisc(3, DiscColour.Red);
			gameBoard.DropDisc(4, DiscColour.Red);

			Assert.IsFalse(gameBoard.HasConnectFour());
		}

		[Test]
		public void HasConnectFour_FourHorizontalStartingFromPosition2_ReturnsTrue()
		{
			gameBoard.DropDisc(2, DiscColour.Red);
			gameBoard.DropDisc(3, DiscColour.Red);
			gameBoard.DropDisc(4, DiscColour.Red);
			gameBoard.DropDisc(5, DiscColour.Red);

			Assert.IsTrue(gameBoard.HasConnectFour());
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
			gameBoard.DropDisc(1, DiscColour.Yellow);
			gameBoard.DropDisc(2, DiscColour.Yellow);
			gameBoard.DropDisc(3, DiscColour.Red);
			gameBoard.DropDisc(4, DiscColour.Yellow);
			gameBoard.DropDisc(5, DiscColour.Red);

			gameBoard.DropDisc(2, DiscColour.Red);
			gameBoard.DropDisc(3, DiscColour.Yellow);
			gameBoard.DropDisc(4, DiscColour.Red);
			gameBoard.DropDisc(5, DiscColour.Yellow);

			gameBoard.DropDisc(3, DiscColour.Red);
			gameBoard.DropDisc(4, DiscColour.Red);
			gameBoard.DropDisc(5, DiscColour.Yellow);

			gameBoard.DropDisc(4, DiscColour.Red);
			gameBoard.DropDisc(5, DiscColour.Red);

			gameBoard.DropDisc(5, DiscColour.Yellow);

			Assert.IsFalse(gameBoard.HasConnectFour());
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
			gameBoard.DropDisc(1, DiscColour.Yellow);
			gameBoard.DropDisc(2, DiscColour.Yellow);
			gameBoard.DropDisc(3, DiscColour.Red);
			gameBoard.DropDisc(4, DiscColour.Yellow);
			gameBoard.DropDisc(5, DiscColour.Red);

			gameBoard.DropDisc(2, DiscColour.Red);
			gameBoard.DropDisc(3, DiscColour.Yellow);
			gameBoard.DropDisc(4, DiscColour.Red);
			gameBoard.DropDisc(5, DiscColour.Yellow);

			gameBoard.DropDisc(3, DiscColour.Red);
			gameBoard.DropDisc(4, DiscColour.Red);
			gameBoard.DropDisc(5, DiscColour.Yellow);

			gameBoard.DropDisc(4, DiscColour.Red);
			gameBoard.DropDisc(5, DiscColour.Yellow);

			gameBoard.DropDisc(5, DiscColour.Yellow);

			Assert.IsTrue(gameBoard.HasConnectFour());
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
			gameBoard.DropDisc(1, DiscColour.Yellow);
			gameBoard.DropDisc(2, DiscColour.Yellow);
			gameBoard.DropDisc(3, DiscColour.Red);
			gameBoard.DropDisc(4, DiscColour.Yellow);

			gameBoard.DropDisc(1, DiscColour.Red);
			gameBoard.DropDisc(2, DiscColour.Red);
			gameBoard.DropDisc(3, DiscColour.Yellow);

			gameBoard.DropDisc(1, DiscColour.Yellow);
			gameBoard.DropDisc(2, DiscColour.Yellow);

			Assert.IsFalse(gameBoard.HasConnectFour());
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
			gameBoard.DropDisc(1, DiscColour.Yellow);
			gameBoard.DropDisc(2, DiscColour.Yellow);
			gameBoard.DropDisc(3, DiscColour.Red);
			gameBoard.DropDisc(4, DiscColour.Yellow);

			gameBoard.DropDisc(1, DiscColour.Red);
			gameBoard.DropDisc(2, DiscColour.Red);
			gameBoard.DropDisc(3, DiscColour.Yellow);

			gameBoard.DropDisc(1, DiscColour.Yellow);
			gameBoard.DropDisc(2, DiscColour.Yellow);

			gameBoard.DropDisc(1, DiscColour.Yellow);

			Assert.IsTrue(gameBoard.HasConnectFour());
		}
    }
}
