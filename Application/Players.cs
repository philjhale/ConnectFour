using System;
using System.Collections.Generic;

namespace ConnectFour.Application
{
	public class Players
	{
		private readonly List<Player> players;
		private int currentPlayerIndex;

		public Players(List<Player> players)
		{
			if (players == null || players.Count == 0) throw new ArgumentException("You must supply some players", "players");

			this.players = players;
			currentPlayerIndex = -1;
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