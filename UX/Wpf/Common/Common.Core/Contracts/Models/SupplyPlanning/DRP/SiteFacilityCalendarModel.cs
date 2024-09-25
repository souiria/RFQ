/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SiteFacilityCalendarModel.cs
Function           :   Site Facility Calendar
Created By         :   Shivam Dhingra
Created on         :   18-Nov-2020
Revision History   :   [18-Nov-2020] : Shivam Dhingra
                   :   Modified column ManufacturingSite to ManufacturingSiteGuid and added field ShiftCount
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning.DRP
{
    /// <summary>
    /// Data Contract for Site Facility Calendar
    /// </summary>
    [DataContract, Serializable]
    public class SiteFacilityCalendarModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local Reference for ManufacturingSiteGuid
        /// </summary>
        private Guid _manufacturingSiteGuid;
        /// <summary>
        /// Get or Set for {ManufacturingSiteGuid}.
        /// This Guid refers to BusinessUnitGuid
        /// </summary>
        [DataMember]
        [Required]
        public Guid ManufacturingSiteGuid
        {
            get => _manufacturingSiteGuid;
            set => SetProperty(ref _manufacturingSiteGuid, value);
        }

        /// <summary>
        /// Local Reference for FacilityName
        /// </summary>
        private string _facilityName;
        /// <summary>
        /// Get or Set for {FacilityName}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        [Required]
        public string FacilityName
        {
            get => _facilityName;
            set => SetProperty(ref _facilityName, value);
        }

        /// <summary>
        /// Local Reference for CalendarDate
        /// </summary>
        private DateTime _calendarDate;
        /// <summary>
        /// Get or Set for {CalendarDate}.
        /// </summary>
        [DataMember]
        public DateTime CalendarDate
        {
            get => _calendarDate;
            set => SetProperty(ref _calendarDate, value);
        }

        /// <summary>
        /// Local Reference for IsHoliday
        /// </summary>
        private bool _isHoliday;
        /// <summary>
        /// Get or Set for {IsHoliday}.
        /// </summary>
        [DataMember]
        public bool IsHoliday
        {
            get => _isHoliday;
            set => SetProperty(ref _isHoliday, value);
        }

        /// <summary>
        /// Local Reference for GPTCHours
        /// </summary>
        private decimal _gptcHours;
        /// <summary>
        /// Get or set for {GPTCHours}
        /// </summary>
        [DataMember]
        [DecimalPrecision(5, 2)]
        public decimal GPTCHours
        {
            get => _gptcHours;
            set => SetProperty(ref _gptcHours, value);
        }

        /// <summary>
        /// Local Reference for WorkingHours
        /// </summary>
        private decimal _workingHours;
        /// <summary>
        /// Get or set for {WorkingHours}
        /// </summary>
        [DataMember]
        [DecimalPrecision(5, 2)]
        public decimal WorkingHours
        {
            get => _workingHours;
            set => SetProperty(ref _workingHours, value);
        }

        /// <summary>
        /// Local Reference for ShiftCount
        /// </summary>
        private short _shiftCount = 3;
        /// <summary>
        /// Get or set for {ShiftCount}
        /// </summary>
        [DataMember]
        [Required]
        public short ShiftCount
        {
            get => _shiftCount;
            set => SetProperty(ref _shiftCount, value);
        }

    }
}
