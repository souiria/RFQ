/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   H1CustomerMappingModel.cs
Function           :   H1 Customer Mapping Model 
Created By         :   Dharmendra Kumar
Created on         :   21-Apr-2020
Revision History   :   [] 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    ///Class file for H1 Customer Mapping Model
    /// </summary>
    public  class H1CustomerMappingModel : BaseModel<Guid>
    {
        private string _customerBusinessGroupName;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupName}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string CustomerBusinessGroupName
        {
            get => _customerBusinessGroupName;
            set => SetProperty(ref _customerBusinessGroupName, value);
        }
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
 
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(50)]
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }
        private Guid _customerHierarchyGuid;
        /// <summary>
        /// Get or Set for {CustomerHierarchyGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerHierarchyGuid
        {
            get => _customerHierarchyGuid;
            set => SetProperty(ref _customerHierarchyGuid, value);
        }        
       
        private string _platformName;
        /// <summary>
        /// Get or Set Value for PlatformName
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string PlatformName
        {
            get => _platformName;
            set => SetProperty(ref _platformName, value);
        }
        private Guid _platformHierarchyGuid;
        /// <summary>
        /// Get or Set for {PlatformHierarchyGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid PlatformHierarchyGuid
        {
            get => _platformHierarchyGuid;
            set => SetProperty(ref _platformHierarchyGuid, value);
        }

        /// <summary>
        ///  local variable _programName
        /// </summary>
        private string _programName;
        /// <summary>
        /// Get or Set value for Program Name
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ProgramName
        {
            get => _programName;
            set => SetProperty(ref _programName, value);
        }
        /// <summary>
        /// local variable _programHierarchyGuid
        /// </summary>
        private Guid _programHierarchyGuid;
        /// <summary>
        /// Get or Set for {ProgramHierarchyGuid}
        /// </summary>
        [DataMember]
        [Required]
        public Guid ProgramHierarchyGuid
        {
            get => _programHierarchyGuid;
            set => SetProperty(ref _programHierarchyGuid, value);
        }

        /// <summary>
        ///  local variable _projectName
        /// </summary>
        private string _projectName;
        /// <summary>
        /// Get or Set for {ProjectName}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ProjectName
        {
            get => _projectName;
            set => SetProperty(ref _projectName, value);
        }
        /// <summary>
        /// local variable for _projectHierarchyGuid
        /// </summary>
        private Guid _projectHierarchyGuid;
        /// <summary>
        /// Get or Set value for {ProjectHierarchyGuid}
        /// </summary>
        [DataMember]
        [Required]
        public Guid ProjectHierarchyGuid
        {
            get => _projectHierarchyGuid;
            set => SetProperty(ref _projectHierarchyGuid, value);
        }


    }
}
