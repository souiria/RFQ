using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// Model for SupplierMaterialHierarchyUploadModel
    /// </summary>
    [DataContract, Serializable]
    public class InvoiceManagementUploadModel : BaseModel<Guid>
    {

        [DataMember]
        public int DHSId { get; set; }

        [DataMember]
        public string Site { get; set; }

        [DataMember]
        public string SupplierCode { get; set; }
        
        [DataMember]
        public string PartNumber { get; set; }

        [DataMember]
        public decimal OrderPrice { get; set; }

        [DataMember]
        public decimal PoPriceAtDateOfInvoiceReceived { get; set; }

        [DataMember]
        public decimal InvoicePrice { get; set; }

        [DataMember]
        public DateTime? OrderPriceEffectiveDate { get; set; }

        [DataMember]
        public DateTime? InvoicePriceEffectiveDate { get; set; }

        [DataMember]
        public DateTime? InvoiceReceivedDate { get; set; }

        [DataMember]
        public string InvoiceNumber { get; set; }

        [DataMember]
        public DateTime? InvoiceDueDate { get; set; }
        [DataMember]
        public string InvoiceCurrency { get; set; }
        [DataMember]
        public decimal InvoiceQuantity { get; set; }
        [DataMember]
        public string DHSCurrency { get; set; }
        [DataMember]
        public decimal ExchangeRate { get; set; }
        [DataMember]
        public decimal OrderedValue { get; set; }
        [DataMember]
        public decimal InvoiceLineValue { get; set; }
        [DataMember]
        public decimal DifferenceInTheCorrencyOfTheInvoice { get; set; }

        [DataMember]
        public bool PayInvoice { get; set; }
        
        [DataMember]
        public string BuyerComment { get; set; }
        
        [DataMember]
        public bool BuyerActionCompleted { get; set; }
        
        [DataMember]
        public string ReasonForQuery { get; set; }
        [DataMember]
        public string Buyer { get; set; }
    }
}
