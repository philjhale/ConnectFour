using System;
using System.Collections;
using System.Collections.Generic;

namespace ConnectFour.Application
{
	public class Players : IEnumerable<Player>
	{
		private readonly List<Player> players;
		private int currentPlayerIndex;

		public Players(List<Player> players)
		{
			if (players == null || players.Count == 0) throw new ArgumentException("You must supply some players", "players");

			this.players = players;
			currentPlayerIndex = -1;
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