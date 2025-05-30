using System.Reflection.Emit;

namespace Master.Extensions
{
    public static class MasterMappingExtensions
    {
        #region Currency

        public static CurrencyDto MapToCurrencyDto(this DbCurrency entity)
        {
            CurrencyDto dto = new CurrencyDto();
            dto.Id = entity.Id;
            dto.CurrencyCode = entity.CurrencyCode;
            dto.CurrencyName = entity.CurrencyName;
            dto.EuroRate = entity.EuroRate;
            dto.IsActive = entity.IsActive;
            return dto;
        }

        public static CurrencyData MapToCurrencyData(this CurrencyDto entity)
        {
            CurrencyData currencyData = new CurrencyData();
            currencyData.Id = entity.Id.ToString();
            currencyData.CurrencyCode = entity.CurrencyCode ?? "";
            currencyData.CurrencyName = entity.CurrencyName ?? "";
            currencyData.EuroRate = entity.EuroRate ?? "";
            currencyData.IsActive = entity.IsActive ?? false;
            return currencyData;
        }

        #endregion

        #region Customer

        public static CustomerBusinessHierarchyDto MapToCustomerBusinessHierarchyDto(this DbCustomerBusinessHierarchy entity)
        {
            CustomerBusinessHierarchyDto dto = new CustomerBusinessHierarchyDto();
            dto.Id = entity.Id;
            dto.CustomerBusinessGroupCode = entity.CustomerBusinessGroupCode;
            dto.CustomerBusinessGroupName = entity.CustomerBusinessGroupName;
            dto.SEWSEBusinessTeam = entity.SEWSEBusinessTeam;
            dto.IsActive = entity.IsActive;
            return dto;
        }

        public static CustomerData MapToCustomerData(this CustomerBusinessHierarchyDto entity)
        {
            CustomerData customerData = new CustomerData();
            customerData.Id = entity.Id.ToString();
            customerData.CustomerBusinessGroupCode = entity.CustomerBusinessGroupCode ?? "";
            customerData.CustomerBusinessGroupName = entity.CustomerBusinessGroupName ?? "";
            customerData.SEWSEBusinessTeam = entity.SEWSEBusinessTeam ?? "";
            customerData.IsActive = entity.IsActive ?? false;
            return customerData;
        }

        public static CustomerHierarchyDto MapToCustomerHierarchyDto(this DbCustomerHierarchy entity)
        {
            CustomerHierarchyDto dto = new CustomerHierarchyDto();

            dto.Id = entity.Id;
            dto.CustomerCode = entity.CustomerCode;
            dto.CustomerName = entity.CustomerName;
            dto.StreetNumber = entity.StreetNumber;
            dto.StreetName = entity.StreetName;
            dto.City = entity.City;
            dto.Region = entity.Region;
            dto.ZipCode = entity.ZipCode;
            dto.Country = entity.Country;
            dto.CustomerBusinessType = entity.CustomerBusinessType;
            dto.IndexedMaterial = entity.IndexedMaterial;
            dto.CustomerBusinessHierarchyGuid = entity.CustomerBusinessHierarchyGuid;
            dto.CustomerBusinessQualityManagerName = entity.CustomerBusinessQualityManagerName;
            dto.CustomerCountryGuid = entity.CustomerCountryGuid;
            dto.IsActive = entity.IsActive;
            return dto;
        }

        public static CustomerLocationData MapToCustomerLocationData(this CustomerHierarchyDto entity)
        {
            CustomerLocationData locationData = new CustomerLocationData();
            locationData.Id = entity.Id.ToString();
            locationData.CustomerCode = entity.CustomerCode ?? "";
            locationData.CustomerName = entity.CustomerName ?? "";
            locationData.IsActive = entity.IsActive ?? false;
            return locationData;
        }

        public static CustomerSalesEntityDto MapToCustomerSalesEntityDto(this DbCustomerSalesEntity entity)
        {
            CustomerSalesEntityDto dto = new CustomerSalesEntityDto();
            dto.Id = entity.Id;
            dto.CustomerSalesEntityCode = entity.CustomerSalesEntityCode;
            dto.CustomerSalesEntityName = entity.CustomerSalesEntityName;
            dto.FinanceCode = entity.FinanceCode;
            dto.StreetNumber = entity.StreetNumber;
            dto.StreetName = entity.StreetName;
            dto.City = entity.City;
            dto.Region = entity.Region;
            dto.ZipCode = entity.ZipCode;
            dto.Country = entity.Country;
            dto.CustomerHierarchyGuid = entity.CustomerHierarchyGuid;
            dto.CustomerSalesCountryGuid = entity.CustomerSalesCountryGuid;
            dto.IsActive = entity.IsActive;
            return dto;
        }

