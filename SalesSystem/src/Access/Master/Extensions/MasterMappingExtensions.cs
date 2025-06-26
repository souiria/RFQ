using System.Reflection.Emit;

namespace Master.Extensions
{
    public static class MasterMappingExtensions
    {
        #region Currency

        public static CurrencyData MapToCurrencyData(this DbCurrency entity)
        {
            CurrencyData data = new CurrencyData();
            data.Id = entity.Id.ToString();
            data.CurrencyCode = entity.CurrencyCode;
            data.CurrencyName = entity.CurrencyName;
            data.EuroRate = entity.EuroRate;
            data.IsActive = entity.IsActive;
            return data;
        }

        #endregion

        #region Customer

        public static CustomerData MapToCustomerData(this DbCustomerBusinessHierarchy entity)
        {
            CustomerData data = new CustomerData();
            data.Id = entity.Id.ToString();
            data.CustomerBusinessGroupCode = entity.CustomerBusinessGroupCode;
            data.CustomerBusinessGroupName = entity.CustomerBusinessGroupName;
            data.SEWSEBusinessTeam = entity.SEWSEBusinessTeam;
            data.IsActive = entity.IsActive;
            return data;
        }

        public static CustomerLocationData MapToLocationData(this DbCustomerHierarchy entity)
        {
            CustomerLocationData data = new CustomerLocationData();

            data.Id = entity.Id.ToString();
            data.CustomerCode = entity.CustomerCode;
            data.CustomerBusinessHierarchyGuid = entity.CustomerBusinessHierarchyGuid.ToString();
            data.IsActive = entity.IsActive;
            return data;
        }

        public static CustomerSalesEntityData MapToCustomerSalesEntityDto(this DbCustomerSalesEntity entity)
        {
            CustomerSalesEntityData data = new CustomerSalesEntityData();
            data.Id = entity.Id.ToString();
            data.CustomerSalesEntityCode = entity.CustomerSalesEntityCode;
            data.CustomerSalesEntityName = entity.CustomerSalesEntityName;
            data.FinanceCode = entity.FinanceCode;
            data.CustomerHierarchyGuid = entity.CustomerHierarchyGuid.ToString();
            data.IsActive = entity.IsActive;
            return data;
        }

        public static CustomerProjectAssociationData MapToCustomerProjectAssociationDto(this DbCustomerProjectAssociation entity)
        {
            CustomerProjectAssociationData data = new CustomerProjectAssociationData();
            data.Id = entity.Id.ToString();
            data.CustomerLocationGuid = entity.CustomerGuid.ToString();
            data.ProjectGuid = entity.ProjectGuid.ToString();
            data.IsActive = entity.IsActive ?? false;
            return data;
        }

        public static CustomerBusinessUserAssociationData MapToCustomerBusinessUserAssociationDto(this DbCustomerBusinessUserAssociation entity)
        {
            CustomerBusinessUserAssociationData data = new CustomerBusinessUserAssociationData();
            data.Id = entity.Id.ToString();
            data.CustomerBusinessHierarchyList = entity.CustomerBusinessHierarchyList;
            data.UserGuid = entity.UserGuid.ToString();
            data.IsActive = entity.IsActive ?? false;
            return data;
        }

        #endregion

        #region Project

        public static MilestoneData MapToMilestoneData(this DbMilestoneHierarchy entity)
        {
            MilestoneData data = new MilestoneData();
            data.Id = entity.Id.ToString();
            data.MilestoneEventName = entity.MilestoneEventName;
            data.EventStartDate = entity.EventStartDate?.ToUniversalTime().ToTimestamp();
            data.EventEndDate = entity.EventEndDate?.ToUniversalTime().ToTimestamp();
            data.ProjectHierarchyGuid = entity.ProjectHierarchyGuid.ToString();
            data.IsActive = entity.IsActive;
            return data;
        }

        public static PlatformData MapToPlatformData(this DbPlatformHierarchy entity)
        {
            PlatformData data = new PlatformData();
            data.Id = entity.Id.ToString();
            data.PlatformName = entity.PlatformName;
            data.CustomerHierarchyGuid = entity.CustomerHierarchyGuid.ToString();
            data.PlatformManagerName = entity.PlatformManagerName;
            data.IsActive = entity.IsActive;
            return data;
        }

        public static ProgramData MapToProgramData(this DbProgramHierarchy entity)
        {
            ProgramData data = new ProgramData();
            data.Id = entity.Id.ToString();
            data.ProgramName = entity.ProgramName;
            data.PlatformHierarchyGuid = entity.PlatformHierarchyGuid.ToString();
            data.IsActive = entity.IsActive;
            return data;
        }

        public static ProjectData MapToProjectData(this DbProjectHierarchy entity)
        {
            ProjectData data = new ProjectData();
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

        #endregion

        #region Vehicle

        public static VehicleData MapToVehicleData(this DbVehicle entity)
        {
            VehicleData data = new VehicleData();
            data.Id = entity.Id.ToString();
            data.VehicleName = entity.VehicleName;
            data.ProjectReference = entity.ProjectReference;
            data.VehicleDisplay = entity.VehicleDisplay;
            data.IsActive = entity.IsActive;
            return data;
        }

        #endregion
    }
}
