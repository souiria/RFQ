using Prism.Events;
using Prism.Regions;
using SEWSE.H1.UX.Infrastructure.Core.Contracts;
using SEWSE.H1.UX.Infrastructure.Core.Models;
using System;
using System.Windows.Input;

namespace SEWSE.H1.UX.Infrastructure.Core
{
    [Obsolete("This ViewModel is obsolete. Please use BaseViewModel instead.")]
    public abstract class AsyncViewModelBase : ViewModelBase
    {
        public new ICommand PageLoadedCommand { get; set; }

        public AsyncViewModelBase(IEventAggregator eventAggregator = null, IRegionManager regionManager = null, IDialogService dialogService = null) : base(eventAggregator, regionManager, null, dialogService)
        {
            PageLoadedCommand = new AwaitableDelegateCommand(() => ShowBusyIndicator(PreLoad));
        }

        protected virtual void PreLoad()
        {
            FillLabelsFromResxFileInUX(LabelsNeeded);
            ExecuteViewLoad();
        }

        protected abstract void ExecuteViewLoad();
    }
}
