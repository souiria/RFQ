using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Events;
using Prism.Regions;
using UX.Commercial.Edi.Core.Dto;
using UX.Commercial.Edi.Core.Enums;
using UX.Commercial.Edi.Core.Events;
using UX.Commercial.Edi.Core.Interfaces;
using UX.Commercial.Edi.Core.Messages;
using UX.Commercial.Edi.Core.Messages.Requests;

namespace UX.Commercial.Edi.ViewModels
{
    internal class GrpcTestViewModel : RegionViewModelBase
    {
        private readonly IMessageService _messageService;

        #region Properties

        private bool _isBusy;
        private bool _isEnabled;
        private bool _openOnExportIsSelected;
        private string _lastExportFileName;
        private ObservableCollection<EdiInvoiceInformationDto> _invoiceInformationData;
        private string _myMessage;

        public string MyMessage
        {
            get => _myMessage;
            set => SetProperty(ref _myMessage, value);
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }

        public bool OpenOnExportIsSelected
        {
            get => _openOnExportIsSelected;
            set => SetProperty(ref _openOnExportIsSelected, value);
        }

        public string LastExportFileName
        {
            get => _lastExportFileName;
            set => SetProperty(ref _lastExportFileName, value);
        }

        public ObservableCollection<EdiInvoiceInformationDto> InvoiceInformationData
        {
            get => _invoiceInformationData;
            set => SetProperty(ref _invoiceInformationData, value);
        }

        public IAsyncEnumerable<EdiInvoiceInformationDto> Test { get; set; }

        #endregion

        public GrpcTestViewModel(IEventAggregator eventAggregator, IRegionManager regionManager, IMessageService messageService) : base(eventAggregator, regionManager)
        {
            _messageService = messageService;
            MyMessage = "Records Loaded:";
            InvoiceInformationData = new();
            EventAggregator.GetEvent<InvalidDispatchesReloadDataEvent>().Subscribe(ExecuteReload);

        }

        protected override async Task ExecuteViewLoad()
        {
            await base.ExecuteViewLoad();
            await GetInvoiceInformation();
        }

        private async Task GetInvoiceInformation()
        {
            try
            {
                EventAggregator.GetEvent<InvalidDispatchesEvent>().Publish(new InvalidDispatchesMessage() { Operation = RibbonTabOperation.InvalidDisabled });
                
                //IsEnabled = false;
                
                InvoiceInformationData.Clear();
                //EventAggregator.GetEvent<InvoiceInformationDataLoadedEvent>().Publish(InvoiceInformationData);
                var request = new InvoiceInformationRequest()
                {
                    IsCompressed = false,
                    RequestType = InvoiceInformationRequestType.GetAllInvoiceInformation
                };

                var results = _messageService.GetAllInvoiceInformation("invoiceInformation", request);
                await foreach (var item in results)
                {
                    InvoiceInformationData.Add(item);
                    if (InvoiceInformationData.Count % 100 == 0)
                    {
                        MyMessage = "Dataset Size: " + InvoiceInformationData.Count;
                        EventAggregator.GetEvent<InvoiceInformationDataLoadedEvent>().Publish(InvoiceInformationData);
                    }
                }
                MyMessage = "Dataset Size: " + InvoiceInformationData.Count;
                EventAggregator.GetEvent<InvoiceInformationDataLoadedEvent>().Publish(InvoiceInformationData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                EventAggregator.GetEvent<InvalidDispatchesEvent>().Publish(new InvalidDispatchesMessage() { Operation = RibbonTabOperation.InvalidEnabled });
                IsEnabled = true;
                HideBusyIndicator();
            }
        }

        private async void ExecuteReload()
        {
            //IsBusy = true;
            await GetInvoiceInformation();
            //IsBusy = false;
        }
        
    }
}
