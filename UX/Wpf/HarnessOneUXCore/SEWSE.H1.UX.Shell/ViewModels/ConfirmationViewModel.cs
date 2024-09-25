using System;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace SEWSE.H1.UX.Shell.ViewModels
{
	public class ConfirmationViewModel : BindableBase, IInteractionRequestAware
	{
		public DelegateCommand YesCommand { get; private set; }
		public DelegateCommand NoCommand { get; private set; }
		public DelegateCommand OkCommand { get; private set; }
		public Action FinishInteraction { get; set; }

		private IConfirmation _notification;
		public INotification Notification
		{
			get { return _notification; }
			set { SetProperty(ref _notification, (IConfirmation)value); }
		}
		public ConfirmationViewModel()
		{
			YesCommand = new DelegateCommand(ExecuteYes);
			NoCommand = new DelegateCommand(ExecuteNo);
			OkCommand = new DelegateCommand(ExecuteYes);
		}
		private void ExecuteNo()
		{
			_notification.Confirmed = false;
			FinishInteraction?.Invoke();
		}
		private void ExecuteYes()
		{
			_notification.Confirmed = true;
			FinishInteraction?.Invoke();
		}
	}
}
