/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   DRPCalculationParametersModel.cs
Function           :   DRPCalculationParameters
Created By         :   Shivam Dhingra
Created on         :   20-Oct-2020
Revision History   :   
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
    /// Data Contract use for DRPCalculationParameters
    /// </summary>
    [DataContract, Serializable]
    public class DRPCalculationParametersModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _drpParameterCode  
        /// </summary>
        private string _drpParameterCode;
        /// <summary>
        /// Get or Set for {DRPParameterCode}.
        /// Value will automatically generated through FunctionControlSequence
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(18)]
        public string DRPParameterCode
        {
            get => _drpParameterCode;
            set => SetProperty(ref _drpParameterCode, value);
        }

        /// <summary>
        /// Local variable _drpParameterName     
        /// </summary>
        private string _drpParameterName;
        /// <summary>
        /// Get or Set for {DRPParameterName}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string DRPParameterName
        {
            get => _drpParameterName;
            set => SetProperty(ref _drpParameterName, value);
        }

        /// <summary>
        /// Local variable _drpParameterDefaultValue  
        /// </summary>
        private string _drpParameterDefaultValue;
        /// <summary>
        /// Get or Set for {DRPParameterDefaultValue}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DRPParameterDefaultValue
        {
            get => _drpParameterDefaultValue;
            set => SetProperty(ref _drpParameterDefaultValue, value);
        }
    }
}
