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
    internal class HeldUpDispatchesViewModel : RegionViewModelBase
    {
        private ObservableCollection<EdiInvoiceInformationDto> _heldUpDispatchesData;

        public ObservableCollection<EdiInvoiceInformationDto> HeldUpDispatchesData
        {
            get => _heldUpDispatchesData;
            set => SetProperty(ref _heldUpDispatchesData, value);
        }
        public HeldUpDispatchesViewModel(IEventAggregator eventAggregator, IRegionManager regionManager) : base(eventAggregator, regionManager)
        {
            HeldUpDispatchesData = new ObservableCollection<EdiInvoiceInformationDto>();
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
            StatusBarMessageHelper.DisplayMessage($"Displaying {HeldUpDispatchesData.Count} invoices", "Held Up Dispatches", UXNotificationType.SuccessMessage);
        }

        private void PopulateData(ObservableCollection<EdiInvoiceInformationDto> ediInvoiceInformation)
        {
            HeldUpDispatchesData.Clear();
            HeldUpDispatchesData.AddRange(ediInvoiceInformation.Where(x => x.Status == EdiInvoiceStatus.HeldUp));
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
