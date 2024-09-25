using System;
using System.Windows;
using Common.UX.Wpf.Helpers;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace SEWSE.H1.UX.Shell.ViewModels
{
	public class CustomErrorViewModel : BindableBase, IInteractionRequestAware
	{
		public DelegateCommand OkCommand { get; private set; }
		public DelegateCommand HelpdeskCommand { get; private set; }
		public Action FinishInteraction { get; set; }

		private INotification _notification;
		public INotification Notification
		{
			get { return _notification; }
			set { SetProperty(ref _notification, value); }
		}
		public CustomErrorViewModel()
		{
			OkCommand = new DelegateCommand(ExecuteSelected);
			HelpdeskCommand = new DelegateCommand(ExecuteCancel);
		}
		private void ExecuteCancel()
		{
			try
			{
				HelpDeskHelper.GetUserScreen();
			}
			catch (Exception ex)
			{
				string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
				MessageBox.Show(ex.Message);
			}
			FinishInteraction?.Invoke();
		}
		private void ExecuteSelected()
		{
			FinishInteraction?.Invoke();
		}
	}
}
