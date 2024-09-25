using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    [DataContract]
    public class RFQRemovedStoreModel : BaseModel<Guid>
    {
        private RFQCreationGroupedPartModel _removedGroupedPart;
        [DataMember]
        public RFQCreationGroupedPartModel RemovedGroupedPart
        {
            get => _removedGroupedPart;
            set => SetProperty(ref _removedGroupedPart, value);
        }

        private RFQPartModel _removedPart;
        [DataMember]
        public RFQPartModel RemovedPart
        {
            get => _removedPart;
            set => SetProperty(ref _removedPart, value);
        }
    }
}
