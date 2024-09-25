namespace SEWSE.H1.UX.Infrastructure.Core.Contracts
{
	public interface IDialog
	{
		double Left { get; set; }
		double Top { get; set; }
		void Close();
		void Show();
	}
}
