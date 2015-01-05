namespace ConnectFour.Application.Game
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

		public virtual string GetDropColumnInput()
		{
			throw new System.NotImplementedException("Implement in derived class");
		}
	}
}