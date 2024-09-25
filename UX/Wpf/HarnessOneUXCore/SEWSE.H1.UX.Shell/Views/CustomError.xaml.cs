using System;
using System.Windows;
using System.Windows.Controls;
using SEWSE.H1.UX.Shell.ViewModels;

namespace SEWSE.H1.UX.Shell.Views
{
	/// <summary>
	/// Interaction logic for CustomError.xaml
	/// </summary>
	public partial class CustomError : UserControl
	{
		private CustomErrorViewModel viewModel;
		public CustomError()
		{
			InitializeComponent();
			viewModel = new CustomErrorViewModel();
			DataContext = viewModel;
			Loaded += CustomPopupView_Loaded;
		}
		private void CustomPopupView_Loaded(object sender, RoutedEventArgs e)
		{
			var parentWindow = this.Parent as Window;

			if (parentWindow != null)
			{
				var c = (Prism.Interactivity.InteractionRequest.Notification)parentWindow.DataContext;
				txtBlockErrorMessage.Text = Convert.ToString(c.Content);
				txtBlockHeader.Text = Convert.ToString(c.Title);
				parentWindow.Measure(parentWindow.DesiredSize);
				if(c.Content.ToString().Contains("60010")) //[HD-00394058] : Lock During DRP run check.
				{
					btnHelpDesk.Visibility = Visibility.Collapsed;
                }
				else if (c.Content.ToString().Contains("60042")) //[HD-00393919] : Unlock Single User Access
				{
					btnHelpDesk.Visibility = Visibility.Collapsed;
				}
				else
                {
					btnHelpDesk.Visibility = Visibility.Visible;
				}
			}
		}
	}
}
