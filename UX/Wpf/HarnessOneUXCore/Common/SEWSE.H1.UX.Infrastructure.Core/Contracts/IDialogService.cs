using System.Windows;
using Prism.Regions;

namespace SEWSE.H1.UX.Infrastructure.Core.Contracts
{
	public interface IDialogService
	{
		FrameworkElement GetDialogInstance();
		void ShowRibbonDialog(string navigationUri, NavigationParameters parameters = null, bool isModal = true);
	}
}
