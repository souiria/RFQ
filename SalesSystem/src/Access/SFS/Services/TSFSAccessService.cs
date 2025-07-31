using Google.Protobuf;

namespace SFS.Services
{
    public class TSFSAccessService : ITSFSAccessService
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
        #endregion

        public TSFSAccessService(
            IServiceProvider serviceProvider,
        bool testing = false)
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
            await Task.Delay(1, cancellationToken);
            return _CarModelGrpcs;
      
        }

        public async Task<ProfileListViewGrpc> GetAllProfiles(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
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
            //GetAllCustomerQuery getcustomerModelQuery = new GetAllCustomerQuery();
            //Result<List<CustomerViewGrpc>> result = await _CustomerQueryHandler.Handle(getcustomerModelQuery, cancellationToken);
            //_CustomerGrpcs = new CustomerListViewGrpc();
            //_CustomerGrpcs.Items.AddRange(result.Value);
            //return _CustomerGrpcs;
        }

        public async Task<SiteListViewGrpc> GetAllSites(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _SiteGrpcs;
            //GetSiteQuery getsiteModelQuery = new GetSiteQuery();
            //Result<List<SiteViewGrpc>> result = await _SiteQueryHandler.Handle(getsiteModelQuery, cancellationToken);
            //_SiteGrpcs = new SiteListViewGrpc();
            //_SiteGrpcs.Items.AddRange(result.Value);
            //return _SiteGrpcs;
        }

        public async Task<ForecastListViewGrpc> GetAllForecasts(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _ForecastGrpcs;
            //GetForecastQuery getcforecastModelQuery = new GetForecastQuery();
            //Result<List<ForecastViewGrpc>> result = await _ForecastQueryHandler.Handle(getcforecastModelQuery, cancellationToken);
            //_ForecastGrpcs = new ForecastListViewGrpc();
            //_ForecastGrpcs.Items.AddRange(result.Value);
            //return _ForecastGrpcs;
        }

        public async Task<MonthlyVolumeDataListViewGrpc> GetMonthlyVolumes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _MonthlyVolumeGrpcs;
            //GetMonthlyVolumeDataQuery getmonthlyModelQuery = new GetMonthlyVolumeDataQuery();
            //Result<List<MonthlyVolumeDataViewGrpc>> result = await _MonthlyQueryHandler.Handle(getmonthlyModelQuery, cancellationToken);
            //_MonthlyVolumeGrpcs = new MonthlyVolumeDataListViewGrpc();
            //_MonthlyVolumeGrpcs.Items.AddRange(result.Value);
            //return _MonthlyVolumeGrpcs;
        }

        public async Task<CustomerNonWorkingDayListViewGrpc> GetCustomerNonWorkingDay(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _CustomerNonWorkingDayGrpcs;
            //GetCustomerNonWorkingDaysQuery getcustomerCalendarModelQuery = new GetCustomerNonWorkingDaysQuery();
            //Result<List<CustomerNonWorkingDayViewGrpc>> result = await _CustomerCalendarQueryHandler.Handle(getcustomerCalendarModelQuery, cancellationToken);
            //_CustomerNonWorkingDayGrpcs = new CustomerNonWorkingDayListViewGrpc();
            //_CustomerNonWorkingDayGrpcs.Items.AddRange(result.Value);
            //return _CustomerNonWorkingDayGrpcs;
        }

        public async Task<CalculationTypeListViewGrpc> GetAllCalculationTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _CalculationTypeGrpcs;
            //GetCalculationTypeQuery getcalculationModelQuery = new GetCalculationTypeQuery();
            //Result<List<CalculationTypeViewGrpc>> result = await _CalculationQueryHandler.Handle(getcalculationModelQuery, cancellationToken);
            //_CalculationTypeGrpcs = new CalculationTypeListViewGrpc();
            //_CalculationTypeGrpcs.Items.AddRange(result.Value);
            //return _CalculationTypeGrpcs;
        }

        public async Task<DailyVolumeDataListViewGrpc> GetAllDailyVolumes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            return _DailyVolumeGrpcs;
            //GetDailyVolumeDataQuery getdailyModelQuery = new GetDailyVolumeDataQuery();
            //Result<List<DailyVolumeDataViewGrpc>> result = await _DailyQueryHandler.Handle(getdailyModelQuery, cancellationToken);
            //_DailyVolumeGrpcs = new DailyVolumeDataListViewGrpc();
            //_DailyVolumeGrpcs.Items.AddRange(result.Value);
            //return _DailyVolumeGrpcs;
        }
    }
}
