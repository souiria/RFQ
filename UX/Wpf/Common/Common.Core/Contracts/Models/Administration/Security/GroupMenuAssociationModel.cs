/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   GroupMenuAssociationModel.cs
Function           :   Group Menu Association for managing Group Menu Association
Created By         :   Ashish Dutta
Created on         :   31-May-2021
Revision History   :
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Base;
namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
   public class GroupMenuAssociationModel : BaseModel<Guid>
    {
        /// <summary>
        /// local variable _groupid
        /// </summary>
        private Guid _groupid;
        [DataMember]
        [Required]
        public Guid GroupId
        {
            get => _groupid;
            set => SetProperty(ref _groupid, value);
        }
        /// <summary>
        /// local variable _menuid
        /// </summary>
        private Guid _menuid;
        [DataMember]
        [Required]
        public Guid MenuId
        {
            get => _menuid;
            set => SetProperty(ref _menuid, value);
        }
        /// <summary>
        /// local variable _groupname
        /// </summary>
        private string _groupname;
        [DataMember]
        [StringLength(50)]
        public string GroupName
        {
            get => _groupname;
            set => SetProperty(ref _groupname, value);
        }
        /// <summary>
        /// local variable _displayname
        /// </summary>
        private string _displayname;
        [DataMember]
        [StringLength(250)]
        public string DisplayName
        {
            get => _displayname;
            set => SetProperty(ref _displayname, value);
        }

        /// <summary>
        /// local variable _menustatus
        /// </summary>
        private bool _menustatus;
        [DataMember]
        public bool MenuStatus
        {
            get => _menustatus;
            set => SetProperty(ref _menustatus, value);
        }
        /// <summary>
        /// local variable _createStatus
        /// </summary>
        private bool _createstatus;
        [DataMember]
        public bool CreateStatus
        {
            get => _createstatus;
            set => SetProperty(ref _createstatus, value);
        }
        /// <summary>
        /// local variable _readstatus
        /// </summary>
        private bool _readstatus;
        [DataMember]
        public bool ReadStatus
        {
            get => _readstatus;
            set => SetProperty(ref _readstatus, value);
        }
        /// <summary>
        /// local variable _updatestatus
        /// </summary>
        private bool _updatestatus;
        [DataMember]
        public bool UpdateStatus
        {
            get => _updatestatus;
            set => SetProperty(ref _updatestatus, value);
        }
        /// <summary>
        /// local variable _deletestatus
        /// </summary>
        private bool _deletestatus;
        [DataMember]
        public bool DeleteStatus
        {
            get => _deletestatus;
            set => SetProperty(ref _deletestatus, value);
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
}
