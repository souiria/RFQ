/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   FinanceDataSyncConfigurationSetupModel.cs
Function           :   Data Contract for Finance Data Sync & Configuration Setup Model
Created By         :   Prakhar
Created on         :   19-Oct-2023
Revision History   :   [] : 
*                  :   []

****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Finance
{
    public class FinanceDataSyncConfigurationSetupModel : BaseModel<Guid>
    {
        private string _dataSynchronizationFunction;
        /// <summary>
        /// Data Sync Function
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DataSynchronizationFunction
        {
            get => _dataSynchronizationFunction;
            set => SetProperty(ref _dataSynchronizationFunction, value);
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
        [StringLength(20)]
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
        [StringLength(40)]
        [Required]
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

        private bool _syncActive = true;
        /// <summary>
        /// Get or Set for {SyncActive}.
        /// </summary>
        [DataMember]
        [Required]
        public bool SyncActive
        {
            get => _syncActive;
            set => SetProperty(ref _syncActive, value);
        }

        private DateTime _lastSynchronizeDateTime;
        /// <summary>
        /// Get or Set for {LastSynchronizeDateTime}.
        /// </summary>
        [DataMember]
        public DateTime LastSynchronizeDateTime
        {
            get => _lastSynchronizeDateTime;
            set => SetProperty(ref _lastSynchronizeDateTime, value);
        }

        private Guid _lastSynchronizeBy;
        /// <summary>
        /// Get or Set for {SynchronizationStatus}.
        /// </summary>
        [DataMember]
        public Guid LastSynchronizeBy
        {
            get => _lastSynchronizeBy;
            set => SetProperty(ref _lastSynchronizeBy, value);
        }

        private string _synchronizationStatus;
        /// <summary>
        /// Get or Set for {LastSynchronizeBy}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string SynchronizationStatus
        {
            get => _synchronizationStatus;
            set => SetProperty(ref _synchronizationStatus, value);
        }

        private string _remarks;
        /// <summary>
        /// Get or Set for {Remarks}.
        /// </summary>
        [DataMember]
        [StringLength(250)]
        public string Remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }

        private string _callingProcedure;
        /// <summary>
        /// Get or Set for {CallingProcedure}.
        /// </summary>
        [DataMember]
        [StringLength(200)]
        [Required]
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
        [Required]
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
        [StringLength(50)]
        public string SynchronizationSetupAtServer
        {
            get => _synchronizationSetupAtServer;
            set => SetProperty(ref _synchronizationSetupAtServer, value);
        }

        private string _timeZoneId;
        /// <summary>
        /// Get or Set for {TimeZone}.
        /// </summary>
        [DataMember]
        [StringLength(200)]
        [Required]
        public string TimeZoneId
        {
            get => _timeZoneId;
            set => SetProperty(ref _timeZoneId, value);
        }

        private int _scheduleFrequencyHours = 0;
        ///// <summary>
        ///// Get or Set for {ScheduleFrequencyHours}
        ///// </summary>
        [DataMember]
        [Required]
        public int ScheduleFrequencyHours
        {
            get => _scheduleFrequencyHours;
            set => SetProperty(ref _scheduleFrequencyHours, value);
        }

        private Guid _h1WHSiteGuid;
        /// <summary>
        /// Get or Set for {H1WHCode}.
        /// </summary>
        [DataMember]
        public Guid WHSiteGuid
        {
            get => _h1WHSiteGuid;
            set => SetProperty(ref _h1WHSiteGuid, value);
        }

        private Guid _h1WHCodeGuid;
        /// <summary>
        /// Get or Set for {H1WHCode}.
        /// </summary>
        [DataMember]
        public Guid H1WHCodeGuid
        {
            get => _h1WHCodeGuid;
            set => SetProperty(ref _h1WHCodeGuid, value);
        }

        private string _monday;
        /// <summary>
        /// Get or Set for {Monday}.
        /// </summary>
        [DataMember]
        [Required]
        public string Monday
        {
            get => _monday;
            set => SetProperty(ref _monday, value);
        }

        private string _tuesday;
        /// <summary>
        /// Get or Set for {tuesday}.
        /// </summary>
        [DataMember]
        [Required]
        public string Tuesday
        {
            get => _tuesday;
            set => SetProperty(ref _tuesday, value);
        }

        private string _wednesday;
        /// <summary>
        /// Get or Set for {wednesday}.
        /// </summary>
        [DataMember]
        [Required]
        public string Wednesday
        {
            get => _wednesday;
            set => SetProperty(ref _wednesday, value);
        }
        private string _thursday;
        /// <summary>
        /// Get or Set for {thursday}.
        /// </summary>
        [DataMember]
        [Required]
        public string Thursday
        {
            get => _thursday;
            set => SetProperty(ref _thursday, value);
        }
        private string _friday;
        /// <summary>
        /// Get or Set for {friday}.
        /// </summary>
        [DataMember]
        [Required]
        public string Friday
        {
            get => _friday;
            set => SetProperty(ref _friday, value);
        }

        private string _saturday;
        /// <summary>
        /// Get or Set for {Saturday}.
        /// </summary>
        [DataMember]
        [Required]
        public string Saturday
        {
            get => _saturday;
            set => SetProperty(ref _saturday, value);
        }

        private string _sunday;
        /// <summary>
        /// Get or Set for {sunday}.
        /// </summary>
        [DataMember]
        [Required]
        public string Sunday
        {
            get => _sunday;
            set => SetProperty(ref _sunday, value);
        }

        private string _wMSSiteCode;
        /// <summary>
        /// Get or Set for {WMSSiteCode}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string WMSSiteCode
        {
            get => _wMSSiteCode;
            set => SetProperty(ref _wMSSiteCode, value);
        }

        private Int16 _syncToWMS;
        /// <summary>
        /// Get or Set for {SyncToWMS}.
        /// </summary>
        [DataMember]

        public Int16 SyncToWMS
        {
            get => _syncToWMS;
            set => SetProperty(ref _syncToWMS, value);
        }


        private int _pullWMSStatus;
        /// <summary>
        /// Get or Set for {PullWMSStatus}.
        /// </summary>
        [DataMember]
        
        public int PullWMSStatus
        {
            get => _pullWMSStatus;
            set => SetProperty(ref _pullWMSStatus, value);
        }

        private DateTime _lastH1SyncTime;
        /// <summary>
        /// Get or Set for {LastH1SyncTime}.
        /// </summary>
        [DataMember]       
        public DateTime LastH1SyncTime
        {
            get => _lastH1SyncTime;
            set => SetProperty(ref _lastH1SyncTime, value);
        }
    }

    public class DataSyncFunctionDropDownModel : BaseModel<Guid>
    {
        private string _dataSyncFunctionName;
        /// <summary>
        /// Data Sync Function
        /// </summary>
        [DataMember]
        [StringLength(200)]
        public string DataSyncFunctionName
        {
            get => _dataSyncFunctionName;
            set => SetProperty(ref _dataSyncFunctionName, value);
        }

    }
    [DataContract, Serializable]
    public class FinanceParameterSettingsModel : BaseModel<Guid>
     {
         private string _parameterKey;
         [DataMember]
         [Required]
         [StringLength(100)]
         public string ParameterKey
         {
             get => _parameterKey;
             set => SetProperty(ref _parameterKey, value);
         }

         private string _parameterDescription;
         [DataMember]
         [Required]
         [StringLength(250)]
         public string ParameterDescription
         {
             get => _parameterDescription;
             set => SetProperty(ref _parameterDescription, value);
         }
         private string _parameterValue1;
         [DataMember]
         [Required]
         [StringLength(100)]
         public string ParameterValue1
         {
             get => _parameterValue1;
             set => SetProperty(ref _parameterValue1, value);
         }

         private string _parameterValue2;
         [DataMember]
         [Required]
         [StringLength(100)]
         public string ParameterValue2
         {
             get => _parameterValue2;
             set => SetProperty(ref _parameterValue2, value);
         }
         private string _parameterValue3;
         [DataMember]
         [Required]
         [StringLength(100)]
         public string ParameterValue3
         {
             get => _parameterValue3;
             set => SetProperty(ref _parameterValue3, value);
         }
         private string _parameterValue4;
         [DataMember]
         [Required]
         [StringLength(100)]
         public string ParameterValue4
         {
             get => _parameterValue4;
             set => SetProperty(ref _parameterValue4, value);
         }
         private string _parameterValue5;
         [DataMember]
         [Required]
         [StringLength(100)]
         public string ParameterValue5
         {
             get => _parameterValue5;
             set => SetProperty(ref _parameterValue5, value);
         }
     }

    [DataContract, Serializable]
    public class FinanceDataSyncCalendarModel : BaseModel<Guid>
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

    [DataContract, Serializable]
    public class H1FinanceDataSyncLogModel : BaseModel<Guid>
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


        private Guid? _financeDataSyncCalendarGuid;
        /// <summary>
        /// Get or Set for {SupplyPlanningDataSyncCalendarGuid}.
        /// </summary>
        [DataMember]
        public Guid? FinanceDataSyncCalendarGuid
        {
            get => _financeDataSyncCalendarGuid;
            set => SetProperty(ref _financeDataSyncCalendarGuid, value);
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











