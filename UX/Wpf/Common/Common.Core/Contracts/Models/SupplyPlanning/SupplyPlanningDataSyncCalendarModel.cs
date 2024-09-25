/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplyPlanningDataSyncCalendarModel.cs
Function           :   Schedule Setup
Created By         :   Srashti Gupta
Created on         :   11-June-2020
Revision History   :   [12-June-2020] : Srashti Gupta
*                  :   Added property {DataSyncSetupGuid}
*                  :   [29-June-2020] : Shivam Dhingra
*                  :   modified model as per requirement
*                  :   [30-June-2020] : Shivam Dhingra
*                  :   changed datatype from bit to short for IsScheduleEnabled and increased length for ScheduleStatus
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for EDISetUpMasters Service
    /// </summary>
    [DataContract, Serializable]
    public class SupplyPlanningDataSyncCalendarModel : BaseModel<Guid>
    {
        //private int _scheduleNumber;
        ///// <summary>
        ///// Get or Set for {ScheduleNumber}.
        ///// </summary>
        //[DataMember]
        //[Required]
        //public int ScheduleNumber
        //{
        //    get => _scheduleNumber;
        //    set => SetProperty(ref _scheduleNumber, value);
        //}

        private Guid _dataSyncConfigurationSetupGuid;
        /// <summary>
        /// Get or Set for {DataSyncConfigurationSetupGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid DataSyncConfigurationSetupGuid
        {
            get => _dataSyncConfigurationSetupGuid;
            set => SetProperty(ref _dataSyncConfigurationSetupGuid, value);
        }


        private string _sourceTableName;
        /// <summary>
        /// Source Table Name
        /// </summary>
        [DataMember]
        [StringLength(200)]
        [Required]
        public string SourceTableName
        {
            get => _sourceTableName;
            set => SetProperty(ref _sourceTableName, value);
        }


        private string _wmsSourceLocation;
        /// <summary>
        /// Get or Set for {WMSSourceLocation}.
        /// </summary>
        [DataMember]
        [StringLength(40)]
        public string WMSSourceLocation
        {
            get => _wmsSourceLocation;
            set => SetProperty(ref _wmsSourceLocation, value);
        }

        private string _wmsSourceType;
        /// <summary>
        /// Get or Set for {WMSSourceType}.
        /// </summary>
        [DataMember]
        [StringLength(40)]
        [Required]
        public string WMSSourceType
        {
            get => _wmsSourceType;
            set => SetProperty(ref _wmsSourceType, value);
        }


        private DateTime _scheduleDateTimeStampInUTC;
        /// <summary>
        /// Get or Set for {ScheduleDateTimeStampInUTC}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime ScheduleDateTimeStampInUTC
        {
            get => _scheduleDateTimeStampInUTC;
            set => SetProperty(ref _scheduleDateTimeStampInUTC, value);
        }

        private DateTime _scheduleDateTimeStampInLocal;
        /// <summary>
        /// Get or Set for {ScheduleDateTimeStampInLocal}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime ScheduleDateTimeStampInLocal
        {
            get => _scheduleDateTimeStampInLocal;
            set => SetProperty(ref _scheduleDateTimeStampInLocal, value);
        }


        private string _scheduleDay;
        /// <summary>
        /// Get or Set for {ScheduleDay}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(10)]
        public string ScheduleDay
        {
            get => _scheduleDay;
            set => SetProperty(ref _scheduleDay, value);
        }

       
        //private string _sourceLocation;
        ///// <summary>
        ///// Get or Set for {SourceLocation}.
        ///// </summary>
        //[DataMember]
        //[Required]
        //[StringLength(100)]
        //public string SourceLocation
        //{
        //    get => _sourceLocation;
        //    set => SetProperty(ref _sourceLocation, value);
        //}

        //private string _sourceType;
        ///// <summary>
        ///// Get or Set for {SourceType}.
        ///// </summary>
        //[DataMember]
        //[Required]
        //[StringLength(50)]
        //public string SourceType
        //{
        //    get => _sourceType;
        //    set => SetProperty(ref _sourceType, value);
        //}

        //private string _sourceLocationTable;
        ///// <summary>
        ///// Get or Set for {SourceLocationTable}.
        ///// </summary>
        //[DataMember]
        //[Required]
        //[StringLength(500)]
        //public string SourceLocationTable
        //{
        //    get => _sourceLocationTable;
        //    set => SetProperty(ref _sourceLocationTable, value);
        //}

        private string _scheduleStatus;
        /// <summary>
        /// Get or Set for {SourceStatus}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ScheduleStatus
        {
            get => _scheduleStatus;
            set => SetProperty(ref _scheduleStatus, value);
        }


        private short _isScheduleEnabled;
        /// <summary>
        /// Get or Set for {IsActive}.
        /// </summary>
        [DataMember]
        [Required]
        public short IsScheduleEnabled
        {
            get => _isScheduleEnabled;
            set => SetProperty(ref _isScheduleEnabled, value);
        }

        private bool _isActive = true;
        /// <summary>
        /// Get or Set for {IsActive}.
        /// </summary>
        [DataMember]
        [Required]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
        //private Guid _dataSyncSetupGuid;
        ///// <summary>
        ///// Get or Set for {DataSyncSetupGuid}.
        ///// </summary>
        //[DataMember]
        //[Required]
        //public Guid DataSyncSetupGuid
        //{
        //    get => _dataSyncSetupGuid;
        //    set => SetProperty(ref _dataSyncSetupGuid, value);
        //}


    }
}
