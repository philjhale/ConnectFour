namespace ConnectFour.Application.Views
{
	public interface IGameBoardView
	{
		void ShowMessage(string message);
		void Refresh();
	}
}