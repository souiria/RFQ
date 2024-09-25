/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierSelectionHierarchyStatelessModel.cs
Function           :  
Created By         :   Shivam Kalia
Created on         :   29-Mar-2022
Revision History   :   [01-Apr-2022] : Shivam Kalia
                   :   [] : Added new MaterialForSupplierSelectionModel
                   :   [12-May-2022] : Shivam Kalia
                   :   [] : Added SupplierGuid Field
****************************************************************************************************/
using Common.Core.Contracts.Interfaces.Purchasing;
using Common.Core.Contracts.Models.Base;
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
    public class SupplierSelectionHierarchyStatelessModel : BaseModel<Guid>
    {
        private Guid _purchasingSupplierMaterialHierarchyGuid;
        [DataMember]
        [Required]
        public Guid PurchasingSupplierMaterialHierarchyGuid
        {
            get => _purchasingSupplierMaterialHierarchyGuid;
            set => SetProperty(ref _purchasingSupplierMaterialHierarchyGuid, value);
        }

        private Guid _businessUnitGuid;
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }
        private int _transitLeadTime;
        [DataMember]
        [Required]
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

    }

    [DataContract, Serializable]
    public class MaterialForSupplierSelectionModel
    {
        #region Properties

        private string _supplierCode;
        [DataMember]
        public string SupplierCode 
        {
            get => _supplierCode;
            set => _supplierCode = value;
        }

        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => _supplierGuid = value;
        }

        [DataMember]
        private Guid _materialGuid;
        public Guid MaterialGuid 
        {
            get => _materialGuid;
            set => _materialGuid = value;
        }

        private string _materialNumber;
        [DataMember]
        public string MaterialNumber 
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }

        private string _materialName;
        [DataMember]
        public string MaterialName 
        {
            get => _materialName;
            set => _materialName = value;
        }

        private bool _matSuppMainSupplier;
        [DataMember]
        public bool MatSuppMainSupplier 
        {
            get => _matSuppMainSupplier;
            set => _matSuppMainSupplier = value;
        }

        private bool _isPOPricingApproved;
        [DataMember]
        public bool IsPOPricingApproved 
        {
            get => _isPOPricingApproved;
            set => _isPOPricingApproved = value;
        }

        private bool _isActive;
        [DataMember]
        public bool IsActive 
        {
            get => _isActive;
            set => _isActive = value;
        }
        #endregion
    }
}
