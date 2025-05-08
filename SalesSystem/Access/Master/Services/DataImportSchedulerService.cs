namespace Master.Services
{
    public class DataImportSchedulerService : BackgroundService
    {

        readonly IMasterAccessService? _MasterAccessService;
        readonly ILogger<DataImportSchedulerService> _Logger;

        public DataImportSchedulerService(IServiceProvider serviceProvider, ILogger<DataImportSchedulerService> logger)
        {
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                _MasterAccessService = scope.ServiceProvider.GetService<IMasterAccessService>();
            }

            _Logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
            _Logger.LogInformation("Background service is running");
#pragma warning restore CA1848 // Use the LoggerMessage delegates

             await PopulateGlobalDataAsync(stoppingToken);

            Task<bool> getMasterData = (Task<bool>)DailyWorker(23, 30, 00, async () => await PopulateGlobalDataAsync(stoppingToken), stoppingToken);

        }

        async Task<bool> PopulateGlobalDataAsync(CancellationToken stoppingToken)
        {
            if (_MasterAccessService != null)
            {
                bool check = await _MasterAccessService.PopulateCurrenciesAsync(stoppingToken);
                if (check)
                {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
                    _Logger.LogInformation("Emacs data retrieved successfully");
#pragma warning restore CA1848 // Use the LoggerMessage delegates
                }
                else
                {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
                    _Logger.LogInformation("Emacs data retrieval failed!!");
#pragma warning restore CA1848 // Use the LoggerMessage delegates
                }
            }

            return true;
        }
        public async Task DailyWorker(int hour, int min, int sec, Action actionToExecute, CancellationToken token)
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
                if (scanDateTime > dateTimeNow)
                {
                    ts = scanDateTime - dateTimeNow;
                }
                else
                {
                    scanDateTime = scanDateTime.AddDays(1);
                    ts = scanDateTime - dateTimeNow;
                }

                try
                {
                    await Task.Delay(ts, token).WaitAsync(token); //change to .WaitAsync(token)
                    actionToExecute();
                }
                catch (OperationCanceledException ex)
                {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
#pragma warning disable CA2254 // Template should be a static expression
                    _Logger.LogError(ex.Message);
#pragma warning restore CA2254 // Template should be a static expression
#pragma warning restore CA1848 // Use the LoggerMessage delegates
                }
            }
        }
    }
}
