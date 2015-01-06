using System;

namespace ConnectFour.Application
{
	public class AutomatedPlayer : Player
	{
		public AutomatedPlayer(string name, DiscColour discColour) : base(name, discColour)
		{
		}

		public override string GetDropColumnInput()
		{
			return new Random().Next(1, 7).ToString();
		}
	}
}