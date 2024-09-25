/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerDemandCalculationSettingsMatrixModel.cs
Function           :   CustomerDemandCalculationSettingsMatrix
Created By         :   Shivam Dhingra
Created on         :   24-Sep-2020
Revision History   :   [01-Oct-2020] :  Shivam Dhingra
*                  :   Added property {CustomerDemandParameterValue}
*                  :   [01-Oct-2020] :  Shivam Dhingra
*                  :   Modified model to change CustomerDemandCalculationParametersGuid to CustomerDemandCalculationParametersList
*                  :   [13-Oct-2021] :  Shivam Dhingra
*                  :   Added new Column CustomerDeliveryPointAssociationGuid
*                  :   [04-May-2022] : Sejal Srivastava
*                  :   [] : Added new column UnLoadingPoint
*                  :   [24-Jan-2023] : Prakhar
*                  :   [] : Added new Class CustomerDemandCalculationSettingMatrixStatelessModel and CustomerDemandCalculationSettingMatrixParamStatelessModel
*                  :   [24-March-2023] : Virendra
*                  :   [] : Added new property UnloadingPointGuid in the class ClassCustomerDemandCalculationSettingMatrixParamStatelessModel                
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
    /// DataContract for CustomerDemandCalculationSettingsMatrix
    /// </summary>
    [DataContract, Serializable]
    public class CustomerDemandCalculationSettingsMatrixModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _customerNameGuid     
        /// </summary>
        private Guid _customerNameGuid;
        /// <summary>
        /// Get or Set for {CustomerNameGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerNameGuid
        {
            get => _customerNameGuid;
            set => SetProperty(ref _customerNameGuid, value);
        }

        /// <summary>
        /// Local variable _customerDemandCalculationParametersList     
        /// </summary>
        private List<CustomerDemandParameterMappingModel> _customerDemandCalculationParametersList;
        /// <summary>
        /// Get or Set for {CustomerDemandCalculationParametersList}.
        /// </summary>
        [DataMember]
        [Required]
        public List<CustomerDemandParameterMappingModel> CustomerDemandCalculationParametersList
        {
            get => _customerDemandCalculationParametersList;
            set => SetProperty(ref _customerDemandCalculationParametersList, value);
        }

        private Guid _customerDeliveryPointAssociationGuid;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPointAssociationGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerDeliveryPointAssociationGuid
        {
            get => _customerDeliveryPointAssociationGuid;
            set => SetProperty(ref _customerDeliveryPointAssociationGuid, value);
        }
        private string _unloadingPoint;
        /// <summary>
        /// Get or Set for {UnloadingPoint}.
        /// </summary>
        [DataMember]
        public string UnloadingPoint
        {
            get => _unloadingPoint;
            set => SetProperty(ref _unloadingPoint, value);
        }

    }

    /// <summary>
    /// DataContract for CustomerDemandParameterMappingModel
    /// </summary>
    [DataContract, Serializable]
    public class CustomerDemandParameterMappingModel
    {
        /// <summary>
        /// Local variable _customerDemandParameterValue  
        /// </summary>
        private string _customerDemandParameterValue;
        /// <summary>
        /// Get or Set for {CustomerDemandParameterValue}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string CustomerDemandParameterValue
        {
            get => _customerDemandParameterValue;
            set => _customerDemandParameterValue = value;
        }

        /// <summary>
        /// Local variable _customerDemandCalculationParameterGuid  
        /// </summary>
        private Guid _customerDemandCalculationParameterGuid;
        /// <summary>
        /// Get or Set for {CustomerDemandCalculationParameterGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerDemandCalculationParameterGuid
        {
            get => _customerDemandCalculationParameterGuid;
            set => _customerDemandCalculationParameterGuid = value;
        }

    }

    [DataContract, Serializable]
    public class CustomerDemandCalculationSettingMatrixStatelessModel 
    {
        private string _unloadingPoint;
        /// <summary>
        /// Get or Set for {UnloadingPoint}.
        /// </summary>
        [DataMember]
        public string UnloadingPoint
        {
            get => _unloadingPoint;
            set =>  _unloadingPoint = value;
        }

        private Guid _customerNameGuid;
        /// <summary>
        /// Get or Set for {CustomerNameGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerNameGuid
        {
            get => _customerNameGuid;
            set =>  _customerNameGuid = value;
        }

        private String _customerDemandParameterCode;
        /// <summary>
        /// Get or Set for {CustomerDemandParameterCode}.
        /// </summary>
        [DataMember]
        public String CustomerDemandParameterCode
        {
            get => _customerDemandParameterCode;
            set =>  _customerDemandParameterCode = value;
        }

        private String _customerDemandParameterName;
        /// <summary>
        /// Get or Set for {CustomerDemandParameterName}.
        /// </summary>
        [DataMember]
        public String CustomerDemandParameterName
        {
            get => _customerDemandParameterName;
            set =>  _customerDemandParameterName = value;
        }

        private String _customerDemandParameterValue;
        /// <summary>
        /// Get or Set for {CustomerDemandParameterValue}.
        /// </summary>
        [DataMember]
        public String CustomerDemandParameterValue
        {
            get => _customerDemandParameterValue;
            set =>  _customerDemandParameterValue = value;
        }

        private bool _isActive = true;
        [ DataMember]
        public virtual bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
    }

    [DataContract, Serializable]
    public class CustomerDemandCalculationSettingMatrixParamStatelessModel
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
        private Guid _unloadingPointGuid;
        /// <summary>
        /// Get or Set for {UnloadingPointGuid}.
        /// </summary>
        [DataMember]
        public Guid UnloadingPointGuid
        {
            get => _unloadingPointGuid;
            set => _unloadingPointGuid = value;
        }

    }
}
