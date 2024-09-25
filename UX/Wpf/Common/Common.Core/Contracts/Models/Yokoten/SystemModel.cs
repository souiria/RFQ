/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SystemModel.cs
Function           :   Data contract for SystemModel
Created By         :   Srashti Gupta
Created on         :   04-Mar-2020
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    /// <summary>
    /// Data contract for SystemModel
    /// </summary>
    [DataContract, Serializable]
    public class SystemModel : BaseModel<Guid>
    {
        private string _systemName;
        /// <summary>
        /// Get or Set for {SystemName}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string SystemName
        {
            get => _systemName;
            set => SetProperty(ref _systemName, value);
        }

        private string _systemType;
        /// <summary>
        /// Get or Set for {SystemType}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(50)]
        public string SystemType
        {
            get => _systemType;
            set => SetProperty(ref _systemType, value);
        }
       
        private Guid _parentId;
        /// <summary>
        /// Get or Set for {ParentId}
        /// </summary>
        [DataMember]
        [Required]
        
        public Guid ParentId
        {
            get => _parentId;
            set => SetProperty(ref _parentId, value);
        }
    }
}
