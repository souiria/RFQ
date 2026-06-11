namespace SalesSystem.Rfq.Models
{
    public class BusinessUnitUxModel
    {
        public string? BusinessUnitCode
        { get; set; }

        public string? BusinessUnitName
        { get; set; }

        public Guid? BusinessUnitTypeGuid
        { get; set; }

        public string? StreetNumber
        { get; set; }

        public string? StreetName
        { get; set; }

        public string? City
        { get; set; }

        public string? Region
        { get; set; }

        public string? ZipCode
        { get; set; }

        public Guid? CountryGuid
        { get; set; }

        public bool? IsActive
        { get; set; }

        public Guid? Id
        { get; set; }

        public DateTime? CreatedDate
        { get; set; }

        public DateTime? ModifiedDate
        { get; set; }

        public Guid? CreatedBy
        { get; set; }

        public Guid? ModifiedBy
        { get; set; }

        public short? SyncToCPD
        { get; set; }

        public bool? IsExternalWarehouse
        { get; set; }

        public string? EWMSWarehouseCode
        { get; set; }

        public string? DisplayName
        { get; set; }

        public string? LegacyBusinessUnitCode
        { get; set; }

        public string? LegacyBusinessUnitName
        { get; set; }

        public string? Company
        { get; set; }

        public string? BusinessUnitDescription
        { get; set; }

        public string? BusinessUnitContactName
        { get; set; }

        public string? BusinessUnitContactNumber
        { get; set; }

        public string? BusinessUnitAltContactNumber
        { get; set; }

        public string? BusinessUnitMainPhoneNumber
        { get; set; }

        public string? BusinessUnitManagerEmail
        { get; set; }

        public string? Router
        { get; set; }

        public string? Subnet
        { get; set; }

        public string? HostFrom
        { get; set; }

        public string? HostTo
        { get; set; }

        public string? ITEngineer
        { get; set; }

        public string? BackupOperator
        { get; set; }

        public string? InterSeptor
        { get; set; }

        public string? InterSeptorFirmware
        { get; set; }

        public string? InterSeptorAlerts
        { get; set; }

        public bool? UseLocalSupport
        { get; set; }

        public string? VideoConference
        { get; set; }

        public string? VideoConferenceIP
        { get; set; }

        public decimal? AccessCircuit
        { get; set; }

        public string? PERouter1
        { get; set; }

        public string? PERouter2
        { get; set; }

        public string? MRTG
        { get; set; }

        public bool? WiFi
        { get; set; }

        public bool? Printer
        { get; set; }

        public bool? Copier
        { get; set; }

        public bool? LocalIT
        { get; set; }

        public bool? Wan
        { get; set; }

        public string? WanType
        { get; set; }

        public string? WanStatus
        { get; set; }

        public int? WanDownCount
        { get; set; }

        public string? WanHighRTT
        { get; set; }

        public bool? LocalBackups
        { get; set; }

        public string? MitelController
        { get; set; }

        public string? MitelControllerBackup
        { get; set; }

        public string? Riverbed
        { get; set; }

        public string? VCenter
        { get; set; }

        public string? CCTV
        { get; set; }

        public string? DefaultFileServer
        { get; set; }

        public string? DefaultMailServer
        { get; set; }

        public string? DefaultCopier
        { get; set; }

        public string? DefaultWDSServer
        { get; set; }

        public string? DefaultDeployRoot
        { get; set; }

        public string? DefaultHRManager
        { get; set; }

        public bool? PDR
        { get; set; }

        public string? Mapurl
        { get; set; }

        public string? Longtitude
        { get; set; }

        public string? Latitude
        { get; set; }

        public string? What3Words
        { get; set; }

        public string? NearestWeatherCity
        { get; set; }

        public string? WeatherTemperatureHigh
        { get; set; }

        public string? WeatherTemperatureLow
        { get; set; }

        public string? Weatherurl
        { get; set; }

        public string? WeatherMaxWindSpeed
        { get; set; }

        public int? WeatherTemperatureThreshold
        { get; set; }

        public DateTime? WeatherReportDate
        { get; set; }

        public string? TrafficSummary
        { get; set; }

        //public int? HEAT_SITE_ID
        //{ get; set; }
    }
}
