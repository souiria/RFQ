/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  PackageMasterModel.cs
Function           :  Package Master Model
Created By         :  Nishu
Created on         :  15-Mar-2024
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.TransportManagementSystem
{
    /// <summary>
    ///  Model for PackageMaster Screen
    /// </summary>
    [DataContract, Serializable]
    public class PackageMasterModel : BaseModel<Guid>
    {
        private string _packageType;
        /// <summary>
        /// Property for Package Type
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string PackageType
        {
            get => _packageType;
            set => SetProperty(ref _packageType, value);
        }
        private string _description;
        /// <summary>
        /// Property for Package Description
        /// </summary>
        [DataMember]
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        private string _packageCode;
        /// <summary>
        /// Property for Package Code
        /// </summary>
        [DataMember]
        public string PackageCode
        {
            get => _packageCode;
            set => SetProperty(ref _packageCode, value);
        }
        private decimal _weight;
        /// <summary>
        /// Property for Weight
        /// </summary>
        [DecimalPrecision(10, 3)]
        [DataMember]
        public decimal Weight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }
        private string _unitOfMeasure;
        /// <summary>
        /// Property for Unit Of Measure
        /// </summary>
        [DataMember]
        public string UnitofMeasure
        {
            get => _unitOfMeasure;
            set => SetProperty(ref _unitOfMeasure, value);
        }
        private string _weightUnit;
        /// <summary>
        /// Property for Weight Unit
        /// </summary>
        [DataMember]
        public string WeightUnit
        {
            get => _weightUnit;
            set => SetProperty(ref _weightUnit, value);
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
