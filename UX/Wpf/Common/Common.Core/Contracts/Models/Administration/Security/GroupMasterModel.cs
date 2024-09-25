/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   GroupMasterModels.cs
Function           :   Group Master for managing security Group
Created By         :   Dharmendra
Created on         :   25-May-2021
Revision History   :   [18-Aug-2021] : Dharmendra 
                    :  []: Add new property  GroupDescription
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
namespace Common.Core.Contracts.Models.Administration.Security
{
    /// <summary>
    /// Model class for bind Group Master Model
    /// </summary>
    [DataContract, Serializable]
    public class GroupMasterModel : BaseModel<Guid>
    {
        /// <summary>
        /// local variable _groupName
        /// </summary>
        private string _groupName;
        [DataMember]
        [StringLength(50)]
        [Required]
        public string GroupName
        {
            get => _groupName;
            set => SetProperty(ref _groupName, value);
        }

        private string _groupDescription;
        [DataMember]
        [StringLength(500)]
        public string GroupDescription
        {
            get => _groupDescription;
            set => SetProperty(ref _groupDescription, value);
        }

        /// <summary>
        /// local variable _groupType
        /// </summary>
        private string _groupType;
        [DataMember]
        [StringLength(20)]
        public string GroupType
        {
            get => _groupType;
            set => SetProperty(ref _groupType, value);
        }
        /// <summary>
        ///  local variable  IsActive
        /// </summary>
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
    /// <summary>
    /// Model class for bind Group Name
    /// </summary>
    [DataContract, Serializable]
    public class BindGroupName
    {
        /// <summary>
        /// local variable _groupName
        /// </summary>
        private string _groupName;
        [DataMember]
        [Required]
        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }

        private Guid _groupGuid;
        [DataMember]
        public Guid GroupGuid
        {
            get { return _groupGuid; }
            set { _groupGuid = value; }
        }
    }
}
