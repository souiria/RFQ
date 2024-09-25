/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   MaterialModel.cs
Function           :   Material Model
Created By         :   Pawan
Created on         :   04-Jul-2018
Revision History   :   [11-Sep-2019] : Pawan
                   :   [] : Added new field for Material nominated
                   :   [06-Apr-2022] : Shivam Dhingra
                   :   [] : Added Override IsActive
                   :   [12-Apr-2022] : Shivam Dhingra
                   :   [] : Added new model MaterialComboModel
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class MaterialModel : BaseModel<Guid>
    {
        private string _materialNumber;
        [DataMember]
        [StringLength(26)]
        [Required]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => SetProperty(ref _materialNumber, value);
        }
        
        private string _materialName;
        [DataMember]
        [StringLength(50)]
        public string MaterialName
        {
            get => _materialName;
            set => SetProperty(ref _materialName, value);
        }

        private Guid _sourceApplicationGuid = Guid.Empty;
        [DataMember]
        //Navigation Property
        public Guid SourceApplicationGuid
        {
            get => _sourceApplicationGuid;
            set => SetProperty(ref _sourceApplicationGuid, value);
        }

        private Guid _unitOfMeasureGuid;
        [DataMember]
        [Required]
        //Navigation Property
        public Guid UnitOfMeasureGuid      
        {
            get => _unitOfMeasureGuid;
            set => SetProperty(ref _unitOfMeasureGuid, value);
        }

        private string _preProductionNumber;
        [DataMember]
        [StringLength(26)]
        public string PreProductionNumber
        {
            get => _preProductionNumber;
            set => SetProperty(ref _preProductionNumber, value);
        }

        private decimal _unitWeight;
        [DataMember]
        [DecimalPrecision(10, 2)]
        public decimal UnitWeight
        {
            get => _unitWeight;
            set => SetProperty(ref _unitWeight, value);
        }

        /// <summary>
        ///  /// Gets or sets a Guid value for the MaterialTypeGuid column.
        /// </summary>
        private Guid _materialTypeGuid;
        [DataMember]
        [Required]
        public Guid MaterialTypeGuid
        {
            get => _materialTypeGuid;
            set => SetProperty(ref _materialTypeGuid, value);
        }
        /// <summary>
        /// Gets or sets a Guid value for the CommodityGuid column.
        /// </summary>
        private Guid _commodityGuid;
        [DataMember]
        [Required]
        public Guid CommodityGuid
        {
            get => _commodityGuid;
            set => SetProperty(ref _commodityGuid, value);
        }
        /// <summary>
        ///  Gets or sets a Guid value for the CutLength column.
        /// </summary>
        private decimal _cutLength;
        [DataMember]
        [DecimalPrecision(8, 3)]
        public decimal CutLength
        {
            get => _cutLength;
            set => SetProperty(ref _cutLength, value);
        }

        /// <summary>
        /// Local Reference of IsCustomerNominatedMaterial
        /// </summary>
        private bool _isCustomerNominatedMaterial;
        /// <summary>
        /// Is Customer Nominated Material
        /// </summary>
        [DataMember]
        public bool IsCustomerNominatedMaterial
        {
            get => _isCustomerNominatedMaterial;
            set => SetProperty(ref _isCustomerNominatedMaterial, value);
        }

        /// <summary>
        /// Local Reference of _isActive
        /// </summary>
        private  bool _isActive;
        /// <summary>
        /// _isActive
        /// </summary>
        [DataMember]
        public new bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }

    [DataContract,Serializable]
    public class MaterialComboModel 
    {
        private string _materialNumber;
        [DataMember]
        [StringLength(26)]
        [Required]
        public string MaterialNumber
        {
            get => _materialNumber;
            set => _materialNumber = value;
        }

        private string _materialName;
        [DataMember]
        [StringLength(50)]
        public string MaterialName
        {
            get => _materialName;
            set => _materialName = value;
        }
        /// <summary>
        /// Local Reference of _isActive
        /// </summary>
        private bool _isActive;
        /// <summary>
        /// _isActive
        /// </summary>
        [DataMember]
        public new bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
        /// <summary>
        /// Local Reference of Id
        /// </summary>
        private Guid _id;
        /// <summary>
        /// _isActive
        /// </summary>
        [DataMember]
        public  Guid Id
        {
            get => _id;
            set => _id = value;
        }

    }
}
