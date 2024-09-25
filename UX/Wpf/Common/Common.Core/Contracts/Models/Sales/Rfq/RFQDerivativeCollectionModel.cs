using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    [DataContract, NotMapped, Serializable]
    public class RFQDerivativeCollectionModel
    {
        [DataMember, NotMapped]
        public HarnessModel Harness { get; set; }
        [DataMember, NotMapped]
        public ObservableCollection<CompositeDetailModel> DerivativeList { get; set; }
        [DataMember, NotMapped]
        public bool IsAllDerivativesSelected { get; set; }
    }
}
