/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerDemandFunctionAndParametersModel.cs
Function           :   Customer Demand Function And Parameters Model
Created By         :   Ranjay
Created on         :   21-Mar-2023
Revision History   :   [03-May-2023] : Prakhar 
                   :   Added new method ParameterValues.
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
    /// Data Contract use for Customer Calendar
    /// </summary>
    [DataContract, Serializable]
    public class CustomerDemandFunctionAndParametersModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _demandFunctionName     
        /// </summary>
        private string _demandFunctionName;
        /// <summary>
        /// Get or Set for {DemandFunctionName}.
        /// </summary>
        [DataMember]
        public string DemandFunctionName
        {
            get => _demandFunctionName;
            set => _demandFunctionName = value;
        }
        /// <summary>
        /// Local variable _parameterName     
        /// </summary>
        private string _parameterName;
        /// <summary>
        /// Get or Set for {ParameterName}.
        /// </summary>
        [DataMember]
        public string ParameterName
        {
            get => _parameterName;
            set => _parameterName = value;
        }
        /// <summary>
        /// Local variable _demandFunctionName     
        /// </summary>
        private string _parameterType;
        /// <summary>
        /// Get or Set for {ParameterType}.
        /// </summary>
        [DataMember]
        public string ParameterType
        {
            get => _parameterType;
            set => _parameterType = value;
        }

        /// <summary>
        /// Local variable _compatibilityFlag     
        /// </summary>
        private bool _compatibilityFlag;
        /// <summary>
        /// Get or Set for {CompatibilityFlag}.
        /// </summary>
        [DataMember]
        public bool CompatibilityFlag
        {
            get => _compatibilityFlag;
            set => _compatibilityFlag = value;
        }

        private string _parameterValues;
        /// <summary>
        /// Get or Set for {ParameterValues}.
        /// </summary>
        [DataMember]
        public string ParameterValues
        {
            get => _parameterValues;
            set => _parameterValues = value;
        }

    }
}
