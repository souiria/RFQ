using Master.Data.DTOs;
using Master.Data.Model;
using SharedKernel;

namespace Master.Extensions
{
    public static class MasterMappingExtensions
    {
        #region Currency

        public static CurrencyDto MapToCurrencyDto(this DbCurrency entity)
        {
            return new CurrencyDto
            {
                Id = entity.Id,
                CurrencyCode = entity.CurrencyCode,
                CurrencyName = entity.CurrencyName,
                EuroRate = entity.EuroRate,
                IsActive = entity.IsActive
            };
        }

        public static CurrencyData MapToCurrencyData(this CurrencyDto entity)
        {
            return new CurrencyData
            {
                Id = entity.Id.ToString(),
                CurrencyCode = entity.CurrencyCode ?? "",
                CurrencyName = entity.CurrencyName ?? "",
                EuroRate = entity.EuroRate ?? "",
                IsActive = entity.IsActive ?? false
            };
        }

        #endregion

        #region Customer

        public static CustomerBusinessHierarchyDto MapToCustomerBusinessHierarchyDto(this DbCustomerBusinessHierarchy entity)
        {
            return new CustomerBusinessHierarchyDto
            {
                Id = entity.Id,
                CustomerBusinessGroupCode = entity.CustomerBusinessGroupCode,
                CustomerBusinessGroupName = entity.CustomerBusinessGroupName,
                SEWSEBusinessTeam = entity.SEWSEBusinessTeam ?? "",
                IsActive = entity.IsActive
            };
        }

        public static CustomerData MapToCustomerData(this CustomerBusinessHierarchyDto entity)
        {
            return new CustomerData
            {
                Id = entity.Id.ToString(),
                CustomerBusinessGroupCode = entity.CustomerBusinessGroupCode ?? "",
                CustomerBusinessGroupName = entity.CustomerBusinessGroupName ?? "",
                SEWSEBusinessTeam = entity.SEWSEBusinessTeam ?? "",
                IsActive = entity.IsActive ?? false
            };
        }

        public static CustomerHierarchyDto MapToCustomerHierarchyDto(this DbCustomerHierarchy entity)
        {
            return new CustomerHierarchyDto
            {
                Id = entity.Id,
                CustomerCode = entity.CustomerCode,
                CustomerName = entity.CustomerName,
                StreetNumber = entity.StreetNumber,
                StreetName = entity.StreetName,
                City = entity.City,
                Region = entity.Region,
                ZipCode = entity.ZipCode,
                Country = entity.Country,
                CustomerBusinessType = entity.CustomerBusinessType,
                IndexedMaterial = entity.IndexedMaterial,
                CustomerBusinessHierarchyGuid = entity.CustomerBusinessHierarchyGuid,
                CustomerBusinessQualityManagerName = entity.CustomerBusinessQualityManagerName,
                CustomerCountryGuid = entity.CustomerCountryGuid,
                IsActive = entity.IsActive
            };
        }

        public static CustomerLocationData MapToCustomerLocationData(this CustomerHierarchyDto entity)
        {
            return new CustomerLocationData
            {
                Id = entity.Id.ToString(),
                CustomerCode = entity.CustomerCode ?? "",
                CustomerName = entity.CustomerName ?? "",
                IsActive = entity.IsActive ?? false
            };
        }

        public static CustomerSalesEntityDto MapToCustomerSalesEntityDto(this DbCustomerSalesEntity entity)
        {
            return new CustomerSalesEntityDto
            {
                CustomerSalesEntityCode = entity.CustomerSalesEntityCode,
                CustomerSalesEntityName = entity.CustomerSalesEntityName,
                FinanceCode = entity.FinanceCode,
                StreetNumber = entity.StreetNumber,
                StreetName = entity.StreetName,
                City = entity.City,
                Region = entity.Region,
                ZipCode = entity.ZipCode,
                Country = entity.Country,
                CustomerHierarchyGuid = entity.CustomerHierarchyGuid,
                Id = entity.Id,
                CustomerSalesCountryGuid = entity.CustomerSalesCountryGuid,
                IsActive = entity.IsActive
            };
        }

        public static CustomerSalesEntityData MapToCustomerSalesEntityData(this CustomerSalesEntityDto entity)
        {
            return new CustomerSalesEntityData
            {
                Id = entity.Id.ToString(),
                CustomerSalesEntityCode = entity.CustomerSalesEntityCode ?? "",
                CustomerSalesEntityName = entity.CustomerSalesEntityName ?? "",
                FinanceCode = entity.FinanceCode ?? "",
                IsActive = entity.IsActive ?? false
            };
        }

        public static CustomerProjectAssociationDto MapToCustomerProjectAssociationDto(this DbCustomerProjectAssociation entity)
        {
            return new CustomerProjectAssociationDto
            {
                Id = entity.Id,
                CustomerLocationGuid = entity.CustomerGuid,
                ProjectGuid = entity.ProjectGuid,
                IsActive = entity.IsActive
            };
        }

        public static CustomerProjectAssociationData MapToCustomerProjectAssociationData(this CustomerProjectAssociationDto entity)
        {
            return new CustomerProjectAssociationData
            {
                Id = entity.Id.ToString(),
                CustomerLocationGuid = entity.CustomerLocationGuid.ToString(),
                ProjectGuid = entity.ProjectGuid.ToString(),
                IsActive = entity.IsActive ?? false
            };
        }

