namespace SFS.Data.Interface
{
   public interface ISFSDbContext
    {
        DbSet<DbCalculationType> CalculationItems
        { get; }
        DbSet<DbCarModel> CarItems
        { get; }
        DbSet<DbCustomer> CustomerItems
        { get; }
        DbSet<DbCustomerNonWorkingDays> CustomerNonWorkingDaysItems
        { get; }
        DbSet<DbDailyVolumeData> DailyVolumeDataItems
        { get; }
        DbSet<DbForecast> ForecastItems
        { get; }
        DbSet<DbMonthlyVolumeData> MonthlyVolumeDataItems
        { get; }
        DbSet<DbPeriod> PeriodItems
        { get; }
        DbSet<DbProfile> ProfileItems
        { get; }
        DbSet<DbSite> SiteItems
        { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
