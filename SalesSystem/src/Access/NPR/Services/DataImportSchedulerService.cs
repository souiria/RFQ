namespace NPR.Services
{
    public class DataImportSchedulerService : BackgroundService
    {
        INPRAccessService _NPRAccessService;
        //readonly IServiceProvider _ServiceProvider;
        readonly ILogger<DataImportSchedulerService> _Logger;

        public DataImportSchedulerService(INPRAccessService nPRAccessService, ILogger<DataImportSchedulerService> logger)
        {
            _NPRAccessService = nPRAccessService;
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

            if (_NPRAccessService != null)
            {
                bool check;
                check = await _NPRAccessService.PopulateH1NPRViewAsync(stoppingToken);
                await LogDataPopulationSuccess("AllH1NPRView", check);
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
