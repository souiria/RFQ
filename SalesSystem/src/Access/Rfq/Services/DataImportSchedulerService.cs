namespace Rfq.Services
{
    public class DataImportSchedulerService : BackgroundService
    {
        IRfqAccessService _RfqAccessService;
        //readonly IServiceProvider _ServiceProvider;
        readonly ILogger<DataImportSchedulerService> _Logger;

        public DataImportSchedulerService(IRfqAccessService rfqAccessService, ILogger<DataImportSchedulerService> logger)
        {
            _RfqAccessService = rfqAccessService;
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

            if (_RfqAccessService != null)
            {
                bool check;
                check = await _RfqAccessService.PopulateRfqDrawingPartNumbers(stoppingToken);
                await LogDataPopulationSuccess("RfqDrawingPartNumbers", check);
                check = await _RfqAccessService.PopulateRfqProjects(stoppingToken);
                await LogDataPopulationSuccess("RfqProjects", check);
                check = await _RfqAccessService.PopulateRfqNotes(stoppingToken);
                await LogDataPopulationSuccess("RfqNotes", check);
                check = await _RfqAccessService.PopulateRfqReasons(stoppingToken);
                await LogDataPopulationSuccess("RfqReasons", check);
                check = await _RfqAccessService.PopulateDsiBends(stoppingToken);
                await LogDataPopulationSuccess("DsiBends", check);
                check = await _RfqAccessService.PopulateDsiBranchConfigurations(stoppingToken);
                await LogDataPopulationSuccess("DsiBranchConfigurations", check);
                check = await _RfqAccessService.PopulateDsiBranchConfigurationBendAssociations(stoppingToken);
                await LogDataPopulationSuccess("DsiBranchConfigurationBendAssociations", check);
                check = await _RfqAccessService.PopulateDsiBranchInsulations(stoppingToken);
                await LogDataPopulationSuccess("DsiBranchInsulations", check);
                check = await _RfqAccessService.PopulateDsiBranchInsulationThroughNodes(stoppingToken);
                await LogDataPopulationSuccess("DsiBranchInsulationThroughNodes", check);
                check = await _RfqAccessService.PopulateDsiCavityMappings(stoppingToken);
                await LogDataPopulationSuccess("DsiCavityMapping", check);
                check = await _RfqAccessService.PopulateDsiCentreStrips(stoppingToken);
                await LogDataPopulationSuccess("DsiCentreStrips", check);
                check = await _RfqAccessService.PopulateDsiComponents(stoppingToken);
                await LogDataPopulationSuccess("DsiComponents", check);
                check = await _RfqAccessService.PopulateDsiCompositeDetails(stoppingToken);
                await LogDataPopulationSuccess("DsiCompositeDetails", check);
                check = await _RfqAccessService.PopulateDsiCompositeDetailCircuitOptionAssociations(stoppingToken);
                await LogDataPopulationSuccess("DsiCompositeDetailCircuitOptionAssociations", check);
                check = await _RfqAccessService.PopulateDsiCompositeOptions(stoppingToken);
                await LogDataPopulationSuccess("DsiCompositeOptions", check);
                check = await _RfqAccessService.PopulateDsiHarnesses(stoppingToken);
                await LogDataPopulationSuccess("DsiHarnesses", check);
                check = await _RfqAccessService.PopulateDsiHarnessScopes(stoppingToken);
                await LogDataPopulationSuccess("DsiHarnessScopes", check);
                check = await _RfqAccessService.PopulateDsiHarnessScopeScopeAssociations(stoppingToken);
                await LogDataPopulationSuccess("DsiHarnessScopeScopeAssociations", check);
                check = await _RfqAccessService.PopulateDsiManualBomQuantities(stoppingToken);
                await LogDataPopulationSuccess("DsiManualBomQuantities", check);
                check = await _RfqAccessService.PopulateDsiMidWireComponents(stoppingToken);
                await LogDataPopulationSuccess("DsiMidWireComponents", check);
                check = await _RfqAccessService.PopulateDsiModuleChildDetails(stoppingToken);
                await LogDataPopulationSuccess("DsiModuleChildDetails", check);
                check = await _RfqAccessService.PopulateDsiModuleCompatibilities(stoppingToken);
                await LogDataPopulationSuccess("DsiModuleCompatibilities", check);
                check = await _RfqAccessService.PopulateDsiMulticoreSpecifications(stoppingToken);
                await LogDataPopulationSuccess("DsiMulticoreSpecifications", check);
                check = await _RfqAccessService.PopulateDsiPinMappings(stoppingToken);
                await LogDataPopulationSuccess("DsiPinMappings", check);
                check = await _RfqAccessService.PopulateDsiPinMappingCavityMappingAssociations(stoppingToken);
                await LogDataPopulationSuccess("DsiPinMappingCavityMappingAssociations", check);
                check = await _RfqAccessService.PopulateDsiScopes(stoppingToken);
                await LogDataPopulationSuccess("DsiScopes", check);
                check = await _RfqAccessService.PopulateDsiSuppliers(stoppingToken);
                await LogDataPopulationSuccess("DsiSuppliers", check);
                check = await _RfqAccessService.PopulateDsiTransformedCompositeDetails(stoppingToken);
                await LogDataPopulationSuccess("DsiTransformedCompositeDetails", check);
                check = await _RfqAccessService.PopulateDsiTransformedHarnesses(stoppingToken);
                await LogDataPopulationSuccess("DsiTransformedHarnesses", check);
                check = await _RfqAccessService.PopulateDsiTransformedModuleChildDetails(stoppingToken);
                await LogDataPopulationSuccess("DsiTransformedModuleChildDetails", check);
                check = await _RfqAccessService.PopulateDsiUnitOfMeasures(stoppingToken);
                await LogDataPopulationSuccess("DsiUnitsOfMeasure", check);
                check = await _RfqAccessService.PopulateDsiWireMulticoreMarkers(stoppingToken);
                await LogDataPopulationSuccess("DsiWireMulticoreMarkers", check);
                check = await _RfqAccessService.PopulateDsiWireSpecifications(stoppingToken);
                await LogDataPopulationSuccess("DsiWireSpecifications", check);
                check = await _RfqAccessService.PopulateDsiWireThroughNodes(stoppingToken);
                await LogDataPopulationSuccess("DsiWireThroughNodes", check);
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