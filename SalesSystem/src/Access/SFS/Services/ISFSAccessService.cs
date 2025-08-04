namespace SFS.Services
{
    public interface ISFSAccessService
    {
        Task<CarModelListViewGrpc> GetAllCarModel(CancellationToken cancellationToken);
        Task<ProfileListViewGrpc> GetAllProfiles(CancellationToken cancellationToken);
        Task<PeriodListViewGrpc> GetAllPeriods(CancellationToken cancellationToken);
        Task<CustomerListViewGrpc> GetAllCustomers(CancellationToken cancellationToken);
        Task<SiteListViewGrpc> GetAllSites(CancellationToken cancellationToken);
        Task<ForecastListViewGrpc> GetAllForecasts(CancellationToken cancellationToken);
        Task<MonthlyVolumeDataListViewGrpc> GetMonthlyVolumes(CancellationToken cancellationToken);
        Task<CustomerNonWorkingDayListViewGrpc> GetCustomerNonWorkingDay(CancellationToken cancellationToken);
        Task<DailyVolumeDataListViewGrpc> GetAllDailyVolumes(CancellationToken cancellationToken);
        Task<CalculationTypeListViewGrpc> GetAllCalculationTypes(CancellationToken cancellationToken);
    }
}

