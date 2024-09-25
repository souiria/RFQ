/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CurrencyAndForeignExchangeSyncLogModel.cs
Function           :   Currency And Foreign Exchange Sync Log
Created By         :   Shivam Dhingra 
Created on         :   26-Nov-2020
Revision History   :   [26-Nov-2020] : Shivam Dhingra
                   :   [] : Inherit BaseModel
                   :   [09-Nov-2021] : Shivam Kalia
                   :   [] : Added new fields CurrentTodayXRateInDHS,TodayXRate,TomorrowXrate and CurrentTomorrowXRateInDHS
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    /// <summary>
    /// DataContract for CurrencyAndForeignExchangeSyncLogModel
    /// </summary>
    [DataContract, Serializable]
    public class CurrencyAndForeignExchangeSyncLogModel : BaseModel<Guid>
    {
        private string _countryName;
        /// <summary>
        /// get or set for CountryName
        /// </summary>
        [DataMember]
        public string CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }

        private string _syncToSite;
        /// <summary>
        /// get or set for SyncToSite
        /// </summary>
        [DataMember]
        public string SyncToSite
        {
            get { return _syncToSite; }
            set { _syncToSite = value; }
        }

        private string _baseCurrencyCode;
        /// <summary>
        /// get or set for BaseCurrencyCode
        /// </summary>
        [DataMember]
        public string BaseCurrencyCode
        {
            get { return _baseCurrencyCode; }
            set { _baseCurrencyCode = value; }
        }

        private string _currencyCode;
        /// <summary>
        /// get or set for CurrencyCode
        /// </summary>
        [DataMember]
        public string CurrencyCode
        {
            get { return _currencyCode; }
            set { _currencyCode = value; }
        }

        //private string _currencyTo;
        ///// <summary>
        ///// get or set for CurrencyTo
        ///// </summary>
        //[DataMember]
        //public string CurrencyTo
        //{
        //    get { return _currencyTo; }
        //    set { _currencyTo = value; }
        //}

        private decimal _todayXRateSync;
        /// <summary>
        /// get or set for TodayXRateSync
        /// </summary>
        [DataMember]
        public decimal TodayXRateSync
        {
            get { return _todayXRateSync; }
            set { _todayXRateSync = value; }
        }

        private decimal _tomorrowXRateSync;
        /// <summary>
        /// get or set for TomorrowXRateSync
        /// </summary>
        [DataMember]
        public decimal TomorrowXRateSync
        {
            get { return _tomorrowXRateSync; }
            set { _tomorrowXRateSync = value; }
        }

        private decimal _currentTodayXRateInDHS;
        /// <summary>
        /// get or set for CurrentTodayXRateInDHS
        /// </summary>
        [DataMember]
        public decimal CurrentTodayXRateInDHS
        {
            get { return _currentTodayXRateInDHS; }
            set { _currentTodayXRateInDHS = value; }
        }

        private decimal _currentTomorrowXRateInDHS;
        /// <summary>
        /// get or set for CurrentTomorrowXRateInDHS
        /// </summary>
        [DataMember]
        public decimal CurrentTomorrowXRateInDHS
        {
            get { return _currentTomorrowXRateInDHS; }
            set { _currentTomorrowXRateInDHS = value; }
        }


        private string _syncToDHSStatus;
        /// <summary>
        /// get or set for SyncToDHSStatus
        /// </summary>
        [DataMember]
        public string SyncToDHSStatus
        {
            get { return _syncToDHSStatus; }
            set { _syncToDHSStatus = value; }
        }

        private DateTime _synctoDHSTimeStamp;
        /// <summary>
        /// get or set for SynctoDHSTimeStamp
        /// </summary>
        [DataMember]
        public DateTime SynctoDHSTimeStamp
        {
            get { return _synctoDHSTimeStamp; }
            set { _synctoDHSTimeStamp = value; }
        }

        private string _syncBy;
        /// <summary>
        /// get or set for SyncBy
        /// </summary>
        [DataMember]
        public string SyncBy
        {
            get { return _syncBy; }
            set { _syncBy = value; }
        }
    }
    /// <summary>
    /// Data Contract use for Procedure Parameters
    /// </summary>
    public class CurrencyAndForeignExchangeSyncLogParamModel
    {

        private Guid _countryGuid;
        /// <summary>
        /// get or set for CountryGuid
        /// </summary>
        [DataMember]
        public Guid CountryGuid
        {
            get { return _countryGuid; }
            set { _countryGuid = value; }
        }

        private DateTime _fromDate;
        /// <summary>
        /// get or set for FromDate
        /// </summary>
        [DataMember]
        public DateTime FromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }

        private DateTime _toDate;
        /// <summary>
        /// get or set for ToDate
        /// </summary>
        [DataMember]
        public DateTime ToDate
        {
            get { return _toDate; }
            set { _toDate = value; }
        }
    }
}
