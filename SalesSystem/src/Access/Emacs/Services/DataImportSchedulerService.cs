using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Emacs.Services
{
    public class DataImportSchedulerService : BackgroundService
    {
        IEMACSAccessService _EMACSAccessService;
        readonly ILogger<DataImportSchedulerService> _Logger;

        public DataImportSchedulerService(IEMACSAccessService eMACSAccessService, ILogger<DataImportSchedulerService> logger)
        {
            _EMACSAccessService = eMACSAccessService;
            _Logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _Logger.GenericLogInformation("Emacs Background service is running");

            await PopulateGlobalDataAsync(stoppingToken);
            await DailyWorker(23, 30, 00, async () => await PopulateGlobalDataAsync(stoppingToken), stoppingToken);
        }

        async Task<bool> PopulateGlobalDataAsync(CancellationToken stoppingToken)
        {
            if (_EMACSAccessService != null)
            {
                //Stopwatch sw = Stopwatch.StartNew();
                //bool check;
                //check = await _EMACSAccessService.PopulateCombinedPartsAsync(stoppingToken);
                //await LogDataPopulationSuccess("CombinedParts", check);
                //check = await _EMACSAccessService.PopulatePartCategoryDetailAsync(stoppingToken);
                //await LogDataPopulationSuccess("PartCategoryDetail", check);
                //check = await _EMACSAccessService.PopulatePartClassDetailAsync(stoppingToken);
                //await LogDataPopulationSuccess("PartClassDetail", check);
                //check = await _EMACSAccessService.PopulatePartGroupsAsync(stoppingToken);
                //await LogDataPopulationSuccess("PartGroups", check);
                //check = await _EMACSAccessService.PopulatePartGroupsConstAsync(stoppingToken);
                //await LogDataPopulationSuccess("PartGroupsConst", check);
                //check = await _EMACSAccessService.PopulateCustomerDataAsync(stoppingToken);
                //await LogDataPopulationSuccess("CustomerData", check);
                //check = await _EMACSAccessService.PopulateColourCodeAsync(stoppingToken);
                //await LogDataPopulationSuccess("ColourCode", check);
                //check = await _EMACSAccessService.PopulateMaterialGroupsAsync(stoppingToken);
                //await LogDataPopulationSuccess("MaterialGroups", check);
                //check = await _EMACSAccessService.PopulateMaterialTypesAsync(stoppingToken);
                //await LogDataPopulationSuccess("MaterialTypes", check);
                //check = await _EMACSAccessService.PopulateNPACustomerAsync(stoppingToken);
                //await LogDataPopulationSuccess("NPACustomer", check);
                //check = await _EMACSAccessService.PopulateSuppliersAsync(stoppingToken);
                //await LogDataPopulationSuccess("Suppliers", check);
                ////check = await _EMACSAccessService.PopulateEmacsRFIViewAsync(stoppingToken);
                ////await LogDataPopulationSuccess("EmacsRFIView", check);
                //check = await _EMACSAccessService.PopulatePARTMSAsync(stoppingToken);
                //await LogDataPopulationSuccess("PARTMS", check);
                //check = await _EMACSAccessService.PopulateAlternativePartsAsync(stoppingToken);
                //await LogDataPopulationSuccess("AlternativeParts", check);
                //sw.Stop();
                //_Logger.GenericLogInformation($"Global cache loaded in {sw.ElapsedMilliseconds}ms ");

                // parallel execution
                // Create all tasks
                Stopwatch stopwatch = Stopwatch.StartNew();
                Task[] tasks = new[]
                {
                    PopulateAndLogAsync("CombinedParts", () => _EMACSAccessService.PopulateCombinedPartsAsync(stoppingToken)),
                    PopulateAndLogAsync("PartCategoryDetail", () => _EMACSAccessService.PopulatePartCategoryDetailAsync(stoppingToken)),
                    PopulateAndLogAsync("PartClassDetail", () => _EMACSAccessService.PopulatePartClassDetailAsync(stoppingToken)),
                    PopulateAndLogAsync("PartGroups", () => _EMACSAccessService.PopulatePartGroupsAsync(stoppingToken)),
                    PopulateAndLogAsync("PartGroupsConst", () => _EMACSAccessService.PopulatePartGroupsConstAsync(stoppingToken)),
                    PopulateAndLogAsync("CustomerData", () => _EMACSAccessService.PopulateCustomerDataAsync(stoppingToken)),
                    PopulateAndLogAsync("ColourCode", () => _EMACSAccessService.PopulateColourCodeAsync(stoppingToken)),
                    PopulateAndLogAsync("MaterialGroups", () => _EMACSAccessService.PopulateMaterialGroupsAsync(stoppingToken)),
                    PopulateAndLogAsync("MaterialTypes", () => _EMACSAccessService.PopulateMaterialTypesAsync(stoppingToken)),
                    PopulateAndLogAsync("NPACustomer", () => _EMACSAccessService.PopulateNPACustomerAsync(stoppingToken)),
                    PopulateAndLogAsync("Suppliers", () => _EMACSAccessService.PopulateSuppliersAsync(stoppingToken)),
                    PopulateAndLogAsync("PARTMS", () => _EMACSAccessService.PopulatePARTMSAsync(stoppingToken)),
                    PopulateAndLogAsync("AlternativeParts", () => _EMACSAccessService.PopulateAlternativePartsAsync(stoppingToken))
                };

                // Wait for all to complete
                await Task.WhenAll(tasks);
                stopwatch.Stop();
                _Logger.GenericLogInformation($"Overall global cache load execution time is {stopwatch.ElapsedMilliseconds}ms");
                return true;
            }

            return false;
        }

        // Helper method
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        async Task PopulateAndLogAsync(string name, Func<Task<bool>> populateFunc)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                bool success = await populateFunc();
                await LogDataPopulationSuccess(name, success);
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error populating {name}", ex);
                await LogDataPopulationSuccess(name, false);
            }
            finally
            {
                stopwatch.Stop();
            }

            _Logger.GenericLogInformation($"{name} execution time is {stopwatch.ElapsedMilliseconds}ms");
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
