namespace SFS.Services
{
    public class SFSAccessService : ISFSAccessService
    {
        #region In Memory Datasets

        CarModelListViewGrpc _CarModelGrpcs;
        ProfileListViewGrpc _ProfileGrpcs;
        PeriodListViewGrpc _PeriodGrpcs;
        CustomerListViewGrpc _CustomerGrpcs;
        SiteListViewGrpc _SiteGrpcs;
        ForecastListViewGrpc _ForecastGrpcs;
        MonthlyVolumeDataListViewGrpc _MonthlyVolumeGrpcs;
        CustomerNonWorkingDayListViewGrpc _CustomerNonWorkingDayGrpcs;
        DailyVolumeDataListViewGrpc _DailyVolumeDataListViewGrpc;
        CalculationTypeListViewGrpc _CalculationTypeListViewGrpc;

        #endregion

        #region Fields and Properties

        bool _CarModelRefreshInProgress;
        readonly IServiceProvider _ServiceProvider;

        #endregion

        public SFSAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            _CarModelGrpcs = new CarModelListViewGrpc();
            _ProfileGrpcs = new ProfileListViewGrpc();
            _PeriodGrpcs = new PeriodListViewGrpc();
            _CustomerGrpcs = new CustomerListViewGrpc();
            _SiteGrpcs = new SiteListViewGrpc();
            _ForecastGrpcs = new ForecastListViewGrpc();
            _MonthlyVolumeGrpcs = new MonthlyVolumeDataListViewGrpc();
            _CustomerNonWorkingDayGrpcs = new CustomerNonWorkingDayListViewGrpc();
            _DailyVolumeDataListViewGrpc = new DailyVolumeDataListViewGrpc();
            _CalculationTypeListViewGrpc = new CalculationTypeListViewGrpc();
            _CarModelRefreshInProgress = false;

            _ServiceProvider = serviceProvider;

            if (testing)
            {
                _CarModelGrpcs = new CarModelListViewGrpc();
                _ProfileGrpcs = new ProfileListViewGrpc();
                _PeriodGrpcs = new PeriodListViewGrpc();
                _CustomerGrpcs = new CustomerListViewGrpc();
                _SiteGrpcs = new SiteListViewGrpc();
                _ForecastGrpcs = new ForecastListViewGrpc();
                _MonthlyVolumeGrpcs = new MonthlyVolumeDataListViewGrpc();
                _CustomerNonWorkingDayGrpcs = new CustomerNonWorkingDayListViewGrpc();
                _DailyVolumeDataListViewGrpc = new DailyVolumeDataListViewGrpc();
                _CalculationTypeListViewGrpc = new CalculationTypeListViewGrpc();
            }
        }

        async Task<bool> PopulateCarModelData(CancellationToken cancellationToken)
        {
            // TBD: Implement database loading logic here.
            await Task.Delay(1, cancellationToken);

            if (!_CarModelRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CarModelRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        public async Task<CarModelListViewGrpc> GetAllCarModel(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            await PopulateCarModelData(cancellationToken);
            return _CarModelGrpcs;
        }

        public async Task<ProfileListViewGrpc> GetAllProfiles(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            await PopulateCarModelData(cancellationToken);
            return _ProfileGrpcs;
        }

        public async Task<PeriodListViewGrpc> GetAllPeriods(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _PeriodGrpcs;
        }

        public async Task<CustomerListViewGrpc> GetAllCustomers(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _CustomerGrpcs;
        }

        public async Task<SiteListViewGrpc> GetAllSites(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _SiteGrpcs;
        }

        public async Task<ForecastListViewGrpc> GetAllForecasts(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _ForecastGrpcs;
        }

        public async Task<MonthlyVolumeDataListViewGrpc> GetMonthlyVolumes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _MonthlyVolumeGrpcs;
        }

        public async Task<CustomerNonWorkingDayListViewGrpc> GetCustomerNonWorkingDay(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _CustomerNonWorkingDayGrpcs;
        }

        public async Task<CalculationTypeListViewGrpc> GetCalculationType(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _CalculationTypeListViewGrpc;
        }

        public async Task<DailyVolumeDataListViewGrpc> GetDailyVolumeData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _DailyVolumeDataListViewGrpc;
        }
    }
}
