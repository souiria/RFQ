using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Common.UX.Wpf.Contracts.Models;
using Prism.Events;
using Prism.Regions;
using UX.Commercial.Edi.Core.Dto;
using UX.Commercial.Edi.Core.Enums;
using UX.Commercial.Edi.Core.Events;
using UX.Commercial.Edi.Core.Messages;

namespace UX.Commercial.Edi.ViewModels
{
    public class InvalidPricesViewModel : RegionViewModelBase
    {
        private ObservableCollection<EdiInvoiceInformationDto> _invalidPricesData;

        public ObservableCollection<EdiInvoiceInformationDto> InvalidPricesData
        {
            get => _invalidPricesData;
            set => SetProperty(ref _invalidPricesData, value);
        }

        public InvalidPricesViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) : base(eventAggregator, regionManager)
        {
            InvalidPricesData = new ObservableCollection<EdiInvoiceInformationDto>();
            EventAggregator.GetEvent<InvoiceInformationDataLoadedEvent>().Subscribe(PopulateData);
            EventAggregator.GetEvent<InvalidDispatchesReprocessDataEvent>().Subscribe(ExecuteReprocessData);
        }

        protected override async Task ExecuteViewLoad()
        {
            await base.ExecuteViewLoad();
            if (EventAggregator != null)
            {
                EventAggregator.GetEvent<InvalidDispatchesReloadDataEvent>().Publish();
                
            }
            StatusBarMessageHelper.DisplayMessage($"Displaying {InvalidPricesData.Count} invoices", "Invalid Prices", UXNotificationType.SuccessMessage);
        }

        private void PopulateData(ObservableCollection<EdiInvoiceInformationDto> ediInvoiceInformation)
        {
            InvalidPricesData.Clear();
            InvalidPricesData.AddRange(ediInvoiceInformation.Where(x => x.Status == EdiInvoiceStatus.MissingPrice));
        }

        private void ExecuteReprocessData(ProcessDataMessage message)
        {
            if (message.Operation == RibbonTabOperation.ReprocessInvalidDispatches)
            {
                // do the thing 
                EventAggregator.GetEvent<ReprocessDataEvent>().Publish();
            }
        }
    }
}
