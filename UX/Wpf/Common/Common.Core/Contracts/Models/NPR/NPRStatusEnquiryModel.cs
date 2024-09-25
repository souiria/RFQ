/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NPRStatusEnquiryModel.cs
Function           :   NPRStatusEnquiryModel
Created By         :  Virendra 
Created on         :   27-sept-2022
Revision History   :   [05-April-2023] : Virendra
                   :   []: Added New class NPRStatus_Filter
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPR
{
    [DataContract, Serializable]
    public class NPRStatusEnquiryModel
    {
        /// <summary>
        /// Local variable _Parameter_Key  
        /// </summary>
        private Guid _nPRId;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        public Guid NPRID
        {
            get => _nPRId;
            set => _nPRId = value;
        }

        private ObservableCollection<ChangeBatch> _changeBatch;
        /// <summary>
        /// Gets of Sets the value of indicating {SampleSiteDetails} a key value pair of Project details
        /// </summary>
        [DataMember]
        public ObservableCollection<ChangeBatch> ChangeBatch
        {
            get => _changeBatch;
            set => _changeBatch = value;
        }
    }
    public class ChangeBatch
    {
        //we can have batchid with this

        private Guid _modifiedBy;
        public Guid ModifiedBy
        {
            get => _modifiedBy;
            set => _modifiedBy = value;
        }

        private string _modifiedByUserName;
        public string ModifiedByUserName
        {
            get => _modifiedByUserName;
            set => _modifiedByUserName = value;
        }

        private DateTime? _modifiedDate;
        public DateTime? ModifiedDate
        {
            get => _modifiedDate;
            set => _modifiedDate = value;
        }

        private string _modifiedDateTime;
        public string ModifiedDateTime
        {
            get => _modifiedDateTime;
            set => _modifiedDateTime = value;
        }

        private string _newValue;
        public string NewValue
        {
            get => _newValue;
            set => _newValue = value;
        }
        private string _oldValue;
        public string OldValue
        {
            get => _oldValue;
            set => _oldValue = value;
        }

        private string _requestId;
        public string RequestId
        {
            get => _requestId;
            set => _requestId = value;
        }

        private string _supplierGroup;
        public string SupplierGroup
        {
            get => _supplierGroup;
            set => _supplierGroup = value;
        }

        private Guid _nprId;
        public Guid NPRID
        {
            get => _nprId;
            set => _nprId = value;
        }
    }
    public class NPRStatus_Filter
    {
        private string _requestID;
        [DataMember]
        public string RequestID
        {
            get => _requestID;
            set => _requestID = value;
        }
        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }
        private string _supplierPartNumber;
        [DataMember]
        public string SupplierPartNumber
        {
            get => _supplierPartNumber;
            set => _supplierPartNumber = value;
        }
        private string _manufacturerGroup;
        [DataMember]
        public string ManufacturerGroup
        {
            get => _manufacturerGroup;
            set => _manufacturerGroup = value;
        }
    }
}
