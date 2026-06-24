namespace DSI.Services
{
    public class DataImportSchedulerService : BackgroundService
    {
        IDSIAccessService _DSIAccessService;
        //readonly IServiceProvider _ServiceProvider;
        readonly ILogger<DataImportSchedulerService> _Logger;

        public DataImportSchedulerService(IDSIAccessService dsiAccessService, ILogger<DataImportSchedulerService> logger)
        {
            _DSIAccessService = dsiAccessService;
            _Logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _Logger.GenericLogInformation("DataImportSchedulerService - Background service is running");

            await PopulateGlobalDataAsync(stoppingToken);
            await DailyWorker(23, 30, 00, async () => await PopulateGlobalDataAsync(stoppingToken), stoppingToken);
        }

        async Task<bool> PopulateGlobalDataAsync(CancellationToken stoppingToken)
        {
            _Logger.GenericLogInformation("DataImportSchedulerService - PopulateGlobalDataAsync");
            if (_DSIAccessService != null)
            {
                bool check;
                check = await _DSIAccessService.PopulateHarness(stoppingToken);
                await LogDataPopulationSuccess("DSIHarness", check);
                check = await _DSIAccessService.PopulateComponent(stoppingToken);
                await LogDataPopulationSuccess("DSIComponent", check);
                check = await _DSIAccessService.PopulateBranchInsulation(stoppingToken);
                await LogDataPopulationSuccess("DSIBranchInsulation", check);
                check = await _DSIAccessService.PopulateCompositeDetail(stoppingToken);
                await LogDataPopulationSuccess("DSICompositeDetail", check);
                check = await _DSIAccessService.PopulateWireSpecification(stoppingToken);
                await LogDataPopulationSuccess("DSIWireSpecification", check);
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