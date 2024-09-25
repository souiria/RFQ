/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SingleUserMaintenanceModel.cs
Function           :   SingleUserMaintenance Model
Created By         :   Sachin Pandey
Created on         :   17-Jan-2024 
Revision History   :   []
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Model for SingleUserMaintenance Screen
    /// </summary>
    [DataContract, Serializable]
    public class SingleUserMaintenanceModel : BaseModel<Guid>
    {
        private Guid _h1MenuGuid;
        /// <summary>
        /// Get or Set for {ScreenGuid}.
        /// </summary>
        [DataMember]
        public Guid H1MenuGuid
        {
            get => _h1MenuGuid;
            set => SetProperty(ref _h1MenuGuid, value);
        }

        private string _screenName;
        /// <summary>
        /// Get or Set for {Screen Name}.
        /// </summary>
        [DataMember]
        public string ScreenName
        {
            get => _screenName;
            set => SetProperty(ref _screenName, value);
        }

        private bool _lockedduringDRP;
        /// <summary>
        /// Get or Set for {LockedDuringDRP}.
        /// </summary>
        [DataMember]
        public bool LockedDuringDRP
        {
            get => _lockedduringDRP;
            set => SetProperty(ref _lockedduringDRP, value);
        }

        private bool _singleUser;
        /// <summary>
        /// Get or Set for {SingleUser}.
        /// </summary>
        [DataMember]
        public bool SingleUser
        {
            get => _singleUser;
            set => SetProperty(ref _singleUser, value);
        }

        private string _updateTimeStamp;
        /// <summary>
        /// Get or Set for {UpdateTimeStamp}.
        /// </summary>
        [DataMember]
        public string UpdateTimeStamp
        {
            get => _updateTimeStamp;
            set => SetProperty(ref _updateTimeStamp, value);
        }

        private string _updatedBy;
        /// <summary>
        /// Get or Set for {Updated By}.
        /// </summary>
        [DataMember]
        public string UpdatedBy
        {
            get => _updatedBy;
            set => _updatedBy = value;
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

        /// <summary>
        /// Validation on properties
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public override string this[string propertyName]
        {
            get
            {
                Error = string.Empty;
                try
                {
                    switch (propertyName)
                    {
                        // Sample Implementation
                        case nameof(ScreenName):
                            if (_screenName == null || _screenName == "")
                            {
                                Error = "Screen Name cannot be blank";
                            }
                            break;
                        default: break;
                    }
                    UpdateErrors(propertyName, Error);
                }
                catch (Exception) { }
                return Error;

            }
        }
    }

    /// <summary>
    /// Model for ScreenNameDropDown
    /// </summary>
    public class ScreenNameDropDownModel
    {
        private Guid _h1MenuGuid;
        /// <summary>
        /// Get or Set for {ScreenGuid}.
        /// </summary>
        [DataMember]
        public Guid H1MenuGuid
        {
            get => _h1MenuGuid;
            set => _h1MenuGuid = value;
        }
        private string _screenName;
        /// <summary>
        /// Get or Set for {Screen Name}.
        /// </summary>
        [DataMember]
        public string ScreenName
        {
            get => _screenName;
            set => _screenName = value;
        }
    }

    /// <summary>
    /// Model for LockDuringDRPOperation
    /// </summary>
    public class LockDuringDRPOperationModel
    {
        private string _viewName;
        /// <summary>
        /// Get or Set for {ViewName}.
        /// </summary>
        [NotMapped, DataMember]
        public string ViewName
        {
            get => _viewName;
            set => _viewName = value;
        }
        private string _error;
        /// <summary>
        /// Get or Set for {Error}.
        /// </summary>
        [NotMapped, DataMember]
        public string Error
        {
            get => _error;
            set => _error = value;
        }
    }
}
