using System;
using System.Windows;
using System.Windows.Controls;
using Common.UX.Wpf.Contracts.Models.Dialog;
using SEWSE.H1.UX.Shell.ViewModels;

namespace SEWSE.H1.UX.Shell.Views
{
	/// <summary>
	/// Interaction logic for CustomConfirmation.xaml
	/// </summary>
	public partial class CustomConfirmation : UserControl
	{
		private ConfirmationViewModel viewModel;
		public CustomConfirmation()
		{
			InitializeComponent();
			viewModel = new ConfirmationViewModel();
			DataContext = viewModel;
			Loaded += CustomPopupView_Loaded;
		}
		private void CustomPopupView_Loaded(object sender, RoutedEventArgs e)
		{
			var parentWindow = this.Parent as Window;
			if (parentWindow != null)
			{
				//var c = (Prism.Interactivity.InteractionRequest.Confirmation)parentWindow.DataContext;
				var c = (UXConfirmationDialog)parentWindow.DataContext;
				UXDialogTypes typeOfTheConfirmation = c.Type;
				if (typeOfTheConfirmation.Equals(UXDialogTypes.YesNoCancelConfirmation))
				{
					btnCancel.Visibility = Visibility.Visible;
					btnOnlyOk.Visibility = Visibility.Collapsed;
					btnOk.Visibility = Visibility.Visible;
					btnNo.Visibility = Visibility.Visible;
				}
				else if (typeOfTheConfirmation.Equals(UXDialogTypes.OkConfirmation))
				{
					btnOk.Visibility = Visibility.Collapsed;
					btnCancel.Visibility = Visibility.Collapsed;
					btnNo.Visibility = Visibility.Collapsed;
					btnOnlyOk.Visibility = Visibility.Visible;
				}
				else
				{
					btnOnlyOk.Visibility = Visibility.Collapsed;
					btnCancel.Visibility = Visibility.Collapsed;
					btnOk.Visibility = Visibility.Visible;
					btnNo.Visibility = Visibility.Visible;
				}
				txtBlockErrorMessage.Text = Convert.ToString(c.Content);
				txtBlockHeader.Text = Convert.ToString(c.Title);
				parentWindow.Measure(parentWindow.DesiredSize);
			}
		}
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			var parentWindow = this.Parent as Window;
			if (parentWindow != null)
			{
				var c = (UXConfirmationDialog)parentWindow.DataContext;
				c.Title = "Closed";
				parentWindow.Close();
			}
		}
	}
}
