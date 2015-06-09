namespace ConnectFour.Application.Solver
{
	public interface IConnectFourSolver
	{
		bool HasConnectFour(int lastDropColumnNumber, int lastDropRowNumber);
	}
}