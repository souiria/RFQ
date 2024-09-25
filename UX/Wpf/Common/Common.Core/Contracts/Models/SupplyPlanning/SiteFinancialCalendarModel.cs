/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SiteFinancialCalendarModel.cs
Function           :   Site Financial Calendar
Created By         :   Srashti Gupta
Created on         :   21-Oct-2020
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Obsolete - Data Contract use for SiteProductionCalendarModel Service
    /// </summary>
    [DataContract, Serializable]
    public class SiteFinancialCalendarModel : BaseModel<Guid>
    {
        private Guid _businessUnitGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private DateTime _weekStartDate;
        /// <summary>
        /// Get or Set for {WeekStartDate}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime WeekStartDate
        {
            get => _weekStartDate;
            set => SetProperty(ref _weekStartDate, value);
        }

        private int _weekNumber;
        /// <summary>
        /// Get or Set for {WeekNumber}.
        /// </summary>
        [DataMember]
        [Required]
        public int WeekNumber
        {
            get => _weekNumber;
            set => SetProperty(ref _weekNumber, value);
        }

        private string _weekMonth;
        /// <summary>
        /// Get or Set for {WeekMonth}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(15)]
        public string WeekMonth
        {
            get => _weekMonth;
            set => SetProperty(ref _weekMonth, value);
        }

        private DateTime _weekEndDate;
        /// <summary>
        /// Get or Set for {WeekEndDate}.
        /// </summary>
        [DataMember]
        [Required]
        public DateTime WeekEndDate
        {
            get => _weekEndDate;
            set => SetProperty(ref _weekEndDate, value);
        }

        private int _weekStartDay;
        /// <summary>
        /// Get or Set for {WeekStartDay}.
        /// </summary>
        [DataMember]
        [Required]
        public int WeekStartDay
        {
            get => _weekStartDay;
            set => SetProperty(ref _weekStartDay, value);
        }

        private string _workingNonWorking;
        /// <summary>
        /// Get or Set for {WorkingNonWorking}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(7)]
        public string WorkingNonWorking
        {
            get => _workingNonWorking;
            set => SetProperty(ref _workingNonWorking, value);
        }

        private int _planYear;
        /// <summary>
        /// Get or Set for {PlanYear}.
        /// </summary>
        [DataMember]
        [Required]
        public int PlanYear
        {
            get => _planYear;
            set => SetProperty(ref _planYear, value);
        }
    }
}
