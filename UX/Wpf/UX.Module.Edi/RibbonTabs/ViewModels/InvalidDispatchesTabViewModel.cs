using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using UX.Module.Edi.Core.Enums;
using UX.Module.Edi.Core.Events;
using UX.Module.Edi.Core.Messages;

namespace UX.Module.Edi.RibbonTabs.ViewModels
{
    public class InvalidDispatchesTabViewModel : BindableBase
    {
        public string Header { get; set; } = "Invalid Dispatches";
        public string HelpdeskCaption { get; set; } = "Helpdesk";
        public string HelpCaption { get; set; } = "Help";
        public string ReprocessInvalidsCaption { get; set; } = "Reprocess Invalid Dispatches";
        public string ReprocessCaption { get; set; } = "Reprocess Duplicate Dispatches";
        public string ReloadCaption { get; set; } = "Reload";
        public DelegateCommand ReprocessInvalidsCommand { get; set; }
        public DelegateCommand ReprocessCommand { get; set; }
        public DelegateCommand ReloadCommand { get; set; }
        public string ExportCaption { get; set; } = "Export";
        public string XLSExportCaption { get; set; } = "Export XLSX";
        public string OpenOnExportCaption { get; set; } = "Open On Export";
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }
        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }
        private bool _isReprocessInvalidsEnabled;
        public bool IsReprocessInvalidsEnabled
        {
            get { return _isReprocessInvalidsEnabled; }
            set { SetProperty(ref _isReprocessInvalidsEnabled, value); }
        }
        private bool _isReprocessEnabled;
        public bool IsReprocessEnabled
        {
            get { return _isReprocessEnabled; }
            set { SetProperty(ref _isReprocessEnabled, value); }
        }

        private bool _isReloadEnabled;
        public bool IsReloadEnabled
        {
            get { return _isReloadEnabled; }
            set { SetProperty(ref _isReloadEnabled, value); }
        }
        public string OpenLastCaption { get; set; } = "Open Last Export";
        public DelegateCommand ExportCommand { get; set; }
        public DelegateCommand OpenLastExportCommand { get; set; }
        public IEventAggregator EventAggregator { get; set; }
        public RibbonTabOperation Operation { get; set; } = RibbonTabOperation.Empty;
        public InvalidDispatchesTabViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;

            ReloadCommand = new DelegateCommand(ExecuteReload);
            ReprocessInvalidsCommand = new DelegateCommand(ExecuteReprocessInvalids);
            ReprocessCommand = new DelegateCommand(ExecuteReprocessDuplicates);
            ExportCommand = new DelegateCommand(ExecuteExport);
            OpenLastExportCommand = new DelegateCommand(ExecuteOpenLastExport);

            EventAggregator.GetEvent<InvalidDispatchesEvent>().Subscribe(UpdateUx);

            // for now
            IsReprocessInvalidsEnabled = true;
        }

        private void UpdateUx(InvalidDispatchesMessage message)
        {
            IsReprocessEnabled = message.Operation == RibbonTabOperation.InvalidDisabled;
            IsReprocessInvalidsEnabled = message.Operation == RibbonTabOperation.InvalidEnabled;
            IsReloadEnabled = message.Operation == RibbonTabOperation.InvalidEnabled;
            Operation = message.Operation;
        }

        private void ExecuteReload()
        {
            if(EventAggregator!=null)
            {
                EventAggregator.GetEvent<InvalidDispatchesReloadDataEvent>().Publish();
            }
        }
        private void ExecuteReprocessInvalids()
        {
            // this is on the backend
            EventAggregator?.GetEvent<InvalidDispatchesReprocessDataEvent>()
                .Publish(new ProcessDataMessage
                    { Operation = RibbonTabOperation.ReprocessInvalidDispatches });
        }
        private void ExecuteReprocessDuplicates()
        {
            if (EventAggregator != null)
            {
                EventAggregator.GetEvent<InvalidDispatchesReprocessDataEvent>()
                    .Publish(new ProcessDataMessage 
                        { Operation = RibbonTabOperation.ReprocessDuplicateDispatches });
            }
        }
        private void ExecuteExport()
        {
            if (EventAggregator != null)
            {
                EventAggregator.GetEvent<InvalidDispatchesExportDataEvent>().Publish(new ExportDataMessage{ Message = "ExportData", IsSelected = IsSelected });
            }
        }
        private void ExecuteOpenLastExport()
        {
            if (EventAggregator != null)
            {
                EventAggregator.GetEvent<InvalidDispatchesExportDataEvent>().Publish(new ExportDataMessage() { Message = "OpenLastExport", IsSelected = IsSelected });
            }
        }
    }
}