        public static CustomerSalesEntityData MapToCustomerSalesEntityData(this CustomerSalesEntityDto entity)
        {
            CustomerSalesEntityData salesEntity = new CustomerSalesEntityData();
            salesEntity.Id = entity.Id.ToString();
            salesEntity.CustomerSalesEntityCode = entity.CustomerSalesEntityCode ?? "";
            salesEntity.CustomerSalesEntityName = entity.CustomerSalesEntityName ?? "";
            salesEntity.FinanceCode = entity.FinanceCode ?? "";
            salesEntity.IsActive = entity.IsActive ?? false;
            return salesEntity;
        }

        public static CustomerProjectAssociationDto MapToCustomerProjectAssociationDto(this DbCustomerProjectAssociation entity)
        {
            CustomerProjectAssociationDto dto = new CustomerProjectAssociationDto();
            dto.Id = entity.Id;
            dto.CustomerLocationGuid = entity.CustomerGuid;
            dto.ProjectGuid = entity.ProjectGuid;
            dto.IsActive = entity.IsActive;
            return dto;
        }

        public static CustomerProjectAssociationData MapToCustomerProjectAssociationData(this CustomerProjectAssociationDto entity)
        {
            CustomerProjectAssociationData projectAssociationData = new CustomerProjectAssociationData();
            projectAssociationData.Id = entity.Id.ToString();
            projectAssociationData.CustomerLocationGuid = entity.CustomerLocationGuid.ToString();
            projectAssociationData.ProjectGuid = entity.ProjectGuid.ToString();
            projectAssociationData.IsActive = entity.IsActive ?? false;
            return projectAssociationData;
        }

        public static CustomerBusinessUserAssociationDto MapToCustomerBusinessUserAssociationDto(this DbCustomerBusinessUserAssociation entity)
        {
            CustomerBusinessUserAssociationDto dto = new CustomerBusinessUserAssociationDto();
            dto.Id = entity.Id;
            dto.CustomerBusinessHierarchyList = entity.CustomerBusinessHierarchyList;
            dto.UserGuid = entity.UserGuid;
            dto.IsActive = entity.IsActive;
            return dto;
        }

        public static CustomerBusinessUserAssociationData MapToCustomerBusinessUserAssociationData(this CustomerBusinessUserAssociationDto entity)
        {
            CustomerBusinessUserAssociationData userAssociationData = new CustomerBusinessUserAssociationData();
            userAssociationData.Id = entity.Id.ToString();
            userAssociationData.CustomerBusinessHierarchyList = entity.CustomerBusinessHierarchyList ?? "";
            userAssociationData.UserGuid = entity.UserGuid.ToString();
            userAssociationData.IsActive = entity.IsActive ?? false;
            return userAssociationData;
        }

        #endregion

        #region Project

        public static MilestoneHierarchyDto MapToDto(this DbMilestoneHierarchy entity)
        {
            MilestoneHierarchyDto dto = new MilestoneHierarchyDto();
            dto.Id = entity.Id;
            dto.MilestoneEventName = entity.MilestoneEventName;
            dto.EventStartDate = entity.EventStartDate;
            dto.EventEndDate = entity.EventEndDate;
            dto.ProjectHierarchyGuid = entity.ProjectHierarchyGuid;
            dto.IsActive = entity.IsActive;
            return dto;
        }

        public static MilestoneData MapToData(this MilestoneHierarchyDto entity)
        {
            MilestoneData milestoneData = new MilestoneData();
            milestoneData.Id = entity.Id.ToString();
            milestoneData.MilestoneEventName = entity.MilestoneEventName ?? "";
            milestoneData.EventStartDate = entity.EventStartDate?.ToUniversalTime().ToTimestamp();
            milestoneData.EventEndDate = entity.EventEndDate?.ToUniversalTime().ToTimestamp();
            milestoneData.ProjectHierarchyGuid = entity.ProjectHierarchyGuid.ToString();
            milestoneData.IsActive = entity.IsActive ?? false;
            return milestoneData;
        }

