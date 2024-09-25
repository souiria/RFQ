/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplyChainSettingsPartWiseModel.cs
Function           :   Data Contract for SupplyChainSettingsPartWise
Created By         :   Shivam Dhingra
Created on         :   27-May-2020
Revision History   :   [03-May-2020] : Amit Agarwal
                   :   [] : New Hierarchy classes added for SupplyChainSettingsPartWise
                   :   [30-June-2020] : Srashti Gupta
                   :   [] : New Hierarchy classes added for SupplyChainSettingsPartWise

                   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract for SupplyChainSettingsPartWiseModel
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainSettingsPartWiseModel : BaseModel<Guid>
    {
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }
        private List<Guid> _supplyMappingGuid;
        /// <summary>
        /// Get or Set for {SupplyMapping}.
        /// </summary>
        [DataMember]
        public List<Guid> SupplyMappingGuid
        {
            get => _supplyMappingGuid;
            set => SetProperty(ref _supplyMappingGuid, value);
        }


        private bool _supplyChainFlag;
        /// <summary>
        /// Get or Set for {SupplyChainFlag}.
        /// </summary>
        [DataMember]
        public bool SupplyChainFlag
        {
            get => _supplyChainFlag;
            set => SetProperty(ref _supplyChainFlag, value);
        }
    }
    /// <summary>
    /// Data Contract for SupplyChainSettingsPartWiseHierarchyModel
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainSettingsPartWiseHierarchyModel : BaseModel<Guid>
    {
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }
        private bool _supplyChainFlag;
        /// <summary>
        /// Get or Set for {SupplyChainFlag}.
        /// </summary>
        [DataMember]
        public bool SupplyChainFlag
        {
            get => _supplyChainFlag;
            set => SetProperty(ref _supplyChainFlag, value);
        }
        private List<SupplySectionHierarchyDetailModel> _supplySectionHierarchyDetail;
        /// <summary>
        /// Get or Set for {SupplyMappingHierarchy}.
        /// </summary>
        [DataMember]
        public List<SupplySectionHierarchyDetailModel> SupplySectionHierarchyDetail
        {
            get => _supplySectionHierarchyDetail;
            set => SetProperty(ref _supplySectionHierarchyDetail, value);
        }
    }
    /// <summary>
    /// Data Contract for SupplySectionHierarchyModel
    /// </summary>
    [DataContract, Serializable]
    public class SupplySectionHierarchyModel : BaseModel<Guid>
    {
        private string _supplySectionName;
        /// <summary>
        /// Get or Set for {_supplySectionName}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string SupplySectionName
        {
            get => _supplySectionName;
            set => SetProperty(ref _supplySectionName, value);
        }
        private List<SupplyChainFieldSettingsModel> _supplyChainFieldSettingsHierachy;
        /// <summary>
        /// Get or Set for {SupplyChainFieldSettingsHierachy}.
        /// </summary>
        [DataMember]
        public List<SupplyChainFieldSettingsModel> SupplyChainFieldSettingsHierachy
        {
            get => _supplyChainFieldSettingsHierachy;
            set => SetProperty(ref _supplyChainFieldSettingsHierachy, value);
        }
    }



    [DataContract, Serializable]
    public class SupplySectionHierarchyDetailModel : BaseModel<Guid>
    {

        private List<SupplySectionHierarchyModel> _supplyMappingHierarchy;
        /// <summary>
        /// Get or Set for {SupplyMappingHierarchy}.
        /// </summary>
        [DataMember]
        public List<SupplySectionHierarchyModel> SupplyMappingHierarchy
        {
            get => _supplyMappingHierarchy;
            set => SetProperty(ref _supplyMappingHierarchy, value);
        }
    }
}
