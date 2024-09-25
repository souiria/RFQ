/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   H1SupplyPlanningDataSyncLogModel.cs
Function           :   Data contract for H1SupplyPlanningDataSyncLogModel
Created By         :   Shivam Dhingra
Created on         :   15-June-2020
Revision History   :   [16-Jun-2020] : Chnaged data type from Guid to int for ScheduleId
                   :   [29-June-2020] : Shivam Dhingra
*                  :   Modified model as per requirement
*                  :   [30-June-2020] : Shivam Dhingra
*                  :   removed field ScheduleNumber
*                  :   [30-June-2020] : Shivam Dhingra
*                  :   Changes done to make properties nullable as similar to DB
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract for H1SupplyPlanningDataSyncLog
    /// </summary>
    [DataContract, Serializable]
    public class H1SupplyPlanningDataSyncLogModel : BaseModel<Guid>
    {
        private string _dataSyncFunction;
        /// <summary>
        /// Data Sync Function
        /// </summary>
        [DataMember]
        [StringLength(40)]
        [Required]
        public string DataSyncFunction
        {
            get => _dataSyncFunction;
            set => SetProperty(ref _dataSyncFunction, value);
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

        private string _sourceServerName;
        /// <summary>
        /// Source Server Name
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string SourceServerName
        {
            get => _sourceServerName;
            set => SetProperty(ref _sourceServerName, value);
        }

        private string _sourceDatabaseName;
        /// <summary>
        /// Source Database Name
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string SourceDatabaseName
        {
            get => _sourceDatabaseName;
            set => SetProperty(ref _sourceDatabaseName, value);
        }

        private string _sourceSystem;
        /// <summary>
        /// Get or Set for {SourceSystem}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string SourceSystem
        {
            get => _sourceSystem;
            set => SetProperty(ref _sourceSystem, value);
        }

        private string _wmsSourceLocation;
        /// <summary>
        /// Get or Set for {WMSSourceLocation}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
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
        [StringLength(20)]
        [Required]
        public string WMSSourceType
        {
            get => _wmsSourceType;
            set => SetProperty(ref _wmsSourceType, value);
        }

        private bool? _syncActive;
        /// <summary>
        /// Get or Set for {SyncActive}.
        /// </summary>
        [DataMember]
        public bool? SyncActive
        {
            get => _syncActive;
            set => SetProperty(ref _syncActive, value);
        }


        private DateTime? _lastSyncDateTime;
        /// <summary>
        /// Get or Set for {LastSyncDateTime}.
        /// </summary>
        [DataMember]
        public DateTime? LastSyncDateTime
        {
            get => _lastSyncDateTime;
            set => SetProperty(ref _lastSyncDateTime, value);
        }

        private string _lastSyncStatus;
        /// <summary>
        /// Get or Set for {LastSyncStatus}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string LastSyncStatus
        {
            get => _lastSyncStatus;
            set => SetProperty(ref _lastSyncStatus, value);
        }

        private string _callingProcedure;
        /// <summary>
        /// Get or Set for {CallingProcedure}.
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string CallingProcedure
        {
            get => _callingProcedure;
            set => SetProperty(ref _callingProcedure, value);
        }

        private string _synchronizationJobName;
        /// <summary>
        /// Get or Set for {SynchronizationJobName}.
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string SynchronizationJobName
        {
            get => _synchronizationJobName;
            set => SetProperty(ref _synchronizationJobName, value);
        }

        private string _synchronizationSetupAtServer;
        /// <summary>
        /// Get or Set for {SynchronizationSetupAtServer}.
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string SynchronizationSetupAtServer
        {
            get => _synchronizationSetupAtServer;
            set => SetProperty(ref _synchronizationSetupAtServer, value);
        }


        private Guid _batchId;
        /// <summary>
        /// Get or Set for {BatchId}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BatchId
        {
            get => _batchId;
            set => SetProperty(ref _batchId, value);
        }


        private DateTime _batchStamp;
        /// <summary>
        /// Get or Set for {BatchStamp}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime BatchStamp
        {
            get => _batchStamp;
            set => SetProperty(ref _batchStamp, value);
        }

        private int _recordCount;
        /// <summary>
        /// Get or Set for {RecordCount}.
        /// </summary>
        [DataMember]
        [Required]
        public int RecordCount
        {
            get => _recordCount;
            set => SetProperty(ref _recordCount, value);
        }


        private string _remarks;
        /// <summary>
        /// Get or Set for {Remarks}.
        /// </summary>
        [DataMember]
        [StringLength(1000)]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }

        //private int? _scheduleNumber;
        ///// <summary>
        ///// Get or Set for {ScheduleNumber}.
        ///// </summary>
        //[DataMember]
        //public int? ScheduleNumber
        //{
        //    get => _scheduleNumber;
        //    set => SetProperty(ref _scheduleNumber, value);
        //}


       

        private Guid? _dataSyncConfigurationSetupGuid;
        /// <summary>
        /// Get or Set for {DataSyncConfigurationSetupGuid}.
        /// </summary>
        [DataMember]
        public Guid? DataSyncConfigurationSetupGuid
        {
            get => _dataSyncConfigurationSetupGuid;
            set => SetProperty(ref _dataSyncConfigurationSetupGuid, value);
        }


        private Guid? _supplyPlanningDataSyncCalendarGuid;
        /// <summary>
        /// Get or Set for {SupplyPlanningDataSyncCalendarGuid}.
        /// </summary>
        [DataMember]
        public Guid? SupplyPlanningDataSyncCalendarGuid
        {
            get => _supplyPlanningDataSyncCalendarGuid;
            set => SetProperty(ref _supplyPlanningDataSyncCalendarGuid, value);
        }


        private DateTime? _scheduleDateTimeStampInLocal;
        /// <summary>
        /// Get or Set for {ScheduleDateTimeStampInLocal}.
        /// </summary>
        [DataMember]
        public DateTime? ScheduleDateTimeStampInLocal
        {
            get => _scheduleDateTimeStampInLocal;
            set => SetProperty(ref _scheduleDateTimeStampInLocal, value);
        }

    }

}
