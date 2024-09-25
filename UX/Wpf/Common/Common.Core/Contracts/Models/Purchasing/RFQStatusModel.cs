/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   RFQStatusModel.cs
Function           :   RFQ Status
Created By         :   Pawan Kumar
Created on         :   14-Jun-2019
Revision History   :   Ajay: 24-Aug-2019, 25-Aug-2019
                       [ ]: Include additional fields (NotificationFlag)
                       [ ]: IsPurchasingTeamNotificationRequired, IsEngineeringTeamNotificationRequired, IsQualityTeamNotifcationRequired, IsSDETeamNotificationRequired
                       [ ]: bool instead of integer
                   :   [27-Aug-2019] : Srashti
                       [ ]: Change the datatype of NPRStage,RFQStage to int 
                   :   [29-Aug-2019] : Pawan
                   :   [] : Added new field for Logistics Notification Status 
                   :   [11-Sep-2019] : Pawan
                   :   [] : Added new field for Supplier Notification Status 
                   :   [19-Sep-2019] : Pawan
                   :   [] : Added new field for Is Virtual Stage 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of RFQ Status
    /// </summary>
    [DataContract, Serializable]
    public class RFQStatusModel : BaseModel<Guid>
    {
        
        //private string _rfqStage;

        ///// <summary>
        ///// Gets or sets a integer value for the RFQ Stages column.
        ///// </summary>
        //[DataMember]
        //[Required]
        //public string RFQStage
        //{
        //    get => _rfqStage;
        //    set => SetProperty(ref _rfqStage, value);
        //}
        
        private string _nprStage;

        /// <summary>
        /// Gets or sets a integer value for the NPR Stages column.
        /// </summary>
        [DataMember]
        [Required]
        public string NPRStage
        {
            get => _nprStage;
            set => SetProperty(ref _nprStage, value);
        }

        private string _rfqStatusDescription;

        /// <summary>
        /// Gets or sets a string value for the Status Description column.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        [Required]        
        public string RFQStatusDescription
        {
            get => _rfqStatusDescription;
            set => SetProperty(ref _rfqStatusDescription, value);
        }

        /// <summary>
        /// 
        /// </summary>
        private bool _isPurchasingTeamNotificationRequired = false;
        /// <summary>
        /// When NPR or RFQ Stages reaches to this stage, does Purchasing team require email notification
        /// </summary>

        [DataMember]
        [Required]
        public bool IsPurchasingTeamNotificationRequired
        {
            get => _isPurchasingTeamNotificationRequired;
            set => SetProperty(ref _isPurchasingTeamNotificationRequired, value);
        }

        private bool _isEngineeringTeamNotificationRequired = false;
        /// <summary>
        /// When NPR or RFQ Stages reaches to this stage, does Engineering team require email notification
        /// </summary>
        [DataMember]
        [Required]
        public bool IsEngineeringTeamNotificationRequired
        {
            get => _isEngineeringTeamNotificationRequired;
            set => SetProperty(ref _isEngineeringTeamNotificationRequired, value);
        }

        private bool _isQualityTeamNotificationRequired = false;

        /// <summary>
        /// When NPR or RFQ Stages reaches to this stage, does Quality team require email notification
        /// </summary>
        [DataMember]
        [Required]
        public bool IsQualityTeamNotifcationRequired
        {
            get => _isQualityTeamNotificationRequired;
            set => SetProperty(ref _isQualityTeamNotificationRequired, value);
        }

        private bool _isSDETeamNotificationRequired = false;
        /// <summary>
        /// When NPR or RFQ Stages reaches to this stage, does SDE/Supplier Development team require email notification
        /// </summary>
        [DataMember]
        [Required]
        public bool IsSDETeamNotificationRequired
        {
            get => _isSDETeamNotificationRequired;
            set => SetProperty(ref _isSDETeamNotificationRequired, value);
        }

        private bool _isLogisticTeamNotificationRequired = false;
        /// <summary>
        /// When NPR or RFQ Stages reaches to this stage, does Logistic team require email notification
        /// </summary>
        [DataMember]
        [Required]
        public bool IsLogisticTeamNotificationRequired
        {
            get => _isLogisticTeamNotificationRequired;
            set => SetProperty(ref _isLogisticTeamNotificationRequired, value);
        }

        private bool _isSupplierTeamNotificationRequired = false;
        /// <summary>
        /// When NPR or RFQ Stages reaches to this stage, does Logistic team require email notification
        /// </summary>
        [DataMember]
        [Required]
        public bool IsSupplierTeamNotificationRequired
        {
            get => _isSupplierTeamNotificationRequired;
            set => SetProperty(ref _isSupplierTeamNotificationRequired, value);
        }

        private bool _isVirtualNPRStage = false;
        /// <summary>
        /// It notifies whether the npr stage is actually a stage or it is just for audit purpose
        /// </summary>
        [DataMember]
        [Required]
        public bool IsVirtualNPRStage
        {
            get => _isVirtualNPRStage;
            set => SetProperty(ref _isVirtualNPRStage, value);
        }

    }
}