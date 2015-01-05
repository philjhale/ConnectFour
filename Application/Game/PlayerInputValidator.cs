namespace ConnectFour.Application.Game
{
	public static class PlayerInputValidator
	{
		public static int GetValidColumn(Player player, GameBoard gameBoard)
		{
			int columnNumber;

			while (!IsValidInput(player.GetDropColumnInput(), gameBoard, out columnNumber))
			{
				// Probably should have some way of reporting bad input
			}

			return columnNumber;
		}

		private static bool IsValidInput(string input, GameBoard gameBoard, out int columnNumber)
		{
			if (!int.TryParse(input, out columnNumber))
				return false;

			if (!gameBoard.CanBeDroppedInto(columnNumber))
				return false;

			return true;
		}
	}
}