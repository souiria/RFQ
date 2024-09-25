/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ETLSupplierSelectionHierarchyGridModel.cs
Function           :   For Supplier Selection Hierarchy Upload Functionality
Created By         :   Srashti Gupta
Created on         :   22-Nov-2019
Revision History   :   [] : 
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLSupplierSelectionHierarchyGridModel : BaseModel<Guid>
    {
        #region Properties
        private Guid _businessUnitGuid;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }
        private int _transitLeadTime;
        [DataMember]
        public int TransitLeadTime
        {
            get => _transitLeadTime;
            set => SetProperty(ref _transitLeadTime, value);
        }
        private DateTime _effectiveDate;
        [DataMember]
        public DateTime EffectiveDate
        {
            get => _effectiveDate;
            set => SetProperty(ref _effectiveDate, value);
        }

        private bool _isCPDSupplier = false;
        [DataMember]
        public bool IsCPDSupplier
        {
            get => _isCPDSupplier;
            set => SetProperty(ref _isCPDSupplier, value);
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private bool _isMatSupp = false;
        [DataMember]
        public bool IsMatSupp
        {
            get => _isMatSupp;
            set => SetProperty(ref _isMatSupp, value);
        }

        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get { return _supplierGuid; }
            set { _supplierGuid = value; }
        }

        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }

        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get { return _materialGuid; }
            set { _materialGuid = value; }
        }

        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get { return _materialNumber; }
            set { _materialNumber = value; }
        }

        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get { return _businessUnitCode; }
            set { _businessUnitCode = value; }
        }

        private int _orderLeadTime;
        [DataMember]
        public int OrderLeadTime
        {
            get { return _orderLeadTime; }
            set { _orderLeadTime = value; }
        }

        private bool _isForecastExist;
        [DataMember]
        public bool IsForecastExist
        {
            get { return _isForecastExist; }
            set { _isForecastExist = value; }
        }

        #endregion
    }
}
