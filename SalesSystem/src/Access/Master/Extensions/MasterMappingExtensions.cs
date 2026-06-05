namespace Master.Extensions
{
    public static class MasterMappingExtensions
    {
        #region Currency

        public static CurrencyGrpc MapToCurrencyGrpc(this DbCurrency entity)
        {
            CurrencyGrpc data = new CurrencyGrpc();
            data.Id = entity.Id.ToString();
            data.CurrencyCode = entity.CurrencyCode;
            data.CurrencyName = entity.CurrencyName;
            data.EuroRate = entity.EuroRate;
            data.IsActive = entity.IsActive;
            return data;
        }

        #endregion

        #region Customer

        public static CustomerGrpc MapToCustomerGrpc(this DbCustomerBusinessHierarchy entity)
        {
            CustomerGrpc data = new CustomerGrpc();
            data.Id = entity.Id.ToString();
            data.CustomerBusinessGroupCode = entity.CustomerBusinessGroupCode;
            data.CustomerBusinessGroupName = entity.CustomerBusinessGroupName;
            data.SEWSEBusinessTeam = entity.SEWSEBusinessTeam;
            data.IsActive = entity.IsActive;
            return data;
        }

        public static CustomerLocationGrpc MapToLocationGrpc(this DbCustomerHierarchy entity)
        {
            CustomerLocationGrpc data = new CustomerLocationGrpc();

            data.Id = entity.Id.ToString();
            data.CustomerCode = entity.CustomerCode;
            data.CustomerBusinessHierarchyGuid = entity.CustomerBusinessHierarchyGuid.ToString();
            data.CustomerName = entity.CustomerName;
            data.IsActive = entity.IsActive;
            return data;
        }

        public static CustomerSalesEntityGrpc MapToCustomerSalesEntityGrpc(this DbCustomerSalesEntity entity)
        {
            CustomerSalesEntityGrpc data = new CustomerSalesEntityGrpc();
            data.Id = entity.Id.ToString();
            data.CustomerSalesEntityCode = entity.CustomerSalesEntityCode;
            data.CustomerSalesEntityName = entity.CustomerSalesEntityName;
            data.FinanceCode = entity.FinanceCode;
            data.CustomerHierarchyGuid = entity.CustomerHierarchyGuid.ToString();
            data.IsActive = entity.IsActive;
            return data;
        }

        public static CustomerProjectAssociationGrpc MapToCustomerProjectAssociationGrpc(this DbCustomerProjectAssociation entity)
        {
            CustomerProjectAssociationGrpc data = new CustomerProjectAssociationGrpc();
            data.Id = entity.Id.ToString();
            data.CustomerLocationGuid = entity.CustomerGuid.ToString();
            data.ProjectGuid = entity.ProjectGuid.ToString();
            data.IsActive = entity.IsActive ?? false;
            return data;
        }

        public static CustomerBusinessUserAssociationGrpc MapToCustomerBusinessUserAssociationGrpc(this DbCustomerBusinessUserAssociation entity)
        {
            CustomerBusinessUserAssociationGrpc data = new CustomerBusinessUserAssociationGrpc();
            data.Id = entity.Id.ToString();
            data.CustomerBusinessHierarchyList = entity.CustomerBusinessHierarchyList;
            data.UserGuid = entity.UserGuid.ToString();
            data.IsActive = entity.IsActive ?? false;
            return data;
        }

        #endregion

        #region Project

        public static MilestoneGrpc MapToMilestoneGrpc(this DbMilestoneHierarchy entity)
        {
            MilestoneGrpc data = new MilestoneGrpc();
            data.Id = entity.Id.ToString();
            data.MilestoneEventName = entity.MilestoneEventName;
            data.EventStartDate = entity.EventStartDate?.ToUniversalTime().ToTimestamp();
            data.EventEndDate = entity.EventEndDate?.ToUniversalTime().ToTimestamp();
            data.ProjectHierarchyGuid = entity.ProjectHierarchyGuid.ToString();
            data.IsActive = entity.IsActive;
            return data;
        }

        public static PlatformGrpc MapToPlatformGrpc(this DbPlatformHierarchy entity)
        {
            PlatformGrpc data = new PlatformGrpc();
            data.Id = entity.Id.ToString();
            data.PlatformName = entity.PlatformName;
            data.CustomerHierarchyGuid = entity.CustomerHierarchyGuid.ToString();
            data.PlatformManagerName = entity.PlatformManagerName;
            data.IsActive = entity.IsActive;
            return data;
        }

        public static ProgramGrpc MapToProgramGrpc(this DbProgramHierarchy entity)
        {
            ProgramGrpc data = new ProgramGrpc();
            data.Id = entity.Id.ToString();
            data.ProgramName = entity.ProgramName;
            data.PlatformHierarchyGuid = entity.PlatformHierarchyGuid.ToString();
            data.IsActive = entity.IsActive;
            return data;
        }

        public static ProjectGrpc MapToProjectGrpc(this DbProjectHierarchy entity)
        {
            ProjectGrpc data = new ProjectGrpc();
            data.Id = entity.Id.ToString();
            data.ProjectCode = entity.ProjectCode;
            data.ProjectName = entity.ProjectName;
            data.CustomerProjectCode = entity.CustomerProjectCode;
            data.ProjectDescription = entity.ProjectDescription;
            data.ProjectAnnualVolume = entity.ProjectAnnualVolume;
            data.ProgramHierarchyGuid = entity.ProgramHierarchyGuid.ToString();
            data.IsActive = entity.IsActive;
            return data;
        }

        public static ProjectEngineeringAssociationGrpc MapToProjectEngineeringAssociationGrpc(this DbProjectEngineeringAssociation entity)
        {
            ProjectEngineeringAssociationGrpc data = new ProjectEngineeringAssociationGrpc();
            data.ProjectGuid = entity.ProjectGuid.ToString();
            data.EngineeringADName = entity.EngineeringADName;
            data.EngineeringFullName = entity.EngineeringFullName;
            data.EmailAddress = entity.EmailAddress;
            data.Id = entity.Id.ToString();
            data.CreatedDate = entity.CreatedDate?.ToUniversalTime().ToTimestamp();
            data.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            data.ModifiedBy = entity.ModifiedBy.ToString();
            data.CreatedBy = entity.CreatedBy.ToString();
            data.IsActive = entity.IsActive;
            data.CustomerGuid = entity.CustomerGuid.ToString();
            return data;
        }   

        #endregion

        #region Vehicle

        public static VehicleGrpc MapToVehicleGrpc(this DbVehicle entity)
        {
            VehicleGrpc data = new VehicleGrpc();
            data.Id = entity.Id.ToString();
            data.VehicleName = entity.VehicleName;
            data.ProjectReference = entity.ProjectReference;
            data.VehicleDisplay = entity.VehicleDisplay;
            data.IsActive = entity.IsActive;
            return data;
        }

        #endregion

        #region SupplierGroup
        
        public static SupplierGroupGrpc MapToSupplierGroupGrpc(this DbSupplierGroup entity)
        {
            SupplierGroupGrpc supplierGroupGrpc = new SupplierGroupGrpc();
            supplierGroupGrpc.Id = entity.Id.ToString();
            supplierGroupGrpc.SupplierGroupName = entity.SupplierGroupName;
            supplierGroupGrpc.SupplierApprovalStatusGuid = entity.SupplierApprovalStatusGuid.ToString();
            supplierGroupGrpc.SupplierPanelGuid = entity.SupplierPanelGuid.ToString();
            supplierGroupGrpc.IsActive = entity.IsActive;
            supplierGroupGrpc.IsSWSPartNumberRequired = entity.IsSWSPartNumberRequired;
            supplierGroupGrpc.CreatedDate = entity.CreatedDate?.ToUniversalTime().ToTimestamp();
            supplierGroupGrpc.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            supplierGroupGrpc.CreatedBy = entity.CreatedBy?.ToString();
            supplierGroupGrpc.ModifiedBy = entity.ModifiedBy?.ToString();
            supplierGroupGrpc.SyncToCPD = entity.SyncToCPD;
            return supplierGroupGrpc;
        }
        #endregion

        #region Supplier
        
        public static SupplierGrpc MapToSupplierGrpc(this DbSupplier entity)
        {
            SupplierGrpc supplierGrpc = new SupplierGrpc();
            supplierGrpc.SupplierCode = entity.SupplierCode;
            supplierGrpc.SupplierName = entity.SupplierName;
            supplierGrpc.Address1 = entity.Address1;
            supplierGrpc.Address2 = entity.Address2;
            supplierGrpc.Address3 = entity.Address3;
            supplierGrpc.City = entity.City;
            supplierGrpc.Region = entity.Region;
            supplierGrpc.ZipCode = entity.ZipCode;
            supplierGrpc.CountryGuid = entity.CountryGuid.ToString();
            supplierGrpc.SupplierTypeGuid = entity.SupplierTypeGuid.ToString();
            supplierGrpc.SupplierGroupGuid = entity.SupplierGroupGuid.ToString();
            supplierGrpc.SupplierIncoTermsGuid = entity.SupplierIncoTermsGuid.ToString();
            supplierGrpc.SupplierCurrencyGuid = entity.SupplierCurrencyGuid.ToString();
            supplierGrpc.SupplierBuyerGuid = entity.SupplierBuyerGuid.ToString();
            supplierGrpc.SupplierDevelopmentTeamGuid = entity.SupplierDevelopmentTeamGuid.ToString();
            supplierGrpc.PaymentTerms = entity.PaymentTerms;
            supplierGrpc.EPOCommodityGroupGuid = entity.EPOCommodityGroupGuid.ToString();
            supplierGrpc.POPriceEffectiveDateTypeGuid = entity.POPriceEffectiveDateTypeGuid.ToString();
            supplierGrpc.SupplierApprovalStatusGuid = entity.SupplierApprovalStatusGuid.ToString();
            supplierGrpc.IsActive = entity.IsActive;
            supplierGrpc.Id = entity.Id.ToString();
            supplierGrpc.CreatedDate = entity.CreatedDate?.ToUniversalTime().ToTimestamp();
            supplierGrpc.ModifiedDate = entity.ModifiedDate?.ToUniversalTime().ToTimestamp();
            supplierGrpc.CreatedBy = entity.CreatedBy.ToString();
            supplierGrpc.SyncToCPD = entity.SyncToCPD;
            supplierGrpc.DistributionCountryOfOriginGuid = entity.DistributionCountryOfOriginGuid.ToString();
            supplierGrpc.IsEOLRequired = entity.IsEOLRequired;
            return supplierGrpc;
        }
        #endregion

        #region UnitOfMeasure

        public static UnitOfMeasureGrpc MapToUnitOfMeasureGrpc(this DbUnitOfMeasure entity)
        {
            UnitOfMeasureGrpc data = new UnitOfMeasureGrpc();

            data.Id = entity.Id.ToString();
            data.Code = entity.Code;
            data.UnitOfMeasureDescription = entity.UnitOfMeasureDescription;
            data.IsActive = entity.IsActive;

            return data;
        }

        #endregion

        #region BusinessUnit
        public static BusinessUnitGrpc MapToBusinessUnitGrpc(this DbBusinessUnit entity)
        {
            BusinessUnitGrpc data = new BusinessUnitGrpc();

            data.Id = entity.Id.ToString();
            data.BusinessUnitCode = entity.BusinessUnitCode;
            data.BusinessUnitName = entity.BusinessUnitName;
            data.BusinessUnitTypeGuid = entity.BusinessUnitTypeGuid.ToString();
            data.StreetNumber = entity.StreetNumber;
            data.StreetName = entity.StreetName;
            data.City = entity.City;
            data.Region = entity.Region;
            data.ZipCode = entity.ZipCode;
            data.CountryGuid = entity.CountryGuid.ToString();
            data.IsActive = entity.IsActive;

            if (entity.CreatedDate.HasValue)
            {
                DateTime createdUtc = entity.CreatedDate.Value.ToUniversalTime();
                data.CreatedDate = Timestamp.FromDateTime(createdUtc);
            }

            if (entity.ModifiedDate.HasValue)
            {
                DateTime modifiedUtc = entity.ModifiedDate.Value.ToUniversalTime();
                data.ModifiedDate = Timestamp.FromDateTime(modifiedUtc);
            }

            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();

            if (entity.SyncToCPD.HasValue)
            {
                data.SyncToCPD = entity.SyncToCPD.Value;
            }

            data.IsExternalWarehouse = entity.IsExternalWarehouse;
            data.EWMSWarehouseCode = entity.EWMSWarehouseCode;
            data.DisplayName = entity.DisplayName;
            data.LegacyBusinessUnitCode = entity.LegacyBusinessUnitCode;
            data.LegacyBusinessUnitName = entity.LegacyBusinessUnitName;
            data.Company = entity.Company;
            data.BusinessUnitDescription = entity.BusinessUnitDescription;
            data.BusinessUnitContactName = entity.BusinessUnitContactName;
            data.BusinessUnitContactNumber = entity.BusinessUnitContactNumber;
            data.BusinessUnitAltContactNumber = entity.BusinessUnitAltContactNumber;
            data.BusinessUnitMainPhoneNumber = entity.BusinessUnitMainPhoneNumber;
            data.BusinessUnitManagerEmail = entity.BusinessUnitManagerEmail;

            data.Router = entity.Router;
            data.Subnet = entity.Subnet;

                data.HostFrom = entity.HostFrom;
  
                data.HostTo = entity.HostTo;
               data.ITEngineer = entity.ITEngineer;
            data.BackupOperator = entity.BackupOperator;
            data.InterSeptor = entity.InterSeptor;
            data.InterSeptorFirmware = entity.InterSeptorFirmware;
            data.InterSeptorAlerts = entity.InterSeptorAlerts;

            data.UseLocalSupport = entity.UseLocalSupport;
            data.VideoConference = entity.VideoConference;
            data.VideoConferenceIP = entity.VideoConferenceIP;

            if (entity.AccessCircuit.HasValue)
            {
                data.AccessCircuit = Convert.ToDouble(entity.AccessCircuit.Value);
            }

            data.PERouter1 = entity.PERouter1;
            data.PERouter2 = entity.PERouter2;
            data.MRTG = entity.MRTG;

            data.WiFi = entity.WiFi;
            data.Printer = entity.Printer;
            data.Copier = entity.Copier;
            data.LocalIT = entity.LocalIT;
            data.Wan = entity.Wan;

            data.WanType = entity.WanType;
            data.WanStatus = entity.WanStatus;

            if (entity.WanDownCount.HasValue)
            {
                data.WanDownCount = entity.WanDownCount.Value;
            }

                data.WanHighRTT = entity.WanHighRTT;
                data.LocalBackups = entity.LocalBackups;
            data.MitelController = entity.MitelController;
            data.MitelControllerBackup = entity.MitelControllerBackup;
            data.Riverbed = entity.Riverbed;
            data.VCenter = entity.VCenter;
            data.CCTV = entity.CCTV;

            data.DefaultFileServer = entity.DefaultFileServer;
            data.DefaultMailServer = entity.DefaultMailServer;
            data.DefaultCopier = entity.DefaultCopier;
            data.DefaultWDSServer = entity.DefaultWDSServer;
            data.DefaultDeployRoot = entity.DefaultDeployRoot;
            data.DefaultHRManager = entity.DefaultHRManager;

            data.PDR = entity.PDR;
            data.MapUrl = entity.Mapurl; // 

                data.Longtitude = entity.Longtitude;
       
                data.Latitude = entity.Latitude;
      

            data.What3Words = entity.What3Words;
            data.NearestWeatherCity = entity.NearestWeatherCity;

            data.WeatherTemperatureHigh = entity.WeatherTemperatureHigh;
 
                data.WeatherTemperatureLow =entity.WeatherTemperatureLow;

            data.WeatherUrl = entity.Weatherurl; // 

                data.WeatherMaxWindSpeed = entity.WeatherMaxWindSpeed;
            

            if (entity.WeatherTemperatureThreshold.HasValue)
            {
                data.WeatherTemperatureThreshold = entity.WeatherTemperatureThreshold.Value;
            }

            if (entity.WeatherReportDate.HasValue)
            {
                DateTime weatherUtc = entity.WeatherReportDate.Value.ToUniversalTime();
                data.WeatherReportDate = Timestamp.FromDateTime(weatherUtc);
            }

            data.TrafficSummary = entity.TrafficSummary;

            if (entity.HEAT_SITE_ID.HasValue)
            {
                data.HEATSITEID = entity.HEAT_SITE_ID.Value;
            }

            return data;
        }
        #endregion
        #region ProjectEngineeringAssociation

        public static ProjectEngineeringAssociationGrpc MapToProjectEngineeringAssociationGrpc(
            this DbProjectEngineeringAssociation entity)
        {
            ProjectEngineeringAssociationGrpc data = new ProjectEngineeringAssociationGrpc();

            data.Id = entity.Id.ToString();
            data.ProjectGuid = entity.ProjectGuid.ToString();
            data.CustomerGuid = entity.CustomerGuid.ToString();

            data.EngineeringADName = entity.EngineeringADName;
            data.EngineeringFullName = entity.EngineeringFullName;
            data.EmailAddress = entity.EmailAddress;
             data.IsActive = entity.IsActive;
              if (entity.CreatedDate.HasValue)
            {
                DateTime createdUtc = entity.CreatedDate.Value.ToUniversalTime();
                data.CreatedDate = Timestamp.FromDateTime(createdUtc);
            }

            if (entity.ModifiedDate.HasValue)
            {
                DateTime modifiedUtc = entity.ModifiedDate.Value.ToUniversalTime();
                data.ModifiedDate = Timestamp.FromDateTime(modifiedUtc);
            }

            data.CreatedBy = entity.CreatedBy.ToString();
            data.ModifiedBy = entity.ModifiedBy.ToString();

            return data;
        }

        #endregion

    }
}
