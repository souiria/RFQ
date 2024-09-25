/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplyPlanningDataSyncCalendarFilterModel.cs
Function           :   Retrieve data on the basis of filters for SupplyPlanningDataSyncCalendar
Created By         :   Shivam Dhingra
Created on         :   25-June-2020
Revision History   :  [26-June-2020] : Shivam Dhingra
*                  :  Added class to call procedure with parameters
*                  :  [01-Sept-2020] : Srashti Gupta
*                  :  Added new properties in {SupplyplanningdataSyncCalendarProcedureParametersModel}
*                  :  [09-Sept-2020] : Shivam Dhingra
*                  :  Added new properties in {SupplyplanningdataSyncCalendarProcedureParametersModel}
*                  :  [09-Sept-2020] : Shivam Dhingra
*                  :  Modified properties to nullable
*                  :  [21-Sept-2020] : Yati Mathur
*                  :  Merged code from Service- Consolidation branch    
*                  :  [07-Oct-2020] : Srashti
*                  :  Added new properties in {DataSynchronizationGuid}
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract for H1SupplyPlanningDataSyncFilterModel
    /// </summary>
    [DataContract, Serializable]
   public class SupplyPlanningDataSyncCalendarFilterModel : BaseModel<Guid>
    {
       
        private string _sourceLocation;
        /// <summary>
        /// Get or Set for {SourceLocation}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string SourceLocation
        {
            get => _sourceLocation;
            set => SetProperty(ref _sourceLocation, value);
        }

       
        private string _sourceLocationTable;
        /// <summary>
        /// Get or Set for {SourceLocationTable}.
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string SourceLocationTable
        {
            get => _sourceLocationTable;
            set => SetProperty(ref _sourceLocationTable, value);
        }


        private DateTime _scheduleDateTimeStampInLocalFrom;
        /// <summary>
        /// Get or Set for {ScheduleDateTimeStampInLocalFrom}.
        /// </summary>
        [DataMember]
        public DateTime ScheduleDateTimeStampInLocalFrom
        {
            get => _scheduleDateTimeStampInLocalFrom;
            set => SetProperty(ref _scheduleDateTimeStampInLocalFrom, value);
        }

        private DateTime _scheduleDateTimeStampInLocalTo;
        /// <summary>
        /// Get or Set for {ScheduleDateTimeStampInLocalTo}.
        /// </summary>
        [DataMember]
        public DateTime ScheduleDateTimeStampInLocalTo
        {
            get => _scheduleDateTimeStampInLocalTo;
            set => SetProperty(ref _scheduleDateTimeStampInLocalTo, value);
        }


    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract, Serializable]
    public class supplyplanningdataSyncCalendarProcedureParametersModel : BaseModel<Guid>
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

        private Guid _dataSynchronizationGuid;
        /// <summary>
        /// Data Sync Guid
        /// </summary>
        [DataMember]
        public Guid DataSynchronizationGuid
        {
            get => _dataSynchronizationGuid;
            set => SetProperty(ref _dataSynchronizationGuid, value);
        }

        private string _sourceTableName;
        /// <summary>
        /// Source Table Name
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string SourceTableName
        {
            get => _sourceTableName;
            set => SetProperty(ref _sourceTableName, value);
        }

        private Guid _userId;
        /// <summary>
        /// UserId
        /// </summary>
        [DataMember]
        public Guid UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private string _scheduleType;
        /// <summary>
        /// Source Table Name
        /// </summary>
        [DataMember]
        [StringLength(12)]
        public string ScheduleType
        {
            get => _scheduleType;
            set => SetProperty(ref _scheduleType, value);
        }

        private DateTime? _oneTimeStartTime;
        /// <summary>
        /// Job Start Time
        /// </summary>
        [DataMember,DataType(DataType.Time)]
        
        public DateTime? OneTimeStartTime
        {
            get => _oneTimeStartTime;
            set => SetProperty(ref _oneTimeStartTime, value);
        }


        private string _frequencyOccurs;
        /// <summary>
        /// Source Table Name
        /// </summary>
        [DataMember]
        [StringLength(12)]
        public string FrequencyOccurs
        {
            get => _frequencyOccurs;
            set => SetProperty(ref _frequencyOccurs, value);
        }


        

        private int? _frequencyRecurrsEvery;
        /// <summary>
        /// Job Start Time
        /// </summary>
        [DataMember]
        public int? FrequencyRecurrsEvery
        {
            get => _frequencyRecurrsEvery;
            set => SetProperty(ref _frequencyRecurrsEvery, value);
        }


        


        private string _frequencyWeekdays;
        /// <summary>
        /// Source Table Name
        /// </summary>
        [DataMember]
        [StringLength(8000)]
        public string FrequencyWeekdays
        {
            get => _frequencyWeekdays;
            set => SetProperty(ref _frequencyWeekdays, value);
        }


        private int? _frequencyMonthlyDays;
        /// <summary>
        /// Job Start Time
        /// </summary>
        [DataMember]
        public int? FrequencyMonthlyDays
        {
            get => _frequencyMonthlyDays;
            set => SetProperty(ref _frequencyMonthlyDays, value);
        }

        private int? _frequencyEveryMonths;
        /// <summary>
        /// Job Start Time
        /// </summary>
        [DataMember]
        public int? FrequencyEveryMonths
        {
            get => _frequencyEveryMonths;
            set => SetProperty(ref _frequencyEveryMonths, value);
        }


        private string _frequencyMonthWeekDay;
        /// <summary>
        /// Source Table Name
        /// </summary>
        [DataMember]
        [StringLength(15)]
        public string FrequencyMonthWeekDay
        {
            get => _frequencyMonthWeekDay;
            set => SetProperty(ref _frequencyMonthWeekDay, value);
        }

        private DateTime? _dailyFrequencyOccursOnce;
        /// <summary>
        /// Job Start Time
        /// </summary>
        [DataMember, DataType(DataType.Time)]

        public DateTime? DailyFrequencyOccursOnce
        {
            get => _dailyFrequencyOccursOnce;
            set => SetProperty(ref _dailyFrequencyOccursOnce, value);
        }

        private int? _dailyFrequencyOccursEvery;
        /// <summary>
        /// Job Start Time
        /// </summary>
        [DataMember]
        public int? DailyFrequencyOccursEvery
        {
            get => _dailyFrequencyOccursEvery;
            set => SetProperty(ref _dailyFrequencyOccursEvery, value);
        }


        private DateTime? _dailyFrequencyStartTime;
        /// <summary>
        /// Job Start Time
        /// </summary>
        [DataMember, DataType(DataType.Time)]

        public DateTime? DailyFrequencyStartTime
        {
            get => _dailyFrequencyStartTime;
            set => SetProperty(ref _dailyFrequencyStartTime, value);
        }

        private DateTime? _dailyFrequencyEndTime;
        /// <summary>
        /// Job Start Time
        /// </summary>
        [DataMember, DataType(DataType.Time)]

        public DateTime? DailyFrequencyEndTime
        {
            get => _dailyFrequencyEndTime;
            set => SetProperty(ref _dailyFrequencyEndTime, value);
        }


        private string _dailyFrequencyType;
        /// <summary>
        /// Source Table Name
        /// </summary>
        [DataMember]
        [StringLength(15)]
        public string DailyFrequencyType
        {
            get => _dailyFrequencyType;
            set => SetProperty(ref _dailyFrequencyType, value);
        }



        private DateTime? _scheduleStartDate;
        /// <summary>
        /// Job Start Time
        /// </summary>
        [DataMember]
        public DateTime? ScheduleStartDate
        {
            get => _scheduleStartDate;
            set => SetProperty(ref _scheduleStartDate, value);
        }


        private DateTime? _scheduleFinishDate;
        /// <summary>
        /// Job Start Time
        /// </summary>
        [DataMember]
        public DateTime? ScheduleFinishDate
        {
            get => _scheduleFinishDate;
            set => SetProperty(ref _scheduleFinishDate, value);
        }




        private string _noEndDate;
        /// <summary>
        /// Source Table Name
        /// </summary>
        [DataMember]
        [StringLength(10)]
        public string NoEndDate
        {
            get => _noEndDate;
            set => SetProperty(ref _noEndDate, value);
        }


        private string _description;
        /// <summary>
        /// Source Table Name
        /// </summary>
        [DataMember]
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        






        //private DateTime _jobStartTime;
        ///// <summary>
        ///// Job Start Time
        ///// </summary>
        //[DataMember]
        //public DateTime JobStartTime
        //{
        //    get => _jobStartTime;
        //    set => SetProperty(ref _jobStartTime, value);
        //}

        //private string _scheduleFrequency;
        ///// <summary>
        ///// Schedule Frequency
        ///// </summary>
        //[DataMember]
        //[StringLength(50)]
        //public string ScheduleFrequency
        //{
        //    get => _scheduleFrequency;
        //    set => SetProperty(ref _scheduleFrequency, value);
        //}

        //private int _scheduleFrequencyHours;
        ///// <summary>
        ///// Schedule Frequency Hours
        ///// </summary>
        //[DataMember]
        //public int ScheduleFrequencyHours
        //{
        //    get => _scheduleFrequencyHours;
        //    set => SetProperty(ref _scheduleFrequencyHours, value);
        //}

        //private DateTime _scheduleDateFrom;
        ///// <summary>
        ///// Schedule Date From
        ///// </summary>
        //[DataMember]
        //public DateTime ScheduleDateFrom
        //{
        //    get => _scheduleDateFrom;
        //    set => SetProperty(ref _scheduleDateFrom, value);
        //}

        //private DateTime _scheduleDateTo;
        ///// <summary>
        ///// Schedule Date To
        ///// </summary>
        //[DataMember]
        //public DateTime ScheduleDateTo
        //{
        //    get => _scheduleDateTo;
        //    set => SetProperty(ref _scheduleDateTo, value);
        //}

    }
}
