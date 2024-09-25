using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using SEWSE.H1.UX.Infrastructure.Core.Contracts;

namespace SEWSE.H1.UX.Infrastructure.Core
{
    [Obsolete("This ViewModel is obsolete. Please use BaseViewModel instead.")]
    public class CRUDViewModelBase : ViewModelBase
    {
        public ICommand RecordUpdatedCommand { get; set; }
        public DelegateCommand CreateCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand HelpCommand { get; set; }
        public DelegateCommand ExportCommand { get; set; }
		public DelegateCommand PrintCommand { get; set; }
        public DelegateCommand OpenExportCommand { get; set; }

        public CRUDViewModelBase(IEventAggregator eventAggregator = null, IRegionManager regionManager = null, IGlobalCommands globalCommands = null) : base()
        {
            if (eventAggregator != null)
                base._eventAggregator = eventAggregator;
            if (regionManager != null)
                base._regionManager = regionManager;
            if (globalCommands != null)
                base._globalCommands = globalCommands;
        }
		public CRUDViewModelBase(IEventAggregator eventAggregator, IRegionManager regionManager, IGlobalCommands globalCommands, IDialogService dialogService) : base()
		{
			if (eventAggregator != null)
				base._eventAggregator = eventAggregator;
			if (regionManager != null)
				base._regionManager = regionManager;
			if (globalCommands != null)
				base._globalCommands = globalCommands;
			if (dialogService != null)
				base._dialogService = dialogService;
		}
	}
}
