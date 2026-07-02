namespace Commercial.Services
{
    public class DataImportSchedulerService : BackgroundService
    {
        ICommercialAccessService _CommercialAccessService;
        readonly ILogger<DataImportSchedulerService> _Logger;

        public DataImportSchedulerService(ICommercialAccessService commercialAccessService, ILogger<DataImportSchedulerService> logger)
        {
            _CommercialAccessService = commercialAccessService;
            _Logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _Logger.GenericLogInformation("Background service is running");
            await PopulateGlobalDataAsync(stoppingToken);
            await DailyWorker(23, 30, 00, async () => await PopulateGlobalDataAsync(stoppingToken), stoppingToken);
        }

        async Task<bool> PopulateGlobalDataAsync(CancellationToken stoppingToken)
        {

            if (_CommercialAccessService != null)
            {
                bool check;
                check = await _CommercialAccessService.PopulatePurchaseOrdersAsync(stoppingToken);
                await LogDataPopulationSuccess("PurchaseOrders", check);
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
