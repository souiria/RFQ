using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Prism.Events;
using SEWSE.H1.Common.Contracts;
using SEWSE.H1.UX.Infrastructure.Core.Events;

namespace SEWSE.H1.UX.Infrastructure.Core.Helpers
{
	public class CustomDialogHelper
	{
		private readonly IEventAggregator _eventAggregator;
		private bool? confirmationResult = null;
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
			return confirmationResult;
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

			return confirmationResult;
		}

		#region Private Methods

		private void DialogResult(bool? result)
		{
			confirmationResult = result;
		}
		#endregion
	}
}
