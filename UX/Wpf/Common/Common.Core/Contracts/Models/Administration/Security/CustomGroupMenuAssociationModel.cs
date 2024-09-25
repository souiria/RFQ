/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomGroupMenuAssociationModel.cs
Function           :   Custom Permissions for User
Created By         :   Dharmendra Kumar
Created on         :   30-Jun-2021
Revision History   :
****************************************************************************************************/
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    /// <summary>
    ///  Data Contract for Display Custom Group Menu
    /// </summary>
    [DataContract, Serializable]
   public class CustomGroupMenuAssociationModel
    {
        private Guid _userGuid;
        /// <summary>
        /// Get or Set for {UserGuid}.
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }

        private string _groupName;
        /// <summary>
        /// Get or Set for {_groupName}.
        /// </summary>
        [DataMember]
        public string GroupName
        {
            get => _groupName;
            set => _groupName = value;
        }
        private Guid _groupGuid;
        /// <summary>
        /// Get or Set for {GroupGuid}.
        /// </summary>
        [DataMember]
        public Guid GroupGuid
        {
            get => _groupGuid;
            set => _groupGuid = value;
        }
        private string _screenName;
        /// <summary>
        /// Get or Set for {ScreenName}.
        /// </summary>
        [DataMember]
        public string ScreenName
        {
            get => _screenName;
            set => _screenName = value;
        }

        private string _viewName;
        /// <summary>
        /// Get or Set for {ViewName}.
        /// </summary>
        [DataMember]
        public string ViewName
        {
            get => _viewName;
            set => _viewName = value;
        }
        private Guid _menuId;
        /// <summary>
        /// Get or Set for {MenuId}.
        /// </summary>
        [DataMember]
        public Guid MenuId
        {
            get => _menuId;
            set => _menuId = value;
        }
        private bool _menuStatus;
        /// <summary>
        /// Get or Set for {MenuStatus}.
        /// </summary>
        [DataMember]
        public bool MenuStatus
        {
            get => _menuStatus;
            set => _menuStatus = value;
        }

        private bool _createStatus;
        /// <summary>
        /// Get or Set for {CreateStatus}.
        /// </summary>
        [DataMember]
        public bool CreateStatus
        {
            get => _createStatus;
            set => _createStatus = value;
        }

        private bool _readStatus;
        /// <summary>
        /// Get or Set for {ReadStatus}.
        /// </summary>
        [DataMember]
        public bool ReadStatus
        {
            get => _readStatus;
            set => _readStatus = value;
        }

        private bool _updateStatus;
        /// <summary>
        /// Get or Set for {UpdateStatus}.
        /// </summary>
        [DataMember]
        public bool UpdateStatus
        {
            get => _updateStatus;
            set => _updateStatus = value;
        }

        private bool _deleteStatus;
        /// <summary>
        /// Get or Set for {DeleteStatus}.
        /// </summary>
        [DataMember]
        public bool DeleteStatus
        {
            get => _deleteStatus;
            set => _deleteStatus = value;
        }
    }


}
