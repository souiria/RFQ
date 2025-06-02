namespace Master.Services
{
    public interface IMasterAccessService
    {
        #region Currency
        Task<Result<List<CurrencyDto>>> GetAllCurrencies(CancellationToken cancellationToken);
        Task<bool> PopulateCurrenciesAsync(CancellationToken cancellationToken);
        #endregion

        #region Customer

        Task<Result<List<CustomerBusinessHierarchyDto>>> GetAllCustomerBusinessUnits(CancellationToken cancellationToken);
        Task<Result<List<CustomerBusinessHierarchyDto>>> GetCustomerBusinessUnitsById(Guid id ,CancellationToken cancellationToken);
        Task<bool> PopulateCustomersAsync(CancellationToken cancellationToken);
        Task<Result<List<CustomerHierarchyDto>>> GetAllCustomerLocations(CancellationToken cancellationToken);
        Task<Result<List<CustomerHierarchyDto>>> GetCustomerLocationsById(Guid id, CancellationToken cancellationToken);
        Task<Result<List<CustomerHierarchyDto>>> GetCustomerLocationsByUserId(Guid userId, CancellationToken cancellationToken);
        Task<bool> PopulateCustomerLocationsAsync(CancellationToken cancellationToken);
        Task<Result<List<CustomerProjectAssociationDto>>> GetAllCustomerProjectAssociations(CancellationToken cancellationToken);
        Task<Result<List<CustomerProjectAssociationDto>>> GetAllCustomerProjectAssociationsByUserId(Guid userId,CancellationToken cancellationToken);
        Task<bool> PopulateCustomerProjectAssociationsAsync(CancellationToken cancellationToken);
        Task<Result<List<CustomerSalesEntityDto>>> GetAllCustomerSalesEntities(CancellationToken cancellationToken);
        Task<Result<List<CustomerSalesEntityDto>>> GetAllCustomerSalesByUserIdEntities(Guid userId, CancellationToken cancellationToken);
        Task<bool> PopulateCustomerSalesEntitiesAsync(CancellationToken cancellationToken);
        Task<Result<List<CustomerBusinessUserAssociationDto>>> GetCustomerBusinessUserAssociations(CancellationToken cancellationToken);
        Task<Result<List<CustomerBusinessUserAssociationDto>>> GetCustomerBusinessUserAssociationsByUserId(Guid userId, CancellationToken cancellationToken);
        Task<bool> PopulateCustomerBusinessUserAssociationsAsync(CancellationToken cancellationToken);

        #endregion

        #region Project

        Task<Result<List<PlatformHierarchyDto>>> GetAllPlatforms(CancellationToken cancellationToken);
        Task<Result<List<PlatformHierarchyDto>>> GetPlatformsById(Guid id,CancellationToken cancellationToken);
        Task<bool> PopulatePlatformsAsync(CancellationToken cancellationToken);
        Task<Result<List<ProgramHierarchyDto>>> GetAllPrograms(CancellationToken cancellationToken);
        Task<Result<List<ProgramHierarchyDto>>> GetProgramsById(Guid id, CancellationToken cancellationToken);
        Task<bool> PopulateProgramsAsync(CancellationToken cancellationToken);
        Task<Result<List<ProjectHierarchyDto>>> GetAllProjects(CancellationToken cancellationToken);
        Task<Result<List<ProjectHierarchyDto>>> GetProjectsById(Guid id, CancellationToken cancellationToken);
        Task<bool> PopulateProjectsAsync(CancellationToken cancellationToken);
        Task<Result<List<MilestoneHierarchyDto>>> GetAllMilestones(CancellationToken cancellationToken);
        Task<Result<List<MilestoneHierarchyDto>>> GetMilestonesById(Guid id, CancellationToken cancellationToken);
        Task<bool> PopulateMilestonesAsync(CancellationToken cancellationToken);

        #endregion

        #region Vehicle

        Task<Result<List<VehicleDto>>> GetAllVehicles(CancellationToken cancellationToken);
        Task<bool> PopulateVehiclesAsync(CancellationToken cancellationToken);

        #endregion
    }
}
