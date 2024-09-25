using System;

namespace SEWSE.H1.UX.Infrastructure.Core.Contracts
{
	public interface IDialogAware
	{
		bool CanCloseDialog();
		//InteractionResult DialogResult { get; }
		event Action RequestClose;
	}
}
