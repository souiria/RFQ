/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerDemandCalculationProgramMaintenanceModel.cs
Function           :   CustomerDemandCalculationProgramMaintenance
Created By         :   Virendra
Created on         :   23-March-2023
Revision History   :  [19-April-2023]: Virendra
                   :  Added Step filed in the class  DemandFunctionNameParameterList  
                   :  [04-May-2023]: Virendra
                   :  Added ParameterValues field in the class  DemandFunctionNameParameterList
                   :  [02-Feb-2024]: Prakhar
                   :  [HD-00394058] : Added new property ViewName in CustomerDemandCalculationProgramMaintenanceSaveModel and CustomerDemandCalculationProgramMaintenanceModel 

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
{ /// <summary>
  /// DataContract for CustomerDemandCalculationProgramMaintenance
  /// </summary>
    [DataContract, Serializable]
    public class CustomerDemandCalculationProgramMaintenanceModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _customerBusinessGroupGuid     
        /// </summary>
        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => SetProperty(ref _customerBusinessGroupGuid, value);
        }

        /// <summary>
        /// Local variable _customerGuid     
        /// </summary>
        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }


        /// <summary>
        /// Local variable _customerDeliveryPointGuid     
        /// </summary>
        private Guid _customerDeliveryPointGuid;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPointGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerDeliveryPointGuid
        {
            get => _customerDeliveryPointGuid;
            set => SetProperty(ref _customerDeliveryPointGuid, value);
        }


        /// <summary>
        /// Local variable _unloadingPointGuid     
        /// </summary>
        private Guid _unloadingPointGuid;
        /// <summary>
        /// Get or Set for {UnloadingPointGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid UnloadingPointGuid
        {
            get => _unloadingPointGuid;
            set => SetProperty(ref _unloadingPointGuid, value);
        }


        /// <summary>
        /// Local variable _steps     
        /// </summary>
        private int _steps;
        /// <summary>
        /// Get or Set for {Steps}.
        /// </summary>
        [DataMember]
        [Required]
        public int Step
        {
            get => _steps;
            set => SetProperty(ref _steps, value);
        }
        private int _originalStep;
        /// <summary>
        /// Get or Set for {OriginalStep}.
        /// </summary>
        [DataMember]
        public int OriginalStep
        {
            get => _originalStep;
            set => SetProperty(ref _originalStep, value);
        }
        /// <summary>
        /// Local variable _customerDemandFunctionGuid     
        /// </summary>
        private Guid _customerDemandFunctionGuid;
        /// <summary>
        /// Get or Set for {CustomerDemandFunctionGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerDemandFunctionGuid
        {
            get => _customerDemandFunctionGuid;
            set => SetProperty(ref _customerDemandFunctionGuid, value);
        }

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
            set => SetProperty(ref _demandFunctionName, value);
        }
        /// <summary>
        /// Local variable _customerDemandCalculationFunctionParameterList     
        /// </summary>
        private List<DemandFunctionNameParameterList> _demandFunctionNameParameterList;
        /// <summary>
        /// Get or Set for {CustomerDemandCalculationParametersList}.
        /// </summary>
        [DataMember]
        public List<DemandFunctionNameParameterList> DemandFunctionNameParameterList
        {
            get => _demandFunctionNameParameterList;
            set => SetProperty(ref _demandFunctionNameParameterList, value);
        }

        private string _viewName;
        [DataMember][NotMapped]
        public string ViewName
        {
            get { return _viewName; }
            set { SetProperty(ref _viewName, value); }
        }


    }
    [DataContract, Serializable]
    public class CustomerDemandCalculationProgramMaintenanceSaveModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _customerBusinessGroupGuid     
        /// </summary>
        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => SetProperty(ref _customerBusinessGroupGuid, value);
        }

        /// <summary>
        /// Local variable _customerGuid     
        /// </summary>
        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }


        /// <summary>
        /// Local variable _customerDeliveryPointGuid     
        /// </summary>
        private Guid _customerDeliveryPointGuid;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPointGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerDeliveryPointGuid
        {
            get => _customerDeliveryPointGuid;
            set => SetProperty(ref _customerDeliveryPointGuid, value);
        }


        /// <summary>
        /// Local variable _unloadingPointGuid     
        /// </summary>
        private Guid _unloadingPointGuid;
        /// <summary>
        /// Get or Set for {UnloadingPointGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid UnloadingPointGuid
        {
            get => _unloadingPointGuid;
            set => SetProperty(ref _unloadingPointGuid, value);
        }


        /// <summary>
        /// Local variable _steps     
        /// </summary>
        private int _steps;
        /// <summary>
        /// Get or Set for {Steps}.
        /// </summary>
        [DataMember]
        [Required]
        public int Step
        {
            get => _steps;
            set => SetProperty(ref _steps, value);
        }
        /// <summary>
        /// Local variable _customerDemandFunctionGuid     
        /// </summary>
        private Guid _customerDemandFunctionGuid;
        /// <summary>
        /// Get or Set for {CustomerDemandFunctionGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerDemandFunctionGuid
        {
            get => _customerDemandFunctionGuid;
            set => SetProperty(ref _customerDemandFunctionGuid, value);
        }

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
            set => SetProperty(ref _demandFunctionName, value);
        }
        /// <summary>
        /// Local variable _parameterValue  
        /// </summary>
        private string _parameterValue;
        /// <summary>
        /// Get or Set for {ParameterValue}.
        /// </summary>
        [DataMember]
        public string ParameterValue
        {
            get => _parameterValue;
            set => _parameterValue = value;
        }
        /// <summary>
        /// Local variable _customerDemandFunctionParameterGuid     
        /// </summary>
        private Guid _customerDemandFunctionParameterGuid;
        /// <summary>
        /// Get or Set for {CustomerDemandFunctionParameterGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerDemandFunctionParameterGuid
        {
            get => _customerDemandFunctionParameterGuid;
            set => SetProperty(ref _customerDemandFunctionParameterGuid, value);
        }
        /// <summary>
        /// Local variable _flagForUPDown     
        /// </summary>
        private string _flagForUPDown;
        /// <summary>
        /// Get or Set for {FlagForUPDown}.
        /// </summary>
        [DataMember]
        public string FlagForUPDown
        {
            get => _flagForUPDown;
            set => SetProperty(ref _flagForUPDown, value);
        }
        private int _originalStep;
        /// <summary>
        /// Get or Set for {OriginalStep}.
        /// </summary>
        [DataMember]
        public int OriginalStep
        {
            get => _originalStep;
            set => SetProperty(ref _originalStep, value);
        }

        private string _viewName;
        [DataMember]
        public string ViewName
        {
            get { return _viewName; }
            set { SetProperty(ref _viewName, value); }
        }
    }
    /// <summary>
    /// DataContract for CustomerDemandParameterMappingModel
    /// </summary>
    [DataContract, Serializable]
    public class DemandFunctionNameParameterList:BaseModel<Guid> 
    {
        /// <summary>
        /// Local variable DemandFunctionName  
        /// </summary>
        private string _demandFunctionName;
        /// <summary>
        /// Get or Set for {DemandFunctionName}.
        /// </summary>
        [DataMember]
        public string  DemandFunctionName
        {
            get => _demandFunctionName;
            //set => _demandFunctionName = value;
            set => SetProperty(ref _demandFunctionName, value);
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
        /// Local variable _parameterType  
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
        /// Local variable _parameterValue  
        /// </summary>
        private string _parameterValue;
        /// <summary>
        /// Get or Set for {ParameterValue}.
        /// </summary>
        [DataMember]
        public string ParameterValue
        {
            get => _parameterValue;
            set => _parameterValue = value;
        }
        /// <summary>
        /// Local variable _customerDemandFunctionGuid     
        /// </summary>
        private Guid _customerDemandFunctionGuid;
        /// <summary>
        /// Get or Set for {CustomerDemandFunctionGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerDemandFunctionGuid
        {
            get => _customerDemandFunctionGuid;
            set => SetProperty(ref _customerDemandFunctionGuid, value);
        }
        /// <summary>
        /// Local variable _customerDemandFunctionParameterGuid     
        /// </summary>
        private Guid _customerDemandFunctionParameterGuid;
        /// <summary>
        /// Get or Set for {CustomerDemandFunctionParameterGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerDemandFunctionParameterGuid
        {
            get => _customerDemandFunctionParameterGuid;
            set => SetProperty(ref _customerDemandFunctionParameterGuid, value);
        }
        private int _step;
        [DataMember]
        public int Step
        {
            get => _step;
            set => SetProperty(ref _step, value);
        }
        /// <summary>
        /// Local variable _ParameterValues     
        /// </summary>
        private string _ParameterValues;
        /// <summary>
        /// Get or Set for {ParameterValues}
        /// </summary>
        [DataMember]
        public string ParameterValues
        {
            get => _ParameterValues;
            set => SetProperty(ref _ParameterValues, value);
        }
    }
    public class GetUnloadingpointByCustomerGuidAndCustomerDeliveryPoint
    {


        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }

        private Guid _customerDeliveryPointGuid;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPointGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerDeliveryPointGuid
        {
            get => _customerDeliveryPointGuid;
            set => _customerDeliveryPointGuid = value;
        }
        private Guid _Id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _Id;
            set => _Id = value;
        }

        private string _unloadingPointCode;
        /// <summary>
        /// Get or Set for {UnloadingPointCode}.
        /// </summary>
        [DataMember]
        public string UnloadingPointCode
        {
            get => _unloadingPointCode;
            set => _unloadingPointCode = value;
        }
    }
}
