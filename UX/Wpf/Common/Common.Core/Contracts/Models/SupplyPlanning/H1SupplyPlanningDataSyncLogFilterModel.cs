/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   H1SupplyPlanningDataSyncFilterModel.cs
Function           :   Retrieve data on the basis of filters for H1SupplyPlanningDataSyncLog
Created By         :   Shivam Dhingra
Created on         :   16-June-2020
Revision History   :   [30-June-2020] : Shivam Dhingra 
                   :   [16-Jun-2020] : Added new filter value SourceTableName

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
    /// Data Contract for H1SupplyPlanningDataSyncFilterModel
    /// </summary>
    [DataContract, Serializable]
    public class H1SupplyPlanningDataSyncLogFilterModel : BaseModel<Guid>
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



    }
}
