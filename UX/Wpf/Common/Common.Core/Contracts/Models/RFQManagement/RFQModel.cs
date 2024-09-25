/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   RFQModel.cs
Function           :   RFQModel
Created By         :   Dharmendra Kumar
Created on         :   24-Jun-2019
Revision History   :   [] : 
                   :   09-07-2019: Added new Property to refer RFQSubmitAllFieldsModel
                   :   [26-Aug-2019] : Pawan
                   :   [] : Added new Property for Supplier Code , Price Type
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.RFQManagement
{
    /// <summary>
    /// Types of RFQ Status
    /// </summary>
    public enum RFQStatusType
    {
        /// <summary>
        /// RFQ Created
        /// </summary>
        RFQCreated,
        /// <summary>
        /// RFQ issued to supplier
        /// </summary>
        RFQIssuedToSupplier,
        /// <summary>
        /// Supplier Submits RFQ
        /// </summary>
        SupplierSubmitsQuotation,
        /// <summary>
        /// Quotation Returned to Same Supplier
        /// </summary>
        QuotationReturnedtoSameSupplier,
        /// <summary>
        /// Supplier ReSubmits Quotation
        /// </summary>
        SupplierReSubmitsQuotation,
        /// <summary>
        /// Approved RFQ Moved to Supplier Selection
        /// </summary>
        ApprovedRFQMovedtoSupplierSelection,
        /// <summary>
        /// NPR Returned to Originator
        /// </summary>
        NPRReturnedtoOriginator,
        /// <summary>
        /// Originator Submit to NPR Backlog
        /// </summary>
        OriginatorSubmittoNPRBacklog,
        /// <summary>
        /// Close NPR with RFQ Status as Business Won
        /// </summary>
        CloseNPRwithRFQStatusasBusinessWon,
        /// <summary>
        /// CloseNPR with RFQ Status as Business Not Won
        /// </summary>
        CloseNPRwithRFQStatusasBusinessNotWon,
        /// <summary>
        /// Email Notification Send
        /// </summary>
        EmailNotificationSend
    }
    /// <summary>
    /// Item of RFQ 
    /// </summary>
    [DataContract, Serializable]
    public class RFQModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local Reference of {NPRBackLogList} property
        /// </summary>
        private List<NPRBacklogModel> _nprBackLogList;
        /// <summary>
        /// Gets or Sets the value of {NPRBacklogModel}
        /// </summary>       
        [DataMember]
        public List<NPRBacklogModel> NPRBackLogList
        {
            get => _nprBackLogList;
            set => SetProperty(ref _nprBackLogList, value);
        }
        /// <summary>
        /// Local Reference of {RFQNumber} property
        /// </summary>
        private string _rfqNumber;
        /// <summary>
        /// Gets or Sets the value of RFQNumber
        /// </summary>       
        [DataMember]
        [StringLength(12)]
        public string RFQNumber
        {
            get => _rfqNumber;
            set => SetProperty(ref _rfqNumber, value);
        }

        /// <summary>
        /// Local status of RFQ Status Item
        /// </summary>
        private RFQStatusType _rfqStatus = RFQStatusType.RFQIssuedToSupplier;
        /// <summary>
        /// Status of NPR Backlog Item
        /// </summary>
        [DataMember]
        public RFQStatusType RFQStatus
        {
            get => _rfqStatus;
            set => SetProperty(ref _rfqStatus, value);
        }

        /// <summary>
        /// Local Reference of Remarks/Comment
        /// </summary>
        private string _remarks;
        /// <summary>
        /// Additional Remarks if any
        /// </summary>
        [DataMember]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }
        private string _rfqStage;

        /// <summary>
        /// Gets or sets a string value for the RFQ Stages.
        /// </summary>
        [DataMember]
        [StringLength(2)]
        public string RFQStage
        {
            get => _rfqStage;
            set => SetProperty(ref _rfqStage, value);
        }

        //private Guid _businessUnitGuid;
        //[DataMember]
        //[Required]
        //public Guid BusinessUnitGuid
        //{
        //    get => _businessUnitGuid;
        //    set => SetProperty(ref _businessUnitGuid, value);
        //}

        //private string _supplierCode;

        ///// <summary>
        ///// Gets or sets a string value for the Supplier Code.
        ///// </summary>
        //[DataMember]
        //[StringLength(4)]
        //public string SupplierCode
        //{
        //    get => _supplierCode;
        //    set => SetProperty(ref _supplierCode, value);
        //}
        //private string _priceTypeCode;
        ///// <summary>
        ///// Gets or sets a string value for the Price Type Code.
        ///// </summary>
        //[DataMember]
        //[StringLength(2)]
        //public string PriceTypeCode
        //{
        //    get => _priceTypeCode;
        //    set => SetProperty(ref _priceTypeCode, value);
        //}

        /// <summary>
        /// Local Reference of RFQReturnedToSupplierRemarks
        /// </summary>
        private string _rfqReturnedtoSupplierRemarks;
        /// <summary>
        /// NPR Returned Remarks
        /// </summary>
        [DataMember]
        public string RFQReturnedToSupplierRemarks
        {
            get => _rfqReturnedtoSupplierRemarks;
            set => SetProperty(ref _rfqReturnedtoSupplierRemarks, value);
        }
    }
}