        public static PlatformHierarchyDto MapToDto(this DbPlatformHierarchy entity)
        {
            PlatformHierarchyDto dto = new PlatformHierarchyDto();
            dto.Id = entity.Id;
            dto.PlatformName = entity.PlatformName;
            dto.CustomerHierarchyGuid = entity.CustomerHierarchyGuid;
            dto.PlatformManagerName = entity.PlatformManagerName;
            dto.IsActive = entity.IsActive;
            return dto;
        }

        public static PlatformData MapToData(this PlatformHierarchyDto entity)
        {
            PlatformData platformData = new PlatformData();
            platformData.Id = entity.Id.ToString();
            platformData.PlatformName = entity.PlatformName ?? "";
            platformData.CustomerHierarchyGuid = entity.CustomerHierarchyGuid.ToString();
            platformData.PlatformManagerName = entity.PlatformManagerName ?? "";
            platformData.IsActive = entity.IsActive ?? false;
            return platformData;
        }

        public static ProgramHierarchyDto MapToDto(this DbProgramHierarchy entity)
        {
            ProgramHierarchyDto dto = new ProgramHierarchyDto();
            dto.Id = entity.Id;
            dto.ProgramName = entity.ProgramName;
            dto.PlatformHierarchyGuid = entity.PlatformHierarchyGuid;
            dto.IsActive = entity.IsActive;
            return dto;
        }

        public static ProgramData MapToData(this ProgramHierarchyDto entity)
        {
            ProgramData programData = new ProgramData();
            programData.Id = entity.Id.ToString();
            programData.ProgramName = entity.ProgramName ?? "";
            programData.PlatformHierarchyGuid = entity.PlatformHierarchyGuid.ToString();
            programData.IsActive = entity.IsActive ?? false;
            return programData;
        }

        public static ProjectHierarchyDto MapToDto(this DbProjectHierarchy entity)
        {
            ProjectHierarchyDto dto = new ProjectHierarchyDto();
            dto.Id = entity.Id;
            dto.ProjectCode = entity.ProjectCode;
            dto.ProjectName = entity.ProjectName;
            dto.CustomerProjectCode = entity.CustomerProjectCode;
            dto.ProjectDescription = entity.ProjectDescription;
            dto.ProjectAnnualVolume = entity.ProjectAnnualVolume;
            dto.ProgramHierarchyGuid = entity.ProgramHierarchyGuid;
            dto.IsActive = entity.IsActive;
            return dto;
        }

        public static ProjectData MapToData(this ProjectHierarchyDto entity)
        {
            ProjectData projectData = new ProjectData();
            projectData.Id = entity.Id.ToString();
            projectData.ProjectCode = entity.ProjectCode ?? "";
            projectData.ProjectName = entity.ProjectName ?? "";
            projectData.CustomerProjectCode = entity.CustomerProjectCode ?? "";
            projectData.ProjectDescription = entity.ProjectDescription ?? "";
            projectData.ProjectAnnualVolume = entity.ProjectAnnualVolume ?? 0;
            projectData.ProgramHierarchyGuid = entity.ProgramHierarchyGuid.ToString();
            projectData.IsActive = entity.IsActive ?? false;
            return projectData;
        }

        #endregion

        #region Vehicle

        public static VehicleDto MapToDto(this DbVehicle entity)
        {
            VehicleDto dto = new VehicleDto();
            dto.Id = entity.Id;
            dto.VehicleName = entity.VehicleName;
            dto.ProjectReference = entity.ProjectReference;
            dto.VehicleDisplay = entity.VehicleDisplay;
            dto.IsActive = entity.IsActive;
            return dto;
        }

        public static VehicleData MapToData(this VehicleDto entity)
        {
            VehicleData vehicleData = new VehicleData();
            vehicleData.Id = entity.Id.ToString();
            vehicleData.VehicleName = entity.VehicleName ?? "";
            vehicleData.ProjectReference = entity.ProjectReference ?? "";
            vehicleData.VehicleDisplay = entity.VehicleDisplay ?? "";
            vehicleData.IsActive = entity.IsActive ?? false;
            return vehicleData;
        }

        #endregion
    }
}
