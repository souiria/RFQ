/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CurrencyExchangeRateConversionAssociationModel.cs
Function           :   Data Contract for CurrencyExchangeRateConversion
Created By         :   Shivam Dhingra
Created on         :   03-Jul-2020
Revision History   :   [06-Jul-2020] : Shivam Dhingra
                   :   [] : Added new field EURExchangeRate
                   :  [17-Oct-2020] : Dharmendra Kumar
                   :   [] : Added new field CountryGuid
                   :  [02-Dec-2020] : Dharmendra Kumar
                   :   [] : Added new Class CurrencyExchangeRateConversionAssociationParamModel inside same name space
                   :   [22-Oct-2021] : Shivam Kalia
                   :   [] : Added new fields CurrencyGuid,TodayXRate,TomorrowXrate,BaseCurrency and commented ExchangeRate,EURExchangeRate
                   :   [26-Nov-2021] : Shivam Kalia
                   :   [] : Added new field CountryGuid in CurrencyExchangeRateConversionAssociationParamModel
                   :   [06-Dec-2023] : Prakhar
                   :   [] : Added new Model CountryDropDown,ProcurementUnitBusinessUnitAssociationStatelessModel,CurrencyDropDown and added property in CurrencyExchangeRateConversionAssociationParamModel
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    /// <summary>
    /// Data Contract for CurrencyExchangeRateConversion
    /// </summary>
    [DataContract, Serializable]
    public class CurrencyExchangeRateConversionAssociationModel : BaseModel<Guid>
    {

        private Guid _sourceCurrencyGuid;
        /// <summary>
        /// Get or Set for {SourceCurrencyGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid SourceCurrencyGuid
        {
            get => _sourceCurrencyGuid;
            set => SetProperty(ref _sourceCurrencyGuid, value);
        }

        private Guid _targetCurrencyGuid;
        /// <summary>
        /// Get or Set for {TargetCurrencyGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid TargetCurrencyGuid
        {
            get => _targetCurrencyGuid;
            set => SetProperty(ref _targetCurrencyGuid, value);
        }

        private String _currencyCode;
        [DataMember]
        [Required]
        public String CurrencyCode
        {
            get => _currencyCode;
            set => SetProperty(ref _currencyCode, value);
        }

        private String _currencyName;
        [DataMember]
        [Required]
        public String CurrencyName
        {
            get => _currencyName;
            set => SetProperty(ref _currencyName, value);
        }

        private Decimal _todayXRate;
        /// <summary>
        /// Get or Set for {TodayXRate}.
        /// </summary>
        [DataMember]
        [Required]
        [DecimalPrecision(8, 4)]
        public Decimal TodayXRate
        {
            get => _todayXRate;
            set => SetProperty(ref _todayXRate, value);
        }

        private Decimal _tomorrowXrate;
        /// <summary>
        /// Get or Set for {TomorrowXrate}.
        /// </summary>
        [DataMember]
        [Required]
        [DecimalPrecision(8, 4)]
        public Decimal TomorrowXrate
        {
            get => _tomorrowXrate;
            set => SetProperty(ref _tomorrowXrate, value);
        }

        private bool _baseCurrency = false;
        /// <summary>
        /// This field will set BaseCurrency
        /// </summary>
        [DataMember]
        public bool BaseCurrency
        {
            get => _baseCurrency;
            set => SetProperty(ref _baseCurrency, value);
        }

        private Guid _countryGuid;
        /// <summary>
        /// This field will set CountryGuid
        /// </summary>
        [DataMember]
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => SetProperty(ref _countryGuid, value);
        }

        private String _countryName;
        /// <summary>
        /// This field will set CountryName
        /// </summary>
        [DataMember]
        public String CountryName
        {
            get => _countryName;
            set => SetProperty(ref _countryName, value);
        }

        private Guid _currencyGuid;
        /// <summary>
        /// This field will set CountryName
        /// </summary>
        [DataMember]
        public Guid CurrencyGuid
        {
            get => _currencyGuid;
            set => SetProperty(ref _currencyGuid, value);
        }

        private Int16 _syncToCPD;
        /// <summary>
        /// This field will set SyncToCPD
        /// </summary>
        [DataMember]
        public Int16 SyncToCPD
        {
            get => _syncToCPD;
            set => SetProperty(ref _syncToCPD, value);
        }
    }
    /// <summary>
    /// Model for pass sync by username guid
    /// </summary>
    public class CurrencyExchangeRateConversionAssociationParamModel
    {

        private Guid _lastSynchronizeByGuid;
        /// <summary>
        /// get or set for LastSynchronizeBy
        /// </summary>
        [DataMember]
        public Guid LastSynchronizeBy
        {
            get { return _lastSynchronizeByGuid; }
            set { _lastSynchronizeByGuid = value; }
        }


        private Guid _countryGuid;
        /// <summary>
        /// This field will set CountryGuid
        /// </summary>
        [DataMember]
        public Guid CountryGuid
        {
            get { return _countryGuid; }
            set { _countryGuid = value; }
        }
    }


    /// <summary>
    /// Model for pass sync by username guid
    /// </summary>
    public class CountryDropDownModel
    {

        private String _countryName;
        /// <summary>
        /// get or set for CountryName
        /// </summary>
        [DataMember]
        public String CountryName
        {
            get { return _countryName; }
            set { _countryName = value; }
        }


        private Guid _id;
        /// <summary>
        /// This field will set CountryId
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }

    public class CurrencyDropDownModel
    {

        private String _currencyName;
        /// <summary>
        /// get or set for CurrencyName
        /// </summary>
        [DataMember]
        public String CurrencyName
        {
            get { return _currencyName; }
            set { _currencyName = value; }
        }

        private String _currencyCode;
        /// <summary>
        /// get or set for CurrencyCode
        /// </summary>
        [DataMember]
        public String CurrencyCode
        {
            get { return _currencyCode; }
            set { _currencyCode = value; }
        }

        private bool _isExchangeRequired;
        /// <summary>
        /// get or set for IsExchangeRequired
        /// </summary>
        [DataMember]
        public bool IsExchangeRequired
        {
            get { return _isExchangeRequired; }
            set { _isExchangeRequired = value; }
        }


        private Guid _id;
        /// <summary>
        /// This field will set CurrencyId
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }

    public class GetallCurrencyExchangeRateConversionAssociationModel
    {

        private Guid _id;
        /// <summary>
        /// This field will set Id
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private Guid _sourceCurrencyGuid;
        /// <summary>
        /// Get or Set for {SourceCurrencyGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid SourceCurrencyGuid
        {
            get => _sourceCurrencyGuid;
            set => _sourceCurrencyGuid = value;
        }

        private Guid _targetCurrencyGuid;
        /// <summary>
        /// Get or Set for {TargetCurrencyGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid TargetCurrencyGuid
        {
            get => _targetCurrencyGuid;
            set => _targetCurrencyGuid = value;
        }


        private Guid _countryGuid;
        /// <summary>
        /// This field will set CountryGuid
        /// </summary>
        [DataMember]
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => _countryGuid = value;
        }

        private Guid _currencyGuid;
        /// <summary>
        /// This field will set CountryName
        /// </summary>
        [DataMember]
        public Guid CurrencyGuid
        {
            get => _currencyGuid;
            set => _currencyGuid = value;
        }


    }

    public class ProcurementUnitBusinessUnitAssociationStatelessModel
    {

        private String _businessUnitCode;
        /// <summary>
        /// get or set for BusinessUnitCode
        /// </summary>
        [DataMember]
        public String BusinessUnitCode
        {
            get => _businessUnitCode;
            set => _businessUnitCode = value;
        }


        private Guid _baseCurrencyGuid;
        /// <summary>
        /// This field will set CountryId
        /// </summary>
        [DataMember]
        public Guid BaseCurrencyGuid
        {
            get => _baseCurrencyGuid;
            set => _baseCurrencyGuid = value;
        }
    }
}
