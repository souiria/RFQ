/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   DemandCalculationMethodSelectionModel.cs
Function           :   Demand Calculation Method Selection 
Created By         :   Sejal Srivastava
Created on         :   28-Apr-2022
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
    /// Data Contract for DemandCalculationMethodSelectionModel
    /// </summary>
    [DataContract, Serializable]
    public class DemandCalculationMethodSelectionModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _customerBusinessGroupGuid     
        /// </summary>
        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
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
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }

        /// <summary>
        /// Local variable _customerDeliveryPointGuid     
        /// </summary>
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
        /// <summary>
        /// Local variable _unloadingPoint     
        /// </summary>
        private string _unloadingPoint;
        /// <summary>
        /// Get or Set for {UnloadingPoint}.
        /// </summary>
        [DataMember]
        public string UnloadingPoint
        {
            get => _unloadingPoint;
            set => _unloadingPoint = value;
        }
        /// <summary>
        /// Local variable _demandMethodGuid     
        /// </summary>
        private Guid _demandMethodGuid;
        /// <summary>
        /// Get or Set for {DemandMethodGuid}.
        /// </summary>
        [DataMember]
        public Guid DemandMethodGuid
        {
            get => _demandMethodGuid;
            set => _demandMethodGuid = value;
        }
    }
}
