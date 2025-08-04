
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
        DailyVolumeDataListViewGrpc _DailyVolumeGrpcs; 
        CalculationTypeListViewGrpc _CalculationTypeGrpcs;
          #endregion

        #region Fields and Properties

        bool _CarModelRefreshInProgress;
        readonly IServiceProvider _ServiceProvider;
        readonly IQueryHandler<GetAllCarModelQuery, List<CarModelViewGrpc>> _CarModelQueryHandler;
        readonly IQueryHandler<GetProfileQuery, List<ProfileViewGrpc>> _ProfileQueryHandler;
        readonly IQueryHandler<GetPeriodQuery, List<PeriodViewGrpc>> _PeriodQueryHandler;
        readonly IQueryHandler<GetAllCustomerQuery, List<CustomerViewGrpc>> _CustomerQueryHandler;
        readonly IQueryHandler<GetSiteQuery, List<SiteViewGrpc>> _SiteQueryHandler;
        readonly IQueryHandler<GetForecastQuery, List<ForecastViewGrpc>> _ForecastQueryHandler;
        readonly IQueryHandler<GetMonthlyVolumeDataQuery, List<MonthlyVolumeDataViewGrpc>> _MonthlyQueryHandler;
        readonly IQueryHandler<GetCustomerNonWorkingDaysQuery, List<CustomerNonWorkingDayViewGrpc>> _CustomerCalendarQueryHandler;
        readonly IQueryHandler<GetDailyVolumeDataQuery, List<DailyVolumeDataViewGrpc>> _DailyQueryHandler;
        readonly IQueryHandler<GetCalculationTypeQuery, List<CalculationTypeViewGrpc>> _CalculationQueryHandler;
        #endregion

        public SFSAccessService(
            IServiceProvider serviceProvider,
            IQueryHandler<GetAllCarModelQuery, List<CarModelViewGrpc>> carModelQueryHandler,
            IQueryHandler<GetProfileQuery, List<ProfileViewGrpc>> profileQueryHandler,
            IQueryHandler<GetPeriodQuery, List<PeriodViewGrpc>> periodQueryHandler,
            IQueryHandler<GetAllCustomerQuery, List<CustomerViewGrpc>> customerQueryHandler,
            IQueryHandler<GetSiteQuery, List<SiteViewGrpc>> siteQueryHandler,
            IQueryHandler<GetForecastQuery, List<ForecastViewGrpc>> forecastQueryHandler,
            IQueryHandler<GetMonthlyVolumeDataQuery, List<MonthlyVolumeDataViewGrpc>> monthlyQueryHandler,
            IQueryHandler<GetCustomerNonWorkingDaysQuery, List<CustomerNonWorkingDayViewGrpc>> customerCalendarQueryHandler,
             IQueryHandler<GetDailyVolumeDataQuery, List<DailyVolumeDataViewGrpc>> dailyQueryHandler,
             IQueryHandler<GetCalculationTypeQuery, List<CalculationTypeViewGrpc>> calculationQueryHandler,
        bool testing = false)
        {
            _CalculationQueryHandler = calculationQueryHandler;
            _CustomerCalendarQueryHandler = customerCalendarQueryHandler;
            _DailyQueryHandler = dailyQueryHandler;
            _CustomerQueryHandler = customerQueryHandler;
            _SiteQueryHandler = siteQueryHandler;
            _ForecastQueryHandler = forecastQueryHandler;
            _MonthlyQueryHandler = monthlyQueryHandler;
            _PeriodQueryHandler = periodQueryHandler;
            _ProfileQueryHandler = profileQueryHandler;
            _CarModelQueryHandler = carModelQueryHandler;
            _CarModelGrpcs = new CarModelListViewGrpc();
            _ProfileGrpcs = new ProfileListViewGrpc();
            _PeriodGrpcs = new PeriodListViewGrpc();
            _CustomerGrpcs = new CustomerListViewGrpc();
            _SiteGrpcs = new SiteListViewGrpc();
            _ForecastGrpcs = new ForecastListViewGrpc();
            _MonthlyVolumeGrpcs = new MonthlyVolumeDataListViewGrpc();
            _CustomerNonWorkingDayGrpcs = new CustomerNonWorkingDayListViewGrpc();
            _DailyVolumeGrpcs = new DailyVolumeDataListViewGrpc();
            _CalculationTypeGrpcs = new CalculationTypeListViewGrpc();
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
                _DailyVolumeGrpcs = new DailyVolumeDataListViewGrpc();
                _CalculationTypeGrpcs = new CalculationTypeListViewGrpc();
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
             GetAllCarModelQuery getAllCarModelQuery = new GetAllCarModelQuery();
             Result<List<CarModelViewGrpc>> result = await _CarModelQueryHandler.Handle(getAllCarModelQuery, cancellationToken);
            _CarModelGrpcs = new CarModelListViewGrpc();
            _CarModelGrpcs.Items.AddRange(result.Value);

            return _CarModelGrpcs;
        }

        public async Task<ProfileListViewGrpc> GetAllProfiles(CancellationToken cancellationToken)
        {
            GetProfileQuery getprofileModelQuery = new GetProfileQuery();
            Result<List<ProfileViewGrpc>> result = await _ProfileQueryHandler.Handle(getprofileModelQuery, cancellationToken);
            _ProfileGrpcs = new ProfileListViewGrpc();
            _ProfileGrpcs.Items.AddRange(result.Value);

            return _ProfileGrpcs;
        }

        public async Task<PeriodListViewGrpc> GetAllPeriods(CancellationToken cancellationToken)
        {
            //await Task.Delay(1, cancellationToken);
            //return _PeriodGrpcs;
            GetPeriodQuery getperiodModelQuery = new GetPeriodQuery();
            Result<List<PeriodViewGrpc>> result = await _PeriodQueryHandler.Handle(getperiodModelQuery, cancellationToken);
            _PeriodGrpcs = new PeriodListViewGrpc();
            _PeriodGrpcs.Items.AddRange(result.Value);

            return _PeriodGrpcs;
        }

        public async Task<CustomerListViewGrpc> GetAllCustomers(CancellationToken cancellationToken)
        {
            //await Task.Delay(1, cancellationToken);
            //return _CustomerGrpcs;
            GetAllCustomerQuery getcustomerModelQuery = new GetAllCustomerQuery();
            Result<List<CustomerViewGrpc>> result = await _CustomerQueryHandler.Handle(getcustomerModelQuery, cancellationToken);
            _CustomerGrpcs = new CustomerListViewGrpc();
            _CustomerGrpcs.Items.AddRange(result.Value);
            return _CustomerGrpcs;
        }

        public async Task<SiteListViewGrpc> GetAllSites(CancellationToken cancellationToken)
        {
            //await Task.Delay(1, cancellationToken);
            //return _SiteGrpcs;
            GetSiteQuery getsiteModelQuery = new GetSiteQuery();
            Result<List<SiteViewGrpc>> result = await _SiteQueryHandler.Handle(getsiteModelQuery, cancellationToken);
            _SiteGrpcs = new SiteListViewGrpc();
            _SiteGrpcs.Items.AddRange(result.Value);
            return _SiteGrpcs;
        }

        public async Task<ForecastListViewGrpc> GetAllForecasts(CancellationToken cancellationToken)
        {
            //await Task.Delay(1, cancellationToken);
            //return _ForecastGrpcs;
            GetForecastQuery getcforecastModelQuery = new GetForecastQuery();
            Result<List<ForecastViewGrpc>> result = await _ForecastQueryHandler.Handle(getcforecastModelQuery, cancellationToken);
            _ForecastGrpcs = new ForecastListViewGrpc();
            _ForecastGrpcs.Items.AddRange(result.Value);
            return _ForecastGrpcs;
        }

        public async Task<MonthlyVolumeDataListViewGrpc> GetMonthlyVolumes(CancellationToken cancellationToken)
        {
            //await Task.Delay(1, cancellationToken);
            //return _MonthlyVolumeGrpcs;
            GetMonthlyVolumeDataQuery getmonthlyModelQuery = new GetMonthlyVolumeDataQuery();
            Result<List<MonthlyVolumeDataViewGrpc>> result = await _MonthlyQueryHandler.Handle(getmonthlyModelQuery, cancellationToken);
            _MonthlyVolumeGrpcs = new MonthlyVolumeDataListViewGrpc();
            _MonthlyVolumeGrpcs.Items.AddRange(result.Value);
            return _MonthlyVolumeGrpcs;
        }

        public async Task<CustomerNonWorkingDayListViewGrpc> GetCustomerNonWorkingDay(CancellationToken cancellationToken)
        {
            //await Task.Delay(1, cancellationToken);
            //return _CustomerNonWorkingDayGrpcs;
            GetCustomerNonWorkingDaysQuery getcustomerCalendarModelQuery = new GetCustomerNonWorkingDaysQuery();
            Result<List<CustomerNonWorkingDayViewGrpc>> result = await _CustomerCalendarQueryHandler.Handle(getcustomerCalendarModelQuery, cancellationToken);
            _CustomerNonWorkingDayGrpcs = new CustomerNonWorkingDayListViewGrpc();
            _CustomerNonWorkingDayGrpcs.Items.AddRange(result.Value);
            return _CustomerNonWorkingDayGrpcs;
        }

        public async Task<CalculationTypeListViewGrpc> GetAllCalculationTypes(CancellationToken cancellationToken)
        {
            //await Task.Delay(1, cancellationToken);
            //return _CalculationTypeGrpcs;
            GetCalculationTypeQuery getcalculationModelQuery = new GetCalculationTypeQuery();
            Result<List<CalculationTypeViewGrpc>> result = await _CalculationQueryHandler.Handle(getcalculationModelQuery, cancellationToken);
            _CalculationTypeGrpcs = new CalculationTypeListViewGrpc();
            _CalculationTypeGrpcs.Items.AddRange(result.Value);
            return _CalculationTypeGrpcs;
        }

        public async Task<DailyVolumeDataListViewGrpc> GetAllDailyVolumes(CancellationToken cancellationToken)
        {
            //await Task.Delay(1, cancellationToken);
            //return _DailyVolumeGrpcs;
            GetDailyVolumeDataQuery getdailyModelQuery = new GetDailyVolumeDataQuery();
            Result<List<DailyVolumeDataViewGrpc>> result = await _DailyQueryHandler.Handle(getdailyModelQuery, cancellationToken);
            _DailyVolumeGrpcs = new DailyVolumeDataListViewGrpc();
            _DailyVolumeGrpcs.Items.AddRange(result.Value);
            return _DailyVolumeGrpcs;
        }
    }
}
