/**************************************************************************************************
 (C) 2018 SEWS-E Ltd., All rights reserved
 File Name          :   SupplierMaterialOriginExceptionModel.cs
 Function           :   Property for model
 Created By         :   Pawan
 Created on         :   10-Feb-2019
 Revision History   :  [05-May-2020] Dharmendra 
 *                  :  [] Modify  SupplierMaterialAssociationGuid to PurchasingSupplierMaterialHierarchyGuid
 *                  :   [31-May-2022] : Shivam Dhingra
*                   :   [] : Added model SupplierMaterialOriginExceptionComboModel
*                   :   [23-Aug-2023] : Dharmendra
*                   :   HD Call Number 00387437 : Migrate 5.2.4 Supplier Material Origin Exception from a stateful service to stateless
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class SupplierMaterialOriginExceptionModel : BaseModel<Guid>
    {
        //private Guid _supplierMaterialAssociationGuid;
        //[DataMember]
        //[Required]
        //public Guid SupplierMaterialAssociationGuid
        //{
        //    get => _supplierMaterialAssociationGuid;
        //    set => SetProperty(ref _supplierMaterialAssociationGuid, value);
        //}    


        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
        }

        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
        }

        private string _supplierCode;
        [DataMember]
        [StringLength(4)]
        public string SupplierCode
        {
            get => _supplierCode;
            set => SetProperty(ref _supplierCode, value);
        }

        private string _materialNumber;
        [DataMember]
        [StringLength(26)]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => SetProperty(ref _materialNumber, value);
        }

        private string euPreferentialOriginStatusCode;
        [DataMember]
        [Required]
        [StringLength(2)]
        public string EUPreferentialOriginStatusCode
        {
            get => euPreferentialOriginStatusCode;
            set => SetProperty(ref euPreferentialOriginStatusCode, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
        private Guid _purchasingSupplierMaterialHierarchyGuid;
        [DataMember]
        [Required]
        public Guid PurchasingSupplierMaterialHierarchyGuid
        {
            get => _purchasingSupplierMaterialHierarchyGuid;
            set => SetProperty(ref _purchasingSupplierMaterialHierarchyGuid, value);
        }
    }
    [DataContract, Serializable]
    public class SupplierMaterialOriginExceptionComboModel
    {
        private string _materialNumber;
        /// <summary>
        /// Get or Set for {MaterialNumber}.
        /// </summary>
        [DataMember]

        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }

        private string _materialName;
        /// <summary>
        /// Get or Set for {MaterialName}.
        /// </summary>
        [DataMember]

        public string MaterialName
        {
            get => _materialName;
            set => _materialName = value;
        }

        private Guid? _materialGuid;
        /// <summary>
        /// Get or Set for {MaterialGuid}.
        /// </summary>
        [DataMember]

        public Guid? MaterialGuid
        {
            get => _materialGuid;
            set => _materialGuid = value;
        }


        private bool _isActive;
        /// <summary>
        /// Get or Set for {IsActive}.
        /// </summary>
        [DataMember]

        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
    }
    [DataContract, Serializable]
    public class SupplierMaterialOriginExceptionFilterModel
    {
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => _supplierGuid = value;
        }
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => _materialGuid=value;
        }
    }
}
