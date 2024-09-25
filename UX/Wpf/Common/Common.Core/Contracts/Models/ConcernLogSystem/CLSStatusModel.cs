/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CLSStatusModel.cs
Function           :   CLS Status
Created By         :   Piyush Anand
Created on         :   02-Jan-2024
Revision History   :  
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of CLS Status
    /// </summary>
    [DataContract, Serializable]
    public class CLSStatusModel : BaseModel<Guid>
    {
        private int? _cLSStage;

        /// <summary>
        /// Gets or sets a integer value for the CLS Stages column.
        /// </summary>
        [DataMember]
        [Required]
        public int? CLSStage
        {
            get => _cLSStage;
            set => SetProperty(ref _cLSStage, value);
        }

        private string _cLSStatusDescription;

        /// <summary>
        /// Gets or sets a string value for the Status Description column.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        [Required]        
        public string CLSStatusDescription
        {
            get => _cLSStatusDescription;
            set => SetProperty(ref _cLSStatusDescription, value);
        }

        /// <summary>
        /// 
        /// </summary>
        private bool _isOriginatorTeamNotificationRequired = false;
        /// <summary>
        /// When CLS or CLS Stages reaches to this stage, does Originator team require email notification
        /// </summary>

        [DataMember]
        [Required]
        public bool IsOriginatorTeamNotificationRequired
        {
            get => _isOriginatorTeamNotificationRequired;
            set => SetProperty(ref _isOriginatorTeamNotificationRequired, value);
        }

        private bool _isControllerTeamNotificationRequired = false;
        /// <summary>
        /// When CLS or CLS Stages reaches to this stage, does Controller team require email notification
        /// </summary>
        [DataMember]
        [Required]
        public bool IsControllerTeamNotificationRequired
        {
            get => _isControllerTeamNotificationRequired;
            set => SetProperty(ref _isControllerTeamNotificationRequired, value);
        }

        private bool _isAnalyzerTeamNotificationRequired = false;

        /// <summary>
        /// When CLS or CLS Stages reaches to this stage, does Analyzer team require email notification
        /// </summary>
        [DataMember]
        [Required]
        public bool IsAnalyzerTeamNotifcationRequired
        {
            get => _isAnalyzerTeamNotificationRequired;
            set => SetProperty(ref _isAnalyzerTeamNotificationRequired, value);
        }

        private bool _isBuisnessApprovalTeamNotificationRequired = false;
        /// <summary>
        /// When CLS or CLS Stages reaches to this stage, does BuisnessApproval team require email notification
        /// </summary>
        [DataMember]
        [Required]
        public bool IsBuisnessApprovalTeamNotificationRequired
        {
            get => _isBuisnessApprovalTeamNotificationRequired;
            set => SetProperty(ref _isBuisnessApprovalTeamNotificationRequired, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}