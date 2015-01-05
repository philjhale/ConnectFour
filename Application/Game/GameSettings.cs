using System.Collections.Generic;

namespace ConnectFour.Application.Game
{
	public class GameSettings
	{
		public int            NumberOfColumns   { get; private set; } 
		public int            NumberOfRows      { get; private set; }
		public List<Player>   Players           { get; private set; }

		public GameSettings(int numberOfColumns, int numberOfRows, Player playerOne, Player playerTwo)
		{
			NumberOfColumns = numberOfColumns;
			NumberOfRows    = numberOfRows;
			Players         = new List<Player>() { playerOne, playerTwo };
		}
	}
}