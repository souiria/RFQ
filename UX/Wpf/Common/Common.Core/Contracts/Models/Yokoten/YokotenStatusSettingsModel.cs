/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   YokotenStatusSettingsModel.cs
Function           :   Data Contracts for Yokoten Status Settings Screen
Created By         :   Pawan
Created on         :   10-Jun-2020
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    /// <summary>
    /// Data contract for Yokoten Status
    /// </summary>
    [DataContract, Serializable]
    public class YokotenStatusSettingsModel : BaseModel<Guid>
    {
        private int _yokotenStatusCode;

        /// <summary>
        /// Gets or sets a integer value for the Yokoten Status column.
        /// </summary>
        [DataMember]
        public int YokotenStatusCode
        {
            get => _yokotenStatusCode;
            set => SetProperty(ref _yokotenStatusCode, value);
        }

        private string _yokotenStatusDescription;
        /// <summary>
        /// Set Yokoten Status
        /// </summary>
        [DataMember]
        [StringLength(250)]
        public string YokotenStatusDescription
        {
            get => _yokotenStatusDescription;
            set => SetProperty(ref _yokotenStatusDescription, value);
        }
        
        private bool _isCentralQualityTeamNotificationRequired = false;
        /// <summary>
        /// When Yokoten reaches to this stage, does Central Quality team require email notification
        /// </summary>
        [DataMember]
        public bool IsCentralQualityTeamNotificationRequired
        {
            get => _isCentralQualityTeamNotificationRequired;
            set => SetProperty(ref _isCentralQualityTeamNotificationRequired, value);
        }

        private bool _isCustomerBusinessQualityTeamNotificationRequired = false;
        /// <summary>
        /// When Yokoten reaches to this stage, does Customer Business Quality team require email notification
        /// </summary>
        [DataMember]
        public bool IsCustomerBusinessQualityTeamNotificationRequired
        {
            get => _isCustomerBusinessQualityTeamNotificationRequired;
            set => SetProperty(ref _isCustomerBusinessQualityTeamNotificationRequired, value);
        }

        private bool _isPlatformManagerNotificationRequired = false;
        /// <summary>
        /// When Yokoten reaches to this stage, does Platform team require email notification
        /// </summary>
        [DataMember]
        public bool IsPlatformManagerNotificationRequired
        {
            get => _isPlatformManagerNotificationRequired;
            set => SetProperty(ref _isPlatformManagerNotificationRequired, value);
        }

        private bool _isSiteQualityManagerNotificationRequired = false;
        /// <summary>
        /// When Yokoten reaches to this stage, does Site Quality Manager require email notification
        /// </summary>
        [DataMember]
        public bool IsSiteQualityManagerNotificationRequired
        {
            get => _isSiteQualityManagerNotificationRequired;
            set => SetProperty(ref _isSiteQualityManagerNotificationRequired, value);
        }

        private bool _isCQETeamNotificationRequired = false;
        /// <summary>
        /// When Yokoten reaches to this stage, does CQE Team require email notification
        /// </summary>
        [DataMember]
        public bool IsCQETeamNotificationRequired
        {
            get => _isCQETeamNotificationRequired;
            set => SetProperty(ref _isCQETeamNotificationRequired, value);
        }

        private bool _isCentralEngineeringTeamNotificationRequired = false;
        /// <summary>
        /// When Yokoten reaches to this stage, does Central Engineering Team require email notification
        /// </summary>
        [DataMember]
        public bool IsCentralEngineeringTeamNotificationRequired
        {
            get => _isCentralEngineeringTeamNotificationRequired;
            set => SetProperty(ref _isCentralEngineeringTeamNotificationRequired, value);
        }

        private bool _isVirtualYokotenStatus = false;
        /// <summary>
        /// It notifies whether the yokoten status is actually a stage or it is just for audit purpose
        /// </summary>
        [DataMember]
        [Required]
        public bool IsVirtualYokotenStatus
        {
            get => _isVirtualYokotenStatus;
            set => SetProperty(ref _isVirtualYokotenStatus, value);
        }
    }
}
