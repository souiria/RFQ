/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   InvoiceManagementModel.cs
Function           :   Invoice Management
Created By         :   Vishwadeep Singh
Created on         :   21-Jul-2023
Revision History   :   [31-Aug-2023] : Prakhar
                   :   [HD-00383937] : Changed InvoiceQuantity from decimal to int
*
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class InvoiceManagementModel : BaseModel<Guid>
    {

        private long _seq_Id;
        [DataMember]
        [Required]
        public long Seq_Id
        {
            get => _seq_Id;
            set => SetProperty(ref _seq_Id, value);
        }

        private string _section_C;
        [DataMember]
        [Required]
        public string Section_C
        {
            get => _section_C;
            set => SetProperty(ref _section_C, value);
        }

        private string _supplierCode;
        [DataMember]
        [Required]
        public string SupplierCode
        {
            get => _supplierCode;
            set => SetProperty(ref _supplierCode, value);
        }

        private string _partNumber;
        [DataMember]
        [Required]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        private decimal _orderPrice;
        [DataMember]
        [Required]
        public decimal OrderPrice
        {
            get => _orderPrice;
            set => SetProperty(ref _orderPrice, value);
        }

        private decimal _supplierMatPOPrice;
        [DataMember]
        [Required]
        public decimal SupplierMatPOPrice
        {
            get => _supplierMatPOPrice;
            set => SetProperty(ref _supplierMatPOPrice, value);
        }

        private decimal _invoicePrice;
        [DataMember]
        [Required]
        public decimal InvoicePrice
        {
            get => _invoicePrice;
            set => SetProperty(ref _invoicePrice, value);
        }

        private DateTime? _orderPriceEffectiveDate;
        [DataMember]
        [Required]
        public DateTime? OrderPriceEffectiveDate
        {
            get => _orderPriceEffectiveDate;
            set => SetProperty(ref _orderPriceEffectiveDate, value);
        }
        private DateTime? _invoicePriceEffectiveDate;
        [DataMember]
        [Required]
        public DateTime? InvoicePriceEffectiveDate
        {
            get => _invoicePriceEffectiveDate;
            set => SetProperty(ref _invoicePriceEffectiveDate, value);
        }

        private DateTime? _invoiceReceivedDate;
        [DataMember]
        [Required]
        public DateTime? InvoiceReceivedDate
        {
            get => _invoiceReceivedDate;
            set => SetProperty(ref _invoiceReceivedDate, value);
        }

        private string _invoiceNumber;
        [DataMember]
        [Required]
        public string InvoiceNumber
        {
            get => _invoiceNumber;
            set => SetProperty(ref _invoiceNumber, value);
        }

        private DateTime? _invoiceDueDate;
        [DataMember]
        [Required]
        public DateTime? InvoiceDueDate
        {
            get => _invoiceDueDate;
            set => SetProperty(ref _invoiceDueDate, value);
        }

        private string _invoiceCurrency;
        [DataMember]
        [Required]
        public string InvoiceCurrency
        {
            get => _invoiceCurrency;
            set => SetProperty(ref _invoiceCurrency, value);
        }

        private int _invoiceQuantity;
        [DataMember]
        [Required]
        public int InvoiceQuantity
        {
            get => _invoiceQuantity;
            set => SetProperty(ref _invoiceQuantity, value);
        }
        private string _dHSCurrency;
        [DataMember]
        [Required]
        public string DHSCurrency
        {
            get => _dHSCurrency;
            set => SetProperty(ref _dHSCurrency, value);
        }

        private decimal _agrCurrExRate;
        [DataMember]
        [Required]
        public decimal AgrCurrExRate
        {
            get => _agrCurrExRate;
            set => SetProperty(ref _agrCurrExRate, value);
        }

        private decimal _orderedValue;
        [DataMember]
        [Required]
        public decimal OrderedValue
        {
            get => _orderedValue;
            set => SetProperty(ref _orderedValue, value);
        }
        
        private decimal _invoiceLineValue;
        [DataMember]
        [Required]
        public decimal InvoiceLineValue
        {
            get => _invoiceLineValue;
            set => SetProperty(ref _invoiceLineValue, value);
        }

        private decimal _diffInCorrencyOfInv;
        [DataMember]
        [Required]
        public decimal DiffInCorrencyOfInv
        {
            get => _diffInCorrencyOfInv;
            set => SetProperty(ref _diffInCorrencyOfInv, value);
        }

        private bool _payInvoice;
        [DataMember]
        [Required]
        public bool PayInvoice
        {
            get => _payInvoice;
            set => SetProperty(ref _payInvoice, value);
        }

        private string _buyerComment;
        [DataMember]
        [Required]
        public string BuyerComment
        {
            get => _buyerComment;
            set => SetProperty(ref _buyerComment, value);
        }
        private bool _buyerActionCompleted;
        [DataMember]
        [Required]
        public bool BuyerActionCompleted
        {
            get => _buyerActionCompleted;
            set => SetProperty(ref _buyerActionCompleted, value);
        }


        private Guid? _reasonForQueryGuid;
        [DataMember]
        [Required]
        public Guid? ReasonForQueryGuid
        {
            get => _reasonForQueryGuid;
            set => SetProperty(ref _reasonForQueryGuid, value);
        }
    }
}
