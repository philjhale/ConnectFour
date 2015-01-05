namespace ConnectFour.Application.Game.Solver
{
	public interface IConnectFourSolver
	{
		bool HasConnectFour(int lastDropPositionX, int lastDropPositionY);
	}
}