using System;

namespace Common.UX.Wpf.Contracts.Interfaces
{
	public interface IDialogAware
	{
		bool CanCloseDialog();
		//InteractionResult DialogResult { get; }
		event Action RequestClose;
	}
}