        public static CustomerBusinessUserAssociationDto MapToCustomerBusinessUserAssociationDto(this DbCustomerBusinessUserAssociation entity)
        {
            return new CustomerBusinessUserAssociationDto
            {
                Id = entity.Id,
                CustomerBusinessHierarchyList = entity.CustomerBusinessHierarchyList,
                UserGuid = entity.UserGuid,
                IsActive = entity.IsActive
            };
        }

        public static CustomerBusinessUserAssociationData MapToCustomerBusinessUserAssociationData(this CustomerBusinessUserAssociationDto entity)
        {
            return new CustomerBusinessUserAssociationData
            {
                Id = entity.Id.ToString(),
                CustomerBusinessHierarchyList = entity.CustomerBusinessHierarchyList ?? "",
                UserGuid = entity.UserGuid.ToString(),
                IsActive = entity.IsActive ?? false
            };
        }

        #endregion

        #region Project

        public static MilestoneHierarchyDto MapToDto(this DbMilestoneHierarchy entity)
        {
            return new MilestoneHierarchyDto
            {
                Id = entity.Id,
                MilestoneEventName = entity.MilestoneEventName,
                EventStartDate = entity.EventStartDate,
                EventEndDate = entity.EventEndDate,
                ProjectHierarchyGuid = entity.ProjectHierarchyGuid,
                IsActive = entity.IsActive
            };
        }

        public static MilestoneData MapToData(this MilestoneHierarchyDto entity)
        {
            return new MilestoneData
            {
                Id = entity.Id.ToString(),
                MilestoneEventName = entity.MilestoneEventName ?? "",
                EventStartDate = entity.EventStartDate?.ToUniversalTime().ToTimestamp(),
                EventEndDate = entity.EventEndDate?.ToUniversalTime().ToTimestamp(),
                ProjectHierarchyGuid = entity.ProjectHierarchyGuid.ToString(),
                IsActive = entity.IsActive ?? false
            };
        }

        public static PlatformHierarchyDto MapToDto(this DbPlatformHierarchy entity)
        {
            return new PlatformHierarchyDto
            {
                Id = entity.Id,
                PlatformName = entity.PlatformName,
                CustomerHierarchyGuid = entity.CustomerHierarchyGuid,
                PlatformManagerName = entity.PlatformManagerName,
                IsActive = entity.IsActive
            };
        }

        public static PlatformData MapToData(this PlatformHierarchyDto entity)
        {
            return new PlatformData
            {
                Id = entity.Id.ToString(),
                PlatformName = entity.PlatformName ?? "",
                CustomerHierarchyGuid = entity.CustomerHierarchyGuid.ToString(),
                PlatformManagerName = entity.PlatformManagerName ?? "",
                IsActive = entity.IsActive ?? false
            };
        }

        public static ProgramHierarchyDto MapToDto(this DbProgramHierarchy entity)
        {
            return new ProgramHierarchyDto
            {
                Id = entity.Id,
                ProgramName = entity.ProgramName,
                PlatformHierarchyGuid = entity.PlatformHierarchyGuid,
                IsActive = entity.IsActive
            };
        }

        public static ProgramData MapToData(this ProgramHierarchyDto entity)
        {
            return new ProgramData
            {
                Id = entity.Id.ToString(),
                ProgramName = entity.ProgramName ?? "",
                PlatformHierarchyGuid = entity.PlatformHierarchyGuid.ToString(),
                IsActive = entity.IsActive ?? false
            };
        }

        public static ProjectHierarchyDto MapToDto(this DbProjectHierarchy entity)
        {
            return new ProjectHierarchyDto
            {
                Id = entity.Id,
                ProjectCode = entity.ProjectCode,
                ProjectName = entity.ProjectName,
                CustomerProjectCode = entity.CustomerProjectCode,
                ProjectDescription = entity.ProjectDescription,
                ProjectAnnualVolume = entity.ProjectAnnualVolume,
                ProgramHierarchyGuid = entity.ProgramHierarchyGuid,
                IsActive = entity.IsActive
            };
        }

        public static ProjectData MapToData(this ProjectHierarchyDto entity)
        {
            return new ProjectData
            {
                Id = entity.Id.ToString(),
                ProjectCode = entity.ProjectCode ?? "",
                ProjectName = entity.ProjectName ?? "",
                CustomerProjectCode = entity.CustomerProjectCode ?? "",
                ProjectDescription = entity.ProjectDescription ?? "",
                ProjectAnnualVolume = entity.ProjectAnnualVolume ?? 0,
                ProgramHierarchyGuid = entity.ProgramHierarchyGuid.ToString(),
                IsActive = entity.IsActive ?? false
            };
        }

        #endregion

        #region Vehicle

        public static VehicleDto MapToDto(this DbVehicle entity)
        {
            return new VehicleDto
            {
                Id = entity.Id,
                VehicleName = entity.VehicleName,
                ProjectReference = entity.ProjectReference,
                VehicleDisplay = entity.VehicleDisplay,
                IsActive = entity.IsActive
            };
        }

        public static VehicleData MapToData(this VehicleDto entity)
        {
            return new VehicleData
            {
                Id = entity.Id.ToString(),
                VehicleName = entity.VehicleName ?? "",
                ProjectReference = entity.ProjectReference ?? "",
                VehicleDisplay = entity.VehicleDisplay ?? "",
                IsActive = entity.IsActive ?? false
            };
        }

        #endregion
    }
}
