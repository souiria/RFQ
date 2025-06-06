namespace Master.Services
{
    public class DataImportSchedulerService : BackgroundService
    {

        IMasterAccessService _MasterAccessService;
        //readonly IServiceProvider _ServiceProvider;
        readonly ILogger<DataImportSchedulerService> _Logger;

        public DataImportSchedulerService(IMasterAccessService masterAccessService, ILogger<DataImportSchedulerService> logger)
        {
            _MasterAccessService = masterAccessService;
            _Logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _Logger.GenericLogInformation("Background service is running");
          
            await PopulateGlobalDataAsync(stoppingToken);
            await DailyWorker(23, 30, 00, async () => await PopulateGlobalDataAsync(stoppingToken), stoppingToken);

            //using (PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromSeconds(30)))
            //{
            //    while (await timer.WaitForNextTickAsync(stoppingToken))
            //    {
            //        // Your scheduled work here
            //        await PopulateGlobalDataAsync(stoppingToken);
            //    }
            //}
        }

        async Task<bool> PopulateGlobalDataAsync(CancellationToken stoppingToken)
        {

            if (_MasterAccessService != null)
            {
                bool check;
                check = await _MasterAccessService.PopulateCurrenciesAsync(stoppingToken);
                await LogDataPopulationSuccess("Currency", check);
                check = await _MasterAccessService.PopulateCustomersAsync(stoppingToken);
                await LogDataPopulationSuccess("Customers", check);
                check = await _MasterAccessService.PopulateCustomerLocationsAsync(stoppingToken);
                await LogDataPopulationSuccess("CustomerLocations", check);
                check = await _MasterAccessService.PopulateCustomerSalesEntitiesAsync(stoppingToken);
                await LogDataPopulationSuccess("CustomerSalesEntities", check);
                check = await _MasterAccessService.PopulateCustomerBusinessUserAssociationsAsync(stoppingToken);
                await LogDataPopulationSuccess("CustomerBusinessUserAssociations", check);
                check = await _MasterAccessService.PopulateCustomerProjectAssociationsAsync(stoppingToken);
                await LogDataPopulationSuccess("CustomerProjectAssociations", check);
                check = await _MasterAccessService.PopulatePlatformsAsync(stoppingToken);
                await LogDataPopulationSuccess("Platforms", check);
                check = await _MasterAccessService.PopulateProgramsAsync(stoppingToken);
                await LogDataPopulationSuccess("Programs", check);
                check = await _MasterAccessService.PopulateProjectsAsync(stoppingToken);
                await LogDataPopulationSuccess("Projects", check);
                check = await _MasterAccessService.PopulateMilestonesAsync(stoppingToken);
                await LogDataPopulationSuccess("Milestones", check);
                check = await _MasterAccessService.PopulateVehiclesAsync(stoppingToken);
                await LogDataPopulationSuccess("Vehicles", check);
            }

            return true;

        }
        async Task DailyWorker(int hour, int min, int sec, Action actionToExecute, CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                DateTime dateTimeNow = DateTime.Now;
                DateTime scanDateTime = new DateTime(
                    dateTimeNow.Year,
                    dateTimeNow.Month,
                    dateTimeNow.Day,
                    hour,       // <-- Hour when the method should be started.
                    min,  // <-- Minutes when the method should be started.
                    sec); // <-- Seconds when the method should be started.

                TimeSpan ts;
                if (scanDateTime <= dateTimeNow)
                {
                    scanDateTime = scanDateTime.AddDays(1);
                    ts = scanDateTime - dateTimeNow;
                }
                else
                {
                    ts = scanDateTime - dateTimeNow;
                }

                try
                {
                    await Task.Delay(ts, token).WaitAsync(token); //change to .WaitAsync(token)
                    actionToExecute();
                }
                catch (OperationCanceledException ex)
                {
                    _Logger.GenericLogError(ex.Message, ex);
                }
            }
        }

        async Task LogDataPopulationSuccess(string data, bool check)
        {
            await Task.Delay(0);
            if (check)
            {

                _Logger.GenericLogInformation($"{data} data retrieved successfully");

            }
            else
            {
                _Logger.GenericLogInformation($"{data} data retrieval failed!!");
            }
        }
    }
}
