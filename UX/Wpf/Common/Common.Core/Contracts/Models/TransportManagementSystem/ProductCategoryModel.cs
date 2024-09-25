/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  ProductCategoryModel.cs
Function           :   
Created By         :  Nishu
Created on         :  06-Mar-2024
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.TransportManagementSystem
{
    /// <summary>
    ///  Model for ProductCategory Screen
    /// </summary>
    [DataContract, Serializable]
    public class ProductCategoryModel : BaseModel<Guid>
    {
        private string _productCategoryCode;
        /// <summary>
        /// Get or Set for {ProductCategoryCode}.
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string ProductCategoryCode
        {
            get => _productCategoryCode;
            set => SetProperty(ref _productCategoryCode, value);
        }
        private string _productCategoryDescription;
        /// <summary>
        /// Get or Set for {ProductCategoryDescription}.
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string ProductCategoryDescription
        {
            get => _productCategoryDescription;
            set => SetProperty(ref _productCategoryDescription, value);
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
