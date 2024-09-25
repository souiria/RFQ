/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplyPlanningDataSyncConfigurationSetupModel.cs
Function           :   Data Contract for Supply Planning Data Sync & Configuration Setup Model
Created By         :   Pawan
Created on         :   03-Jun-2020
Revision History   :   [09-June-2020] : Srashti
*                  :   Added new properties {SynchronizationJobName},{SynchronizationSetupAtServer},{TimeZone},{Time},{ScheduleFrequency}       
*                  :   [11-June-2020] : Srashti
*                  :   Modified datatype of {TimeZone}
*                  :   [29-June-2020] : Shivam Dhingra
*                  :   Modified model as per requirement
*                  :   [03-Jul-2020] : Shivam Dhingra
*                  :   Added new field ScheduleFrequencyHours
*                  :   [11-Sep-2020] : Dharmendra
*                  :   Added new field ScheduleType
*                  :  [21-Sept-2020] : Yati Mathur
*                  :  Merged code from Service- Consolidation branch                   
*                  :  [19-Oct-2021] : Shivam Kalia
*                  :  Added new field H1WHCodeGuid
*                  :   [01-Nov-2021] : Shivam Dhingra
*                  :   Added new fields and modified old ones as per new requirements
*                  :   [08-Nov-2021] : Shivam Dhingra
*                  :   Made WeekDay fields nullable
*                  :   [13-Dec-2023]: Piyush Anand
                   :   [HD-00401275] Convert Properties Datatype due to changes in statefull to stateless services. 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract for Data Synchronization Configuration Setup
    /// </summary>
    [DataContract, Serializable]
    public class SupplyPlanningDataSyncConfigurationSetupModel : BaseModel<Guid>
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

        //private DateTime _lastSynchronizeAttemptedTimeStamp;
        ///// <summary>
        ///// Get or Set for {LastSynchronizeAttemptedTimeStamp}.
        ///// </summary>
        //[DataMember]
        //public DateTime LastSynchronizeAttemptedTimeStamp
        //{
        //    get => _lastSynchronizeAttemptedTimeStamp;
        //    set => SetProperty(ref _lastSynchronizeAttemptedTimeStamp, value);
        //}

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

        //private DateTime _jobStartTime;
        ///// <summary>
        ///// Get or Set for {Time}.
        ///// </summary>
        //[DataMember,DataType(DataType.Time)]
        //[Required]
        //public DateTime JobStartTime
        //{
        //    get => _jobStartTime;
        //    set => SetProperty(ref _jobStartTime, value);
        //}

        //private string _scheduleFrequency;
        ///// <summary>
        ///// Get or Set for {ScheduleFrequency}.
        ///// </summary>
        //[DataMember]
        //[StringLength(50)]
        //[Required]
        //public string ScheduleFrequency
        //{
        //    get => _scheduleFrequency;
        //    set => SetProperty(ref _scheduleFrequency, value);
        //}

        //private int _scheduleFrequencyHours = 0;
        ///// <summary>
        ///// Get or Set for {ScheduleFrequencyHours}
        ///// </summary>
        //[DataMember]
        //[Required]
        //public int ScheduleFrequencyHours
        //{
        //    get => _scheduleFrequencyHours;
        //    set => SetProperty(ref _scheduleFrequencyHours, value);
        //}
        //private Guid _wMSSiteGuid;
        ///// <summary>
        ///// Get or Set for {WMSSiteCode}.
        ///// </summary>
        //[DataMember]
        //public Guid WMSSiteGuid
        //{
        //    get => _wMSSiteGuid;
        //    set => SetProperty(ref _wMSSiteGuid, value);
        //}
        //private string _scheduleType;
        ///// <summary>
        ///// Get or Set for {ScheduleType}.
        ///// </summary>
        //[DataMember]
        //[StringLength(12)]
        //public string ScheduleType
        //{
        //    get => _scheduleType;
        //    set => SetProperty(ref _scheduleType, value);
        //}

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
    }
}
