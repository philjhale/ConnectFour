namespace ConnectFour.Application
{
	public abstract class Player : IPlayerInput
	{
		public string Name	            { get; private set; }
		public DiscColour DiscColour	{ get; private set; }

		protected Player(string name, DiscColour discColour)
		{
			Name            = name;
			DiscColour      = discColour;
		}

        public abstract string GetDropColumnInput();
	}
}