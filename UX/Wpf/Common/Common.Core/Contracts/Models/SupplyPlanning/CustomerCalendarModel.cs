/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerCalendarModel.cs
Function           :   Customer Calendar
Created By         :   Shivam Dhingra
Created on         :   28-Oct-2020
Revision History   :   [12-Oct-2021] : Shahab
                   :   [] : Modified to CustomerDeliveryPointGuid
                   :   [17-Dec-2021] : Shivam Dhingra
                   :   [] : Added new column WeekMonth
                   :   [05-Jan-2023] : Ranjay
                   :   []: Added new column PlanYear
                   :   [25-Jan-2023] : Ranjay
                   :   []: Added new class CustomerCalendarFilterModel,GetCustomerCalendarReplicationStatusModel and modified CustomerCalendarModel
                   :   [29-Jan-2024] : Prakhar
                   :   [HD-00394058]: Added new property ViewNamein CustomerCalendarModel,CustomerCalendarFilterModel,CustomerCalendarReplicationModel and CustomerCalendarShowDataModel
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

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for Customer Calendar
    /// </summary>
    [DataContract, Serializable]
    public class CustomerCalendarModel : BaseModel<Guid>
    {
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        public string CustomerName
        {
            get { return _customerName; }
            set { SetProperty(ref _customerName, value); }
        }
        /// <summary>
        /// Local variable _CustomerDeliveryPoint     
        /// </summary>
        private string _CustomerDeliveryPoint;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPoint}.
        /// </summary>
        public string CustomerDeliveryPoint
        {
            get { return _CustomerDeliveryPoint; }
            set { SetProperty(ref _CustomerDeliveryPoint, value); }
        }
        /// <summary>
        /// Local variable _weekNumber     
        /// </summary>
        private int _weekNumber;
        /// <summary>
        /// Get or Set for {WeekNumber}.
        /// </summary>
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
        private string _weekDay;
        public string WeekDay
        {
            get { return _weekDay; }
            set { SetProperty(ref _weekDay, value); }
        }
        /// <summary>
        /// Local variable _customerHolidayFlag     
        /// </summary>
        private bool _customerHolidayFlag;
        /// <summary>
        /// Get or Set for {CustomerHolidayFlag}.
        /// </summary>
        [DataMember]
        public bool CustomerHolidayFlag
        {
            get => _customerHolidayFlag;
            set => SetProperty(ref _customerHolidayFlag, value);
        }

        private string _viewName;
        [DataMember]
        public string ViewName
        {
            get { return _viewName; }
            set { SetProperty(ref _viewName, value); }
        }

    }

    [DataContract, Serializable]
    public class CustomerCalendarShowDataModel
    {
        /// <summary>
        /// Local variable _id     
        /// </summary>
        private Guid _id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        /// <summary>
        /// Local variable _customerName     
        /// </summary>
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        /// <summary>
        /// Local variable _CustomerDeliveryPoint     
        /// </summary>
        private string _CustomerDeliveryPoint;
        /// <summary>
        /// Get or Set for {CustomerDeliveryPoint}.
        /// </summary>
        [DataMember]
        public string CustomerDeliveryPoint
        {
            get { return _CustomerDeliveryPoint; }
            set { _CustomerDeliveryPoint = value; }
        }
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
            set { _weekNumber = value; }
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
            set => _weekMonth = value;
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
            set => _planYear = value;
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
            set => _calendarDate = value;
        }
        private string _weekDay;
        /// <summary>
        /// Get or Set for {WeekDay}.
        /// </summary>
        [DataMember]
        public string WeekDay
        {
            get { return _weekDay; }
            set { _weekDay = value; }
        }
        /// <summary>
        /// Local variable _customerHolidayFlag     
        /// </summary>
        private bool _customerHolidayFlag;
        /// <summary>
        /// Get or Set for {CustomerHolidayFlag}.
        /// </summary>
        [DataMember]
        public bool CustomerHolidayFlag
        {
            get => _customerHolidayFlag;
            set => _customerHolidayFlag = value;
        }
        private string _error;
        [DataMember]
        public string Error
        {
            get => _error;
            set => _error = value;
        }
    }

    /// <summary>
    /// Data Contract use for Customer Calendar Filter
    /// </summary>
    [DataContract, Serializable]
    public class CustomerCalendarFilterModel
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
        /// Local variable _CustomerDeliveryPointGuid     
        /// </summary>
        private Guid? _CustomerDeliveryPointGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid? CustomerDeliveryPointGuid
        {
            get => _CustomerDeliveryPointGuid;
            set => _CustomerDeliveryPointGuid = value;
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
        private string _viewName;
        [DataMember]
        public string ViewName
        {
            get => _viewName;
            set => _viewName = value;
        }
    }

    /// <summary>
    /// Data Contract use for Save Customer Calendar Replication
    /// </summary>
    [DataContract, Serializable]
    public class CustomerCalendarReplicationModel
    {
        /// <summary>
        /// Local variable _fromCustomerGuid     
        /// </summary>
        private Guid _fromCustomerGuid;
        /// <summary>
        /// Get or Set for {FromCustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid FromCustomerGuid
        {
            get => _fromCustomerGuid;
            set => _fromCustomerGuid = value;
        }

        /// <summary>
        /// Local variable _fromCustomerDeliveryPointGuid     
        /// </summary>
        private Guid _fromCustomerDeliveryPointGuid;
        /// <summary>
        /// Get or Set for {FromCustomerDeliveryPointGuid}.
        /// </summary>
        [DataMember]
        public Guid FromCustomerDeliveryPointGuid
        {
            get => _fromCustomerDeliveryPointGuid;
            set => _fromCustomerDeliveryPointGuid = value;
        }

        /// <summary>
        /// Local variable _toCustomerGuid     
        /// </summary>
        private Guid _toCustomerGuid;
        /// <summary>
        /// Get or Set for {ToCustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid ToCustomerGuid
        {
            get => _toCustomerGuid;
            set => _toCustomerGuid = value;
        }

        /// <summary>
        /// Local variable _toCustomerDeliveryPointGuid     
        /// </summary>
        private Guid _toCustomerDeliveryPointGuid;
        /// <summary>
        /// Get or Set for {ToCustomerDeliveryPointGuid}.
        /// </summary>
        [DataMember]
        public Guid ToCustomerDeliveryPointGuid
        {
            get => _toCustomerDeliveryPointGuid;
            set => _toCustomerDeliveryPointGuid = value;
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

        /// <summary>
        /// Local variable _isAdhoc     
        /// </summary>
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
            get  => _viewName; 
            set => _viewName = value ; 
        }
    }


    /// <summary>
    /// Data Contract use for get Customer Calendar Replication status
    /// </summary>
    [DataContract, Serializable]
    public class GetCustomerCalendarReplicationStatusModel
    {
        /// <summary>
        /// Local variable _errorCode     
        /// </summary>
        private int _errorCode;
        /// <summary>
        /// Get or Set for {ErrorCode}.
        /// </summary>
        [DataMember]
        public int ErrorCode
        {
            get => _errorCode;
            set => _errorCode = value;
        }
        /// <summary>
        /// Local variable _returnMessage     
        /// </summary>
        private string _returnMessage;
        /// <summary>
        /// Get or Set for {ReturnMessage}.
        /// </summary>
        [DataMember]
        public string ReturnMessage
        {
            get => _returnMessage;
            set => _returnMessage = value;
        }
    }
}
