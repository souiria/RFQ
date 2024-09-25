/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplyPlanningMailDistributionSettingModel.cs
Function           :  
Created By         :   Ranjay
Created on         :   05-Aug-2022
Revision History   :   [12-Aug-2022] : Ranjay
*                  :   Added column GroupName, ProcessName 

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
    /// Data Contract use for SupplyPlanningMailDistributionSetting
    /// </summary>
    [DataContract, Serializable]
    public class SupplyPlanningMailDistributionSettingModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _groupMasterGuid     
        /// </summary>
        private Guid _groupMasterGuid;
        /// <summary>
        /// Get or Set for {GroupMasterGuid}.
        /// </summary>
        [DataMember]
        public Guid GroupMasterGuid
        {
            get => _groupMasterGuid;
            set => SetProperty(ref _groupMasterGuid, value);
        }

        /// <summary>
        /// Local variable _processNameGuid     
        /// </summary>
        private Guid _processNameGuid;
        /// <summary>
        /// Get or Set for {ProcessNameGuid}.
        /// </summary>
        [DataMember]
        public Guid ProcessNameGuid
        {
            get => _processNameGuid;
            set => SetProperty(ref _processNameGuid, value);
        }

        /// <summary>
        /// Local variable _groupName     
        /// </summary>
        private string _groupName;
        /// <summary>
        /// Get or Set for {GroupName}.
        /// </summary>
        [DataMember]
        public string GroupName
        {
            get => _groupName;
            set => _groupName = value;
        }

        /// <summary>
        /// Local variable _processName     
        /// </summary>
        private string _processName;
        /// <summary>
        /// Get or Set for {ProcessName}.
        /// </summary>
        [DataMember]
        public string ProcessName
        {
            get => _processName;
            set => _processName = value;
        }
    }

    /// <summary>
    /// Model class for bind Group Name
    /// </summary>
    [DataContract, Serializable]
    public class BindProcessName
    {
        /// <summary>
        /// Local variable _processGuid     
        /// </summary>
        private Guid _processGuid;
        /// <summary>
        /// Get or Set for {ProcessGuid}.
        /// </summary>
        [DataMember]
        public Guid ProcessGuid
        {
            get { return _processGuid; }
            set { _processGuid = value; }
        }
        /// <summary>
        /// local variable _processName
        /// </summary>
        private string _processName;
        /// <summary>
        /// Get or Set for {ProcessName}.
        /// </summary>
        [DataMember]
        public string ProcessName
        {
            get { return _processName; }
            set { _processName = value; }
        }
    }
}
