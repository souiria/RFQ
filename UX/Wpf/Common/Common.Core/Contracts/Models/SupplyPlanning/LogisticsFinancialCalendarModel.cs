/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   LogisticsFinancialCalendarModel.cs
Function           :   Logistics Financial Calendar
Created By         :   Shivam Dhingra
Created on         :   21-Oct-2020
Revision History   :   [25-Jan-2023] : Mayur Pawar
*                  :   [ ] : Added LogisticsFinancialCalendarModelparam Class and LogisticsFinancialCalendarStatelessModel Class HD call no:00363433 


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
    /// Data Contract use for LogisticsFinancialCalendar Service
    /// </summary>
    [DataContract, Serializable]
    public class LogisticsFinancialCalendarModel : BaseModel<Guid>
    {
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
    }

    public class LogisticsFinancialCalendarStatelessModel //mayur
    {
        private int _planYear;
        /// <summary>
        /// Get or Set for {PlanYear}.
        /// </summary>
        [DataMember]
        [Required]
        public int PlanYear
        {
            get => _planYear;
            set => _planYear = value;
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
            set => _weekStartDate = value;
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
            set =>  _weekEndDate = value;
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
            set =>  _weekNumber = value;
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
            set =>  _weekMonth = value;
        }
    }

    public class LogisticsFinancialCalendarModelparam
    {
        private Guid _userGuid;
        /// <summary>
        /// Get or Set for {WeekMonth}.
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }

        private int _isAdhoc;
        /// <summary>
        /// Get or Set for {WeekMonth}.
        /// </summary>
        [DataMember]

        public int IsAdhoc
        {
            get => _isAdhoc;
            set => _isAdhoc = value;
        }
    }
}
