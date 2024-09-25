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
    internal class InvalidProductsViewModel : RegionViewModelBase
    {
        private ObservableCollection<EdiInvoiceInformationDto> _invalidProductsData;

        public ObservableCollection<EdiInvoiceInformationDto> InvalidProductsData
        {
            get => _invalidProductsData;
            set => SetProperty(ref _invalidProductsData, value);
        }
        public InvalidProductsViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) : base(eventAggregator, regionManager)
        {
            Header = "Invalid Products";
            InvalidProductsData = new ObservableCollection<EdiInvoiceInformationDto>();
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
            StatusBarMessageHelper.DisplayMessage($"Displaying {InvalidProductsData.Count} invoices", "Invalid Products", UXNotificationType.SuccessMessage);
        }

        private void PopulateData(ObservableCollection<EdiInvoiceInformationDto> ediInvoiceInformation)
        {
            InvalidProductsData.Clear();
            InvalidProductsData.AddRange(ediInvoiceInformation.Where(x => x.Status == EdiInvoiceStatus.MissingPart));
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
