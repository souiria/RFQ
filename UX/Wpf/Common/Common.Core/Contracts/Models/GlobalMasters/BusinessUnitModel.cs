/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   BusinessUnitModel.cs
Function           :   Business Unit
Created By         :   
Created on         :   
Revision History   :   [02-Dec-2020] : Shivam Dhingra
                   :   [] : Added new fields WarehouseSystem and IsExternalWarehouse
                   :   [26-Nov-2021] : Shivam Dhingra
                   :   [] : Rename WareHouseSystem to EWMSWarehouseCode
                   :   [11-Jul-2022] : Shivam Dhingra
                   :   [] : Added new fields
                   :   [26-Jul-2022] : Ranjay
                   :   [] : Changed weatherReportDate field type nullable
                   :   [09-Feb-2023] : Mayur
                   :   [] : Increased lenght of StreetNumber and StreetName
                   :   [15-Feb-2023] : Mayur
                   :   [] : Created BusinessUnitStatelessModel and BusinessUnitStatelessFilterModel
                   :   [26-Mar-2024] : Ashish Dutta
                   :   [] : Increase lenght of BusinessUnitManagerEmail 50 to 254 


****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class BusinessUnitModel : BaseModel<Guid>
    {
        private string _businessUnitCode;
        [DataMember]
        [Required]
        [StringLength(4)]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }

        private string _businessUnitName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string BusinessUnitName
        {
            get => _businessUnitName;
            set => SetProperty(ref _businessUnitName, value);
        }

        private Guid _businessUnitTypeGuid;
        [DataMember]
        [Required]
        public Guid BusinessUnitTypeGuid
        {
            get => _businessUnitTypeGuid;
            set => SetProperty(ref _businessUnitTypeGuid, value);
        }

        private string _streetNumber;
        [DataMember]
        [StringLength(500)]
        public string StreetNumber
        {
            get => _streetNumber;
            set => SetProperty(ref _streetNumber, value);
        }

        private string _streetName;
        [DataMember]
        [StringLength(500)]
        public string StreetName
        {
            get => _streetName;
            set => SetProperty(ref _streetName, value);
        }

        private string _city;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        private string _region;
        [DataMember]
        [StringLength(50)]
        public string Region
        {
            get => _region;
            set => SetProperty(ref _region, value);
        }

        private string _zipCode;
        [DataMember]
        [Required]
        [StringLength(20)]
        public string ZipCode
        {
            get => _zipCode;
            set => SetProperty(ref _zipCode, value);
        }

        private Guid _countryGuid;
        [DataMember]
        [Required]      
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => SetProperty(ref _countryGuid, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private bool _isExternalWarehouse = false;
        /// <summary>
        /// get or set for IsExternalWarehouse
        /// </summary>
        [DataMember]
        public bool IsExternalWarehouse
        {
            get => _isExternalWarehouse;
            set => SetProperty(ref _isExternalWarehouse, value);
        }

        private string _ewmsWarehouseCode;
        /// <summary>
        /// get or set for EWMSWarehouseCode
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string EWMSWarehouseCode
        {
            get => _ewmsWarehouseCode;
            set => SetProperty(ref _ewmsWarehouseCode, value);
        }

        //New Columns Added from here

        private string _displayName;
        /// <summary>
        /// get or set for DisplayName
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        private string _legacyBusinessUnitCode;
        /// <summary>
        /// get or set for LegacyBusinessUnitCode
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string LegacyBusinessUnitCode
        {
            get => _legacyBusinessUnitCode;
            set => SetProperty(ref _legacyBusinessUnitCode, value);
        }

        private string _legacyBusinessUnitName;
        /// <summary>
        /// get or set for LegacyBusinessUnitName
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string LegacyBusinessUnitName
        {
            get => _legacyBusinessUnitName;
            set => SetProperty(ref _legacyBusinessUnitName, value);
        }

        private string _company;
        /// <summary>
        /// get or set for Company
        /// </summary>
        [DataMember]
        [StringLength(10)]
        public string Company
        {
            get => _company;
            set => SetProperty(ref _company, value);
        }

        private string _businessUnitDescription;
        /// <summary>
        /// get or set for BusinessUnitDescription
        /// </summary>
        [DataMember]
        [StringLength(40)]
        public string BusinessUnitDescription
        {
            get => _businessUnitDescription;
            set => SetProperty(ref _businessUnitDescription, value);
        }

        private string _businessUnitContactName;
        /// <summary>
        /// get or set for BusinessUnitContactName
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string BusinessUnitContactName
        {
            get => _businessUnitContactName;
            set => SetProperty(ref _businessUnitContactName, value);
        }

        private string _businessUnitContactNumber;
        /// <summary>
        /// get or set for BusinessUnitContactNumber
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string BusinessUnitContactNumber
        {
            get => _businessUnitContactNumber;
            set => SetProperty(ref _businessUnitContactNumber, value);
        }

        private string _businessUnitAltContactNumber;
        /// <summary>
        /// get or set for BusinessUnitAltContactNumber
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string BusinessUnitAltContactNumber
        {
            get => _businessUnitAltContactNumber;
            set => SetProperty(ref _businessUnitAltContactNumber, value);
        }

        private string _businessUnitMainPhoneNumber;
        /// <summary>
        /// get or set for BusinessUnitMainPhoneNumber
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string BusinessUnitMainPhoneNumber
        {
            get => _businessUnitMainPhoneNumber;
            set => SetProperty(ref _businessUnitMainPhoneNumber, value);
        }
        //commented by Ashish on 26-Mar-2024
        //private string _businessUnitManagerEmail;
        ///// <summary>
        ///// get or set for BusinessUnitManagerEmail
        ///// </summary>
        //[DataMember]
        //[StringLength(50)]
        //public string BusinessUnitManagerEmail
        //{
        //    get => _businessUnitManagerEmail;
        //    set => SetProperty(ref _businessUnitManagerEmail, value);
        //}
        //commented End by Ashish on 26-Mar-2024


        //Added by Ashish on 26-Mar-2024
        private string _businessUnitManagerEmail;
        /// <summary>
        /// get or set for BusinessUnitManagerEmail
        /// </summary>
        [DataMember]
        [StringLength(254)]
        public string BusinessUnitManagerEmail
        {
            get => _businessUnitManagerEmail;
            set => SetProperty(ref _businessUnitManagerEmail, value);
        }
        //Added End by Ashish on 26-Mar-2024

        private string _router;
        /// <summary>
        /// get or set for Router
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string Router
        {
            get => _router;
            set => SetProperty(ref _router, value);
        }

        private string _subnet;
        /// <summary>
        /// get or set for Subnet
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Subnet
        {
            get => _subnet;
            set => SetProperty(ref _subnet, value);
        }

        private string _hostFrom;
        /// <summary>
        /// get or set for HostFrom
        /// </summary>
        [DataMember]
        [StringLength(3)]
        public string HostFrom
        {
            get => _hostFrom;
            set => SetProperty(ref _hostFrom, value);
        }

        private string _hostTo;
        /// <summary>
        /// get or set for HostTo
        /// </summary>
        [DataMember]
        [StringLength(3)]
        public string HostTo
        {
            get => _hostTo;
            set => SetProperty(ref _hostTo, value);
        }

        private string _iTEngineer;
        /// <summary>
        /// get or set for ITEngineer
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string ITEngineer
        {
            get => _iTEngineer;
            set => SetProperty(ref _iTEngineer, value);
        }

        private string _backupOperator;
        /// <summary>
        /// get or set for BackupOperator
        /// </summary>
        [DataMember]
        [StringLength(254)]
        public string BackupOperator
        {
            get => _backupOperator;
            set => SetProperty(ref _backupOperator, value);
        }

        private string _interSeptor;
        /// <summary>
        /// get or set for InterSeptor
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string InterSeptor
        {
            get => _interSeptor;
            set => SetProperty(ref _interSeptor, value);
        }

        private string _interSeptorFirmware;
        /// <summary>
        /// get or set for InterSeptorFirmware
        /// </summary>
        [DataMember]
        [StringLength(5)]
        public string InterSeptorFirmware
        {
            get => _interSeptorFirmware;
            set => SetProperty(ref _interSeptorFirmware, value);
        }

        private string _interSeptorAlerts;
        /// <summary>
        /// get or set for InterSeptorAlerts
        /// </summary>
        [DataMember]
        [StringLength(254)]
        public string InterSeptorAlerts
        {
            get => _interSeptorAlerts;
            set => SetProperty(ref _interSeptorAlerts, value);
        }

        private bool _useLocalSupport;
        /// <summary>
        /// get or set for UseLocalSupport
        /// </summary>
        [DataMember]
        public bool UseLocalSupport
        {
            get => _useLocalSupport;
            set => SetProperty(ref _useLocalSupport, value);
        }

        private string _videoConference;
        /// <summary>
        /// get or set for VideoConference
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string VideoConference
        {
            get => _videoConference;
            set => SetProperty(ref _videoConference, value);
        }

        private string _videoConferenceIP;
        /// <summary>
        /// get or set for VideoConferenceIP
        /// </summary>
        [DataMember]
        [StringLength(30)]
        public string VideoConferenceIP
        {
            get => _videoConferenceIP;
            set => SetProperty(ref _videoConferenceIP, value);
        }

        private decimal _accessCircuit;
        /// <summary>
        /// get or set for AccessCircuit
        /// </summary>
        [DataMember]
        [DecimalPrecision(18,0)]
        public decimal AccessCircuit
        {
            get => _accessCircuit;
            set => SetProperty(ref _accessCircuit, value);
        }

        private string _pERouter1;
        /// <summary>
        /// get or set for PERouter1
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string PERouter1
        {
            get => _pERouter1;
            set => SetProperty(ref _pERouter1, value);
        }

        private string _pERouter2;
        /// <summary>
        /// get or set for PERouter2
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string PERouter2
        {
            get => _pERouter2;
            set => SetProperty(ref _pERouter2, value);
        }

        private string _mRTG;
        /// <summary>
        /// get or set for MRTG
        /// </summary>
        [DataMember]
        [StringLength(150)]
        public string MRTG
        {
            get => _mRTG;
            set => SetProperty(ref _mRTG, value);
        }

        private bool _wiFi;
        /// <summary>
        /// get or set for WiFi
        /// </summary>
        [DataMember]
        public bool WiFi
        {
            get => _wiFi;
            set => SetProperty(ref _wiFi, value);
        }

        private bool _printer;
        /// <summary>
        /// get or set for Printer
        /// </summary>
        [DataMember]
        public bool Printer
        {
            get => _printer;
            set => SetProperty(ref _printer, value);
        }

        private bool _copier;
        /// <summary>
        /// get or set for Copier
        /// </summary>
        [DataMember]
        public bool Copier
        {
            get => _copier;
            set => SetProperty(ref _copier, value);
        }

        private bool _localIT;
        /// <summary>
        /// get or set for LocalIT
        /// </summary>
        [DataMember]
        public bool LocalIT
        {
            get => _localIT;
            set => SetProperty(ref _localIT, value);
        }

        private bool _wan;
        /// <summary>
        /// get or set for Wan
        /// </summary>
        [DataMember]
        public bool Wan
        {
            get => _wan;
            set => SetProperty(ref _wan, value);
        }

        private string _wanType;
        /// <summary>
        /// get or set for WanType
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WanType
        {
            get => _wanType;
            set => SetProperty(ref _wanType, value);
        }

        private string _wanStatus;
        /// <summary>
        /// get or set for WanStatus
        /// </summary>
        [DataMember]
        [StringLength(7)]
        public string WanStatus
        {
            get => _wanStatus;
            set => SetProperty(ref _wanStatus, value);
        }

        private int _wanDownCount;
        /// <summary>
        /// get or set for WanDownCount
        /// </summary>
        [DataMember]
        public int WanDownCount
        {
            get => _wanDownCount;
            set => SetProperty(ref _wanDownCount, value);
        }

        private string _wanHighRTT;
        /// <summary>
        /// get or set for WanHighRTT
        /// </summary>
        [DataMember]
        [StringLength(3)]
        public string WanHighRTT
        {
            get => _wanHighRTT;
            set => SetProperty(ref _wanHighRTT, value);
        }

        private bool _localBackups;
        /// <summary>
        /// get or set for LocalBackups
        /// </summary>
        [DataMember]
        public bool LocalBackups
        {
            get => _localBackups;
            set => SetProperty(ref _localBackups, value);
        }

        private string _mitelController;
        /// <summary>
        /// get or set for MitelController
        /// </summary>
        [DataMember]
        [StringLength(30)]
        public string MitelController
        {
            get => _mitelController;
            set => SetProperty(ref _mitelController, value);
        }

        private string _mitelControllerBackup;
        /// <summary>
        /// get or set for MitelControllerBackup
        /// </summary>
        [DataMember]
        [StringLength(30)]
        public string MitelControllerBackup
        {
            get => _mitelControllerBackup;
            set => SetProperty(ref _mitelControllerBackup, value);
        }

        private string _riverbed;
        /// <summary>
        /// get or set for Riverbed
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string Riverbed
        {
            get => _riverbed;
            set => SetProperty(ref _riverbed, value);
        }

        private string _VCenter;
        /// <summary>
        /// get or set for VCenter
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string VCenter
        {
            get => _VCenter;
            set => SetProperty(ref _VCenter, value);
        }

        private string _CCTV;
        /// <summary>
        /// get or set for CCTV
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string CCTV
        {
            get => _CCTV;
            set => SetProperty(ref _CCTV, value);
        }

        private string _defaultFileServer;
        /// <summary>
        /// get or set for DefaultFileServer
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DefaultFileServer
        {
            get => _defaultFileServer;
            set => SetProperty(ref _defaultFileServer, value);
        }

        private string _defaultMailServer;
        /// <summary>
        /// get or set for DefaultMailServer
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DefaultMailServer
        {
            get => _defaultMailServer;
            set => SetProperty(ref _defaultMailServer, value);
        }

        private string _defaultCopier;
        /// <summary>
        /// get or set for DefaultCopier
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DefaultCopier
        {
            get => _defaultCopier;
            set => SetProperty(ref _defaultCopier, value);
        }

        private string _defaultWDSServer;
        /// <summary>
        /// get or set for DefaultWDSServer
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DefaultWDSServer
        {
            get => _defaultWDSServer;
            set => SetProperty(ref _defaultWDSServer, value);
        }

        private string _defaultDeployRoot;
        /// <summary>
        /// get or set for DefaultDeployRoot
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DefaultDeployRoot
        {
            get => _defaultDeployRoot;
            set => SetProperty(ref _defaultDeployRoot, value);
        }

        private string _defaultHRManager;
        /// <summary>
        /// get or set for DefaultHRManager
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DefaultHRManager
        {
            get => _defaultHRManager;
            set => SetProperty(ref _defaultHRManager, value);
        }

        private bool _PDR;
        /// <summary>
        /// get or set for PDR
        /// </summary>
        [DataMember]
        public bool PDR
        {
            get => _PDR;
            set => SetProperty(ref _PDR, value);
        }

        private string _mapUrl;
        /// <summary>
        /// get or set for MapUrl
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string MapUrl
        {
            get => _mapUrl;
            set => SetProperty(ref _mapUrl, value);
        }

        private string _longtitude;
        /// <summary>
        /// get or set for Longtitude
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Longtitude
        {
            get => _longtitude;
            set => SetProperty(ref _longtitude, value);
        }

        private string _latitude;
        /// <summary>
        /// get or set for Latitude
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Latitude
        {
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }

        private string _what3Words;
        /// <summary>
        /// get or set for What3Words
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string What3Words
        {
            get => _what3Words;
            set => SetProperty(ref _what3Words, value);
        }

        private string _nearestWeatherCity;
        /// <summary>
        /// get or set for NearestWeatherCity
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string NearestWeatherCity
        {
            get => _nearestWeatherCity;
            set => SetProperty(ref _nearestWeatherCity, value);
        }

        private string _weatherTemperatureHigh;
        /// <summary>
        /// get or set for WeatherTemperatureHigh
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WeatherTemperatureHigh
        {
            get => _weatherTemperatureHigh;
            set => SetProperty(ref _weatherTemperatureHigh, value);
        }

        private string _weatherTemperatureLow;
        /// <summary>
        /// get or set for WeatherTemperatureLow
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WeatherTemperatureLow
        {
            get => _weatherTemperatureLow;
            set => SetProperty(ref _weatherTemperatureLow, value);
        }

        private string _weatherUrl;
        /// <summary>
        /// get or set for WeatherUrl
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string WeatherUrl
        {
            get => _weatherUrl;
            set => SetProperty(ref _weatherUrl, value);
        }

        private string _weatherMaxWindSpeed;
        /// <summary>
        /// get or set for WeatherMaxWindSpeed
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string WeatherMaxWindSpeed
        {
            get => _weatherMaxWindSpeed;
            set => SetProperty(ref _weatherMaxWindSpeed, value);
        }

        private int _weatherTemperatureThreshold;
        /// <summary>
        /// get or set for WeatherTemperatureThreshold
        /// </summary>
        [DataMember]
        public int WeatherTemperatureThreshold
        {
            get => _weatherTemperatureThreshold;
            set => SetProperty(ref _weatherTemperatureThreshold, value);
        }

        private DateTime? _weatherReportDate;
        /// <summary>
        /// get or set for WeatherReportDate
        /// </summary>
        [DataMember]
        public DateTime? WeatherReportDate
        {
            get => _weatherReportDate;
            set => SetProperty(ref _weatherReportDate, value);
        }


        private string _trafficSummary;
        /// <summary>
        /// get or set for TrafficSummary
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string TrafficSummary
        {
            get => _trafficSummary;
            set => SetProperty(ref _trafficSummary, value);
        }

    }

    [DataContract, Serializable]
    public class BusinessUnitStatelessModel
    {
        private Guid _id;
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => _businessUnitCode = value;
        }

        private string _businessUnitName;
        [DataMember]
        public string BusinessUnitName
        {
            get => _businessUnitName;
            set =>  _businessUnitName = value;
        }
    }

    public class BusinessUnitStatelessFilterModel
    {
        private string _businessUnitType;
        [DataMember]
        public string BusinessUnitType
        {
            get => _businessUnitType;
            set => _businessUnitType = value;
        }

        private int _check;
        [DataMember]
        public int Check
        {
            get => _check;
            set => _check = value;
        }
    }
}
