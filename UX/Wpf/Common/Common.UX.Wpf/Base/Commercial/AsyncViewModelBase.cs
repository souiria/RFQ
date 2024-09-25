using System;
using System.Windows.Input;
using Common.UX.Wpf.Commands;
using Common.UX.Wpf.Contracts.Interfaces;
using Prism.Events;
using Prism.Regions;

namespace Common.UX.Wpf.Base.Commercial
{
    [Obsolete("This ViewModel is obsolete. Please use BaseViewModel instead.")]
    public abstract class AsyncViewModelBase : ViewModelBase
    {
        public new ICommand PageLoadedCommand { get; set; }

        public AsyncViewModelBase(IEventAggregator eventAggregator = null, IRegionManager regionManager = null, IDialogService dialogService = null) : base(eventAggregator, regionManager, dialogService)
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
