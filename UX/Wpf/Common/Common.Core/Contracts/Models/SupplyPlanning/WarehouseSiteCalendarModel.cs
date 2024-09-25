/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WarehouseSiteCalendarModel.cs
Function           :   Warehouse Site Calendar
Created By         :   Srashti Gupta
Created on         :   25-Nov-2020
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for Warehouse Site Calendar
    /// </summary>
    [DataContract, Serializable]
    public class WarehouseSiteCalendarModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _businessUnitGuid     
        /// </summary>
        private Guid _businessUnitGuid;
        /// <summary>
        /// Get or Set for {Warehouse Site Guid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        /// <summary>
        /// Local variable _calendarDate     
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
        /// Local variable _warehouseSiteHolidayFlag     
        /// </summary>
        private bool _warehouseSiteHolidayFlag;
        /// <summary>
        /// Get or Set for {WarehouseSiteHolidayFlag}.
        /// </summary>
        [DataMember]
        public bool WarehouseSiteHolidayFlag
        {
            get => _warehouseSiteHolidayFlag;
            set => SetProperty(ref _warehouseSiteHolidayFlag, value);
        }
    }
}
