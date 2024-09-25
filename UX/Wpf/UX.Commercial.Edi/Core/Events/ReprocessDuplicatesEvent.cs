using System.Collections.ObjectModel;
using Prism.Events;
using UX.Commercial.Edi.Core.Dto;

namespace UX.Commercial.Edi.Core.Events
{
    public class ReprocessDuplicatesEvent : PubSubEvent<ObservableCollection<DuplicateDataDto>> { }
}
