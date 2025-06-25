namespace Master.Services
{
    public interface IMasterAccessService
    {
        #region Currency
        Task<ListCurrencyData> GetAllCurrencies(CancellationToken cancellationToken);
        Task<ListCurrencyData> GetCurrenciesById(string id ,CancellationToken cancellationToken);
        Task<bool> PopulateCurrenciesAsync(CancellationToken cancellationToken);
        #endregion

        #region Customer

        Task<ListCustomerData> GetAllCustomerBusinessUnits(CancellationToken cancellationToken);
        Task<ListCustomerData> GetCustomerBusinessUnitsById(string id ,CancellationToken cancellationToken);
        Task<bool> PopulateCustomersAsync(CancellationToken cancellationToken);
        Task<ListCustomerLocationData> GetAllCustomerLocations(CancellationToken cancellationToken);
        Task<ListCustomerLocationData> GetCustomerLocationsById(string id, CancellationToken cancellationToken);
        Task<ListCustomerLocationData> GetCustomerLocationsByUserId(string userId, CancellationToken cancellationToken);
        Task<bool> PopulateCustomerLocationsAsync(CancellationToken cancellationToken);
        Task<ListCustomerProjectAssociationData> GetAllCustomerProjectAssociations(CancellationToken cancellationToken);
        Task<ListCustomerProjectAssociationData> GetAllCustomerProjectAssociationsByUserId(string userId,CancellationToken cancellationToken);
        Task<bool> PopulateCustomerProjectAssociationsAsync(CancellationToken cancellationToken);
        Task<ListCustomerSalesEntityData> GetAllCustomerSalesEntities(CancellationToken cancellationToken);
        Task<ListCustomerSalesEntityData> GetAllCustomerSalesByUserIdEntities(string userId, CancellationToken cancellationToken);
        Task<bool> PopulateCustomerSalesEntitiesAsync(CancellationToken cancellationToken);
        Task<ListCustomerBusinessUserAssociationData> GetCustomerBusinessUserAssociations(CancellationToken cancellationToken);
        Task<ListCustomerBusinessUserAssociationData> GetCustomerBusinessUserAssociationsByUserId(string userId, CancellationToken cancellationToken);
        Task<bool> PopulateCustomerBusinessUserAssociationsAsync(CancellationToken cancellationToken);

        #endregion

        #region Project

        Task<ListPlatformData> GetAllPlatforms(CancellationToken cancellationToken);
        Task<ListPlatformData> GetPlatformsById(string id,CancellationToken cancellationToken);
        Task<bool> PopulatePlatformsAsync(CancellationToken cancellationToken);
        Task<ListProgramData> GetAllPrograms(CancellationToken cancellationToken);
        Task<ListProgramData> GetProgramsById(string id, CancellationToken cancellationToken);
        Task<bool> PopulateProgramsAsync(CancellationToken cancellationToken);
        Task<ListProjectData> GetAllProjects(CancellationToken cancellationToken);
        Task<ListProjectData> GetProjectsById(string id, CancellationToken cancellationToken);
        Task<bool> PopulateProjectsAsync(CancellationToken cancellationToken);
        Task<ListMilestoneData> GetAllMilestones(CancellationToken cancellationToken);
        Task<ListMilestoneData> GetMilestonesById(string id, CancellationToken cancellationToken);
        Task<bool> PopulateMilestonesAsync(CancellationToken cancellationToken);

        #endregion

        #region Vehicle

        Task<ListVehicleData> GetAllVehicles(CancellationToken cancellationToken);
        Task<bool> PopulateVehiclesAsync(CancellationToken cancellationToken);
        Task<ListVehicleData> GetVehiclesById(string id, CancellationToken cancellationToken);
        Task<ListVehicleData> GetVehiclesByDisplay(string vehicleDisplay, CancellationToken cancellationToken);

        #endregion
    }
}
