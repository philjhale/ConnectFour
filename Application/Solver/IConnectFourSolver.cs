namespace ConnectFour.Application.Solver
{
	public interface IConnectFourSolver
	{
		bool HasConnectFour(int lastDropPositionX, int lastDropPositionY);
	}
}