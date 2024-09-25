using System.Collections.ObjectModel;
using Prism.Events;
using UX.Module.Edi.Core.Dto;

namespace UX.Module.Edi.Core.Events
{
    public class InvoiceInformationDataLoadedEvent : PubSubEvent<ObservableCollection<EdiInvoiceInformationDto>> { }
}
