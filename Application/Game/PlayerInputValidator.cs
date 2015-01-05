namespace ConnectFour.Application.Game
{
	public static class PlayerInputValidator
	{
		public static int GetValidColumn(Player player, Board board)
		{
			int columnNumber;

			while (!IsValidInput(player.GetDropColumnInput(), board, out columnNumber))
			{
				// Probably should have some way of reporting bad input
			}

			return columnNumber;
		}

		private static bool IsValidInput(string input, Board board, out int columnNumber)
		{
			if (!int.TryParse(input, out columnNumber))
				return false;

			if (!board.CanBeDroppedInto(columnNumber))
				return false;

			return true;
		}
	}
}