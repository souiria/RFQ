/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   UserGroupMenuAssociationModel.cs
Function           :   Model for saving Group ,Menu Association , User Group Association combined data
Created By         :   Shivam Dhingra
Created on         :   25-Jun-2021
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

namespace Common.Core.Contracts.Models.Administration.Security
{
    /// <summary>
    /// Class file for UserGroupMenuAssociationModel
    /// </summary>
    [DataContract, Serializable]
    public class UserGroupMenuAssociationModel : BaseModel<Guid>
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
            get { return _groupName; }
            set { _groupName = value; }
        }
        /// <summary>
        /// local variable _groupType
        /// </summary>
        private string _groupType;
        [DataMember]
        [StringLength(20)]
        public string GroupType
        {
            get { return _groupType; }
            set { _groupType = value; }
        }
        /// <summary>
        ///  local variable  IsActive
        /// </summary>
        private bool _groupIsActive = true;
        [DataMember]
        public bool GroupIsActive
        {
            get { return _groupIsActive; }
            set { _groupIsActive = value; }
        }

        /// <summary>
        ///  local variable  Id
        /// </summary>
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }


        //Group Menu Association Fields

        /// <summary>
        /// local variable _groupid
        /// </summary>
        private Guid _groupId;
        [DataMember]
        [Required]
        public Guid GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }
        /// <summary>
        /// local variable _menuid
        /// </summary>
        private Guid _menuid;
        [DataMember]
        [Required]
        public Guid MenuId
        {
            get { return _menuid; }
            set { _menuid = value; }
        }

        /// <summary>
        /// local variable _menustatus
        /// </summary>
        private bool _menustatus;
        [DataMember]
        public bool MenuStatus
        {
            get { return _menustatus; }
            set { _menustatus = value; }
        }
        /// <summary>
        /// local variable _createStatus
        /// </summary>
        private bool _createstatus;
        [DataMember]
        public bool CreateStatus
        {
            get { return _createstatus; }
            set { _createstatus = value; }
        }
        /// <summary>
        /// local variable _readstatus
        /// </summary>
        private bool _readstatus;
        [DataMember]
        public bool ReadStatus
        {
            get { return _readstatus; }
            set { _readstatus = value; }
        }
        /// <summary>
        /// local variable _updatestatus
        /// </summary>
        private bool _updatestatus;
        [DataMember]
        public bool UpdateStatus
        {
            get { return _updatestatus; }
            set { _updatestatus = value; }
        }
        /// <summary>
        /// local variable _deletestatus
        /// </summary>
        private bool _deletestatus;
        [DataMember]
        public bool DeleteStatus
        {
            get { return _deletestatus; }
            set { _deletestatus = value; }
        }
        /// <summary>
        ///  local variable  GroupMenuAssociationIsActive
        /// </summary>
        private bool _groupMenuAssociationIsActive = true;
        [DataMember]
        public bool GroupMenuAssociationIsActive
        {
            get { return _groupMenuAssociationIsActive; }
            set { _groupMenuAssociationIsActive = value; }
        }

        /// <summary>
        /// local variable GroupMenuAssociationId
        /// </summary>
        private Guid _groupMenuAssociationId;
        [DataMember]
        [Required]
        public Guid GroupMenuAssociationId
        {
            get { return _groupMenuAssociationId; }
            set { _groupMenuAssociationId = value; }
        }

        //User Group Association Fields

        /// <summary>
        /// local variable _groupGuid
        /// </summary>
        private Guid _groupGuid = Guid.Empty;
        [DataMember]
        public Guid GroupGuid
        {
            get { return _groupGuid; }
            set { _groupGuid = value; }

        }

        /// <summary>
        /// local variable _userGuid
        /// </summary>
        private Guid _userGuid;
        [DataMember]
        public Guid UserGuid
        {
            get { return _userGuid; }
            set { _userGuid = value; }
        }
        private bool _userGroupAssociationIsActive = true;
        [DataMember]
        public bool UserGroupAssociationIsActive
        {
            get { return _userGroupAssociationIsActive; }
            set { _userGroupAssociationIsActive = value; }
        }

        /// local variable UserGroupAssociationId
        /// </summary>
        private Guid _userGroupAssociationId;
        [DataMember]
        public Guid UserGroupAssociationId
        {
            get { return _userGroupAssociationId; }
            set { _userGroupAssociationId = value; }
        }

        private DateTime? _createdDate;

        [DataMember, DataType(DataType.DateTime)]
        public DateTime? CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }

        private DateTime? _modifiedDate;
        [DataMember, DataType(DataType.DateTime)]
        public DateTime? ModifiedDate
        {

            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }

        private Guid _createdBy;
        [DataMember]
        public Guid CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        private Guid _modifiedBy;
        [DataMember]
        public Guid ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }

        private int _crudOperationTypeGroupMaster;
        [DataMember]
        public int CrudOperationTypeGroupMaster
        {
            get { return _crudOperationTypeGroupMaster; }
            set { _crudOperationTypeGroupMaster = value; }
        }

        private int _crudOperationTypeGroupMenuAssociation;
        [DataMember]
        public int CrudOperationTypeGroupMenuAssociation
        {
            get { return _crudOperationTypeGroupMenuAssociation; }
            set { _crudOperationTypeGroupMenuAssociation = value; }
        }

        private int _crudOperationTypeUserGroupAssociation;
        [DataMember]
        public int CrudOperationTypeUserGroupAssociation
        {
            get { return _crudOperationTypeUserGroupAssociation; }
            set { _crudOperationTypeUserGroupAssociation = value; }
        }
    }
}
