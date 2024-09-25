/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplyChainMappingUploadModel.cs
Function           :   Supply Chain Mapping Upload
Created By         :   Virendra Pal
Created on         :   13-sept-2022
Revision History   :   [01-Feb-2024] : Prakhar
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
    public class SupplyChainMappingUploadModel : BaseModel<Guid>
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
        private string _supplyChainId;
        /// <summary>
        /// SupplyChainId
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(35)]
        public string SupplyChainId
        {
            get => _supplyChainId;
            set => SetProperty(ref _supplyChainId, value);
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
        [DataMember]
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
}
