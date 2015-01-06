using System;

namespace ConnectFour.Application
{
	public class ConsolePlayer : Player
	{
		public ConsolePlayer(string name, DiscColour discColour) : base(name, discColour)
		{
		}

		public override string GetDropColumnInput()
		{
			return Console.ReadLine();
		}
	}
}