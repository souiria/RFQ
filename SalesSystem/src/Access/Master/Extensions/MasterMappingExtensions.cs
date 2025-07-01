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
    }
}
