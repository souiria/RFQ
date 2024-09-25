/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerDemandParameterSettingsModel.cs
Function           :   Data Contract for CustomerDemandParameterSettings
Created By         :   Ranjay
Created on         :   08-Dec-2022
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
    /// Data contract for CustomerDemandParameterSettings
    /// </summary>
    [DataContract, Serializable]
    public class CustomerDemandParameterSettingsModel : BaseModel<Guid>
    {
        private Guid _customernameguid;
        /// <summary>
        /// Get or Set for {StepNumber}.
        /// </summary>
        [DataMember]
        public Guid CustomerNameGuid
        {
            get => _customernameguid;
            set => SetProperty(ref _customernameguid, value);
        }

        private Guid _customerdeliverypointguid;
        /// <summary>
        /// Get or Set for {StepNumber}.
        /// </summary>
        [DataMember]
        public Guid CustomerDeliveryPointGuid
        {
            get => _customerdeliverypointguid;
            set => SetProperty(ref _customerdeliverypointguid, value);
        }

        private Guid _unloadingpointguid;
        /// <summary>
        /// Get or Set for {StepNumber}.
        /// </summary>
        [DataMember]
        public Guid UnloadingPointGuid
        {
            get => _unloadingpointguid;
            set => SetProperty(ref _unloadingpointguid, value);
        }

        private int _stepNumber;
        /// <summary>
        /// Get or Set for {StepNumber}.
        /// </summary>
        [DataMember]
        public int StepNumber
        {
            get => _stepNumber;
            set => SetProperty(ref _stepNumber, value);
        }

        private string _functionName;
        /// <summary>
        /// Get or Set for {FunctionName}.
        /// </summary>
        [DataMember]
        public string FunctionName
        {
            get => _functionName;
            set => SetProperty(ref _functionName, value);
        }

        private string _parametersValue;
        /// <summary>
        /// Get or Set for {ParameterValue}.
        /// </summary>
        [DataMember]
        public string ParameterValue
        {
            get => _parametersValue;
            set => SetProperty(ref _parametersValue, value);
        }

        private string _remarks;
        /// <summary>
        /// Get or Set for {Remarks}.
        /// </summary>
        [DataMember]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }        
    }

    /// <summary>
    /// Data contract for CustomerDemandParameterSettingsFilterModel
    /// </summary>
    [DataContract, Serializable]
    public class CustomerDemandParameterSettingsFilterModel
    {
        private Guid _customernameguid;
        /// <summary>
        /// Get or Set for {StepNumber}.
        /// </summary>
        [DataMember]
        public Guid CustomerNameGuid
        {
            get => _customernameguid;
            set => _customernameguid = value;
        }

        private Guid _customerdeliverypointguid;
        /// <summary>
        /// Get or Set for {StepNumber}.
        /// </summary>
        [DataMember]
        public Guid CustomerDeliveryPointGuid
        {
            get => _customerdeliverypointguid;
            set => _customerdeliverypointguid = value;
        }

        private Guid _unloadingpointguid;
        /// <summary>
        /// Get or Set for {StepNumber}.
        /// </summary>
        [DataMember]
        public Guid UnloadingPointGuid
        {
            get => _unloadingpointguid;
            set => _unloadingpointguid = value;
        }
    }

}
