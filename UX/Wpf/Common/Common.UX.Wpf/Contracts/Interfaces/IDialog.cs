namespace Common.UX.Wpf.Contracts.Interfaces
{
	public interface IDialog
	{
		double Left { get; set; }
		double Top { get; set; }
		void Close();
		void Show();
	}
}
