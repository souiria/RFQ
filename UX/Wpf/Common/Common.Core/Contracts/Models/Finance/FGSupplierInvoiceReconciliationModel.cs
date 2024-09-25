/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   FGSupplierInvoiceReconciliation.cs
Function           :   FG Supplier Invoice Reconciliation
Created By         :   Prakhar Singh
Created on         :   13-03-2023
Revision History   : [29-Mar-2023] : Ranjay 
                   : [] Added new field in class FGSupplierInvoiceReconciliationFilterModel
                   : [08-Jul-2023] : Dharmendra 
                   : []  Remove unused property
                   : [10-Jan-2024] : Prakhar 
                   : [HD-00395018]: Added new Class FGSupplierInvoiceReconciliationPriceDifferenceRecapModel

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

namespace Common.Core.Contracts.Models.Finance
{
    [DataContract, Serializable]
    public class FGSupplierInvoiceReconciliationModel : BaseModel<Guid>
    {

        private string _invoiceNo;
        [DataMember]
        public string InvoiceNo
        {
            get => _invoiceNo;
            set => SetProperty(ref _invoiceNo, value);
        }

        private bool _invoiceOverallValueStatus;
        [DataMember]
        public bool InvoiceOverallValueStatus
        {
            get => _invoiceOverallValueStatus;
            set => SetProperty(ref _invoiceOverallValueStatus, value);
        }

        private bool _itemValueStatus;
        [DataMember]
        public bool ItemValueStatus
        {
            get => _itemValueStatus;
            set => SetProperty(ref _itemValueStatus, value);
        }

        private bool _productPriceStatus;
        [DataMember]
        public bool ProductPriceStatus
        {
            get => _productPriceStatus;
            set => SetProperty(ref _productPriceStatus, value);
        }

        private bool _receptionDiscrepanciesStatus;
        [DataMember]
        public bool ReceptionDiscrepanciesStatus
        {
            get => _receptionDiscrepanciesStatus;
            set => SetProperty(ref _receptionDiscrepanciesStatus, value);
        }

        private bool _extraQtyReceptionVsOrderStatus;
        [DataMember]
        public bool ExtraQtyReceptionVsOrderStatus
        {
            get => _extraQtyReceptionVsOrderStatus;
            set => SetProperty(ref _extraQtyReceptionVsOrderStatus, value);
        }

        private bool _validated;
        [DataMember]
        public bool Validated
        {
            get => _validated;
            set => SetProperty(ref _validated, value);
        }

        private string _comments;
        [DataMember]
        public string Comments
        {
            get => _comments;
            set => SetProperty(ref _comments, value);
        }

        private string _print;
        [DataMember]
        public string Print
        {
            get => _print;
            set => SetProperty(ref _print, value);
        }

        private string _export;
        [DataMember]
        public string Export
        {
            get => _export;
            set => SetProperty(ref _export, value);
        }

        private DateTime _invoiceDateTime;
        [DataMember]
        public DateTime InvoiceDateTime
        {
            get => _invoiceDateTime;
            set => SetProperty(ref _invoiceDateTime, value);
        }

        private string _dispatchNo;
        [DataMember]
        public string DispatchNo
        {
            get => _dispatchNo;
            set => SetProperty(ref _dispatchNo, value);
        }

        private DateTime _dispatchDate;
        [DataMember]
        public DateTime DispatchDate
        {
            get => _dispatchDate;
            set => SetProperty(ref _dispatchDate, value);
        }

        private string _buyerPartNo;
        [DataMember]
        public string BuyerPartNo
        {
            get => _buyerPartNo;
            set => SetProperty(ref _buyerPartNo, value);
        }

        private string _orderNo;
        [DataMember]
        public string OrderNo
        {
            get => _orderNo;
            set => SetProperty(ref _orderNo, value);
        }

        private decimal _invoiceProductPrice;
        [DataMember]
        [DecimalPrecision(15, 6)]
        [Required]
        public decimal InvoiceProductPrice
        {
            get => _invoiceProductPrice;
            set => SetProperty(ref _invoiceProductPrice, value);
        }
        //check
        private Decimal _pOProductPrice;
        [DataMember]
        [DecimalPrecision(15, 6)]
        [Required]
        public decimal POProductPrice
        {
            get => _pOProductPrice;
            set => SetProperty(ref _pOProductPrice, value);
        }

        private int _qtyDelivered;
        [DataMember]
        public int QtyDelivered
        {
            get => _qtyDelivered;
            set => SetProperty(ref _qtyDelivered, value);
        }

      
        private DateTime _paymentDueDate;
        [DataMember]
        public DateTime PaymentDueDate
        {
            get => _paymentDueDate;
            set => SetProperty(ref _paymentDueDate, value);
        }

    }
    [DataContract, Serializable]
    public class FGSupplierInvoiceReconciliationFilterModel
    {
        private Guid _buisnessUnitGuid;
        /// <summary>
        /// Get or Set for {BuisnessUnitGuid}.
        /// </summary>
        [DataMember]
        public Guid BuisnessUnitGuid
        {
            get => _buisnessUnitGuid;
            set => _buisnessUnitGuid = value;
        }

        private DateTime? _dateTo;
        /// <summary>
        /// Get or Set for {DateTo}.
        /// </summary>
        [DataMember]
        public DateTime? DateTo
        {
            get => _dateTo;
            set => _dateTo = value;
        }

        private DateTime? _dateFrom;
        /// <summary>
        /// Get or Set for {DateFrom}.
        /// </summary>
        [DataMember]
        public DateTime? DateFrom
        {
            get => _dateFrom;
            set => _dateFrom = value;
        }

        private string _invoiceValidated;
        [DataMember]
        public string InvoiceValidated
        {
            get => _invoiceValidated;
            set => _invoiceValidated = value;
        }

        private string _invoiceNumber;
        [DataMember]
        public string InvoiceNumber
        {
            get => _invoiceNumber;
            set => _invoiceNumber = value;
        }

        private string _mode;
        [DataMember]
        public string Mode
        {
            get => _mode;
            set => _mode = value;
        }
    }

    public class FGSupplierInvoiceReconciliationPriceDifferenceRecapModel
    {
        private string _invoiceNo;
        [DataMember]
        public string InvoiceNo
        {
            get => _invoiceNo;
            set => _invoiceNo = value;
        }

        private DateTime _invoiceDateTime;
        [DataMember]
        public DateTime InvoiceDateTime
        {
            get => _invoiceDateTime;
            set => _invoiceDateTime = value;
        }

        private string _buyerPartNo;
        [DataMember]
        public string BuyerPartNo
        {
            get => _buyerPartNo;
            set =>  _buyerPartNo = value;
        }

        private string _orderNo;
        [DataMember]
        public string OrderNo
        {
            get => _orderNo;
            set =>  _orderNo = value;
        }

        private string _sellerPartNo;
        [DataMember]
        public string SellerPartNo
        {
            get => _sellerPartNo;
            set => _sellerPartNo = value;
        }

        private int _qtyDelivered;
        [DataMember]
        public int QtyDelivered
        {
            get => _qtyDelivered;
            set =>  _qtyDelivered = value;
        }

        private Decimal _invoicePrice;
        [DataMember]
        [DecimalPrecision(15, 6)]
        [Required]
        public decimal InvoicePrice
        {
            get => _invoicePrice;
            set =>  _invoicePrice = value;
        }

        private Decimal _poprice;
        [DataMember]
        [DecimalPrecision(15, 6)]
        [Required]
        public decimal Poprice
        {
            get => _poprice;
            set => _poprice = value;
        }
    }
}
