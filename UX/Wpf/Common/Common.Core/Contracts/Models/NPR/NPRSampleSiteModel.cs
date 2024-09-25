/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NPRSampleSiteModel.cs
Function           :   New Part Request 
Created By         :   Amit Agarwal
Created on         :   10-Jun-2019
Revision History   :   Srashti
*                  :   [30-Aug-2019]: Added the [ExpectedDeliveryDate],[OrderedDate],[Comments],[SampleOrderStatus]
*                  :   [01-Sep-2019] : Pawan
*                  :   [] : Added Field for Receipt Date 
*                  :   [09-Sep-2019] : Pawan
*                  :   [] : Added Field for Freight Account  and Transport Agent
*                  :   [16-Sep-2019] : Pawan
*                  :   [] : Added Field for PO Number
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPR
{
    public enum SampleOrderStatus
    {
        Required,
        Ordered,
        Received
    }
    /// <summary>
    /// This class is used to have information about project details of NPR.
    /// </summary>
    [DataContract, Serializable]
    public class NPRSampleSiteModel :  BaseModel<Guid>
    {
        /// <summary>
        /// Local Reference of BusinessUnitGuid property
        /// </summary>
        private Guid _businessUnitGuid;
        /// <summary>
        /// Get or Sets the value of indicating {BusinessUnitGuid} of Business Unit Master
        /// </summary>
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        /// <summary>
        /// Local reference of BusinessUnitName property
        /// </summary>
        private string _businessUnitName;
        /// <summary>
        /// Gets of Sets the value of indicating {BusinessUnitName}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(50)]
        public string BusinessUnitName
        {
            get => _businessUnitName;
            set => SetProperty(ref _businessUnitName, value);
        }

        /// <summary>
        /// Local reference of BusinessUnitCode property
        /// </summary>
        private string _businessUnitCode;
        /// <summary>
        /// Gets of Sets the value of indicating {BusinessUnitCode}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(4)]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }

        /// <summary>
        /// Local reference of SampleQty property
        /// </summary>
        private int _sampleQty;
        /// <summary>
        /// Gets of Sets the value of indicating {SampleQty}
        /// </summary>
        [DataMember]
        [Required]
        public int SampleQty
        {
            get => _sampleQty;
            set => SetProperty(ref _sampleQty, value);
        }

        /// <summary>
        /// Local Reference of SendSampleContactPersonGuid property
        /// </summary>
        private Guid _sendSampleContactPersonGuid;
        /// <summary>
        /// Get or Sets the value of indicating {SendSampleContactPersonGuid} of Contact
        /// </summary>
        [DataMember]
        [Required]
        public Guid SendSampleContactPersonGuid
        {
            get => _sendSampleContactPersonGuid;
            set => SetProperty(ref _sendSampleContactPersonGuid, value);
        }

        /// <summary>
        /// Local reference of SendSampleContactPersonName property
        /// </summary>
        private string _sendSampleContactPersonName;
        /// <summary>
        /// Gets of Sets the value of indicating {SendSampleContactPersonName}
        /// </summary>
        [DataMember]
        [StringLength(50)]
        [Required]
        public string SendSampleContactPersonName
        {
            get => _sendSampleContactPersonName;
            set => SetProperty(ref _sendSampleContactPersonName, value);
        }

        /// <summary>
        /// Local reference of RequiredDate property
        /// </summary>
        private DateTime _requiredDate;
        /// <summary>
        /// Gets of Sets the value of indicating {RequiredDate} of Sample Site
        /// </summary>
        [DataMember, DataType(DataType.Date)]
        [Required]
        public DateTime RequiredDate
        {
            get => _requiredDate;
            set => SetProperty(ref _requiredDate, value.Date);
        }

        /// <summary>
        /// Local reference of ExpectedDeliveryDate property
        /// </summary>
        private DateTime _expectedDeliveryDate;
        /// <summary>
        /// Gets of Sets the value of indicating {ExpectedDeliveryDate} of Sample Site
        /// </summary>
        [DataMember, DataType(DataType.Date)]
        [Required]
        public DateTime ExpectedDeliveryDate
        { 
            get => _expectedDeliveryDate;
            set => SetProperty(ref _expectedDeliveryDate, value.Date);
        }

        /// <summary>
        /// Local reference of ReceiptDate property
        /// </summary>
        private DateTime _receiptDate;
        /// <summary>
        /// Gets of Sets the value of indicating {ReceiptDate} of Sample Site
        /// </summary>
        [DataMember, DataType(DataType.Date)]
        [Required]
        public DateTime ReceiptDate
        {
            get => _receiptDate;
            set => SetProperty(ref _receiptDate, value.Date);
        }

        /// <summary>
        /// Local reference of OrderedDate property
        /// </summary>
        private DateTime _orderedDate;
        /// <summary>
        /// Gets of Sets the value of indicating {OrderedDate} of Sample Site
        /// </summary>
        [DataMember, DataType(DataType.Date)]
        [Required]
        public DateTime OrderedDate

        {
            get => _orderedDate;
            set => SetProperty(ref _orderedDate, value.Date);
        }

        /// <summary>
        /// Local reference of Comments property
        /// </summary>
        private string _comments;
        /// <summary>
        /// Gets of Sets the value of indicating {Comments} of Sample Site
        /// </summary>
        [DataMember]
        [Required]
        public string Comments

        {
            get => _comments;
            set => SetProperty(ref _comments, value);
        }

        /// <summary>
        /// Local reference of SampleOrderStatus property
        /// </summary>
        private SampleOrderStatus _sampleOrderStatus;
        /// <summary>
        /// Gets of Sets the value of indicating {SampleOrderStatus} of Sample Site
        /// </summary>
        [DataMember]
        [Required]
        public SampleOrderStatus SampleOrderStatus

        {
            get => _sampleOrderStatus;
            set => SetProperty(ref _sampleOrderStatus, value);
        }

        private string _freightAccount;
        /// <summary>
        /// Gets or sets a string value for the Freight Account, freetext of max length 20 digits.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string FreightAccount
        {
            get => _freightAccount;
            set => SetProperty(ref _freightAccount, value);
        }

        private string _transportAgent;
        /// <summary>
        /// Gets or sets a string value for the Freight Account, freetext of max length 15 digits and probable input is DHL/Courier Service Name.
        /// </summary>
        [DataMember]
        [StringLength(15)]
        public string TransportAgent
        {
            get => _transportAgent;
            set => SetProperty(ref _transportAgent, value);
        }

        private string _poNumber;
        /// <summary>
        /// Gets or sets a string value for the PO Number, freetext of max length 15 digits.
        /// </summary>
        [DataMember]
        [StringLength(15)]
        public string PONumber
        {
            get => _poNumber;
            set => SetProperty(ref _poNumber, value);
        }
    }
}
