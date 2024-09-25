using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.SF.Contracts.Models.Sales.Rfq
{
    [DataContract, Serializable]
    public class RFQSupplierModel : ExternalDataSourceModel<object>
    {
        [DataMember]
        public string SupplierId { get; set; }
        [DataMember]
        public string SumitomoNumber { get; set; }
        [DataMember]
        public string SupplierCode { get; set; }
        [DataMember]
        public string SupplierName { get; set; }
        [DataMember]
        public string SupplierNumber { get; set; }
        [DataMember]
        public string PORatio { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public string Price { get; set; }
        [DataMember]
        public string UnitOfMeasurement { get; set; }

    }
}
