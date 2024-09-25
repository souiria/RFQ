/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   POPriceTypeModel.cs
Function           :   
Created By         :  
Created on         :   
Revision History   :   [07-Jan-2021] : Shivam Dhingra
                   :   Added new column SupplierPortal
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public  class POPriceTypeModel: BaseModel<Guid>
    {
        private string _poPriceTypeCode;
        [DataMember]
        [Required]
        [StringLength(2)]
        public string POPriceTypeCode
        {
            get => _poPriceTypeCode;
            set => SetProperty(ref _poPriceTypeCode, value);
        }

        private string _poPriceTypeDescription;
        [DataMember]
        [StringLength(50)]
        public string POPriceTypeDescription
        {
            get => _poPriceTypeDescription;
            set => SetProperty(ref _poPriceTypeDescription, value);
        }

        private bool _isActive = true;
        [DataMember]
        public new bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        /// <summary>
        /// Local reference for SupplierPortal
        /// </summary>
        private bool _supplierPortal;
        /// <summary>
        /// get or set for SupplierPortal
        /// </summary>
        [DataMember]
        public bool SupplierPortal
        {
            get => _supplierPortal;
            set => SetProperty(ref _supplierPortal, value);
        }
    }
}
