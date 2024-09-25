/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierSelectionHierarchyDisplayModel.cs
Function           :   Supplier Selection filter model
Created By         :   Dharmendra 
Created on         :   16-Jun-2022
Revision History   :   [] :
****************************************************************************************************/
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class SupplierSelectionHierarchyDisplayModel
    {
        private Guid _businessUnitGuid;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => _businessUnitGuid = value;
        }
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => _materialGuid = value;
        }
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => _supplierGuid = value;
        }
        private int _transitLeadTime;
        [DataMember]
        public int TransitLeadTime
        {
            get => _transitLeadTime;
            set => _transitLeadTime = value;
        }
        private DateTime _effectiveDate;
        [DataMember]
        public DateTime EffectiveDate
        {
            get => _effectiveDate;
            set => _effectiveDate = value;
        }
        private bool _matSuppMainSupplier = false;
        [DataMember]
        public bool MatSuppMainSupplier
        {
            get => _matSuppMainSupplier;
            set => _matSuppMainSupplier= value;
        }
        private bool _isFCExists = false;
        [DataMember]
        public bool IsFCExists
        {
            get => _isFCExists;
            set => _isFCExists = value;
        }
        private int _orderLeadTime;
        [DataMember]
        public int OrderLeadTime
        {
            get => _orderLeadTime;
            set => _orderLeadTime = value;
        }
            private Guid _id;
            [DataMember]
            public Guid Id
            {
            get => _id;
            set => _id = value;
            }
        private string _supplierCode = string.Empty;
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }

        private string _materialNumber = string.Empty;
        [DataMember]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }
        private string _businessUnitCode;
        [DataMember]

        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => _businessUnitCode = value;
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
        private Guid _createdBy;
        [DataMember]
        public Guid CreatedBy
        {
            get => _createdBy;
            set => _createdBy = value;
        }
        private DateTime _createdDate;
        [DataMember]
        public DateTime CreatedDate
        {
            get => _createdDate;
            set => _createdDate = value;
        }
        private Guid _modifiedBy;
        [DataMember]
        public Guid ModifiedBy
        {
            get => _modifiedBy;
            set => _modifiedBy = value;
        }
        private DateTime _modifiedDate;
        [DataMember]
        public DateTime ModifiedDate
        {
            get => _modifiedDate;
            set => _modifiedDate = value;
        }
        private bool _psmIsActive = true;
        [DataMember]
        public bool PSMIsActive
        {
            get => _psmIsActive;
            set => _psmIsActive = value;
        }
    }
}
