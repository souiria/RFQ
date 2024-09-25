using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Common.UX.Wpf.Contracts.Interfaces;
using Common.UX.Wpf.Contracts.Models.Dialog;
using Common.UX.Wpf.Events;
using Prism.Events;

namespace Common.UX.Wpf.Helpers
{
	public class CustomDialogHelper:ICustomDialogHelper
	{
		private readonly IEventAggregator _eventAggregator;
		private bool? _confirmationResult;

		public CustomDialogHelper(IEventAggregator eventAggregator)
		{
			_eventAggregator = eventAggregator;
		}
		/// <summary>
		/// Display error dialog with the custom message.
		/// </summary>
		/// <param name="title">Title of the dialog window</param>
		/// <param name="content">Contents to be displayed in the notification dialog.</param>
		/// <returns></returns>
		public async Task ErrorMessage(string title, string content)
		{
			try
			{
				UXErrorDialog errorMessage = new UXErrorDialog()
				{
					Title = title,
					Content = content,
					Type = UXDialogTypes.Error
				};

				await Application.Current.Dispatcher.BeginInvoke(
						   DispatcherPriority.Normal,
						   new Action(
							   delegate ()
							   {
								   _eventAggregator.GetEvent<ShellDialogEvent<UXCustomDialogBase>>().Publish(errorMessage);
							   }
						   )
					   );
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		/// <summary>
		/// Result of type bool [=true] mean Accept,[=False] mean Deny and
		/// [=Null] mean user has canclled the Confirmation window!
		/// </summary>
		/// <param name="title">Title of the dialog window</param>
		/// <param name="content">Contents to be displayed in the notification dialog.</param>
		/// <returns></returns>
		public async Task<bool?> GetConfirmation(string title, string content, UXDialogTypes type)
		{
			UXConfirmationDialog userConfirmation = new UXConfirmationDialog(DialogResult)
			{
				Title = title,
				Content = content,
				Type = type
			};

			await Application.Current.Dispatcher.BeginInvoke(
					   DispatcherPriority.Normal,
					   new Action(
						   delegate ()
						   {
							   _eventAggregator.GetEvent<ShellDialogEvent<UXCustomDialogBase>>().Publish(userConfirmation);
						   }
					   )
				   );
			return _confirmationResult;
		}
		public bool? GetCloseConfirmation(string title, string content)
		{
			UXConfirmationDialog userConfirmation = new UXConfirmationDialog(DialogResult)
			{
				Title = title,
				Content = content,
				Type = UXDialogTypes.YesNoCancelConfirmation
			};
			_eventAggregator.GetEvent<ShellDialogEvent<UXCustomDialogBase>>().Publish(userConfirmation);

			return _confirmationResult;
		}

		#region Private Methods

		private void DialogResult(bool? result)
		{
			_confirmationResult = result;
		}
		#endregion
	}
}
