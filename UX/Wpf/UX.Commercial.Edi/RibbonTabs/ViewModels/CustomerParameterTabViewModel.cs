using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using UX.Commercial.Edi.Core.Enums;
using UX.Commercial.Edi.Core.Events;
using UX.Commercial.Edi.Core.Messages;

namespace UX.Commercial.Edi.RibbonTabs.ViewModels
{
    public class CustomerParameterTabViewModel : BindableBase
    {
        private bool _isSelected;
        private bool _isEnabled;
        private bool _isBusy;
        private bool _isSaveEnabled;
        private bool _isRefreshEnabled;

        private IEventAggregator _eventAggregator;

        public string Header { get; set; } = "Location Master";
        public string HelpdeskCaption { get; set; } = "Helpdesk";
        public string HelpCaption { get; set; } = "Help";
        public string ActionsCaption { get; set; } = "Actions";
        public string AddCaption { get; set; } = "Add";
        public string DuplicateCaption { get; set; } = "Duplicate";
        public string DeleteCaption { get; set; } = "Delete";
        public string SaveCaption { get; set; } = "Update";
        public string ExportCaption { get; set; } = "Export";
        public string XLSExportCaption { get; set; } = "Export XLSX";
        public string OpenOnExportCaption { get; set; } = "Open On Export";
        public string OpenLastCaption { get; set; } = "Open Last Export";
        public string RefreshCaption { get; set; } = "Refresh";
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
        public bool IsRefreshEnabled
        {
            get { return _isRefreshEnabled; }
            set { SetProperty(ref _isRefreshEnabled, value); }
        }
        public bool IsSaveEnabled
        {
            get { return _isSaveEnabled; }
            set { SetProperty(ref _isSaveEnabled, value); }
        }

        public IEventAggregator EventAggregator { get => _eventAggregator; set => _eventAggregator = value; }
        
        public DelegateCommand CreateCommand { get; set; }
        public DelegateCommand DuplicateCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand ExportCommand { get; set; }
        public DelegateCommand OpenLastExportCommand { get; set; }
        public CustomerParameterTabViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            CreateCommand = new DelegateCommand(ExecuteCreate);
            DuplicateCommand = new DelegateCommand(ExecuteDuplicate);
            DeleteCommand = new DelegateCommand(ExecuteDelete);
            SaveCommand = new DelegateCommand(ExecuteSave);
            RefreshCommand = new DelegateCommand(ExecuteRefresh);
            ExportCommand = new DelegateCommand(ExecuteExport);
            OpenLastExportCommand = new DelegateCommand(ExecuteOpenLastExport);

            IsBusy = false;
            IsRefreshEnabled = false;
            IsSaveEnabled = false;
            EventAggregator.GetEvent<CustomerParameterEvent>().Subscribe(UpdateUX);
        }

        private void UpdateUX(CustomerParameterMessage message)
        {
            switch (message.Message)
            {
                case "IsBusy":
                    IsBusy = message.IsBusy;
                    break;
                case "IsDirty":
                    IsRefreshEnabled = message.IsDirty;
                    IsSaveEnabled = message.IsDirty;
                    break;
                default:
                    break;
            }
        }

        private void ExecuteCreate()
        {
            if (EventAggregator != null)
            {
                EventAggregator
                    .GetEvent<CustomerParameterUpdateEvent>()
                    .Publish(new UpdateMessage 
                    { 
                        Message = "CreateData", 
                        Operation = CRUDOperation.Create 
                    });
            }
        }
        private void ExecuteDuplicate()
        {
            if (EventAggregator != null)
            {
                EventAggregator
                    .GetEvent<CustomerParameterUpdateEvent>()
                    .Publish(new UpdateMessage() 
                    { 
                        Message = "DuplicateData", 
                        Operation = CRUDOperation.Duplicate 
                    });
            }
        }
        private void ExecuteDelete()
        {
            if (EventAggregator != null)
            {
                EventAggregator
                    .GetEvent<CustomerParameterUpdateEvent>()
                    .Publish(new UpdateMessage() 
                    { 
                        Message = "DeleteData", 
                        Operation = CRUDOperation.Delete 
                    });
            }
        }
        private void ExecuteSave()
        {
            if (EventAggregator != null)
            {
                EventAggregator
                    .GetEvent<CustomerParameterUpdateEvent>()
                    .Publish(new UpdateMessage() { 
                        Message = "SaveData",
                        Operation=CRUDOperation.Update 
                    });
            }
        }
        private void ExecuteRefresh()
        {
            if (EventAggregator != null)
            {
                EventAggregator
                    .GetEvent<CustomerParameterReloadDataEvent>()
                    .Publish();
            }
        }
        private void ExecuteExport()
        {
            if (EventAggregator != null)
            {
                EventAggregator
                    .GetEvent<CustomerParameterExportDataEvent>()
                    .Publish(new ExportDataMessage() 
                    { 
                        Message = "ExportData", 
                        IsSelected = IsSelected 
                    });
            }
        }
        private void ExecuteOpenLastExport()
        {
            if (EventAggregator != null)
            {
                EventAggregator
                    .GetEvent<CustomerParameterExportDataEvent>()
                    .Publish(new ExportDataMessage() 
                    { 
                        Message = "OpenLastExport", 
                        IsSelected = IsSelected 
                    });
            }
        }
    }
}
