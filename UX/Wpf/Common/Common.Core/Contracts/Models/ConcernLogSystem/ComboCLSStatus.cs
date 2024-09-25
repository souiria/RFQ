/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ComboCLSStatus.cs
Function           :   Maintain combo details for CLS Status
Created By         :   Piyush Anand
Created on         :   10-Jan-2024
Revision History   :   
****************************************************************************************************/
using System;

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    public class ComboCLSStatus
    {
        private Guid _id;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _cLSStage;

        /// <summary>
        /// Gets or sets a integer value for the CLS Stages column.
        /// </summary>
        public int CLSStage
        {
            get { return _cLSStage; }
            set { _cLSStage = value; }
        }

        private string _cLSStatusDescription;

        /// <summary>
        /// Gets or sets a string value for the Status Description column.
        /// </summary>
        public string CLSStatusDescription
        {
            get { return _cLSStatusDescription; }
            set { _cLSStatusDescription = value; }
        }

        private bool _isOriginatorTeamNotificationRequired = false;
        /// <summary>
        /// When CLS or CLS Stages reaches to this stage, does Originator team require email notification
        /// </summary>
        public bool IsOriginatorTeamNotificationRequired
        {
            get { return _isOriginatorTeamNotificationRequired; }
            set { _isOriginatorTeamNotificationRequired = value; }
        }

        private bool _isControllerTeamNotificationRequired = false;
        /// <summary>
        /// When CLS or CLS Stages reaches to this stage, does Controller team require email notification
        /// </summary>
        public bool IsControllerTeamNotificationRequired
        {
            get { return _isControllerTeamNotificationRequired; }
            set { _isControllerTeamNotificationRequired = value; }
        }

        private bool _isAnalyzerTeamNotificationRequired = false;

        /// <summary>
        /// When CLS or CLS Stages reaches to this stage, does Analyzer team require email notification
        /// </summary>
        public bool IsAnalyzerTeamNotifcationRequired
        {
            get { return _isAnalyzerTeamNotificationRequired; }
            set { _isAnalyzerTeamNotificationRequired = value; }
        }

        private bool _isBuisnessApprovalTeamNotificationRequired = false;
        /// <summary>
        /// When CLS or CLS Stages reaches to this stage, does BuisnessApproval team require email notification
        /// </summary>
        public bool IsBuisnessApprovalTeamNotificationRequired
        {
            get { return _isBuisnessApprovalTeamNotificationRequired; }
            set { _isBuisnessApprovalTeamNotificationRequired = value; }
        }
    }
}
