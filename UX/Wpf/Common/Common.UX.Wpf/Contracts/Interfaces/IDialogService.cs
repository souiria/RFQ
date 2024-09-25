using System.Windows;
using Prism.Regions;

namespace Common.UX.Wpf.Contracts.Interfaces
{
	public interface IDialogService
	{
		FrameworkElement GetDialogInstance();
		void ShowRibbonDialog(string navigationUri, NavigationParameters parameters = null, bool isModal = true,int Width=0, int Height=0);
        void ShowRibbonDialogForBaseViewModel(string navigationUri, NavigationParameters parameters = null, bool isModal = true,int Width=0, int Height=0);
    }
}
