/**************************************************************************************************
(C) 2020 SEWS-E Ltd., All rights reserved
File Name          :   DRPCalculationSettingsMatrixModel.cs
Function           :   DRPCalculationSettingsMatrix
Created By         :   Mrigesh Kumar
Created on         :   27-Oct-2020
Revision History   :   [23-Nov-2020] : Srashti Gupta
*                  :   Modified the model
*                  :   [15-Dec-2020] : Shivam Dhingra
*                  :   Added new field WarehouseGuid
*                  
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
    /// DataContract for DRPCalculationSettingsMatrix
    /// </summary>
    [DataContract, Serializable]
    public class DRPCalculationSettingsMatrixModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _customerBusinessHierarchyGuid     
        /// </summary>
        private Guid _customerBusinessHierarchyGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessHierarchyGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerBusinessHierarchyGuid
        {
            get => _customerBusinessHierarchyGuid;
            set => SetProperty(ref _customerBusinessHierarchyGuid, value);
        }

        /// <summary>
        /// Local variable _businessUnitGuid  
        /// </summary>
        private Guid _businessUnitGuid;
        /// <summary>
        /// Get or Set for {Manufacturing Site}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => _businessUnitGuid = value;
        }

        /// <summary>
        /// Local variable _customerHierarchyGuid  
        /// </summary>
        private Guid _customerHierarchyGuid;
        /// <summary>
        /// Get or Set for {CustomerHierarchyGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerHierarchyGuid
        {
            get => _customerHierarchyGuid;
            set => _customerHierarchyGuid = value;
        }

        /// <summary>
        /// Local variable _drpCalculationParametersList     
        /// </summary>
        private List<DRPCalculationParameterMappingModel> _drpCalculationParametersList;
        /// <summary>
        /// Get or Set for {DRPCalculationParametersList}.
        /// </summary>
        [DataMember]
        [Required]
        public List<DRPCalculationParameterMappingModel> DRPCalculationParametersList
        {
            get => _drpCalculationParametersList;
            set => SetProperty(ref _drpCalculationParametersList, value);
        }

        /// <summary>
        /// Local variable _warehouseGuid  
        /// </summary>
        private Guid _warehouseGuid;
        /// <summary>
        /// Get or Set for {WarehouseGuid}.
        /// </summary>
        [DataMember]
        public Guid WarehouseGuid
        {
            get => _warehouseGuid;
            set => _warehouseGuid = value;
        }


    }

    /// <summary>
    /// DataContract for DRPCalculationParameterMappingModel
    /// </summary>
    [DataContract, Serializable]
    public class DRPCalculationParameterMappingModel
    {
        /// <summary>
        /// Local variable _drpCalculationParameterGuid  
        /// </summary>
        private Guid _drpCalculationParameterGuid;
        /// <summary>
        /// Get or Set for {DRPCalculationParameterGuid}.
        /// </summary>
        [DataMember]
        public Guid DRPCalculationParameterGuid
        {
            get => _drpCalculationParameterGuid;
            set => _drpCalculationParameterGuid = value;
        }

        /// <summary>
        /// Local variable _drpParameterValue  
        /// </summary>
        private string _drpCalculationParameterValue;
        /// <summary>
        /// Get or Set for {DRPCalculationParameterValue}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DRPCalculationParameterValue
        {
            get => _drpCalculationParameterValue;
            set => _drpCalculationParameterValue = value;
        }
    }
}

