/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerDemandInterchangeabilityModel.cs
Function           :   [HD Call- 0397031] CustomerDemandInterchangeabilityModel
Created By         :   Virendra
Created on         :   27-Nov-2023
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
   public class CustomerDemandInterchangeabilityModel : BaseModel<Guid>
    { /// <summary>
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
        /// Local variable _tragetPartNumberGuid     
        /// </summary>
        private Guid _tragetPartNumberGuid;
        /// <summary>
        /// Get or Set for {TragetPartNumberGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid TragetPartNumberGuid
        {
            get => _tragetPartNumberGuid;
            set => SetProperty(ref _tragetPartNumberGuid, value);
        }
        /// <summary>
        /// Local variable _replacementPartNumberGuid     
        /// </summary>
        private Guid _replacementPartNumberGuid;
        /// <summary>
        /// Get or Set for {ReplacementPartNumberGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid ReplacementPartNumberGuid
        {
            get => _replacementPartNumberGuid;
            set => SetProperty(ref _replacementPartNumberGuid, value);
        }
        /// <summary>
        /// Local variable _tragetPartNumber     
        /// </summary>
        private string _tragetPartNumber;
        /// <summary>
        /// Get or Set for {TragetPartNumber}.
        /// </summary>
        [DataMember]
        public string TargetPartNumber
        {
            get => _tragetPartNumber;
            set => SetProperty(ref _tragetPartNumber, value);
        }
        /// <summary>
        /// Local variable _replacementPartNumber     
        /// </summary>
        private string _replacementPartNumber;
        /// <summary>
        /// Get or Set for {ReplacementPartNumber}.
        /// </summary>
        [DataMember]
        public string ReplacementPartNumber
        {
            get => _replacementPartNumber;
            set => SetProperty(ref _replacementPartNumber, value);
        }
        private DateTime? _startDate;
        [DataMember]
        [Required]
        public DateTime? StartDate
        {
            get => _startDate ?? DateTime.UtcNow;
            set => SetProperty(ref _startDate, value);
        }
        private DateTime? _endDate;
        [DataMember]
        public DateTime? EndDate
        {
            get { return _endDate; }
            set => SetProperty(ref _endDate, value);
        }
    }
}
