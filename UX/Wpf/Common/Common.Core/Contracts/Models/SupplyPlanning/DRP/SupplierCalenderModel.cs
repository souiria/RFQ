/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierCalendarModel.cs
Function           :   Supplier Calendar
Created By         :   Prakhar Singh
Created on         :   14-Feb-2023 [HDCall 00370357]
Revision History   :   [24-Aug-2023] : Prakhar
                   :   [] : Added model for SupplierCalendarCustomerHierarchyDropDownFilterModel and SupplierCalendarCustomerBusinessHierarchyDropDownModel
                   :   [29-Jan-2024] : Prakhar
                   :   [HD-00394058]: Added new property ViewName in SupplierCalendarFilterModel and SupplierCalendarModel
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning.DRP
{
    /// <summary>
    /// Data Contract use for Supplier Calendar
    /// </summary>
    [DataContract, Serializable]
    public class SupplierCalendarModel : BaseModel<Guid>
    {     
        /// <summary>
        /// Local variable _weekNumber     
        /// </summary>
        private int _weekNumber;
        /// <summary>
        /// Get or Set for {WeekNumber}.
        /// </summary>
        [DataMember]
        public int WeekNumber
        {
            get { return _weekNumber; }
            set { SetProperty(ref _weekNumber, value); }
        }
        /// <summary>
        /// Local variable _weekMonth     
        /// </summary>
        private string _weekMonth;
        /// <summary>
        /// Get or Set for {WeekMonth}.
        /// </summary>
        [DataMember]

        [StringLength(15)]
        public string WeekMonth
        {
            get => _weekMonth;
            set => SetProperty(ref _weekMonth, value);
        }
        /// <summary>
        /// Local variable _planYear     
        /// </summary>
        private int _planYear;
        /// <summary>
        /// Get or Set for {PlanYear}.
        /// </summary>
        [DataMember]
        public int PlanYear
        {
            get => _planYear;
            set => SetProperty(ref _planYear, value);
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

        /// Get or Set for {WeekDayName}.
        private string _weekDayName;

        [DataMember]
        public string WeekDayName
        {
            get { return _weekDayName; }
            set { SetProperty(ref _weekDayName, value); }
        }
        /// <summary>
        /// Local variable _customerHolidayFlag     
        /// </summary>
        private bool _supplierHolidayFlag;
        /// <summary>
        /// Get or Set for {CustomerHolidayFlag}.
        /// </summary>
        [DataMember]
        public bool SupplierHolidayFlag
        {
            get => _supplierHolidayFlag;
            set => SetProperty(ref _supplierHolidayFlag, value);
        }

        private Guid _manufacturingSiteGuid;
        /// <summary>
        /// Get or Set for {ManufacturingSiteGuid}.
        /// </summary>
        [DataMember]
        public Guid ManufacturingSiteGuid
        {
            get => _manufacturingSiteGuid;
            set => SetProperty(ref _manufacturingSiteGuid, value);
        }

        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }

        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => SetProperty(ref _customerBusinessGroupGuid, value);
        }

        //private string _oldWeekMonth;
        //[DataMember]
        //public string OldWeekMonth
        //{
        //    get { return _oldWeekMonth; }
        //    set { SetProperty(ref _oldWeekMonth, value); }
        //}
       

        private string _viewName;
        [NotMapped, DataMember]
        public string ViewName
        {
            get => _viewName;
            set => SetProperty(ref _viewName, value);
        }

    }

    [DataContract, Serializable]
    public class SupplierCalendarFilterModel
    {
        /// <summary>
        /// Local variable _customerBusinessGroupGuid     
        /// </summary>
        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => _customerBusinessGroupGuid = value;
        }

        /// <summary>
        /// Local variable _customerName     
        /// </summary>
        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }

        /// <summary>
        /// Local variable _ManufacturingSiteGuid    
        /// </summary>
        private Guid _manufacturingSiteGuid;
        /// <summary>
        /// Get or Set for {ManufacturingSiteGuid}.
        /// </summary>
        [DataMember]
        public Guid ManufacturingSiteGuid
        {
            get => _manufacturingSiteGuid;
            set => _manufacturingSiteGuid = value;
        }

        /// <summary>
        /// Local variable _userGuid     
        /// </summary>
        private Guid _userGuid;
        /// <summary>
        /// Get or Set for {UserGuid}.
        /// </summary>
        [DataMember]
        public Guid UserGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }

        private int _isAdhoc;
        /// <summary>
        /// Get or Set for {IsAdhoc}.
        /// </summary>
        [DataMember]

        public int IsAdhoc
        {
            get => _isAdhoc;
            set => _isAdhoc = value;
        }
        private string _viewName;
        [DataMember]
        public string ViewName
        {
            get => _viewName;
            set => _viewName = value;
        }
    }

    [DataContract, Serializable]
    public class SupplierCalendarCustomerBuisnessHierarchyDropDownFilterModel
    {
        private Guid _id;
        /// <summary>
        /// _id
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        private string _customerBusinessGroupName;
        /// <summary>
        /// ManufacturingSiteGuid
        /// </summary>
        [DataMember]
        public string CustomerBusinessGroupName
        {
            get => _customerBusinessGroupName;
            set => _customerBusinessGroupName = value;
        }

        private string _customerBusinessGroupCode;
        /// <summary>
        /// ManufacturingSiteGuid
        /// </summary>
        [DataMember]
        public string CustomerBusinessGroupCode
        {
            get => _customerBusinessGroupCode;
            set => _customerBusinessGroupCode = value;
        }
    }

  
    [DataContract, Serializable]
    public class SupplierCalendarCustomerHierarchyDropDownModel
    {
        private Guid _id;
        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        private string _customerCode;
        /// <summary>
        /// CustomerCode
        /// </summary>
        /// <example>
        /// HTR, HUM, Renault_Fr, Renault_Tr, PSA_POISSY, PSA_MADRID, TMMR, TMMT
        /// </example>
        [DataMember]
        public string CustomerCode
        {
            get => _customerCode;
            set => _customerCode = value;
        }

        private string _customerName;
        /// <summary>
        /// CustomerName
        /// </summary>
        /// <example>
        /// Honda Turkey, Honda UK, Renault France, Renault Turkey, PSA Poissy, PSA Madrid, Toyota Russia
        /// </example>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }
    }

}
