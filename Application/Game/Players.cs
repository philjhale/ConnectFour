using System.Collections;
using System.Collections.Generic;

namespace ConnectFour.Application.Game
{
	public class Players : IEnumerable<Player>
	{
		private readonly List<Player> players;
		private int currentPlayerIndex;

		public Players(params Player[] player)
		{
			players = new List<Player>();
			players.AddRange(player);
			currentPlayerIndex = -1;
			// TODO Throw exception if players list length is 0?
		}

		public IEnumerator<Player> GetEnumerator()
		{
			return players.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public Player Next()
		{
			currentPlayerIndex++;

			if (currentPlayerIndex >= players.Count)
				currentPlayerIndex = 0;

			return players[currentPlayerIndex];
		}
	}
}