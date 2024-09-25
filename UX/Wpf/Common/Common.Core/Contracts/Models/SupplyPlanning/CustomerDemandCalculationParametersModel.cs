/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerDemandCalculationParametersModel.cs
Function           :   CustomerDemandCalculationParameters
Created By         :   Shivam Dhingra
Created on         :   23-Sep-2020
Revision History   :   [01-Oct-2020] :  Shivam Dhingra
*                  :   Added property {DefaultParameterValue}
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for CustomerDemandCalculation
    /// </summary>
    [DataContract, Serializable]
    public class CustomerDemandCalculationParametersModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _customerDemandParameterName     
        /// </summary>
        private string _customerDemandParameterName;
        /// <summary>
        /// Get or Set for {CustomerDemandParameterName}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string CustomerDemandParameterName
        {
            get => _customerDemandParameterName;
            set => SetProperty(ref _customerDemandParameterName, value);
        }

        /// <summary>
        /// Local variable _customerDemandParameterCode  
        /// </summary>
        private string _customerDemandParameterCode;
        /// <summary>
        /// Get or Set for {CustomerDemandParameterCode}.
        /// Value will automatically generated through FunctionControlSequence
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(18)]
        public string CustomerDemandParameterCode
        {
            get => _customerDemandParameterCode;
            set => SetProperty(ref _customerDemandParameterCode, value);
        }

        /// <summary>
        /// Local variable _defaultParameterValue  
        /// </summary>
        private string _defaultParameterValue;
        /// <summary>
        /// Get or Set for {DefaultParameterValue}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DefaultParameterValue
        {
            get => _defaultParameterValue;
            set => SetProperty(ref _defaultParameterValue, value);
        }
    }
}
