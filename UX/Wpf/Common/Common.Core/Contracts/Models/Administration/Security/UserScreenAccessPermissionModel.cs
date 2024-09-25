/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   UserScreenAccessPermissionModel.cs
Function           :   User Screen Access Permissions
Created By         :   Shivam Dhingra
Created on         :   17-Jun-2021
Revision History   :
****************************************************************************************************/
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
    /// Data Contract for User Screen Access Permissions
    /// </summary>
    [DataContract,Serializable]
    public class UserScreenAccessPermissionModel
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

        private string _functionName;
        /// <summary>
        /// Get or Set for {FunctionName}.
        /// </summary>
        [DataMember]
        public string FunctionName
        {
            get => _functionName;
            set => _functionName = value;
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

    /// <summary>
    /// Class file for Parameters for User Screen Access Permission
    /// </summary>
    [DataContract,Serializable]
    public class UserScreenAccessPermissionParameterModel
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

        private string _displayName;
        /// <summary>
        /// Get or Set for {DisplayName}.
        /// </summary>
        [DataMember]
        public string DisplayName
        {
            get => _displayName;
            set => _displayName = value;
        }

    }

}
