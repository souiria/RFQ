/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplyChainMappingModel.cs
Function           :   Supply Chain Mapping
Created By         :   Shivam Dhingra
Created on         :   17-Aug-2021
Revision History   :   [17-Aug-2021] : Shivam Dhingra
                   :   [] : Corrected field name
                   :   [19-Aug-2021] : Shivam Dhingra
                   :   [] : Set SupplyChainId Parameter as nullable
                   :   [02-Sep-2021] : Shivam Dhingra
                   :   [] : Set effectiveBy as nullable
                   :   [20-Jan-2022] : Shivam Dhingra
                   :   [] : Added new models for ExportMissingCustomerProductNumbers
                   :   [25-Jan-2022] : Shivam Dhingra
                   :   [] : Added new column BatchQuantity
                   :   [28-Jan-2022] : Shivam Dhingra
                   :   [] : Added new parameter in ExportMissingCustomerProductnumbres
                   :   [02-Feb-2022] : Shivam Dhingra
                   :   [] : Added new column PreProdOverwrite and RunOutOverwrite                  
                   :   [11-Feb-2022] : Ranjay
                   :   [] : Added new column PackFactor
                   :   [04-Aug-2022] : Sejal Srivastava
                   :   [] Added new model to get customer part number     
                   :   [12-Sept-2022] : Virendra
                   :   [] Added new SupplyChainId field in supplychainmapping model  
                   :   [13-Sept-2022] : Virendra
                   :   [] Removed SupplyChainId field in supplychainmapping model  
                   :   [01-Feb-2024] : Prakhar
                   :   [HD-00394058] Added Viewname property in supplychainmapping model  
                   :   [30-Apr-2024] : Piyush Anand
                   :   [HD-00405335] : Add a New Column Comments
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Class File for SupplyChainMapping
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainMappingModel : BaseModel<Guid>
    {

        private Guid _supplyChainGuid;
        /// <summary>
        /// SupplyChainGuid
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public Guid SupplyChainGuid
        {
            get => _supplyChainGuid;
            set => SetProperty(ref _supplyChainGuid, value);
        }
        private string _customerPartNumber;
        /// <summary>
        /// CustomerPartNumber
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(18)]
        public string CustomerPartNumber
        {
            get => _customerPartNumber;
            set => SetProperty(ref _customerPartNumber, value);
        }

        private int _supplyRatio = 0;
        /// <summary>
        /// _supplyRatio
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int SupplyRatio
        {
            get => _supplyRatio;
            set => SetProperty(ref _supplyRatio, value);
        }

        private string _supplyType;
        /// <summary>
        /// SupplyType
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(20)]
        public string SupplyType
        {
            get => _supplyType;
            set => SetProperty(ref _supplyType, value);
        }

        private DateTime _effectiveFrom;
        /// <summary>
        /// EffectiveFrom
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime EffectiveFrom
        {
            get => _effectiveFrom;
            set => SetProperty(ref _effectiveFrom, value);
        }

        private DateTime? _effectiveBy;
        /// <summary>
        /// EffectiveBy
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? EffectiveBy
        {
            get => _effectiveBy;
            set => SetProperty(ref _effectiveBy, value);
        }

        private int _batchQuantity = 1;
        /// <summary>
        /// _batchQuantity
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int BatchQuantity
        {
            get => _batchQuantity;
            set => SetProperty(ref _batchQuantity, value);
        }

        private DateTime? _preProdOverwrite;
        /// <summary>
        /// _preProdOverwrite
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? PreProdOverwrite
        {
            get => _preProdOverwrite;
            set => SetProperty(ref _preProdOverwrite, value);
        }

        private DateTime? _runOutOverwrite;
        /// <summary>
        /// _runOutOverwrite
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? RunOutOverwrite
        {
            get => _runOutOverwrite;
            set => SetProperty(ref _runOutOverwrite, value);
        }

        private int _packFactor = 1;
        /// <summary>
        /// _packFactor
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int PackFactor
        {
            get => _packFactor;
            set => SetProperty(ref _packFactor, value);
        }

        private string _viewName;
        [DataMember][NotMapped]
        public string ViewName
        {
            get { return _viewName; }
            set { SetProperty(ref _viewName, value); }
        }

        private string _comments;
        /// <summary>
        /// Comments
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(100)]
        public string Comments
        {
            get => _comments;
            set => SetProperty(ref _comments, value);
        }
    }

    /// <summary>
    /// DAta Contract for SupplyChainMappingProcedureParameters
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainMappingProcedureParametersModel
    {
        /// <summary>
        /// Local variable _supplyChainId
        /// </summary>
        private Guid? _supplyChainId;
        /// <summary>
        /// Get or Set for {SupplyChainId}.
        /// </summary>
        [DataMember]
        public Guid? SupplyChainId
        {
            get => _supplyChainId;
            set => _supplyChainId = value;
        }

        /// <summary>
        /// Local variable _customerPartNumber
        /// </summary>
        private string _customerPartNumber;
        /// <summary>
        /// Get or Set for {CustomerPartNumber}.
        /// </summary>
        [DataMember]
        public string CustomerPartNumber
        {
            get => _customerPartNumber;
            set => _customerPartNumber = value;
        }

    }

    /// <summary>
    /// Class file for SupplyChainMappingMissingCustomerProductNumbersModel
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainMappingMissingCustomerProductNumbersModel
    {
        
        /// <summary>
        /// Local variable _project
        /// </summary>
        private string _project;
        /// <summary>
        /// Get or Set for {Project}.
        /// </summary>
        [DataMember]
        public string Project
        {
            get => _project;
            set => _project = value;
        }

        /// <summary>
        /// Local variable Family
        /// </summary>
        private string _family;
        /// <summary>
        /// Get or Set for {Family}.
        /// </summary>
        [DataMember]
        public string Family
        {
            get => _family;
            set => _family = value;
        }

        /// <summary>
        /// Local variable _customerProductNumber
        /// </summary>
        private string _customerProductNumber;
        /// <summary>
        /// Get or Set for {CustomerProductNumber}.
        /// </summary>
        [DataMember]
        public string CustomerProductNumber
        {
            get => _customerProductNumber;
            set => _customerProductNumber = value;
        }

    }

    /// <summary>
    /// Class file for SupplyChainMappingMissingCustomerProductNumbersProcedureModel
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainMappingMissingCustomerProductNumbersProcedureModel

    {
        /// <summary>
        /// Local variable _UserId
        /// </summary>
        private Guid? _UserId;
        /// <summary>
        /// Get or Set for {UserId}.
        /// </summary>
        [DataMember]
        public Guid? UserId
        {
            get => _UserId;
            set => _UserId = value;
        }

        /// <summary>
        /// Local variable _supplyChainGuid
        /// </summary>
        private Guid? _supplyChainGuid;
        /// <summary>
        /// Get or Set for {SupplyChainGuid}.
        /// </summary>
        [DataMember]
        public Guid? SupplyChainGuid
        {
            get => _supplyChainGuid;
            set => _supplyChainGuid = value;
        }


    }

    /// <summary>
    /// Class file for SupplyChainMappingGetCustomerPartNumberParamterModel
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainMappingGetCustomerPartNumberParamterModel
    {
        /// <summary>
        /// Local variable _supplyChainGuid
        /// </summary>
        private Guid? _supplyChainGuid;
        /// <summary>
        /// Get or Set for {SupplyChainGuid}.
        /// </summary>
        [DataMember]
        public Guid? SupplyChainGuid
        {
            get => _supplyChainGuid;
            set => _supplyChainGuid = value;
        }
    }

    /// <summary>
    /// Class file for SupplyChainMappingGetCustomerPartNumberModel
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainMappingGetCustomerPartNumberModel
    {

        /// <summary>
        /// Local variable _customerPartNumber
        /// </summary>
        private string _customerPartNumber;
        /// <summary>
        /// Get or Set for {CustomerProductNumber}.
        /// </summary>
        [DataMember]
        public string CustomerPartNumber
        {
            get => _customerPartNumber;
            set => _customerPartNumber = value;
        }
    }

}
