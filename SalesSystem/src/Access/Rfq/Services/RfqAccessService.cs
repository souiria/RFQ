namespace Rfq.Services
{
    public partial class RfqAccessService : IRfqAccessService
    {
        ILogger<RfqAccessService> _Logger;

        #region In Memory Datasets

        #region RfqDrawingPartNumbers

        ListRfqDrawingPartNumbersGrpc _ListRfqDrawingPartNumbersGrpc;
        #endregion

        #region RfqProject
        ListRfqProjectGrpc _ListRfqProjectsGrpc;
        #endregion

        #region RfqNotes
        ListRfqNotesGrpc _ListRfqNotesGrpc;
        #endregion

        #region RfqReason
        ListRfqReasonGrpc _ListRfqReasonsGrpc;
        #endregion

        #region DsiBend
        ListDsiBendGrpc _ListDsiBendsGrpc;
        #endregion

        #region DsiBranchConfiguration
        ListDsiBranchConfigurationGrpc _ListDsiBranchConfigurationsGrpc;
        #endregion

        #region DsiBranchConfigurationBendAssociation
        ListDsiBranchConfigurationBendAssociationGrpc _ListDsiBranchConfigurationBendAssociationsGrpc;
        #endregion

        #region DsiBranchInsulation
        ListDsiBranchInsulationGrpc _ListDsiBranchInsulationsGrpc;
        #endregion

        #region DsiBranchInsulationThroughNode
        ListDsiBranchInsulationThroughNodeGrpc _ListDsiBranchInsulationThroughNodesGrpc;
        #endregion

        #region DsiCavityMapping
        ListDsiCavityMappingGrpc _ListDsiCavityMappings;
        #endregion

        #region DsiCentreStrip
        ListDsiCentreStripGrpc _ListDsiCentreStripGrpc;
        #endregion

        #region DsiCircuitOption
        ListDsiCircuitOptionGrpc _ListDsiCircuitOptionGrpc;
        #endregion

        #region DsiComponent
        ListDsiComponentGrpc _ListDsiComponentGrpc;
        #endregion

        #region DsiCompositeDetail
        ListDsiCompositeDetailGrpc _ListDsiCompositeDetailGrpc;
        #endregion

        #region DsiCompositeDetailCircuitOptionAssociation
        ListDsiCompositeDetailCircuitOptionAssociationGrpc _ListDsiCompositeDetailCircuitOptionAssociationGrpc;
        #endregion

        #region DsiCompositeOption
        ListDsiCompositeOptionGrpc _ListDsiCompositeOptionGrpc;
        #endregion

        #region DsiHarness
        ListDsiHarnessGrpc _ListDsiHarnessGrpc;
        #endregion

        #region DsiHarnessScope
        ListDsiHarnessScopeGrpc _ListDsiHarnessScopeGrpc;
        #endregion

        #region DsiHarnessScopeScopeAssociation
        ListDsiHarnessScopeScopeAssociationGrpc _ListDsiHarnessScopeScopeAssociationGrpc;
        #endregion

        #region DsiManualBomQuantity
        ListDsiManualBomQuantityGrpc _ListDsiManualBomQuantityGrpc;
        #endregion

        #region DsiMidWireComponent
        ListDsiMidWireComponentGrpc _ListDsiMidWireComponentGrpc;
        #endregion

        #region DsiModuleChildDetail
        ListDsiModuleChildDetailGrpc _ListDsiModuleChildDetailGrpc;
        #endregion

        #region DsiModuleCompatibility
        ListDsiModuleCompatibilityGrpc _ListDsiModuleCompatibilityGrpc;
        #endregion

        #region DsiMulticoreSpecification
        ListDsiMulticoreSpecificationGrpc _ListDsiMulticoreSpecificationGrpc;
        #endregion

        #region DsiPinMapping
        ListDsiPinMappingGrpc _ListDsiPinMappingGrpc;
        #endregion

        #region DsiPinMappingCavityMappingAssociation
        ListDsiPinMappingCavityMappingAssociationGrpc _ListDsiPinMappingCavityMappingAssociationGrpc;
        #endregion

        #region DsiScope
        ListDsiScopeGrpc _ListDsiScopeGrpc;
        #endregion

        #region DsiSupplier
        ListDsiSupplierGrpc _ListDsiSupplierGrpc;
        #endregion

        #region DsiTransformedCompositeDetail
        ListDsiTransformedCompositeDetailGrpc _ListDsiTransformedCompositeDetailGrpc;
        #endregion

        #region DsiTransformedHarness
        ListDsiTransformedHarnessGrpc _ListDsiTransformedHarnessGrpc;
        #endregion

        #region DsiTransformedModuleChildDetail
        ListDsiTransformedModuleChildDetailGrpc _ListDsiTransformedModuleChildDetailGrpc;
        #endregion

        #region DsiUnitOfMeasure
        ListDsiUnitOfMeasureGrpc _ListDsiUnitOfMeasureGrpc;
        #endregion

        #region DsiWireMulticoreMarker
        ListDsiWireMulticoreMarkerGrpc _ListDsiWireMulticoreMarkerGrpc;
        #endregion

        #region DsiWireSpecification
        ListDsiWireSpecificationGrpc _ListDsiWireSpecificationGrpc;
        #endregion

        #region DsiWireThroughNode
        ListDsiWireThroughNodeGrpc _ListDsiWireThroughNodeGrpc;
        #endregion

        #region RfqNprRequest
        ListRfqNprRequestGrpc _ListRfqNprRequestGrpc;
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Fields and Properties

        #region RfqDrawingPartNumbers

        IQueryHandler<GetRfqDrawingPartNumberQuery, List<RfqDrawingPartNumbersGrpc>>? _RfqDrawingPartNumbersHandler;
        bool _RfqDrawingPartNumbersRefreshInProgress;

        #endregion

        #region RfqProject

        IQueryHandler<GetRfqProjectQuery, List<RfqProjectGrpc>>? _RfqProjectHandler;
        bool _RfqProjectRefreshInProgress;

        #endregion

        #region RfqNotes

        IQueryHandler<GetRfqNotesQuery, List<RfqNotesGrpc>>? _RfqNotesHandler;
        bool _RfqNotesRefreshInProgress;

        #endregion

        #region RfqReason

        IQueryHandler<GetRfqReasonQuery, List<RfqReasonGrpc>>? _RfqReasonHandler;
        bool _RfqReasonRefreshInProgress;

        #endregion

        #region DsiBend
        IQueryHandler<GetDsiBendQuery, List<DsiBendGrpc>>? _DsiBendHandler;
        bool _DsiBendRefreshInProgress;
        #endregion

        #region DsiBranchConfiguration
        IQueryHandler<GetDsiBranchConfigurationQuery, List<DsiBranchConfigurationGrpc>>? _DsiBranchConfigurationHandler;
        bool _DsiBranchConfigurationRefreshInProgress;
        #endregion

        #region DsiBranchConfigurationBendAssociation
        IQueryHandler<GetDsiBranchConfigurationBendAssociationQuery, List<DsiBranchConfigurationBendAssociationGrpc>>? _DsiBranchConfigurationBendAssociationHandler;
        bool _DsiBranchConfigurationBendAssociationRefreshInProgress;
        #endregion

        #region DsiBranchInsulation
        IQueryHandler<GetDsiBranchInsulationQuery, List<DsiBranchInsulationGrpc>>? _DsiBranchInsulationHandler;
        bool _DsiBranchInsulationRefreshInProgress;
        #endregion

        #region DsiBranchInsulationThroughNode
        IQueryHandler<GetDsiBranchInsulationThroughNodeQuery, List<DsiBranchInsulationThroughNodeGrpc>>? _DsiBranchInsulationThroughNodeHandler;
        bool _DsiBranchInsulationThroughNodeRefreshInProgress;
        #endregion

        #region DsiCavityMapping
        IQueryHandler<GetDsiCavityMappingQuery, List<DsiCavityMappingGrpc>>? _DsiCavityMappingHandler;
        bool _DsiCavityMappingRefreshInProgress;
        #endregion

        #region DsiCentreStrip
        IQueryHandler<GetDsiCentreStripQuery, List<DsiCentreStripGrpc>>? _DsiCentreStripHandler;
        bool _DsiCentreStripRefreshInProgress;
        #endregion

        #region DsiCircuitOption
        IQueryHandler<GetDsiCircuitOptionQuery, List<DsiCircuitOptionGrpc>>? _DsiCircuitOptionHandler;
        bool _DsiCircuitOptionRefreshInProgress;
        #endregion

        #region DsiComponent
        IQueryHandler<GetDsiComponentQuery, List<DsiComponentGrpc>>? _DsiComponentHandler;
        bool _DsiComponentRefreshInProgress;
        #endregion

        #region DsiCompositeDetail
        IQueryHandler<GetDsiCompositeDetailQuery, List<DsiCompositeDetailGrpc>>? _DsiCompositeDetailHandler;
        bool _DsiCompositeDetailRefreshInProgress;
        #endregion

        #region DsiCompositeDetailCircuitOptionAssociation
        IQueryHandler<GetDsiCompositeDetailCircuitOptionAssociationQuery, List<DsiCompositeDetailCircuitOptionAssociationGrpc>>? _DsiCompositeDetailCircuitOptionAssociationHandler;
        bool _DsiCompositeDetailCircuitOptionAssociationRefreshInProgress;

        #endregion

        #region DsiCompositeOption
        IQueryHandler<GetDsiCompositeOptionQuery, List<DsiCompositeOptionGrpc>>? _DsiCompositeOptionHandler;
        bool _DsiCompositeOptionRefreshInProgress;
        #endregion

        #region DsiHarness
        IQueryHandler<GetDsiHarnessQuery, List<DsiHarnessGrpc>>? _DsiHarnessHandler;
        bool _DsiHarnessRefreshInProgress;
        #endregion

        #region DsiHarnessScope
        IQueryHandler<GetDsiHarnessScopeQuery, List<DsiHarnessScopeGrpc>>? _DsiHarnessScopeHandler;
        bool _DsiHarnessScopeRefreshInProgress;
        #endregion

        #region DsiHarnessScopeScopeAssociation
        IQueryHandler<GetDsiHarnessScopeScopeAssociationQuery, List<DsiHarnessScopeScopeAssociationGrpc>>? _DsiHarnessScopeScopeAssociationHandler;
        bool _DsiHarnessScopeScopeAssociationRefreshInProgress;
        #endregion

        #region DsiManualBomQuantity
        IQueryHandler<GetDsiManualBomQuantityQuery, List<DsiManualBomQuantityGrpc>>? _DsiManualBomQuantityHandler;
        bool _DsiManualBomQuantityRefreshInProgress;
        #endregion

        #region DsiMidWireComponent
        IQueryHandler<GetDsiMidWireComponentQuery, List<DsiMidWireComponentGrpc>>? _DsiMidWireComponentHandler;
        bool _DsiMidWireComponentRefreshInProgress;
        #endregion

        #region DsiModuleChildDetail
        IQueryHandler<GetDsiModuleChildDetailQuery, List<DsiModuleChildDetailGrpc>>? _DsiModuleChildDetailHandler;
        bool _DsiModuleChildDetailRefreshInProgress;
        #endregion

        #region DsiModuleCompatibility
        IQueryHandler<GetDsiModuleCompatibilityQuery, List<DsiModuleCompatibilityGrpc>>? _DsiModuleCompatibilityHandler;
        bool _DsiModuleCompatibilityRefreshInProgress;
        #endregion

        #region DsiMulticoreSpecification
        IQueryHandler<GetDsiMulticoreSpecificationQuery, List<DsiMulticoreSpecificationGrpc>>? _DsiMulticoreSpecificationHandler;
        bool _DsiMulticoreSpecificationRefreshInProgress;
        #endregion

        #region DsiPinMapping
        IQueryHandler<GetDsiPinMappingQuery, List<DsiPinMappingGrpc>>? _DsiPinMappingHandler;
        bool _DsiPinMappingRefreshInProgress;
        #endregion

        #region DsiPinMappingCavityMappingAssociation
        IQueryHandler<GetDsiPinMappingCavityMappingAssociationQuery, List<DsiPinMappingCavityMappingAssociationGrpc>>? _DsiPinMappingCavityMappingAssociationHandler;
        bool _DsiPinMappingCavityMappingAssociationRefreshInProgress;
        #endregion

        #region DsiScope
        IQueryHandler<GetDsiScopeQuery, List<DsiScopeGrpc>>? _DsiScopeHandler;
        bool _DsiScopeRefreshInProgress;
        #endregion

        #region DsiSupplier
        IQueryHandler<GetDsiSupplierQuery, List<DsiSupplierGrpc>>? _DsiSupplierHandler;
        bool _DsiSupplierRefreshInProgress;
        #endregion

        #region DsiTransformedCompositeDetail
        IQueryHandler<GetDsiTransformedCompositeDetailQuery, List<DsiTransformedCompositeDetailGrpc>>? _DsiTransformedCompositeDetailHandler;
        bool _DsiTransformedCompositeDetailRefreshInProgress;
        #endregion

        #region DsiTransformedHarness
        IQueryHandler<GetDsiTransformedHarnessQuery, List<DsiTransformedHarnessGrpc>>? _DsiTransformedHarnessHandler;
        bool _DsiTransformedHarnessRefreshInProgress;
        #endregion

        #region DsiTransformedModuleChildDetail
        IQueryHandler<GetDsiTransformedModuleChildDetailQuery, List<DsiTransformedModuleChildDetailGrpc>>? _DsiTransformedModuleChildDetailHandler;
        bool _DsiTransformedModuleChildDetailRefreshInProgress;
        #endregion

        #region DsiUnitOfMeasure
        IQueryHandler<GetDsiUnitOfMeasureQuery, List<DsiUnitOfMeasureGrpc>>? _DsiUnitOfMeasureHandler;
        bool _DsiUnitOfMeasureRefreshInProgress;
        #endregion

        #region DsiWireMulticoreMarker
        IQueryHandler<GetDsiWireMulticoreMarkerQuery, List<DsiWireMulticoreMarkerGrpc>>? _DsiWireMulticoreMarkerHandler;
        bool _DsiWireMulticoreMarkerRefreshInProgress;
        #endregion

        #region DsiWireSpecification
        IQueryHandler<GetDsiWireSpecificationQuery, List<DsiWireSpecificationGrpc>>? _DsiWireSpecificationHandler;
        bool _DsiWireSpecificationRefreshInProgress;
        #endregion

        #region DsiWireThroughNode
        IQueryHandler<GetDsiWireThroughNodeQuery, List<DsiWireThroughNodeGrpc>>? _DsiWireThroughNodeHandler;
        bool _DsiWireThroughNodeRefreshInProgress;
        #endregion

        #region RfqNprRequest
        IQueryHandler<GetRfqNprRequestQuery, List<RfqNprRequestGrpc>>? _RfqNprRequestHandler;
        bool _RfqNprRequestRefreshInProgress;
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////

        readonly IServiceProvider _ServiceProvider;

        #endregion

        #region Constructor
        public RfqAccessService(IServiceProvider serviceProvider,
                                ILogger<RfqAccessService> logger,
                                bool testing = false)
        {
            #region RfqDrawingPartNumbers

            _ListRfqDrawingPartNumbersGrpc = new ListRfqDrawingPartNumbersGrpc();
            _RfqDrawingPartNumbersRefreshInProgress = false;

            #endregion

            #region RfqProject

            _ListRfqProjectsGrpc = new ListRfqProjectGrpc();
            _RfqProjectRefreshInProgress = false;

            #endregion

            #region RfqNotes

            _ListRfqNotesGrpc = new ListRfqNotesGrpc();
            _RfqNotesRefreshInProgress = false;

            #endregion

            #region RfqReason

            _ListRfqReasonsGrpc = new ListRfqReasonGrpc();
            _RfqReasonRefreshInProgress = false;

            #endregion

            #region DsiBend

            _ListDsiBendsGrpc = new ListDsiBendGrpc();
            _DsiBendRefreshInProgress = false;

            #endregion

            #region DsiBranchConfiguration

            _ListDsiBranchConfigurationsGrpc = new ListDsiBranchConfigurationGrpc();
            _DsiBranchConfigurationRefreshInProgress = false;

            #endregion

            #region DsiBranchConfigurationBendAssociation

            _ListDsiBranchConfigurationBendAssociationsGrpc = new ListDsiBranchConfigurationBendAssociationGrpc();
            _DsiBranchConfigurationBendAssociationRefreshInProgress = false;

            #endregion

            #region DsiBranchInsulation

            _ListDsiBranchInsulationsGrpc = new ListDsiBranchInsulationGrpc();
            _DsiBranchInsulationRefreshInProgress = false;

            #endregion

            #region DsiBranchInsulationThroughNode

            _ListDsiBranchInsulationThroughNodesGrpc = new ListDsiBranchInsulationThroughNodeGrpc();
            _DsiBranchInsulationThroughNodeRefreshInProgress = false;

            #endregion

            #region DsiCavityMapping

            _ListDsiCavityMappings = new ListDsiCavityMappingGrpc();
            _DsiCavityMappingRefreshInProgress = false;

            #endregion

            #region DsiCircuitOption
            _ListDsiCircuitOptionGrpc = new ListDsiCircuitOptionGrpc();
            _DsiCircuitOptionRefreshInProgress = false;
            #endregion

            #region DsiCentreStrip

            _ListDsiCentreStripGrpc = new ListDsiCentreStripGrpc();
            _DsiCentreStripRefreshInProgress = false;

            #endregion

            #region DsiCompositeDetail
            _ListDsiCompositeDetailGrpc = new ListDsiCompositeDetailGrpc();
            _DsiCompositeDetailRefreshInProgress = false;
            #endregion

            #region DsiComponent
            _ListDsiComponentGrpc = new ListDsiComponentGrpc();
            _DsiComponentRefreshInProgress = false;
            #endregion

            #region DsiCompositeDetailCircuitOptionAssociation
            _ListDsiCompositeDetailCircuitOptionAssociationGrpc = new ListDsiCompositeDetailCircuitOptionAssociationGrpc();
            _DsiCompositeDetailCircuitOptionAssociationRefreshInProgress = false;
            #endregion

            #region DsiCompositeOption
            _ListDsiCompositeOptionGrpc = new ListDsiCompositeOptionGrpc();
            _DsiCompositeOptionRefreshInProgress = false;
            #endregion

            #region DsiHarness
            _ListDsiHarnessGrpc = new ListDsiHarnessGrpc();
            _DsiHarnessRefreshInProgress = false;
            #endregion

            #region DsiHarnessScope
            _ListDsiHarnessScopeGrpc = new ListDsiHarnessScopeGrpc();
            _DsiHarnessScopeRefreshInProgress = false;
            #endregion

            #region DsiHarnessScopeScopeAssociation
            _ListDsiHarnessScopeScopeAssociationGrpc = new ListDsiHarnessScopeScopeAssociationGrpc();
            _DsiHarnessScopeScopeAssociationRefreshInProgress = false;
            #endregion

            #region DsiManualBomQuantity
            _ListDsiManualBomQuantityGrpc = new ListDsiManualBomQuantityGrpc();
            _DsiManualBomQuantityRefreshInProgress = false;
            #endregion

            #region DsiMidWireComponent
            _ListDsiMidWireComponentGrpc = new ListDsiMidWireComponentGrpc();
            _DsiMidWireComponentRefreshInProgress = false;
            #endregion

            #region DsiModuleChildDetail
            _ListDsiModuleChildDetailGrpc = new ListDsiModuleChildDetailGrpc();
            _DsiModuleChildDetailRefreshInProgress = false;
            #endregion

            #region DsiModuleCompatibility
            _ListDsiModuleCompatibilityGrpc = new ListDsiModuleCompatibilityGrpc();
            _DsiModuleCompatibilityRefreshInProgress = false;
            #endregion

            #region DsiMulticoreSpecification
            _ListDsiMulticoreSpecificationGrpc = new ListDsiMulticoreSpecificationGrpc();
            _DsiMulticoreSpecificationRefreshInProgress = false;
            #endregion

            #region DsiPinMapping
            _ListDsiPinMappingGrpc = new ListDsiPinMappingGrpc();
            _DsiPinMappingRefreshInProgress = false;
            #endregion

            #region DsiPinMappingCavityMappingAssociation
            _ListDsiPinMappingCavityMappingAssociationGrpc = new ListDsiPinMappingCavityMappingAssociationGrpc();
            _DsiPinMappingCavityMappingAssociationRefreshInProgress = false;
            #endregion

            #region DsiScope
            _ListDsiScopeGrpc = new ListDsiScopeGrpc();
            _DsiScopeRefreshInProgress = false;
            #endregion

            #region DsiSupplier
            _ListDsiSupplierGrpc = new ListDsiSupplierGrpc();
            _DsiSupplierRefreshInProgress = false;
            #endregion

            #region DsiTransformedCompositeDetail
            _ListDsiTransformedCompositeDetailGrpc = new ListDsiTransformedCompositeDetailGrpc();
            _DsiTransformedCompositeDetailRefreshInProgress = false;
            #endregion

            #region DsiTransformedHarness
            _ListDsiTransformedHarnessGrpc = new ListDsiTransformedHarnessGrpc();
            _DsiTransformedHarnessRefreshInProgress = false;
            #endregion

            #region DsiTransformedModuleChildDetail
            _ListDsiTransformedModuleChildDetailGrpc = new ListDsiTransformedModuleChildDetailGrpc();
            _DsiTransformedModuleChildDetailRefreshInProgress = false;
            #endregion

            #region DsiUnitOfMeasure
            _ListDsiUnitOfMeasureGrpc = new ListDsiUnitOfMeasureGrpc();
            _DsiUnitOfMeasureRefreshInProgress = false;
            #endregion

            #region DsiWireMulticoreMarker
            _ListDsiWireMulticoreMarkerGrpc = new ListDsiWireMulticoreMarkerGrpc();
            _DsiWireMulticoreMarkerRefreshInProgress = false;
            #endregion

            #region DsiWireSpecification
            _ListDsiWireSpecificationGrpc = new ListDsiWireSpecificationGrpc();
            _DsiWireSpecificationRefreshInProgress = false;
            #endregion

            #region DsiWireThroughNode
            _ListDsiWireThroughNodeGrpc = new ListDsiWireThroughNodeGrpc();
            _DsiWireThroughNodeRefreshInProgress = false;
            #endregion

            #region RfqNprRequest
            _ListRfqNprRequestGrpc = new ListRfqNprRequestGrpc();
            _RfqNprRequestRefreshInProgress = false;
            #endregion

            //////////////////////////////////////////////////////////////////////////////////////////////

            _ServiceProvider = serviceProvider;
            _Logger = logger;

            if (testing)
            {
                PopulateSampleData();
            }
        }
        #endregion

        #region Handlers

        #region RfqDrawingPartNumbers
        public async Task<ListRfqDrawingPartNumbersGrpc> GetAllRfqDrawingPartNumbers(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.Any())
            {
                if(takeAmount <= 0)
                {
                    return _ListRfqDrawingPartNumbersGrpc;
                }

                ListRfqDrawingPartNumbersGrpc returnList = new ListRfqDrawingPartNumbersGrpc();
                IEnumerable<RfqDrawingPartNumbersGrpc> query = _ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.Skip(position).Take(takeAmount);
                returnList.RfqDrawingPartNumbers.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateRfqDrawingPartNumbers(cancellationToken);
                return _ListRfqDrawingPartNumbersGrpc;
            }
        }

        public async Task<ListRfqDrawingPartNumbersGrpc> CreateRfqDrawingPartNumbers(RfqDrawingPartNumbersGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            _Logger.GenericLogInformation($"III RfqAccessService.CreateRfqDrawingPartNumbers - Entering with passed {request.RfqDrawingPartNumbersGrpcsToCreate.Count} parts passed in");
            ListRfqDrawingPartNumbersGrpc responseList = new ListRfqDrawingPartNumbersGrpc();
            if (request == null || request.RfqDrawingPartNumbersGrpcsToCreate == null || request.RfqDrawingPartNumbersGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            System.Diagnostics.StackTrace stackTrace = new System.Diagnostics.StackTrace(true);

            try
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    List<RfqDrawingPartNumbersGrpc> itemsToCreate = new();
                    foreach (RfqDrawingPartNumbersGrpc? part in request.RfqDrawingPartNumbersGrpcsToCreate)
                    {
                        if(!_ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.Any(x => x.OriginalPartNumber == part.OriginalPartNumber && x.RfqId == part.RfqId))
                        {
                            itemsToCreate.Add(part);
                        }
                    }

                    if (itemsToCreate.Count == 0)
                    {
                        return responseList; // Nothing new to create
                    }

                    _Logger.GenericLogInformation($"III RfqAccessService.CreateRfqDrawingPartNumbers - Starting with cached part count {_ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.Count}");

                    ICommandHandler<RfqDrawingPartNumberCommand, List<DbRfqDrawingPartNumber>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqDrawingPartNumberCommand, List<DbRfqDrawingPartNumber>>>();
                    RfqDrawingPartNumberCommand command = new RfqDrawingPartNumberCommand(CommandType.Create, itemsToCreate);
                    Result<List<DbRfqDrawingPartNumber>> result = await handler.Handle(command, cancellationToken);

                    if (result.IsSuccess)
                    {

                        _Logger.GenericLogInformation($"III RfqAccessService.CreateRfqDrawingPartNumbers - CQRS Handler retuned success - created {result.Value.Count} parts");

#if DEBUG
                        await PopulateRfqDrawingPartNumbers(cancellationToken);
                        List<DbRfqDrawingPartNumber> createdComponents = result.Value;

                        List<RfqDrawingPartNumbersGrpc> createdGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                        responseList.RfqDrawingPartNumbers.AddRange(createdGrpcComponents);

                        _Logger.GenericLogInformation($"III RfqAccessService.CreateRfqDrawingPartNumbers - PopulateRfqDrawingPartNumbers called, cached part count {_ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.Count}");
#else
                    List<DbRfqDrawingPartNumber> createdComponents = result.Value;
                    List<RfqDrawingPartNumbersGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.AddRange(updatedGrpcComponents);
                    responseList.RfqDrawingPartNumbers.AddRange(updatedGrpcComponents);
#endif

                    }
                    else
                    {
                        _Logger.GenericLogInformation($"FFF RfqAccessService.CreateRfqDrawingPartNumbers - CQRS Handler retuned success");
                    }

                        return responseList;
                }
            }
            catch (TaskCanceledException ex)
            {
                // Also a cancellation scenario
                _Logger.GenericLogInformation($"WWW RfqAccessService.CreateRfqDrawingPartNumbers - Task cancelled (likely timeout): {ex.Message}");
                throw;
            }
            catch (OperationCanceledException ex)
            {
                // This is expected when the client cancels (timeout)
                _Logger.GenericLogInformation($"WWW RfqAccessService.CreateRfqDrawingPartNumbers - Operation cancelled (likely timeout): {ex.Message}");
                throw; // Re-throw so gRPC can return proper status code
            }
            catch (InvalidOperationException ex)
            {
                _Logger.GenericLogError($"EEE RfqAccessService.CreateRfqDrawingPartNumbers - InvalidOperationException: {ex.Message}", ex);
                throw;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"EEE RfqAccessService.CreateRfqDrawingPartNumbers - Unexpected exception: {ex.Message}", ex);
                throw;
            }
        }

        public async Task<bool> UpdateRfqDrawingPartNumbers(RfqDrawingPartNumbersGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqDrawingPartNumbersGrpc responseList = new ListRfqDrawingPartNumbersGrpc();
            if (request == null || request.RfqDrawingPartNumbersGrpcsToUpdate == null || request.RfqDrawingPartNumbersGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqDrawingPartNumberCommand, List<DbRfqDrawingPartNumber>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqDrawingPartNumberCommand, List<DbRfqDrawingPartNumber>>>();
                RfqDrawingPartNumberCommand command = new RfqDrawingPartNumberCommand(CommandType.Update, request.RfqDrawingPartNumbersGrpcsToUpdate);
                Result<List<DbRfqDrawingPartNumber>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
#if DEBUG
                    // invalidate cache and repopulate
                    _ListRfqDrawingPartNumbersGrpc = new();
                    await PopulateRfqDrawingPartNumbers(cancellationToken);
                    responseList.RfqDrawingPartNumbers.AddRange(_ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers);
#else
                    foreach (RfqDrawingPartNumbersGrpc updatedComponent in request.RfqDrawingPartNumbersGrpcsToUpdate)
                    {
                        RfqDrawingPartNumbersGrpc? foundItem = _ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers[index] = updatedComponent;
                        }
                    }
#endif
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region RfqProject
        public async Task<ListRfqProjectGrpc> DeleteRfqProjectByRowId(RfqProjectGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqProjectGrpc responseList = new ListRfqProjectGrpc();

            if (request == null || request.RowId == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                RfqDbContext dbContext = scope.ServiceProvider.GetRequiredService<RfqDbContext>();

                object[] keyValues = new object[] { request.RowId };
                DbRfqProject? entity = await dbContext.RfqProject.FindAsync(keyValues, cancellationToken);

                if (entity == null)
                {
                    return responseList;
                }

                entity.IsActive = false;

         
                await dbContext.SaveChangesAsync(cancellationToken);

                RfqProjectGrpc updated = entity.FromEntity();

                // Update local cache
                RfqProjectGrpc? cached = _ListRfqProjectsGrpc.RfqProjects.FirstOrDefault(p => p.RowId == updated.RowId);
                if (cached != null)
                {
                    cached.IsActive = false;
                }

                responseList.RfqProjects.Add(updated);
               
                return responseList;
            }
        }

        public async Task<ListRfqProjectGrpc> GetAllRfqProjects(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);

            

            if (_ListRfqProjectsGrpc.RfqProjects.Any())
            {
                ListRfqProjectGrpc activeProjectsList = new ListRfqProjectGrpc();

                List<RfqProjectGrpc> activeProjects = _ListRfqProjectsGrpc.RfqProjects
                    .Where(p => p.IsActive != null && p.IsActive.Value)
                    .ToList();

                activeProjectsList.RfqProjects.AddRange(activeProjects);

                if (takeAmount <= 0)
                {
                    return activeProjectsList;
                }

                ListRfqProjectGrpc returnList = new ListRfqProjectGrpc();
                IEnumerable<RfqProjectGrpc> query = activeProjectsList.RfqProjects.Skip(position).Take(takeAmount);
                returnList.RfqProjects.AddRange(query);
                return returnList;
            }

            await PopulateRfqProjects(cancellationToken);
            return _ListRfqProjectsGrpc;
        }

        public async Task<ListRfqProjectGrpc> CreateRfqProjects(RfqProjectGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqProjectGrpc responseList = new ListRfqProjectGrpc();
            if (request == null || request.RfqProjectGrpcsToCreate == null || request.RfqProjectGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqProjectCommand, List<DbRfqProject>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqProjectCommand, List<DbRfqProject>>>();
                RfqProjectCommand command = new RfqProjectCommand(CommandType.Create, request.RfqProjectGrpcsToCreate);
                Result<List<DbRfqProject>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbRfqProject> createdProjects = result.Value;
                    List<RfqProjectGrpc> updatedGrpcProjects = createdProjects.Select(p => p.FromEntity()).ToList();
                    _ListRfqProjectsGrpc.RfqProjects.AddRange(updatedGrpcProjects);
                    responseList.RfqProjects.AddRange(updatedGrpcProjects);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateRfqProjects(RfqProjectGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqProjectGrpc responseList = new ListRfqProjectGrpc();
            if (request == null || request.RfqProjectGrpcsToUpdate == null || request.RfqProjectGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqProjectCommand, List<DbRfqProject>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqProjectCommand, List<DbRfqProject>>>();
                RfqProjectCommand command = new RfqProjectCommand(CommandType.Update, request.RfqProjectGrpcsToUpdate);
                Result<List<DbRfqProject>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (RfqProjectGrpc updatedComponent in request.RfqProjectGrpcsToUpdate)
                    {
                        RfqProjectGrpc? foundItem = _ListRfqProjectsGrpc.RfqProjects.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListRfqProjectsGrpc.RfqProjects.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListRfqProjectsGrpc.RfqProjects[index] = updatedComponent;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        #region RfqNotes

        public async Task<ListRfqNotesGrpc> GetAllRfqNotes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqNotesGrpc.RfqNotes.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListRfqNotesGrpc;
                }

                ListRfqNotesGrpc returnList = new ListRfqNotesGrpc();
                IEnumerable<RfqNotesGrpc> query = _ListRfqNotesGrpc.RfqNotes.Skip(position).Take(takeAmount);
                returnList.RfqNotes.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateRfqNotes(cancellationToken);
                return _ListRfqNotesGrpc;
            }
        }

        public async Task<ListRfqNotesGrpc> CreateRfqNotes(RfqNotesGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqNotesGrpc responseList = new ListRfqNotesGrpc();
            if (request == null || request.RfqNotesGrpcsToCreate == null || request.RfqNotesGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqNotesCommand, List<DbRfqNotes>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqNotesCommand, List<DbRfqNotes>>>();
                RfqNotesCommand command = new RfqNotesCommand(CommandType.Create, request.RfqNotesGrpcsToCreate);
                Result<List<DbRfqNotes>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbRfqNotes> createdComponents = result.Value;
                    List<RfqNotesGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListRfqNotesGrpc.RfqNotes.AddRange(updatedGrpcComponents);
                    responseList.RfqNotes.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateRfqNotes(RfqNotesGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqNotesGrpc responseList = new ListRfqNotesGrpc();
            if (request == null || request.RfqNotesGrpcsToUpdate == null || request.RfqNotesGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqNotesCommand, List<DbRfqNotes>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqNotesCommand, List<DbRfqNotes>>>();
                RfqNotesCommand command = new RfqNotesCommand(CommandType.Update, request.RfqNotesGrpcsToUpdate);
                Result<List<DbRfqNotes>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (RfqNotesGrpc updatedComponent in request.RfqNotesGrpcsToUpdate)
                    {
                        RfqNotesGrpc? foundItem = _ListRfqNotesGrpc.RfqNotes.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListRfqNotesGrpc.RfqNotes.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListRfqNotesGrpc.RfqNotes[index] = updatedComponent;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region RfqReason

        public async Task<ListRfqReasonGrpc> GetAllRfqReasons(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqReasonsGrpc.RfqReasons.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListRfqReasonsGrpc;
                }

                ListRfqReasonGrpc returnList = new ListRfqReasonGrpc();
                IEnumerable<RfqReasonGrpc> query = _ListRfqReasonsGrpc.RfqReasons.Skip(position).Take(takeAmount);
                returnList.RfqReasons.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateRfqReasons(cancellationToken);
                return _ListRfqReasonsGrpc;
            }
        }

        public async Task<ListRfqReasonGrpc> CreateRfqReason(RfqReasonGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqReasonGrpc responseList = new ListRfqReasonGrpc();
            if (request == null || request.RfqReasonGrpcsToCreate == null || request.RfqReasonGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqReasonCommand, List<DbRfqReason>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqReasonCommand, List<DbRfqReason>>>();
                RfqReasonCommand command = new RfqReasonCommand(CommandType.Create, request.RfqReasonGrpcsToCreate);
                Result<List<DbRfqReason>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbRfqReason> createdComponents = result.Value;
                    List<RfqReasonGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListRfqReasonsGrpc.RfqReasons.AddRange(updatedGrpcComponents);
                    responseList.RfqReasons.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateRfqReasons(RfqReasonGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqReasonGrpc responseList = new ListRfqReasonGrpc();
            if (request == null || request.RfqReasonGrpcsToUpdate == null || request.RfqReasonGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqReasonCommand, List<DbRfqReason>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqReasonCommand, List<DbRfqReason>>>();
                RfqReasonCommand command = new RfqReasonCommand(CommandType.Update, request.RfqReasonGrpcsToUpdate);
                Result<List<DbRfqReason>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (RfqReasonGrpc updatedComponent in request.RfqReasonGrpcsToUpdate)
                    {
                        RfqReasonGrpc? foundItem = _ListRfqReasonsGrpc.RfqReasons.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListRfqReasonsGrpc.RfqReasons.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListRfqReasonsGrpc.RfqReasons[index] = updatedComponent;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region DsiBend

        public async Task<ListDsiBendGrpc> GetAllDsiBends(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiBendsGrpc.DsiBends.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiBendsGrpc;
                }

                ListDsiBendGrpc returnList = new ListDsiBendGrpc();
                IEnumerable<DsiBendGrpc> query = _ListDsiBendsGrpc.DsiBends.Skip(position).Take(takeAmount);
                returnList.DsiBends.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateDsiBends(cancellationToken);
                return _ListDsiBendsGrpc;
            }
        }

        public async Task<ListDsiBendGrpc> CreateDsiBends(DsiBendGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBendGrpc responseList = new ListDsiBendGrpc();
            if (request == null || request.DsiBendGrpcsToCreate == null || request.DsiBendGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBendCommand, List<DbDsiBend>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBendCommand, List<DbDsiBend>>>();
                DsiBendCommand command = new DsiBendCommand(CommandType.Create, request.DsiBendGrpcsToCreate);
                Result<List<DbDsiBend>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbDsiBend> createdComponents = result.Value;
                    List<DsiBendGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListDsiBendsGrpc.DsiBends.AddRange(updatedGrpcComponents);
                    responseList.DsiBends.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateDsiBends(DsiBendGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBendGrpc responseList = new ListDsiBendGrpc();
            if (request == null || request.DsiBendGrpcsToUpdate == null || request.DsiBendGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBendCommand, List<DbDsiBend>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBendCommand, List<DbDsiBend>>>();
                DsiBendCommand command = new DsiBendCommand(CommandType.Update, request.DsiBendGrpcsToUpdate);
                Result<List<DbDsiBend>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (DsiBendGrpc updatedComponent in request.DsiBendGrpcsToUpdate)
                    {
                        DsiBendGrpc? foundItem = _ListDsiBendsGrpc.DsiBends.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListDsiBendsGrpc.DsiBends.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListDsiBendsGrpc.DsiBends[index] = updatedComponent;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region DsiBranchConfiguration

        public async Task<ListDsiBranchConfigurationGrpc> GetAllDsiBranchConfigurations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiBranchConfigurationsGrpc.DsiBranchConfigurations.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiBranchConfigurationsGrpc;
                }

                ListDsiBranchConfigurationGrpc returnList = new ListDsiBranchConfigurationGrpc();
                IEnumerable<DsiBranchConfigurationGrpc> query = _ListDsiBranchConfigurationsGrpc.DsiBranchConfigurations.Skip(position).Take(takeAmount);
                returnList.DsiBranchConfigurations.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateDsiBranchConfigurations(cancellationToken);
                return _ListDsiBranchConfigurationsGrpc;
            }
        }

        public async Task<ListDsiBranchConfigurationGrpc> CreateDsiBranchConfigurations(DsiBranchConfigurationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBranchConfigurationGrpc responseList = new ListDsiBranchConfigurationGrpc();
            if (request == null || request.DsiBranchConfigurationGrpcsToCreate == null || request.DsiBranchConfigurationGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBranchConfigurationCommand, List<DbDsiBranchConfiguration>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBranchConfigurationCommand, List<DbDsiBranchConfiguration>>>();
                DsiBranchConfigurationCommand command = new DsiBranchConfigurationCommand(CommandType.Create, request.DsiBranchConfigurationGrpcsToCreate);
                Result<List<DbDsiBranchConfiguration>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbDsiBranchConfiguration> createdComponents = result.Value;
                    List<DsiBranchConfigurationGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListDsiBranchConfigurationsGrpc.DsiBranchConfigurations.AddRange(updatedGrpcComponents);
                    responseList.DsiBranchConfigurations.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateDsiBranchConfigurations(DsiBranchConfigurationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBranchConfigurationGrpc responseList = new ListDsiBranchConfigurationGrpc();
            if (request == null || request.DsiBranchConfigurationGrpcsToUpdate == null || request.DsiBranchConfigurationGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBranchConfigurationCommand, List<DbDsiBranchConfiguration>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBranchConfigurationCommand, List<DbDsiBranchConfiguration>>>();
                DsiBranchConfigurationCommand command = new DsiBranchConfigurationCommand(CommandType.Update, request.DsiBranchConfigurationGrpcsToUpdate);
                Result<List<DbDsiBranchConfiguration>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (DsiBranchConfigurationGrpc updatedComponent in request.DsiBranchConfigurationGrpcsToUpdate)
                    {
                        DsiBranchConfigurationGrpc? foundItem = _ListDsiBranchConfigurationsGrpc.DsiBranchConfigurations.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListDsiBranchConfigurationsGrpc.DsiBranchConfigurations.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListDsiBranchConfigurationsGrpc.DsiBranchConfigurations[index] = updatedComponent;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region DsiBranchConfigurationBendAssociation

        public async Task<ListDsiBranchConfigurationBendAssociationGrpc> GetAllDsiBranchConfigurationBendAssociations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiBranchConfigurationBendAssociationsGrpc.DsiBranchConfigurationBendAssociations.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiBranchConfigurationBendAssociationsGrpc;
                }

                ListDsiBranchConfigurationBendAssociationGrpc returnList = new ListDsiBranchConfigurationBendAssociationGrpc();
                IEnumerable<DsiBranchConfigurationBendAssociationGrpc> query = _ListDsiBranchConfigurationBendAssociationsGrpc.DsiBranchConfigurationBendAssociations.Skip(position).Take(takeAmount);
                returnList.DsiBranchConfigurationBendAssociations.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateDsiBranchConfigurationBendAssociations(cancellationToken);
                return _ListDsiBranchConfigurationBendAssociationsGrpc;
            }
        }

        public async Task<ListDsiBranchConfigurationBendAssociationGrpc> CreateDsiBranchConfigurationBendAssociations(DsiBranchConfigurationBendAssociationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBranchConfigurationBendAssociationGrpc responseList = new ListDsiBranchConfigurationBendAssociationGrpc();
            if (request == null || request.DsiBranchConfigurationBendAssociationGrpcsToCreate == null || request.DsiBranchConfigurationBendAssociationGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBranchConfigurationBendAssociationCommand, List<DbDsiBranchConfigurationBendAssociation>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBranchConfigurationBendAssociationCommand, List<DbDsiBranchConfigurationBendAssociation>>>();
                DsiBranchConfigurationBendAssociationCommand command = new DsiBranchConfigurationBendAssociationCommand(CommandType.Create, request.DsiBranchConfigurationBendAssociationGrpcsToCreate);
                Result<List<DbDsiBranchConfigurationBendAssociation>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbDsiBranchConfigurationBendAssociation> createdComponents = result.Value;
                    List<DsiBranchConfigurationBendAssociationGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListDsiBranchConfigurationBendAssociationsGrpc.DsiBranchConfigurationBendAssociations.AddRange(updatedGrpcComponents);
                    responseList.DsiBranchConfigurationBendAssociations.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateDsiBranchConfigurationBendAssociations(DsiBranchConfigurationBendAssociationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBranchConfigurationBendAssociationGrpc responseList = new ListDsiBranchConfigurationBendAssociationGrpc();
            if (request == null || request.DsiBranchConfigurationBendAssociationGrpcsToUpdate == null || request.DsiBranchConfigurationBendAssociationGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBranchConfigurationBendAssociationCommand, List<DbDsiBranchConfigurationBendAssociation>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBranchConfigurationBendAssociationCommand, List<DbDsiBranchConfigurationBendAssociation>>>();
                DsiBranchConfigurationBendAssociationCommand command = new DsiBranchConfigurationBendAssociationCommand(CommandType.Update, request.DsiBranchConfigurationBendAssociationGrpcsToUpdate);
                Result<List<DbDsiBranchConfigurationBendAssociation>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (DsiBranchConfigurationBendAssociationGrpc updatedComponent in request.DsiBranchConfigurationBendAssociationGrpcsToUpdate)
                    {
                        DsiBranchConfigurationBendAssociationGrpc? foundItem = _ListDsiBranchConfigurationBendAssociationsGrpc.DsiBranchConfigurationBendAssociations.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListDsiBranchConfigurationBendAssociationsGrpc.DsiBranchConfigurationBendAssociations.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListDsiBranchConfigurationBendAssociationsGrpc.DsiBranchConfigurationBendAssociations[index] = updatedComponent;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region DsiBranchInsulation

        public async Task<ListDsiBranchInsulationGrpc> GetAllDsiBranchInsulations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiBranchInsulationsGrpc.DsiBranchInsulations.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiBranchInsulationsGrpc;
                }

                ListDsiBranchInsulationGrpc returnList = new ListDsiBranchInsulationGrpc();
                IEnumerable<DsiBranchInsulationGrpc> query = _ListDsiBranchInsulationsGrpc.DsiBranchInsulations.Skip(position).Take(takeAmount);
                returnList.DsiBranchInsulations.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateDsiBranchInsulations(cancellationToken);
                return _ListDsiBranchInsulationsGrpc;
            }
        }

        public async Task<ListDsiBranchInsulationGrpc> CreateDsiBranchInsulations(DsiBranchInsulationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBranchInsulationGrpc responseList = new ListDsiBranchInsulationGrpc();
            if (request == null || request.DsiBranchInsulationGrpcsToCreate == null || request.DsiBranchInsulationGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBranchInsulationCommand, List<DbDsiBranchInsulation>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBranchInsulationCommand, List<DbDsiBranchInsulation>>>();
                DsiBranchInsulationCommand command = new DsiBranchInsulationCommand(CommandType.Create, request.DsiBranchInsulationGrpcsToCreate);
                Result<List<DbDsiBranchInsulation>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbDsiBranchInsulation> createdComponents = result.Value;
                    List<DsiBranchInsulationGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListDsiBranchInsulationsGrpc.DsiBranchInsulations.AddRange(updatedGrpcComponents);
                    responseList.DsiBranchInsulations.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateDsiBranchInsulations(DsiBranchInsulationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBranchInsulationGrpc responseList = new ListDsiBranchInsulationGrpc();
            if (request == null || request.DsiBranchInsulationGrpcsToUpdate == null || request.DsiBranchInsulationGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBranchInsulationCommand, List<DbDsiBranchInsulation>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBranchInsulationCommand, List<DbDsiBranchInsulation>>>();
                DsiBranchInsulationCommand command = new DsiBranchInsulationCommand(CommandType.Update, request.DsiBranchInsulationGrpcsToUpdate);
                Result<List<DbDsiBranchInsulation>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (DsiBranchInsulationGrpc updatedComponent in request.DsiBranchInsulationGrpcsToUpdate)
                    {
                        DsiBranchInsulationGrpc? foundItem = _ListDsiBranchInsulationsGrpc.DsiBranchInsulations.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListDsiBranchInsulationsGrpc.DsiBranchInsulations.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListDsiBranchInsulationsGrpc.DsiBranchInsulations[index] = updatedComponent;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region DsiBranchInsulationThroughNode

        public async Task<ListDsiBranchInsulationThroughNodeGrpc> GetAllDsiBranchInsulationThroughNodes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiBranchInsulationThroughNodesGrpc.DsiBranchInsulationThroughNodes.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiBranchInsulationThroughNodesGrpc;
                }

                ListDsiBranchInsulationThroughNodeGrpc returnList = new ListDsiBranchInsulationThroughNodeGrpc();
                IEnumerable<DsiBranchInsulationThroughNodeGrpc> query = _ListDsiBranchInsulationThroughNodesGrpc.DsiBranchInsulationThroughNodes.Skip(position).Take(takeAmount);
                returnList.DsiBranchInsulationThroughNodes.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateDsiBranchInsulationThroughNodes(cancellationToken);
                return _ListDsiBranchInsulationThroughNodesGrpc;
            }
        }

        public async Task<ListDsiBranchInsulationThroughNodeGrpc> CreateDsiBranchInsulationThroughNodes(DsiBranchInsulationThroughNodeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBranchInsulationThroughNodeGrpc responseList = new ListDsiBranchInsulationThroughNodeGrpc();
            if (request == null || request.DsiBranchInsulationThroughNodeGrpcsToCreate == null || request.DsiBranchInsulationThroughNodeGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBranchInsulationThroughNodeCommand, List<DbDsiBranchInsulationThroughNode>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBranchInsulationThroughNodeCommand, List<DbDsiBranchInsulationThroughNode>>>();
                DsiBranchInsulationThroughNodeCommand command = new DsiBranchInsulationThroughNodeCommand(CommandType.Create, request.DsiBranchInsulationThroughNodeGrpcsToCreate);
                Result<List<DbDsiBranchInsulationThroughNode>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbDsiBranchInsulationThroughNode> createdComponents = result.Value;
                    List<DsiBranchInsulationThroughNodeGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListDsiBranchInsulationThroughNodesGrpc.DsiBranchInsulationThroughNodes.AddRange(updatedGrpcComponents);
                    responseList.DsiBranchInsulationThroughNodes.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateDsiBranchInsulationThroughNodes(DsiBranchInsulationThroughNodeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiBranchInsulationThroughNodeGrpc responseList = new ListDsiBranchInsulationThroughNodeGrpc();
            if (request == null || request.DsiBranchInsulationThroughNodeGrpcsToUpdate == null || request.DsiBranchInsulationThroughNodeGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiBranchInsulationThroughNodeCommand, List<DbDsiBranchInsulationThroughNode>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiBranchInsulationThroughNodeCommand, List<DbDsiBranchInsulationThroughNode>>>();
                DsiBranchInsulationThroughNodeCommand command = new DsiBranchInsulationThroughNodeCommand(CommandType.Update, request.DsiBranchInsulationThroughNodeGrpcsToUpdate);
                Result<List<DbDsiBranchInsulationThroughNode>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (DsiBranchInsulationThroughNodeGrpc updatedComponent in request.DsiBranchInsulationThroughNodeGrpcsToUpdate)
                    {
                        DsiBranchInsulationThroughNodeGrpc? foundItem = _ListDsiBranchInsulationThroughNodesGrpc.DsiBranchInsulationThroughNodes.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListDsiBranchInsulationThroughNodesGrpc.DsiBranchInsulationThroughNodes.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListDsiBranchInsulationThroughNodesGrpc.DsiBranchInsulationThroughNodes[index] = updatedComponent;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region DsiCavityMapping

        public async Task<ListDsiCavityMappingGrpc> GetAllDsiCavityMappings(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiCavityMappings.DsiCavityMappingGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiCavityMappings;
                }

                ListDsiCavityMappingGrpc returnList = new ListDsiCavityMappingGrpc();
                IEnumerable<DsiCavityMappingGrpc> query = _ListDsiCavityMappings.DsiCavityMappingGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiCavityMappingGrpcs.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateDsiCavityMappings(cancellationToken);
                return _ListDsiCavityMappings;
            }
        }

        public async Task<ListDsiCavityMappingGrpc> CreateDsiCavityMappings(DsiCavityMappingGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiCavityMappingGrpc responseList = new ListDsiCavityMappingGrpc();
            if (request == null || request.DsiCavityMappingGrpcsToCreate == null || request.DsiCavityMappingGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiCavityMappingCommand, List<DbDsiCavityMapping>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiCavityMappingCommand, List<DbDsiCavityMapping>>>();
                DsiCavityMappingCommand command = new DsiCavityMappingCommand(CommandType.Create, request.DsiCavityMappingGrpcsToCreate);
                Result<List<DbDsiCavityMapping>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    List<DbDsiCavityMapping> createdComponents = result.Value;
                    List<DsiCavityMappingGrpc> updatedGrpcComponents = createdComponents.Select(p => p.FromEntity()).ToList();
                    _ListDsiCavityMappings.DsiCavityMappingGrpcs.AddRange(updatedGrpcComponents);
                    responseList.DsiCavityMappingGrpcs.AddRange(updatedGrpcComponents);
                    return responseList;
                }
                else
                {
                    return responseList;
                }
            }
        }

        public async Task<bool> UpdateDsiCavityMappings(DsiCavityMappingGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiCavityMappingGrpc responseList = new ListDsiCavityMappingGrpc();
            if (request == null || request.DsiCavityMappingGrpcsToUpdate == null || request.DsiCavityMappingGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiCavityMappingCommand, List<DbDsiCavityMapping>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiCavityMappingCommand, List<DbDsiCavityMapping>>>();
                DsiCavityMappingCommand command = new DsiCavityMappingCommand(CommandType.Update, request.DsiCavityMappingGrpcsToUpdate);
                Result<List<DbDsiCavityMapping>> result = await handler.Handle(command, cancellationToken);
                if (result.IsSuccess)
                {
                    foreach (DsiCavityMappingGrpc updatedComponent in request.DsiCavityMappingGrpcsToUpdate)
                    {
                        DsiCavityMappingGrpc? foundItem = _ListDsiCavityMappings.DsiCavityMappingGrpcs.FirstOrDefault(p => p.RowId == updatedComponent.RowId);
                        if (foundItem == null)
                        {
                            continue;
                        }

                        int index = _ListDsiCavityMappings.DsiCavityMappingGrpcs.IndexOf(foundItem);
                        if (index != -1)
                        {
                            _ListDsiCavityMappings.DsiCavityMappingGrpcs[index] = updatedComponent;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion

        #region DsiCentreStrip

        public async Task<ListDsiCentreStripGrpc> GetAllDsiCentreStrips(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiCentreStripGrpc.DsiCentreStripGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiCentreStripGrpc;
                }

                ListDsiCentreStripGrpc returnList = new ListDsiCentreStripGrpc();
                IEnumerable<DsiCentreStripGrpc> query = _ListDsiCentreStripGrpc.DsiCentreStripGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiCentreStripGrpcs.AddRange(query);
                return returnList;
            }
            else
            {
                await PopulateDsiCentreStrips(cancellationToken);
                return _ListDsiCentreStripGrpc;
            }
        }

        public async Task<ListDsiCentreStripGrpc> CreateDsiCentreStrips(DsiCentreStripGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiCentreStripGrpc responseList = new ListDsiCentreStripGrpc();
            if (request?.DsiCentreStripGrpcsToCreate == null || request.DsiCentreStripGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiCentreStripCommand, List<DbDsiCentreStrip>> handler =
                    scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiCentreStripCommand, List<DbDsiCentreStrip>>>();

                DsiCentreStripCommand command = new DsiCentreStripCommand(CommandType.Create, request.DsiCentreStripGrpcsToCreate);
                Result<List<DbDsiCentreStrip>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiCentreStripGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiCentreStripGrpc.DsiCentreStripGrpcs.AddRange(updated);
                    responseList.DsiCentreStripGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiCentreStrips(DsiCentreStripGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiCentreStripGrpcsToUpdate == null || request.DsiCentreStripGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiCentreStripCommand, List<DbDsiCentreStrip>> handler =
                    scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiCentreStripCommand, List<DbDsiCentreStrip>>>();

                DsiCentreStripCommand command = new DsiCentreStripCommand(CommandType.Update, request.DsiCentreStripGrpcsToUpdate);
                Result<List<DbDsiCentreStrip>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiCentreStripGrpc updated in request.DsiCentreStripGrpcsToUpdate)
                    {
                        DsiCentreStripGrpc? existing = _ListDsiCentreStripGrpc.DsiCentreStripGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiCentreStripGrpc.DsiCentreStripGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiCentreStripGrpc.DsiCentreStripGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiCircuitOption

        public async Task<ListDsiCircuitOptionGrpc> GetAllDsiCircuitOptions(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiCircuitOptionGrpc;
                }

                ListDsiCircuitOptionGrpc returnList = new ListDsiCircuitOptionGrpc();
                IEnumerable<DsiCircuitOptionGrpc> query = _ListDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiCircuitOptionGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiCircuitOptions(cancellationToken);
            return _ListDsiCircuitOptionGrpc;
        }

        public async Task<ListDsiCircuitOptionGrpc> CreateDsiCircuitOptions(DsiCircuitOptionGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiCircuitOptionGrpc responseList = new ListDsiCircuitOptionGrpc();
            if (request?.DsiCircuitOptionGrpcsToCreate == null || request.DsiCircuitOptionGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiCircuitOptionCommand, List<DbDsiCircuitOption>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiCircuitOptionCommand, List<DbDsiCircuitOption>>>();
                DsiCircuitOptionCommand command = new DsiCircuitOptionCommand(CommandType.Create, request.DsiCircuitOptionGrpcsToCreate);
                Result<List<DbDsiCircuitOption>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiCircuitOptionGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs.AddRange(updated);
                    responseList.DsiCircuitOptionGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiCircuitOptions(DsiCircuitOptionGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiCircuitOptionGrpcsToUpdate == null || request.DsiCircuitOptionGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiCircuitOptionCommand, List<DbDsiCircuitOption>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiCircuitOptionCommand, List<DbDsiCircuitOption>>>();
                DsiCircuitOptionCommand command = new DsiCircuitOptionCommand(CommandType.Update, request.DsiCircuitOptionGrpcsToUpdate);
                Result<List<DbDsiCircuitOption>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiCircuitOptionGrpc? updated in request.DsiCircuitOptionGrpcsToUpdate)
                    {
                        DsiCircuitOptionGrpc? existing = _ListDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiComponent

        public async Task<ListDsiComponentGrpc> GetAllDsiComponents(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiComponentGrpc.DsiComponentGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiComponentGrpc;
                }

                ListDsiComponentGrpc returnList = new ListDsiComponentGrpc();
                IEnumerable<DsiComponentGrpc> query = _ListDsiComponentGrpc.DsiComponentGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiComponentGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiComponents(cancellationToken);
            return _ListDsiComponentGrpc;
        }

        public async Task<ListDsiComponentGrpc> CreateDsiComponents(DsiComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiComponentGrpc responseList = new ListDsiComponentGrpc();
            if (request?.DsiComponentGrpcsToCreate == null || request.DsiComponentGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiComponentCommand, List<DbDsiComponent>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiComponentCommand, List<DbDsiComponent>>>();
                DsiComponentCommand command = new DsiComponentCommand(CommandType.Create, request.DsiComponentGrpcsToCreate);
                Result<List<DbDsiComponent>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiComponentGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiComponentGrpc.DsiComponentGrpcs.AddRange(updated);
                    responseList.DsiComponentGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiComponents(DsiComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiComponentGrpcsToUpdate == null || request.DsiComponentGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiComponentCommand, List<DbDsiComponent>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiComponentCommand, List<DbDsiComponent>>>();
                DsiComponentCommand command = new DsiComponentCommand(CommandType.Update, request.DsiComponentGrpcsToUpdate);
                Result<List<DbDsiComponent>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiComponentGrpc? updated in request.DsiComponentGrpcsToUpdate)
                    {
                        DsiComponentGrpc? existing = _ListDsiComponentGrpc.DsiComponentGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiComponentGrpc.DsiComponentGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiComponentGrpc.DsiComponentGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiCompositeDetail

        public async Task<ListDsiCompositeDetailGrpc> GetAllDsiCompositeDetails(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiCompositeDetailGrpc.DsiCompositeDetailGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiCompositeDetailGrpc;
                }

                ListDsiCompositeDetailGrpc returnList = new ListDsiCompositeDetailGrpc();
                IEnumerable<DsiCompositeDetailGrpc> query = _ListDsiCompositeDetailGrpc.DsiCompositeDetailGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiCompositeDetailGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiCompositeDetails(cancellationToken);
            return _ListDsiCompositeDetailGrpc;
        }

        public async Task<ListDsiCompositeDetailGrpc> CreateDsiCompositeDetails(DsiCompositeDetailGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiCompositeDetailGrpc responseList = new ListDsiCompositeDetailGrpc();
            if (request?.DsiCompositeDetailGrpcsToCreate == null || request.DsiCompositeDetailGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiCompositeDetailCommand, List<DbDsiCompositeDetail>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiCompositeDetailCommand, List<DbDsiCompositeDetail>>>();
                DsiCompositeDetailCommand command = new DsiCompositeDetailCommand(CommandType.Create, request.DsiCompositeDetailGrpcsToCreate);
                Result<List<DbDsiCompositeDetail>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiCompositeDetailGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiCompositeDetailGrpc.DsiCompositeDetailGrpcs.AddRange(updated);
                    responseList.DsiCompositeDetailGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiCompositeDetails(DsiCompositeDetailGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiCompositeDetailGrpcsToUpdate == null || request.DsiCompositeDetailGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiCompositeDetailCommand, List<DbDsiCompositeDetail>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiCompositeDetailCommand, List<DbDsiCompositeDetail>>>();
                DsiCompositeDetailCommand command = new DsiCompositeDetailCommand(CommandType.Update, request.DsiCompositeDetailGrpcsToUpdate);
                Result<List<DbDsiCompositeDetail>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiCompositeDetailGrpc? updated in request.DsiCompositeDetailGrpcsToUpdate)
                    {
                        DsiCompositeDetailGrpc? existing = _ListDsiCompositeDetailGrpc.DsiCompositeDetailGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiCompositeDetailGrpc.DsiCompositeDetailGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiCompositeDetailGrpc.DsiCompositeDetailGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiCompositeDetailCircuitOptionAssociation

        public async Task<ListDsiCompositeDetailCircuitOptionAssociationGrpc> GetAllDsiCompositeDetailCircuitOptionAssociations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiCompositeDetailCircuitOptionAssociationGrpc.DsiCompositeDetailCircuitOptionAssociationGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiCompositeDetailCircuitOptionAssociationGrpc;
                }

                ListDsiCompositeDetailCircuitOptionAssociationGrpc returnList = new ListDsiCompositeDetailCircuitOptionAssociationGrpc();
                IEnumerable<DsiCompositeDetailCircuitOptionAssociationGrpc> query = _ListDsiCompositeDetailCircuitOptionAssociationGrpc.DsiCompositeDetailCircuitOptionAssociationGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiCompositeDetailCircuitOptionAssociationGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiCompositeDetailCircuitOptionAssociations(cancellationToken);
            return _ListDsiCompositeDetailCircuitOptionAssociationGrpc;
        }

        public async Task<ListDsiCompositeDetailCircuitOptionAssociationGrpc> CreateDsiCompositeDetailCircuitOptionAssociations(DsiCompositeDetailCircuitOptionAssociationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiCompositeDetailCircuitOptionAssociationGrpc responseList = new ListDsiCompositeDetailCircuitOptionAssociationGrpc();
            if (request?.DsiCompositeDetailCircuitOptionAssociationGrpcsToCreate == null || request.DsiCompositeDetailCircuitOptionAssociationGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiCompositeDetailCircuitOptionAssociationCommand, List<DbDsiCompositeDetailCircuitOptionAssociation>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiCompositeDetailCircuitOptionAssociationCommand, List<DbDsiCompositeDetailCircuitOptionAssociation>>>();
                DsiCompositeDetailCircuitOptionAssociationCommand command = new DsiCompositeDetailCircuitOptionAssociationCommand(CommandType.Create, request.DsiCompositeDetailCircuitOptionAssociationGrpcsToCreate);
                Result<List<DbDsiCompositeDetailCircuitOptionAssociation>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiCompositeDetailCircuitOptionAssociationGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiCompositeDetailCircuitOptionAssociationGrpc.DsiCompositeDetailCircuitOptionAssociationGrpcs.AddRange(updated);
                    responseList.DsiCompositeDetailCircuitOptionAssociationGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiCompositeDetailCircuitOptionAssociations(DsiCompositeDetailCircuitOptionAssociationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiCompositeDetailCircuitOptionAssociationGrpcsToUpdate == null || request.DsiCompositeDetailCircuitOptionAssociationGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiCompositeDetailCircuitOptionAssociationCommand, List<DbDsiCompositeDetailCircuitOptionAssociation>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiCompositeDetailCircuitOptionAssociationCommand, List<DbDsiCompositeDetailCircuitOptionAssociation>>>();
                DsiCompositeDetailCircuitOptionAssociationCommand command = new DsiCompositeDetailCircuitOptionAssociationCommand(CommandType.Update, request.DsiCompositeDetailCircuitOptionAssociationGrpcsToUpdate);
                Result<List<DbDsiCompositeDetailCircuitOptionAssociation>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiCompositeDetailCircuitOptionAssociationGrpc? updated in request.DsiCompositeDetailCircuitOptionAssociationGrpcsToUpdate)
                    {
                        DsiCompositeDetailCircuitOptionAssociationGrpc? existing = _ListDsiCompositeDetailCircuitOptionAssociationGrpc.DsiCompositeDetailCircuitOptionAssociationGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiCompositeDetailCircuitOptionAssociationGrpc.DsiCompositeDetailCircuitOptionAssociationGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiCompositeDetailCircuitOptionAssociationGrpc.DsiCompositeDetailCircuitOptionAssociationGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiCompositeOption

        public async Task<ListDsiCompositeOptionGrpc> GetAllDsiCompositeOptions(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiCompositeOptionGrpc.DsiCompositeOptionGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiCompositeOptionGrpc;
                }

                ListDsiCompositeOptionGrpc returnList = new ListDsiCompositeOptionGrpc();
                IEnumerable<DsiCompositeOptionGrpc> query = _ListDsiCompositeOptionGrpc.DsiCompositeOptionGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiCompositeOptionGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiCompositeOptions(cancellationToken);
            return _ListDsiCompositeOptionGrpc;
        }

        public async Task<ListDsiCompositeOptionGrpc> CreateDsiCompositeOptions(DsiCompositeOptionGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiCompositeOptionGrpc responseList = new ListDsiCompositeOptionGrpc();
            if (request?.DsiCompositeOptionGrpcsToCreate == null || request.DsiCompositeOptionGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiCompositeOptionCommand, List<DbDsiCompositeOption>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiCompositeOptionCommand, List<DbDsiCompositeOption>>>();
                DsiCompositeOptionCommand command = new DsiCompositeOptionCommand(CommandType.Create, request.DsiCompositeOptionGrpcsToCreate);
                Result<List<DbDsiCompositeOption>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiCompositeOptionGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiCompositeOptionGrpc.DsiCompositeOptionGrpcs.AddRange(updated);
                    responseList.DsiCompositeOptionGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiCompositeOptions(DsiCompositeOptionGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiCompositeOptionGrpcsToUpdate == null || request.DsiCompositeOptionGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiCompositeOptionCommand, List<DbDsiCompositeOption>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiCompositeOptionCommand, List<DbDsiCompositeOption>>>();
                DsiCompositeOptionCommand command = new DsiCompositeOptionCommand(CommandType.Update, request.DsiCompositeOptionGrpcsToUpdate);
                Result<List<DbDsiCompositeOption>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiCompositeOptionGrpc? updated in request.DsiCompositeOptionGrpcsToUpdate)
                    {
                        DsiCompositeOptionGrpc? existing = _ListDsiCompositeOptionGrpc.DsiCompositeOptionGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiCompositeOptionGrpc.DsiCompositeOptionGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiCompositeOptionGrpc.DsiCompositeOptionGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiHarness

        public async Task<ListDsiHarnessGrpc> GetAllDsiHarnesses(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiHarnessGrpc.DsiHarnessGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiHarnessGrpc;
                }

                ListDsiHarnessGrpc returnList = new ListDsiHarnessGrpc();
                IEnumerable<DsiHarnessGrpc> query = _ListDsiHarnessGrpc.DsiHarnessGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiHarnessGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiHarnesses(cancellationToken);
            return _ListDsiHarnessGrpc;
        }

        public async Task<ListDsiHarnessGrpc> CreateDsiHarnesses(DsiHarnessGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiHarnessGrpc responseList = new ListDsiHarnessGrpc();
            if (request?.DsiHarnessGrpcsToCreate == null || request.DsiHarnessGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiHarnessCommand, List<DbDsiHarness>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiHarnessCommand, List<DbDsiHarness>>>();
                DsiHarnessCommand command = new DsiHarnessCommand(CommandType.Create, request.DsiHarnessGrpcsToCreate);
                Result<List<DbDsiHarness>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiHarnessGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiHarnessGrpc.DsiHarnessGrpcs.AddRange(updated);
                    responseList.DsiHarnessGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiHarnesses(DsiHarnessGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiHarnessGrpcsToUpdate == null || request.DsiHarnessGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiHarnessCommand, List<DbDsiHarness>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiHarnessCommand, List<DbDsiHarness>>>();
                DsiHarnessCommand command = new DsiHarnessCommand(CommandType.Update, request.DsiHarnessGrpcsToUpdate);
                Result<List<DbDsiHarness>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiHarnessGrpc? updated in request.DsiHarnessGrpcsToUpdate)
                    {
                        DsiHarnessGrpc? existing = _ListDsiHarnessGrpc.DsiHarnessGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiHarnessGrpc.DsiHarnessGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiHarnessGrpc.DsiHarnessGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiHarnessScope

        public async Task<ListDsiHarnessScopeGrpc> GetAllDsiHarnessScopes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiHarnessScopeGrpc.DsiHarnessScopeGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiHarnessScopeGrpc;
                }

                ListDsiHarnessScopeGrpc returnList = new ListDsiHarnessScopeGrpc();
                IEnumerable<DsiHarnessScopeGrpc> query = _ListDsiHarnessScopeGrpc.DsiHarnessScopeGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiHarnessScopeGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiHarnessScopes(cancellationToken);
            return _ListDsiHarnessScopeGrpc;
        }

        public async Task<ListDsiHarnessScopeGrpc> CreateDsiHarnessScopes(DsiHarnessScopeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiHarnessScopeGrpc responseList = new ListDsiHarnessScopeGrpc();
            if (request?.DsiHarnessScopeGrpcsToCreate == null || request.DsiHarnessScopeGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiHarnessScopeCommand, List<DbDsiHarnessScope>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiHarnessScopeCommand, List<DbDsiHarnessScope>>>();
                DsiHarnessScopeCommand command = new DsiHarnessScopeCommand(CommandType.Create, request.DsiHarnessScopeGrpcsToCreate);
                Result<List<DbDsiHarnessScope>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiHarnessScopeGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiHarnessScopeGrpc.DsiHarnessScopeGrpcs.AddRange(updated);
                    responseList.DsiHarnessScopeGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiHarnessScopes(DsiHarnessScopeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiHarnessScopeGrpcsToUpdate == null || request.DsiHarnessScopeGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiHarnessScopeCommand, List<DbDsiHarnessScope>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiHarnessScopeCommand, List<DbDsiHarnessScope>>>();
                DsiHarnessScopeCommand command = new DsiHarnessScopeCommand(CommandType.Update, request.DsiHarnessScopeGrpcsToUpdate);
                Result<List<DbDsiHarnessScope>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiHarnessScopeGrpc? updated in request.DsiHarnessScopeGrpcsToUpdate)
                    {
                        DsiHarnessScopeGrpc? existing = _ListDsiHarnessScopeGrpc.DsiHarnessScopeGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiHarnessScopeGrpc.DsiHarnessScopeGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiHarnessScopeGrpc.DsiHarnessScopeGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiHarnessScopeScopeAssociation

        public async Task<ListDsiHarnessScopeScopeAssociationGrpc> GetAllDsiHarnessScopeScopeAssociations(CancellationToken cancellationToken, int position, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiHarnessScopeScopeAssociationGrpc.DsiHarnessScopeScopeAssociationGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiHarnessScopeScopeAssociationGrpc;
                }

                ListDsiHarnessScopeScopeAssociationGrpc returnList = new ListDsiHarnessScopeScopeAssociationGrpc();
                IEnumerable<DsiHarnessScopeScopeAssociationGrpc> query = _ListDsiHarnessScopeScopeAssociationGrpc.DsiHarnessScopeScopeAssociationGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiHarnessScopeScopeAssociationGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiHarnessScopeScopeAssociations(cancellationToken);
            return _ListDsiHarnessScopeScopeAssociationGrpc;
        }

        public async Task<ListDsiHarnessScopeScopeAssociationGrpc> CreateDsiHarnessScopeScopeAssociations(DsiHarnessScopeScopeAssociationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiHarnessScopeScopeAssociationGrpc responseList = new ListDsiHarnessScopeScopeAssociationGrpc();
            if (request?.DsiHarnessScopeScopeAssociationGrpcsToCreate == null || request.DsiHarnessScopeScopeAssociationGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiHarnessScopeScopeAssociationCommand, List<DbDsiHarnessScopeScopeAssociation>> handler =
                    scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiHarnessScopeScopeAssociationCommand, List<DbDsiHarnessScopeScopeAssociation>>>();
                DsiHarnessScopeScopeAssociationCommand command =
                    new DsiHarnessScopeScopeAssociationCommand(CommandType.Create, request.DsiHarnessScopeScopeAssociationGrpcsToCreate);
                Result<List<DbDsiHarnessScopeScopeAssociation>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiHarnessScopeScopeAssociationGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiHarnessScopeScopeAssociationGrpc.DsiHarnessScopeScopeAssociationGrpcs.AddRange(updated);
                    responseList.DsiHarnessScopeScopeAssociationGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiHarnessScopeScopeAssociations(DsiHarnessScopeScopeAssociationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiHarnessScopeScopeAssociationGrpcsToUpdate == null || request.DsiHarnessScopeScopeAssociationGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiHarnessScopeScopeAssociationCommand, List<DbDsiHarnessScopeScopeAssociation>> handler =
                    scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiHarnessScopeScopeAssociationCommand, List<DbDsiHarnessScopeScopeAssociation>>>();
                DsiHarnessScopeScopeAssociationCommand command =
                    new DsiHarnessScopeScopeAssociationCommand(CommandType.Update, request.DsiHarnessScopeScopeAssociationGrpcsToUpdate);
                Result<List<DbDsiHarnessScopeScopeAssociation>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiHarnessScopeScopeAssociationGrpc? updated in request.DsiHarnessScopeScopeAssociationGrpcsToUpdate)
                    {
                        DsiHarnessScopeScopeAssociationGrpc? existing =
                            _ListDsiHarnessScopeScopeAssociationGrpc.DsiHarnessScopeScopeAssociationGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiHarnessScopeScopeAssociationGrpc.DsiHarnessScopeScopeAssociationGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiHarnessScopeScopeAssociationGrpc.DsiHarnessScopeScopeAssociationGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiManualBomQuantity

        public async Task<ListDsiManualBomQuantityGrpc> GetAllDsiManualBomQuantities(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiManualBomQuantityGrpc.DsiManualBomQuantityGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiManualBomQuantityGrpc;
                }

                ListDsiManualBomQuantityGrpc returnList = new ListDsiManualBomQuantityGrpc();
                IEnumerable<DsiManualBomQuantityGrpc> query = _ListDsiManualBomQuantityGrpc.DsiManualBomQuantityGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiManualBomQuantityGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiManualBomQuantities(cancellationToken);
            return _ListDsiManualBomQuantityGrpc;
        }

        public async Task<ListDsiManualBomQuantityGrpc> CreateDsiManualBomQuantities(DsiManualBomQuantityGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiManualBomQuantityGrpc responseList = new ListDsiManualBomQuantityGrpc();
            if (request?.DsiManualBomQuantityGrpcsToCreate == null || request.DsiManualBomQuantityGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiManualBomQuantityCommand, List<DbDsiManualBomQuantity>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiManualBomQuantityCommand, List<DbDsiManualBomQuantity>>>();
                DsiManualBomQuantityCommand command = new DsiManualBomQuantityCommand(CommandType.Create, request.DsiManualBomQuantityGrpcsToCreate);
                Result<List<DbDsiManualBomQuantity>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiManualBomQuantityGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiManualBomQuantityGrpc.DsiManualBomQuantityGrpcs.AddRange(updated);
                    responseList.DsiManualBomQuantityGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiManualBomQuantities(DsiManualBomQuantityGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiManualBomQuantityGrpcsToUpdate == null || request.DsiManualBomQuantityGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiManualBomQuantityCommand, List<DbDsiManualBomQuantity>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiManualBomQuantityCommand, List<DbDsiManualBomQuantity>>>();
                DsiManualBomQuantityCommand command = new DsiManualBomQuantityCommand(CommandType.Update, request.DsiManualBomQuantityGrpcsToUpdate);
                Result<List<DbDsiManualBomQuantity>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiManualBomQuantityGrpc? updated in request.DsiManualBomQuantityGrpcsToUpdate)
                    {
                        DsiManualBomQuantityGrpc? existing = _ListDsiManualBomQuantityGrpc.DsiManualBomQuantityGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiManualBomQuantityGrpc.DsiManualBomQuantityGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiManualBomQuantityGrpc.DsiManualBomQuantityGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiMidWireComponent

        public async Task<ListDsiMidWireComponentGrpc> GetAllDsiMidWireComponents(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiMidWireComponentGrpc.DsiMidWireComponentGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiMidWireComponentGrpc;
                }

                ListDsiMidWireComponentGrpc returnList = new ListDsiMidWireComponentGrpc();
                IEnumerable<DsiMidWireComponentGrpc> query = _ListDsiMidWireComponentGrpc.DsiMidWireComponentGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiMidWireComponentGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiManualBomQuantities(cancellationToken);
            return _ListDsiMidWireComponentGrpc;
        }

        public async Task<ListDsiMidWireComponentGrpc> CreateDsiMidWireComponents(DsiMidWireComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiMidWireComponentGrpc responseList = new ListDsiMidWireComponentGrpc();
            if (request?.DsiMidWireComponentGrpcsToCreate == null || request.DsiMidWireComponentGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiMidWireComponentCommand, List<DbDsiMidWireComponent>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiMidWireComponentCommand, List<DbDsiMidWireComponent>>>();
                DsiMidWireComponentCommand command = new DsiMidWireComponentCommand(CommandType.Create, request.DsiMidWireComponentGrpcsToCreate);
                Result<List<DbDsiMidWireComponent>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiMidWireComponentGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiMidWireComponentGrpc.DsiMidWireComponentGrpcs.AddRange(updated);
                    responseList.DsiMidWireComponentGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiMidWireComponents(DsiMidWireComponentGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiMidWireComponentGrpcsToUpdate == null || request.DsiMidWireComponentGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiMidWireComponentCommand, List<DbDsiMidWireComponent>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiMidWireComponentCommand, List<DbDsiMidWireComponent>>>();
                DsiMidWireComponentCommand command = new DsiMidWireComponentCommand(CommandType.Update, request.DsiMidWireComponentGrpcsToUpdate);
                Result<List<DbDsiMidWireComponent>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiMidWireComponentGrpc? updated in request.DsiMidWireComponentGrpcsToUpdate)
                    {
                        DsiMidWireComponentGrpc? existing = _ListDsiMidWireComponentGrpc.DsiMidWireComponentGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiMidWireComponentGrpc.DsiMidWireComponentGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiMidWireComponentGrpc.DsiMidWireComponentGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiModuleChildDetail

        public async Task<ListDsiModuleChildDetailGrpc> GetAllDsiModuleChildDetails(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiModuleChildDetailGrpc.DsiModuleChildDetailGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiModuleChildDetailGrpc;
                }

                ListDsiModuleChildDetailGrpc returnList = new ListDsiModuleChildDetailGrpc();
                IEnumerable<DsiModuleChildDetailGrpc> query = _ListDsiModuleChildDetailGrpc.DsiModuleChildDetailGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiModuleChildDetailGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiModuleChildDetails(cancellationToken);
            return _ListDsiModuleChildDetailGrpc;
        }

        public async Task<ListDsiModuleChildDetailGrpc> CreateDsiModuleChildDetails(DsiModuleChildDetailGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiModuleChildDetailGrpc responseList = new ListDsiModuleChildDetailGrpc();
            if (request?.DsiModuleChildDetailGrpcsToCreate == null || request.DsiModuleChildDetailGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiModuleChildDetailCommand, List<DbDsiModuleChildDetail>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiModuleChildDetailCommand, List<DbDsiModuleChildDetail>>>();
                DsiModuleChildDetailCommand command = new DsiModuleChildDetailCommand(CommandType.Create, request.DsiModuleChildDetailGrpcsToCreate);
                Result<List<DbDsiModuleChildDetail>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiModuleChildDetailGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiModuleChildDetailGrpc.DsiModuleChildDetailGrpcs.AddRange(updated);
                    responseList.DsiModuleChildDetailGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiModuleChildDetails(DsiModuleChildDetailGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiModuleChildDetailGrpcsToUpdate == null || request.DsiModuleChildDetailGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiModuleChildDetailCommand, List<DbDsiModuleChildDetail>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiModuleChildDetailCommand, List<DbDsiModuleChildDetail>>>();
                DsiModuleChildDetailCommand command = new DsiModuleChildDetailCommand(CommandType.Update, request.DsiModuleChildDetailGrpcsToUpdate);
                Result<List<DbDsiModuleChildDetail>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiModuleChildDetailGrpc? updated in request.DsiModuleChildDetailGrpcsToUpdate)
                    {
                        DsiModuleChildDetailGrpc? existing = _ListDsiModuleChildDetailGrpc.DsiModuleChildDetailGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiModuleChildDetailGrpc.DsiModuleChildDetailGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiModuleChildDetailGrpc.DsiModuleChildDetailGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiModuleCompatibility

        public async Task<ListDsiModuleCompatibilityGrpc> GetAllDsiModuleCompatibilities(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiModuleCompatibilityGrpc.DsiModuleCompatibilityGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiModuleCompatibilityGrpc;
                }

                ListDsiModuleCompatibilityGrpc returnList = new ListDsiModuleCompatibilityGrpc();
                IEnumerable<DsiModuleCompatibilityGrpc> query = _ListDsiModuleCompatibilityGrpc.DsiModuleCompatibilityGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiModuleCompatibilityGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiModuleCompatibilities(cancellationToken);
            return _ListDsiModuleCompatibilityGrpc;
        }

        public async Task<ListDsiModuleCompatibilityGrpc> CreateDsiModuleCompatibilities(DsiModuleCompatibilityGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiModuleCompatibilityGrpc responseList = new ListDsiModuleCompatibilityGrpc();
            if (request?.DsiModuleCompatibilityGrpcsToCreate == null || request.DsiModuleCompatibilityGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiModuleCompatibilityCommand, List<DbDsiModuleCompatibility>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiModuleCompatibilityCommand, List<DbDsiModuleCompatibility>>>();
                DsiModuleCompatibilityCommand command = new DsiModuleCompatibilityCommand(CommandType.Create, request.DsiModuleCompatibilityGrpcsToCreate);
                Result<List<DbDsiModuleCompatibility>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiModuleCompatibilityGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiModuleCompatibilityGrpc.DsiModuleCompatibilityGrpcs.AddRange(updated);
                    responseList.DsiModuleCompatibilityGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiModuleCompatibilities(DsiModuleCompatibilityGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiModuleCompatibilityGrpcsToUpdate == null || request.DsiModuleCompatibilityGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiModuleCompatibilityCommand, List<DbDsiModuleCompatibility>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiModuleCompatibilityCommand, List<DbDsiModuleCompatibility>>>();
                DsiModuleCompatibilityCommand command = new DsiModuleCompatibilityCommand(CommandType.Update, request.DsiModuleCompatibilityGrpcsToUpdate);
                Result<List<DbDsiModuleCompatibility>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiModuleCompatibilityGrpc? updated in request.DsiModuleCompatibilityGrpcsToUpdate)
                    {
                        DsiModuleCompatibilityGrpc? existing = _ListDsiModuleCompatibilityGrpc.DsiModuleCompatibilityGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiModuleCompatibilityGrpc.DsiModuleCompatibilityGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiModuleCompatibilityGrpc.DsiModuleCompatibilityGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiMulticoreSpecification

        public async Task<ListDsiMulticoreSpecificationGrpc> GetAllDsiMulticoreSpecifications(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiMulticoreSpecificationGrpc.DsiMulticoreSpecificationGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiMulticoreSpecificationGrpc;
                }

                ListDsiMulticoreSpecificationGrpc returnList = new ListDsiMulticoreSpecificationGrpc();
                IEnumerable<DsiMulticoreSpecificationGrpc> query = _ListDsiMulticoreSpecificationGrpc.DsiMulticoreSpecificationGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiMulticoreSpecificationGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiMulticoreSpecifications(cancellationToken);
            return _ListDsiMulticoreSpecificationGrpc;
        }

        public async Task<ListDsiMulticoreSpecificationGrpc> CreateDsiMulticoreSpecifications(DsiMulticoreSpecificationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiMulticoreSpecificationGrpc responseList = new ListDsiMulticoreSpecificationGrpc();
            if (request?.DsiMulticoreSpecificationGrpcsToCreate == null || request.DsiMulticoreSpecificationGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiMulticoreSpecificationCommand, List<DbDsiMulticoreSpecification>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiMulticoreSpecificationCommand, List<DbDsiMulticoreSpecification>>>();
                DsiMulticoreSpecificationCommand command = new DsiMulticoreSpecificationCommand(CommandType.Create, request.DsiMulticoreSpecificationGrpcsToCreate);
                Result<List<DbDsiMulticoreSpecification>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiMulticoreSpecificationGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiMulticoreSpecificationGrpc.DsiMulticoreSpecificationGrpcs.AddRange(updated);
                    responseList.DsiMulticoreSpecificationGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiMulticoreSpecifications(DsiMulticoreSpecificationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiMulticoreSpecificationGrpcsToUpdate == null || request.DsiMulticoreSpecificationGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiMulticoreSpecificationCommand, List<DbDsiMulticoreSpecification>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiMulticoreSpecificationCommand, List<DbDsiMulticoreSpecification>>>();
                DsiMulticoreSpecificationCommand command = new DsiMulticoreSpecificationCommand(CommandType.Update, request.DsiMulticoreSpecificationGrpcsToUpdate);
                Result<List<DbDsiMulticoreSpecification>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiMulticoreSpecificationGrpc? updated in request.DsiMulticoreSpecificationGrpcsToUpdate)
                    {
                        DsiMulticoreSpecificationGrpc? existing = _ListDsiMulticoreSpecificationGrpc.DsiMulticoreSpecificationGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiMulticoreSpecificationGrpc.DsiMulticoreSpecificationGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiMulticoreSpecificationGrpc.DsiMulticoreSpecificationGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiPinMapping

        public async Task<ListDsiPinMappingGrpc> GetAllDsiPinMappings(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiPinMappingGrpc.DsiPinMappingGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiPinMappingGrpc;
                }

                ListDsiPinMappingGrpc returnList = new ListDsiPinMappingGrpc();
                IEnumerable<DsiPinMappingGrpc> query = _ListDsiPinMappingGrpc.DsiPinMappingGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiPinMappingGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiPinMappings(cancellationToken); 
            return _ListDsiPinMappingGrpc;
        }

        public async Task<ListDsiPinMappingGrpc> CreateDsiPinMappings(DsiPinMappingGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiPinMappingGrpc responseList = new ListDsiPinMappingGrpc();
            if (request?.DsiPinMappingGrpcsToCreate == null || request.DsiPinMappingGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiPinMappingCommand, List<DbDsiPinMapping>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiPinMappingCommand, List<DbDsiPinMapping>>>();
                DsiPinMappingCommand command = new DsiPinMappingCommand(CommandType.Create, request.DsiPinMappingGrpcsToCreate);
                Result<List<DbDsiPinMapping>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiPinMappingGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiPinMappingGrpc.DsiPinMappingGrpcs.AddRange(updated);
                    responseList.DsiPinMappingGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiPinMappings(DsiPinMappingGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiPinMappingGrpcsToUpdate == null || request.DsiPinMappingGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiPinMappingCommand, List<DbDsiPinMapping>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiPinMappingCommand, List<DbDsiPinMapping>>>();
                DsiPinMappingCommand command = new DsiPinMappingCommand(CommandType.Update, request.DsiPinMappingGrpcsToUpdate);
                Result<List<DbDsiPinMapping>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiPinMappingGrpc? updated in request.DsiPinMappingGrpcsToUpdate)
                    {
                        DsiPinMappingGrpc? existing = _ListDsiPinMappingGrpc.DsiPinMappingGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiPinMappingGrpc.DsiPinMappingGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiPinMappingGrpc.DsiPinMappingGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiPinMappingCavityMappingAssociation

        public async Task<ListDsiPinMappingCavityMappingAssociationGrpc> GetAllDsiPinMappingCavityMappingAssociations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiPinMappingCavityMappingAssociationGrpc.DsiPinMappingCavityMappingAssociationGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiPinMappingCavityMappingAssociationGrpc;
                }

                ListDsiPinMappingCavityMappingAssociationGrpc returnList = new ListDsiPinMappingCavityMappingAssociationGrpc();
                IEnumerable<DsiPinMappingCavityMappingAssociationGrpc> query = _ListDsiPinMappingCavityMappingAssociationGrpc.DsiPinMappingCavityMappingAssociationGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiPinMappingCavityMappingAssociationGrpcs.AddRange(query);
                return returnList;
            }

            return _ListDsiPinMappingCavityMappingAssociationGrpc;
        }

        public async Task<ListDsiPinMappingCavityMappingAssociationGrpc> CreateDsiPinMappingCavityMappingAssociations(DsiPinMappingCavityMappingAssociationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiPinMappingCavityMappingAssociationGrpc responseList = new ListDsiPinMappingCavityMappingAssociationGrpc();
            if (request?.DsiPinMappingCavityMappingAssociationGrpcsToCreate == null || request.DsiPinMappingCavityMappingAssociationGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiPinMappingCavityMappingAssociationCommand, List<DbDsiPinMappingCavityMappingAssociation>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiPinMappingCavityMappingAssociationCommand, List<DbDsiPinMappingCavityMappingAssociation>>>();
                DsiPinMappingCavityMappingAssociationCommand command = new DsiPinMappingCavityMappingAssociationCommand(CommandType.Create, request.DsiPinMappingCavityMappingAssociationGrpcsToCreate);
                Result<List<DbDsiPinMappingCavityMappingAssociation>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiPinMappingCavityMappingAssociationGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiPinMappingCavityMappingAssociationGrpc.DsiPinMappingCavityMappingAssociationGrpcs.AddRange(updated);
                    responseList.DsiPinMappingCavityMappingAssociationGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiPinMappingCavityMappingAssociations(DsiPinMappingCavityMappingAssociationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiPinMappingCavityMappingAssociationGrpcsToUpdate == null || request.DsiPinMappingCavityMappingAssociationGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiPinMappingCavityMappingAssociationCommand, List<DbDsiPinMappingCavityMappingAssociation>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiPinMappingCavityMappingAssociationCommand, List<DbDsiPinMappingCavityMappingAssociation>>>();
                DsiPinMappingCavityMappingAssociationCommand command = new DsiPinMappingCavityMappingAssociationCommand(CommandType.Update, request.DsiPinMappingCavityMappingAssociationGrpcsToUpdate);
                Result<List<DbDsiPinMappingCavityMappingAssociation>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiPinMappingCavityMappingAssociationGrpc? updated in request.DsiPinMappingCavityMappingAssociationGrpcsToUpdate)
                    {
                        DsiPinMappingCavityMappingAssociationGrpc? existing = _ListDsiPinMappingCavityMappingAssociationGrpc.DsiPinMappingCavityMappingAssociationGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiPinMappingCavityMappingAssociationGrpc.DsiPinMappingCavityMappingAssociationGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiPinMappingCavityMappingAssociationGrpc.DsiPinMappingCavityMappingAssociationGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiScope

        public async Task<ListDsiScopeGrpc> GetAllDsiScopes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiScopeGrpc.DsiScopeGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiScopeGrpc;
                }

                ListDsiScopeGrpc returnList = new ListDsiScopeGrpc();
                IEnumerable<DsiScopeGrpc> query = _ListDsiScopeGrpc.DsiScopeGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiScopeGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiScopes(cancellationToken);
            return _ListDsiScopeGrpc;
        }

        public async Task<ListDsiScopeGrpc> CreateDsiScopes(DsiScopeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiScopeGrpc responseList = new ListDsiScopeGrpc();
            if (request?.DsiScopeGrpcsToCreate == null || request.DsiScopeGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiScopeCommand, List<DbDsiScope>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiScopeCommand, List<DbDsiScope>>>();
                DsiScopeCommand command = new DsiScopeCommand(CommandType.Create, request.DsiScopeGrpcsToCreate);
                Result<List<DbDsiScope>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiScopeGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiScopeGrpc.DsiScopeGrpcs.AddRange(updated);
                    responseList.DsiScopeGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiScopes(DsiScopeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiScopeGrpcsToUpdate == null || request.DsiScopeGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiScopeCommand, List<DbDsiScope>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiScopeCommand, List<DbDsiScope>>>();
                DsiScopeCommand command = new DsiScopeCommand(CommandType.Update, request.DsiScopeGrpcsToUpdate);
                Result<List<DbDsiScope>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiScopeGrpc? updated in request.DsiScopeGrpcsToUpdate)
                    {
                        DsiScopeGrpc? existing = _ListDsiScopeGrpc.DsiScopeGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiScopeGrpc.DsiScopeGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiScopeGrpc.DsiScopeGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiSupplier

        public async Task<ListDsiSupplierGrpc> GetAllDsiSuppliers(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiSupplierGrpc.DsiSupplierGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiSupplierGrpc;
                }

                ListDsiSupplierGrpc returnList = new ListDsiSupplierGrpc();
                IEnumerable<DsiSupplierGrpc> query = _ListDsiSupplierGrpc.DsiSupplierGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiSupplierGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiSuppliers(cancellationToken);
            return _ListDsiSupplierGrpc;
        }

        public async Task<ListDsiSupplierGrpc> CreateDsiSuppliers(DsiSupplierGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiSupplierGrpc responseList = new ListDsiSupplierGrpc();
            if (request?.DsiSupplierGrpcsToCreate == null || request.DsiSupplierGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiSupplierCommand, List<DbDsiSupplier>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiSupplierCommand, List<DbDsiSupplier>>>();
                DsiSupplierCommand command = new DsiSupplierCommand(CommandType.Create, request.DsiSupplierGrpcsToCreate);
                Result<List<DbDsiSupplier>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiSupplierGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiSupplierGrpc.DsiSupplierGrpcs.AddRange(updated);
                    responseList.DsiSupplierGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiSuppliers(DsiSupplierGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiSupplierGrpcsToUpdate == null || request.DsiSupplierGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiSupplierCommand, List<DbDsiSupplier>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiSupplierCommand, List<DbDsiSupplier>>>();
                DsiSupplierCommand command = new DsiSupplierCommand(CommandType.Update, request.DsiSupplierGrpcsToUpdate);
                Result<List<DbDsiSupplier>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiSupplierGrpc? updated in request.DsiSupplierGrpcsToUpdate)
                    {
                        DsiSupplierGrpc? existing = _ListDsiSupplierGrpc.DsiSupplierGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiSupplierGrpc.DsiSupplierGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiSupplierGrpc.DsiSupplierGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiTransformedCompositeDetail

        public async Task<ListDsiTransformedCompositeDetailGrpc> GetAllDsiTransformedCompositeDetails(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiTransformedCompositeDetailGrpc.DsiTransformedCompositeDetailGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiTransformedCompositeDetailGrpc;
                }

                ListDsiTransformedCompositeDetailGrpc returnList = new ListDsiTransformedCompositeDetailGrpc();
                IEnumerable<DsiTransformedCompositeDetailGrpc> query = _ListDsiTransformedCompositeDetailGrpc.DsiTransformedCompositeDetailGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiTransformedCompositeDetailGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiTransformedCompositeDetails(cancellationToken);
            return _ListDsiTransformedCompositeDetailGrpc;
        }

        public async Task<ListDsiTransformedCompositeDetailGrpc> CreateDsiTransformedCompositeDetails(DsiTransformedCompositeDetailGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiTransformedCompositeDetailGrpc responseList = new ListDsiTransformedCompositeDetailGrpc();
            if (request?.DsiTransformedCompositeDetailGrpcsToCreate == null || request.DsiTransformedCompositeDetailGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiTransformedCompositeDetailCommand, List<DbDsiTransformedCompositeDetail>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiTransformedCompositeDetailCommand, List<DbDsiTransformedCompositeDetail>>>();
                DsiTransformedCompositeDetailCommand command = new DsiTransformedCompositeDetailCommand(CommandType.Create, request.DsiTransformedCompositeDetailGrpcsToCreate);
                Result<List<DbDsiTransformedCompositeDetail>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiTransformedCompositeDetailGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiTransformedCompositeDetailGrpc.DsiTransformedCompositeDetailGrpcs.AddRange(updated);
                    responseList.DsiTransformedCompositeDetailGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiTransformedCompositeDetails(DsiTransformedCompositeDetailGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiTransformedCompositeDetailGrpcsToUpdate == null || request.DsiTransformedCompositeDetailGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiTransformedCompositeDetailCommand, List<DbDsiTransformedCompositeDetail>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiTransformedCompositeDetailCommand, List<DbDsiTransformedCompositeDetail>>>();
                DsiTransformedCompositeDetailCommand command = new DsiTransformedCompositeDetailCommand(CommandType.Update, request.DsiTransformedCompositeDetailGrpcsToUpdate);
                Result<List<DbDsiTransformedCompositeDetail>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiTransformedCompositeDetailGrpc? updated in request.DsiTransformedCompositeDetailGrpcsToUpdate)
                    {
                        DsiTransformedCompositeDetailGrpc? existing = _ListDsiTransformedCompositeDetailGrpc.DsiTransformedCompositeDetailGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiTransformedCompositeDetailGrpc.DsiTransformedCompositeDetailGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiTransformedCompositeDetailGrpc.DsiTransformedCompositeDetailGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiTransformedHarness

        public async Task<ListDsiTransformedHarnessGrpc> GetAllDsiTransformedHarnesses(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiTransformedHarnessGrpc.DsiTransformedHarnessGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiTransformedHarnessGrpc;
                }

                ListDsiTransformedHarnessGrpc returnList = new ListDsiTransformedHarnessGrpc();
                IEnumerable<DsiTransformedHarnessGrpc> query = _ListDsiTransformedHarnessGrpc.DsiTransformedHarnessGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiTransformedHarnessGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiTransformedHarnesses(cancellationToken);
            return _ListDsiTransformedHarnessGrpc;
        }

        public async Task<ListDsiTransformedHarnessGrpc> CreateDsiTransformedHarnesses(DsiTransformedHarnessGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiTransformedHarnessGrpc responseList = new ListDsiTransformedHarnessGrpc();
            if (request?.DsiTransformedHarnessGrpcsToCreate == null || request.DsiTransformedHarnessGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiTransformedHarnessCommand, List<DbDsiTransformedHarness>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiTransformedHarnessCommand, List<DbDsiTransformedHarness>>>();
                DsiTransformedHarnessCommand command = new DsiTransformedHarnessCommand(CommandType.Create, request.DsiTransformedHarnessGrpcsToCreate);
                Result<List<DbDsiTransformedHarness>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiTransformedHarnessGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiTransformedHarnessGrpc.DsiTransformedHarnessGrpcs.AddRange(updated);
                    responseList.DsiTransformedHarnessGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiTransformedHarnesses(DsiTransformedHarnessGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiTransformedHarnessGrpcsToUpdate == null || request.DsiTransformedHarnessGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiTransformedHarnessCommand, List<DbDsiTransformedHarness>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiTransformedHarnessCommand, List<DbDsiTransformedHarness>>>();
                DsiTransformedHarnessCommand command = new DsiTransformedHarnessCommand(CommandType.Update, request.DsiTransformedHarnessGrpcsToUpdate);
                Result<List<DbDsiTransformedHarness>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiTransformedHarnessGrpc? updated in request.DsiTransformedHarnessGrpcsToUpdate)
                    {
                        DsiTransformedHarnessGrpc? existing = _ListDsiTransformedHarnessGrpc.DsiTransformedHarnessGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiTransformedHarnessGrpc.DsiTransformedHarnessGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiTransformedHarnessGrpc.DsiTransformedHarnessGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiTransformedModuleChildDetail

        public async Task<ListDsiTransformedModuleChildDetailGrpc> GetAllDsiTransformedModuleChildDetails(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiTransformedModuleChildDetailGrpc.DsiTransformedModuleChildDetailGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiTransformedModuleChildDetailGrpc;
                }

                ListDsiTransformedModuleChildDetailGrpc returnList = new ListDsiTransformedModuleChildDetailGrpc();
                IEnumerable<DsiTransformedModuleChildDetailGrpc> query = _ListDsiTransformedModuleChildDetailGrpc.DsiTransformedModuleChildDetailGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiTransformedModuleChildDetailGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiTransformedModuleChildDetails(cancellationToken);
            return _ListDsiTransformedModuleChildDetailGrpc;
        }

        public async Task<ListDsiTransformedModuleChildDetailGrpc> CreateDsiTransformedModuleChildDetails(DsiTransformedModuleChildDetailGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiTransformedModuleChildDetailGrpc responseList = new ListDsiTransformedModuleChildDetailGrpc();
            if (request?.DsiTransformedModuleChildDetailGrpcsToCreate == null || request.DsiTransformedModuleChildDetailGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiTransformedModuleChildDetailCommand, List<DbDsiTransformedModuleChildDetail>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiTransformedModuleChildDetailCommand, List<DbDsiTransformedModuleChildDetail>>>();
                DsiTransformedModuleChildDetailCommand command = new DsiTransformedModuleChildDetailCommand(CommandType.Create, request.DsiTransformedModuleChildDetailGrpcsToCreate);
                Result<List<DbDsiTransformedModuleChildDetail>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiTransformedModuleChildDetailGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiTransformedModuleChildDetailGrpc.DsiTransformedModuleChildDetailGrpcs.AddRange(updated);
                    responseList.DsiTransformedModuleChildDetailGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiTransformedModuleChildDetails(DsiTransformedModuleChildDetailGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiTransformedModuleChildDetailGrpcsToUpdate == null || request.DsiTransformedModuleChildDetailGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiTransformedModuleChildDetailCommand, List<DbDsiTransformedModuleChildDetail>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiTransformedModuleChildDetailCommand, List<DbDsiTransformedModuleChildDetail>>>();
                DsiTransformedModuleChildDetailCommand command = new DsiTransformedModuleChildDetailCommand(CommandType.Update, request.DsiTransformedModuleChildDetailGrpcsToUpdate);
                Result<List<DbDsiTransformedModuleChildDetail>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiTransformedModuleChildDetailGrpc? updated in request.DsiTransformedModuleChildDetailGrpcsToUpdate)
                    {
                        DsiTransformedModuleChildDetailGrpc? existing = _ListDsiTransformedModuleChildDetailGrpc.DsiTransformedModuleChildDetailGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiTransformedModuleChildDetailGrpc.DsiTransformedModuleChildDetailGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiTransformedModuleChildDetailGrpc.DsiTransformedModuleChildDetailGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiUnitOfMeasure

        public async Task<ListDsiUnitOfMeasureGrpc> GetAllDsiUnitOfMeasures(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiUnitOfMeasureGrpc.DsiUnitOfMeasureGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiUnitOfMeasureGrpc;
                }

                ListDsiUnitOfMeasureGrpc returnList = new ListDsiUnitOfMeasureGrpc();
                IEnumerable<DsiUnitOfMeasureGrpc> query = _ListDsiUnitOfMeasureGrpc.DsiUnitOfMeasureGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiUnitOfMeasureGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiUnitOfMeasures(cancellationToken);
            return _ListDsiUnitOfMeasureGrpc;
        }

        public async Task<ListDsiUnitOfMeasureGrpc> CreateDsiUnitOfMeasures(DsiUnitOfMeasureGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiUnitOfMeasureGrpc responseList = new ListDsiUnitOfMeasureGrpc();
            if (request?.DsiUnitOfMeasureGrpcsToCreate == null || request.DsiUnitOfMeasureGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiUnitOfMeasureCommand, List<DbDsiUnitOfMeasure>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiUnitOfMeasureCommand, List<DbDsiUnitOfMeasure>>>();
                DsiUnitOfMeasureCommand command = new DsiUnitOfMeasureCommand(CommandType.Create, request.DsiUnitOfMeasureGrpcsToCreate);
                Result<List<DbDsiUnitOfMeasure>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiUnitOfMeasureGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiUnitOfMeasureGrpc.DsiUnitOfMeasureGrpcs.AddRange(updated);
                    responseList.DsiUnitOfMeasureGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiUnitOfMeasures(DsiUnitOfMeasureGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiUnitOfMeasureGrpcsToUpdate == null || request.DsiUnitOfMeasureGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiUnitOfMeasureCommand, List<DbDsiUnitOfMeasure>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiUnitOfMeasureCommand, List<DbDsiUnitOfMeasure>>>();
                DsiUnitOfMeasureCommand command = new DsiUnitOfMeasureCommand(CommandType.Update, request.DsiUnitOfMeasureGrpcsToUpdate);
                Result<List<DbDsiUnitOfMeasure>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiUnitOfMeasureGrpc? updated in request.DsiUnitOfMeasureGrpcsToUpdate)
                    {
                        DsiUnitOfMeasureGrpc? existing = _ListDsiUnitOfMeasureGrpc.DsiUnitOfMeasureGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiUnitOfMeasureGrpc.DsiUnitOfMeasureGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiUnitOfMeasureGrpc.DsiUnitOfMeasureGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiWireMulticoreMarker

        public async Task<ListDsiWireMulticoreMarkerGrpc> GetAllDsiWireMulticoreMarkers(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiWireMulticoreMarkerGrpc.DsiWireMulticoreMarkerGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiWireMulticoreMarkerGrpc;
                }

                ListDsiWireMulticoreMarkerGrpc returnList = new ListDsiWireMulticoreMarkerGrpc();
                IEnumerable<DsiWireMulticoreMarkerGrpc> query = _ListDsiWireMulticoreMarkerGrpc.DsiWireMulticoreMarkerGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiWireMulticoreMarkerGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiWireMulticoreMarkers(cancellationToken);
            return _ListDsiWireMulticoreMarkerGrpc;
        }

        public async Task<ListDsiWireMulticoreMarkerGrpc> CreateDsiWireMulticoreMarkers(DsiWireMulticoreMarkerGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiWireMulticoreMarkerGrpc responseList = new ListDsiWireMulticoreMarkerGrpc();
            if (request?.DsiWireMulticoreMarkerGrpcsToCreate == null || request.DsiWireMulticoreMarkerGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiWireMulticoreMarkerCommand, List<DbDsiWireMulticoreMarker>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiWireMulticoreMarkerCommand, List<DbDsiWireMulticoreMarker>>>();
                DsiWireMulticoreMarkerCommand command = new DsiWireMulticoreMarkerCommand(CommandType.Create, request.DsiWireMulticoreMarkerGrpcsToCreate);
                Result<List<DbDsiWireMulticoreMarker>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiWireMulticoreMarkerGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiWireMulticoreMarkerGrpc.DsiWireMulticoreMarkerGrpcs.AddRange(updated);
                    responseList.DsiWireMulticoreMarkerGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiWireMulticoreMarkers(DsiWireMulticoreMarkerGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiWireMulticoreMarkerGrpcsToUpdate == null || request.DsiWireMulticoreMarkerGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiWireMulticoreMarkerCommand, List<DbDsiWireMulticoreMarker>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiWireMulticoreMarkerCommand, List<DbDsiWireMulticoreMarker>>>();
                DsiWireMulticoreMarkerCommand command = new DsiWireMulticoreMarkerCommand(CommandType.Update, request.DsiWireMulticoreMarkerGrpcsToUpdate);
                Result<List<DbDsiWireMulticoreMarker>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiWireMulticoreMarkerGrpc? updated in request.DsiWireMulticoreMarkerGrpcsToUpdate)
                    {
                        DsiWireMulticoreMarkerGrpc? existing = _ListDsiWireMulticoreMarkerGrpc.DsiWireMulticoreMarkerGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiWireMulticoreMarkerGrpc.DsiWireMulticoreMarkerGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiWireMulticoreMarkerGrpc.DsiWireMulticoreMarkerGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiWireSpecification

        public async Task<ListDsiWireSpecificationGrpc> GetAllDsiWireSpecifications(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiWireSpecificationGrpc.DsiWireSpecificationGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiWireSpecificationGrpc;
                }

                ListDsiWireSpecificationGrpc returnList = new ListDsiWireSpecificationGrpc();
                IEnumerable<DsiWireSpecificationGrpc> query = _ListDsiWireSpecificationGrpc.DsiWireSpecificationGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiWireSpecificationGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiWireSpecifications(cancellationToken);
            return _ListDsiWireSpecificationGrpc;
        }

        public async Task<ListDsiWireSpecificationGrpc> CreateDsiWireSpecifications(DsiWireSpecificationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiWireSpecificationGrpc responseList = new ListDsiWireSpecificationGrpc();
            if (request?.DsiWireSpecificationGrpcsToCreate == null || request.DsiWireSpecificationGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiWireSpecificationCommand, List<DbDsiWireSpecification>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiWireSpecificationCommand, List<DbDsiWireSpecification>>>();
                DsiWireSpecificationCommand command = new DsiWireSpecificationCommand(CommandType.Create, request.DsiWireSpecificationGrpcsToCreate);
                Result<List<DbDsiWireSpecification>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiWireSpecificationGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiWireSpecificationGrpc.DsiWireSpecificationGrpcs.AddRange(updated);
                    responseList.DsiWireSpecificationGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiWireSpecifications(DsiWireSpecificationGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiWireSpecificationGrpcsToUpdate == null || request.DsiWireSpecificationGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiWireSpecificationCommand, List<DbDsiWireSpecification>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiWireSpecificationCommand, List<DbDsiWireSpecification>>>();
                DsiWireSpecificationCommand command = new DsiWireSpecificationCommand(CommandType.Update, request.DsiWireSpecificationGrpcsToUpdate);
                Result<List<DbDsiWireSpecification>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiWireSpecificationGrpc? updated in request.DsiWireSpecificationGrpcsToUpdate)
                    {
                        DsiWireSpecificationGrpc? existing = _ListDsiWireSpecificationGrpc.DsiWireSpecificationGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiWireSpecificationGrpc.DsiWireSpecificationGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiWireSpecificationGrpc.DsiWireSpecificationGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region DsiWireThroughNode

        public async Task<ListDsiWireThroughNodeGrpc> GetAllDsiWireThroughNodes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListDsiWireThroughNodeGrpc.DsiWireThroughNodeGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListDsiWireThroughNodeGrpc;
                }

                ListDsiWireThroughNodeGrpc returnList = new ListDsiWireThroughNodeGrpc();
                IEnumerable<DsiWireThroughNodeGrpc> query = _ListDsiWireThroughNodeGrpc.DsiWireThroughNodeGrpcs.Skip(position).Take(takeAmount);
                returnList.DsiWireThroughNodeGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateDsiWireThroughNodes(cancellationToken);
            return _ListDsiWireThroughNodeGrpc;
        }
        public async Task<ListDsiWireThroughNodeGrpc> CreateDsiWireThroughNodes(DsiWireThroughNodeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListDsiWireThroughNodeGrpc responseList = new ListDsiWireThroughNodeGrpc();
            if (request?.DsiWireThroughNodeGrpcsToCreate == null || request.DsiWireThroughNodeGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiWireThroughNodeCommand, List<DbDsiWireThroughNode>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiWireThroughNodeCommand, List<DbDsiWireThroughNode>>>();
                DsiWireThroughNodeCommand command = new DsiWireThroughNodeCommand(CommandType.Create, request.DsiWireThroughNodeGrpcsToCreate);
                Result<List<DbDsiWireThroughNode>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<DsiWireThroughNodeGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListDsiWireThroughNodeGrpc.DsiWireThroughNodeGrpcs.AddRange(updated);
                    responseList.DsiWireThroughNodeGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateDsiWireThroughNodes(DsiWireThroughNodeGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.DsiWireThroughNodeGrpcsToUpdate == null || request.DsiWireThroughNodeGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<DsiWireThroughNodeCommand, List<DbDsiWireThroughNode>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DsiWireThroughNodeCommand, List<DbDsiWireThroughNode>>>();
                DsiWireThroughNodeCommand command = new DsiWireThroughNodeCommand(CommandType.Update, request.DsiWireThroughNodeGrpcsToUpdate);
                Result<List<DbDsiWireThroughNode>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (DsiWireThroughNodeGrpc? updated in request.DsiWireThroughNodeGrpcsToUpdate)
                    {
                        DsiWireThroughNodeGrpc? existing = _ListDsiWireThroughNodeGrpc.DsiWireThroughNodeGrpcs.FirstOrDefault(p => p.RowId == updated.RowId);
                        if (existing != null)
                        {
                            int index = _ListDsiWireThroughNodeGrpc.DsiWireThroughNodeGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListDsiWireThroughNodeGrpc.DsiWireThroughNodeGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        #endregion

        #region RfqNprRequest

        public async Task<ListRfqNprRequestGrpc> GetAllRfqNprRequest(CancellationToken cancellationToken, int position = 0, int takeAmount = 0)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListRfqNprRequestGrpc.RfqNprRequestGrpcs.Any())
            {
                if (takeAmount <= 0)
                {
                    return _ListRfqNprRequestGrpc;
                }

                ListRfqNprRequestGrpc returnList = new ListRfqNprRequestGrpc();
                IEnumerable<RfqNprRequestGrpc> query = _ListRfqNprRequestGrpc.RfqNprRequestGrpcs.Skip(position).Take(takeAmount);
                returnList.RfqNprRequestGrpcs.AddRange(query);
                return returnList;
            }

            await PopulateRfqNprRequest(cancellationToken);
            return _ListRfqNprRequestGrpc;
        }

        public async Task<ListRfqNprRequestGrpc> CreateRfqNprRequest(RfqNprRequestGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            ListRfqNprRequestGrpc responseList = new ListRfqNprRequestGrpc();
            if (request?.RfqNprRequestGrpcsToCreate == null || request.RfqNprRequestGrpcsToCreate.Count == 0)
            {
                return responseList;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqNprRequestCommand, List<DbRfqNprRequestModel>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqNprRequestCommand, List<DbRfqNprRequestModel>>>();
                RfqNprRequestCommand command = new RfqNprRequestCommand(CommandType.Create, request.RfqNprRequestGrpcsToCreate);
                Result<List<DbRfqNprRequestModel>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    List<RfqNprRequestGrpc> updated = result.Value.Select(p => p.FromEntity()).ToList();
                    _ListRfqNprRequestGrpc.RfqNprRequestGrpcs.AddRange(updated);
                    responseList.RfqNprRequestGrpcs.AddRange(updated);
                }

                return responseList;
            }
        }

        public async Task<bool> UpdateRfqNprRequest(RfqNprRequestGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.RfqNprRequestGrpcsToUpdate == null || request.RfqNprRequestGrpcsToUpdate.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqNprRequestCommand, List<DbRfqNprRequestModel>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqNprRequestCommand, List<DbRfqNprRequestModel>>>();
                RfqNprRequestCommand command = new RfqNprRequestCommand(CommandType.Update, request.RfqNprRequestGrpcsToUpdate);
                Result<List<DbRfqNprRequestModel>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    foreach (RfqNprRequestGrpc? updated in request.RfqNprRequestGrpcsToUpdate)
                    {
                        RfqNprRequestGrpc? existing = _ListRfqNprRequestGrpc.RfqNprRequestGrpcs.FirstOrDefault(p => p.Id.ToUpperInvariant() == updated.Id.ToUpperInvariant());
                        if (existing != null)
                        {
                            int index = _ListRfqNprRequestGrpc.RfqNprRequestGrpcs.IndexOf(existing);
                            if (index != -1)
                            {
                                _ListRfqNprRequestGrpc.RfqNprRequestGrpcs[index] = updated;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        public async Task<bool> DeleteRfqNprRequestById(RfqNprRequestGrpcRequest request, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (request?.RfqNprRequestGrpcsToDelete == null || request.RfqNprRequestGrpcsToDelete.Count == 0)
            {
                return false;
            }

            using (IServiceScope scope = _ServiceProvider.CreateScope())
            {
                ICommandHandler<RfqNprRequestCommand, List<DbRfqNprRequestModel>> handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<RfqNprRequestCommand, List<DbRfqNprRequestModel>>>();
                RfqNprRequestCommand command = new RfqNprRequestCommand(CommandType.Delete, request.RfqNprRequestGrpcsToDelete);
                Result<List<DbRfqNprRequestModel>> result = await handler.Handle(command, cancellationToken);

                if (result.IsSuccess)
                {
                    //foreach (RfqNprRequestGrpc? deleted in request.RfqNprRequestGrpcsToDelete)
                    //{
                    //    RfqNprRequestGrpc? existing = _ListRfqNprRequestGrpc.RfqNprRequestGrpcs.FirstOrDefault(p => p.Id.ToUpperInvariant() == deleted.Id.ToUpperInvariant());
                    //    if (existing != null)
                    //    {
                    //        int index = _ListRfqNprRequestGrpc.RfqNprRequestGrpcs.IndexOf(existing);
                    //        if (index != -1)
                    //        {
                    //            _ListRfqNprRequestGrpc.RfqNprRequestGrpcs[index] = deleted;
                    //        }
                    //    }
                    //}
                    await PopulateRfqNprRequest(cancellationToken);
                    return true;
                }

                return false;
            }
        }

        #endregion

        #region Data Imports

        #region RfqDrawingPartNumbers
        public async Task<bool> PopulateRfqDrawingPartNumbers(CancellationToken cancellationToken)
        {
            if (!_RfqDrawingPartNumbersRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _RfqDrawingPartNumbersHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetRfqDrawingPartNumberQuery, List<RfqDrawingPartNumbersGrpc>>>();
                    _RfqDrawingPartNumbersRefreshInProgress = true;
                    GetRfqDrawingPartNumberQuery query = new GetRfqDrawingPartNumberQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<RfqDrawingPartNumbersGrpc>> results = await _RfqDrawingPartNumbersHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.Clear();
                        _ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.AddRange(results.Value);
                    }

                    _RfqDrawingPartNumbersRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region RfqAccessService
        public async Task<bool> PopulateRfqProjects(CancellationToken cancellationToken)
        {
            if (!_RfqProjectRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _RfqProjectHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetRfqProjectQuery, List<RfqProjectGrpc>>>();
                    _RfqProjectRefreshInProgress = true;
                    GetRfqProjectQuery query = new GetRfqProjectQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<RfqProjectGrpc>> results = await _RfqProjectHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListRfqProjectsGrpc.RfqProjects.Clear();
                        _ListRfqProjectsGrpc.RfqProjects.AddRange(results.Value);
                    }

                    _RfqProjectRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region RfqNotes
        public async Task<bool> PopulateRfqNotes(CancellationToken cancellationToken)
        {
            if (!_RfqNotesRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _RfqNotesHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetRfqNotesQuery, List<RfqNotesGrpc>>>();
                    _RfqNotesRefreshInProgress = true;
                    GetRfqNotesQuery query = new GetRfqNotesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<RfqNotesGrpc>> results = await _RfqNotesHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListRfqNotesGrpc.RfqNotes.Clear();
                        _ListRfqNotesGrpc.RfqNotes.AddRange(results.Value);
                    }

                    _RfqNotesRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region RfqReason

        public async Task<bool> PopulateRfqReasons(CancellationToken cancellationToken)
        {
            if (!_RfqReasonRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _RfqReasonHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetRfqReasonQuery, List<RfqReasonGrpc>>>();
                    _RfqReasonRefreshInProgress = true;
                    GetRfqReasonQuery query = new GetRfqReasonQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<RfqReasonGrpc>> results = await _RfqReasonHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListRfqReasonsGrpc.RfqReasons.Clear();
                        _ListRfqReasonsGrpc.RfqReasons.AddRange(results.Value);
                    }

                    _RfqReasonRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region DsiBend

        public async Task<bool> PopulateDsiBends(CancellationToken cancellationToken)
        {
            if (!_DsiBendRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiBendHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiBendQuery, List<DsiBendGrpc>>>();
                    _DsiBendRefreshInProgress = true;
                    GetDsiBendQuery query = new GetDsiBendQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiBendGrpc>> results = await _DsiBendHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiBendsGrpc.DsiBends.Clear();
                        _ListDsiBendsGrpc.DsiBends.AddRange(results.Value);
                    }

                    _DsiBendRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region DsiBranchConfiguration

        public async Task<bool> PopulateDsiBranchConfigurations(CancellationToken cancellationToken)
        {
            if (!_DsiBranchConfigurationRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiBranchConfigurationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiBranchConfigurationQuery, List<DsiBranchConfigurationGrpc>>>();
                    _DsiBranchConfigurationRefreshInProgress = true;
                    GetDsiBranchConfigurationQuery query = new GetDsiBranchConfigurationQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiBranchConfigurationGrpc>> results = await _DsiBranchConfigurationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiBranchConfigurationsGrpc.DsiBranchConfigurations.Clear();
                        _ListDsiBranchConfigurationsGrpc.DsiBranchConfigurations.AddRange(results.Value);
                    }

                    _DsiBranchConfigurationRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region DsiBranchConfigurationBendAssociation

        public async Task<bool> PopulateDsiBranchConfigurationBendAssociations(CancellationToken cancellationToken)
        {
            if (!_DsiBranchConfigurationBendAssociationRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiBranchConfigurationBendAssociationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiBranchConfigurationBendAssociationQuery, List<DsiBranchConfigurationBendAssociationGrpc>>>();
                    _DsiBranchConfigurationBendAssociationRefreshInProgress = true;
                    GetDsiBranchConfigurationBendAssociationQuery query = new GetDsiBranchConfigurationBendAssociationQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiBranchConfigurationBendAssociationGrpc>> results = await _DsiBranchConfigurationBendAssociationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiBranchConfigurationBendAssociationsGrpc.DsiBranchConfigurationBendAssociations.Clear();
                        _ListDsiBranchConfigurationBendAssociationsGrpc.DsiBranchConfigurationBendAssociations.AddRange(results.Value);
                    }

                    _DsiBranchConfigurationBendAssociationRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region DsiBranchInsulation

        public async Task<bool> PopulateDsiBranchInsulations(CancellationToken cancellationToken)
        {
            if (!_DsiBranchInsulationRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiBranchInsulationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiBranchInsulationQuery, List<DsiBranchInsulationGrpc>>>();
                    _DsiBranchInsulationRefreshInProgress = true;
                    GetDsiBranchInsulationQuery query = new GetDsiBranchInsulationQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiBranchInsulationGrpc>> results = await _DsiBranchInsulationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiBranchInsulationsGrpc.DsiBranchInsulations.Clear();
                        _ListDsiBranchInsulationsGrpc.DsiBranchInsulations.AddRange(results.Value);
                    }

                    _DsiBranchInsulationRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region DsiBranchInsulationThroughNode

        public async Task<bool> PopulateDsiBranchInsulationThroughNodes(CancellationToken cancellationToken)
        {
            if (!_DsiBranchInsulationThroughNodeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiBranchInsulationThroughNodeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiBranchInsulationThroughNodeQuery, List<DsiBranchInsulationThroughNodeGrpc>>>();
                    _DsiBranchInsulationThroughNodeRefreshInProgress = true;
                    GetDsiBranchInsulationThroughNodeQuery query = new GetDsiBranchInsulationThroughNodeQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiBranchInsulationThroughNodeGrpc>> results = await _DsiBranchInsulationThroughNodeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiBranchInsulationThroughNodesGrpc.DsiBranchInsulationThroughNodes.Clear();
                        _ListDsiBranchInsulationThroughNodesGrpc.DsiBranchInsulationThroughNodes.AddRange(results.Value);
                    }

                    _DsiBranchInsulationThroughNodeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region DsiCavityMapping

        public async Task<bool> PopulateDsiCavityMappings(CancellationToken cancellationToken)
        {
            if (!_DsiCavityMappingRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiCavityMappingHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiCavityMappingQuery, List<DsiCavityMappingGrpc>>>();
                    _DsiCavityMappingRefreshInProgress = true;
                    GetDsiCavityMappingQuery query = new GetDsiCavityMappingQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiCavityMappingGrpc>> results = await _DsiCavityMappingHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiCavityMappings.DsiCavityMappingGrpcs.Clear();
                        _ListDsiCavityMappings.DsiCavityMappingGrpcs.AddRange(results.Value);
                    }

                    _DsiCavityMappingRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region DsiCentreStrip
        public async Task<bool> PopulateDsiCentreStrips(CancellationToken cancellationToken)
        {
            if (!_DsiCentreStripRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiCentreStripHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiCentreStripQuery, List<DsiCentreStripGrpc>>>();
                    _DsiCentreStripRefreshInProgress = true;
                    GetDsiCentreStripQuery query = new GetDsiCentreStripQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiCentreStripGrpc>> results = await _DsiCentreStripHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiCentreStripGrpc.DsiCentreStripGrpcs.Clear();
                        _ListDsiCentreStripGrpc.DsiCentreStripGrpcs.AddRange(results.Value);
                    }

                    _DsiCentreStripRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiCircuitOption
        public async Task<bool> PopulateDsiCircuitOptions(CancellationToken cancellationToken)
        {
            if (!_DsiCircuitOptionRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiCircuitOptionHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiCircuitOptionQuery, List<DsiCircuitOptionGrpc>>>();
                    _DsiCircuitOptionRefreshInProgress = true;
                    GetDsiCircuitOptionQuery query = new GetDsiCircuitOptionQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiCircuitOptionGrpc>> results = await _DsiCircuitOptionHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs.Clear();
                        _ListDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs.AddRange(results.Value);
                    }

                    _DsiCircuitOptionRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiComponent
        public async Task<bool> PopulateDsiComponents(CancellationToken cancellationToken)
        {
            if (!_DsiComponentRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiComponentHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiComponentQuery, List<DsiComponentGrpc>>>();
                    _DsiComponentRefreshInProgress = true;
                    GetDsiComponentQuery query = new GetDsiComponentQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiComponentGrpc>> results = await _DsiComponentHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiComponentGrpc.DsiComponentGrpcs.Clear();
                        _ListDsiComponentGrpc.DsiComponentGrpcs.AddRange(results.Value);
                    }

                    _DsiComponentRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiCompositeDetail
        public async Task<bool> PopulateDsiCompositeDetails(CancellationToken cancellationToken)
        {
            if (!_DsiCompositeDetailRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiCompositeDetailHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiCompositeDetailQuery, List<DsiCompositeDetailGrpc>>>();
                    _DsiCompositeDetailRefreshInProgress = true;
                    GetDsiCompositeDetailQuery query = new GetDsiCompositeDetailQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiCompositeDetailGrpc>> results = await _DsiCompositeDetailHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiCompositeDetailGrpc.DsiCompositeDetailGrpcs.Clear();
                        _ListDsiCompositeDetailGrpc.DsiCompositeDetailGrpcs.AddRange(results.Value);
                    }

                    _DsiCompositeDetailRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiCompositeDetailCircuitOptionAssociation
        public async Task<bool> PopulateDsiCompositeDetailCircuitOptionAssociations(CancellationToken cancellationToken)
        {
            if (!_DsiCompositeDetailCircuitOptionAssociationRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiCompositeDetailCircuitOptionAssociationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiCompositeDetailCircuitOptionAssociationQuery, List<DsiCompositeDetailCircuitOptionAssociationGrpc>>>();
                    _DsiCompositeDetailCircuitOptionAssociationRefreshInProgress = true;
                    GetDsiCompositeDetailCircuitOptionAssociationQuery query = new GetDsiCompositeDetailCircuitOptionAssociationQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiCompositeDetailCircuitOptionAssociationGrpc>> results = await _DsiCompositeDetailCircuitOptionAssociationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiCompositeDetailCircuitOptionAssociationGrpc.DsiCompositeDetailCircuitOptionAssociationGrpcs.Clear();
                        _ListDsiCompositeDetailCircuitOptionAssociationGrpc.DsiCompositeDetailCircuitOptionAssociationGrpcs.AddRange(results.Value);
                    }

                    _DsiCompositeDetailCircuitOptionAssociationRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiCompositeOption
        public async Task<bool> PopulateDsiCompositeOptions(CancellationToken cancellationToken)
        {
            if (!_DsiCompositeOptionRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiCompositeOptionHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiCompositeOptionQuery, List<DsiCompositeOptionGrpc>>>();
                    _DsiCompositeOptionRefreshInProgress = true;
                    GetDsiCompositeOptionQuery query = new GetDsiCompositeOptionQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiCompositeOptionGrpc>> results = await _DsiCompositeOptionHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiCompositeOptionGrpc.DsiCompositeOptionGrpcs.Clear();
                        _ListDsiCompositeOptionGrpc.DsiCompositeOptionGrpcs.AddRange(results.Value);
                    }

                    _DsiCompositeOptionRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiHarness
        public async Task<bool> PopulateDsiHarnesses(CancellationToken cancellationToken)
        {
            if (!_DsiHarnessRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiHarnessHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiHarnessQuery, List<DsiHarnessGrpc>>>();
                    _DsiHarnessRefreshInProgress = true;
                    GetDsiHarnessQuery query = new GetDsiHarnessQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiHarnessGrpc>> results = await _DsiHarnessHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiHarnessGrpc.DsiHarnessGrpcs.Clear();
                        _ListDsiHarnessGrpc.DsiHarnessGrpcs.AddRange(results.Value);
                    }

                    _DsiHarnessRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiHarnessScope
        public async Task<bool> PopulateDsiHarnessScopes(CancellationToken cancellationToken)
        {
            if (!_DsiHarnessScopeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiHarnessScopeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiHarnessScopeQuery, List<DsiHarnessScopeGrpc>>>();
                    _DsiHarnessScopeRefreshInProgress = true;
                    GetDsiHarnessScopeQuery query = new GetDsiHarnessScopeQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiHarnessScopeGrpc>> results = await _DsiHarnessScopeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiHarnessScopeGrpc.DsiHarnessScopeGrpcs.Clear();
                        _ListDsiHarnessScopeGrpc.DsiHarnessScopeGrpcs.AddRange(results.Value);
                    }

                    _DsiHarnessScopeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiHarnessScopeScopeAssociation
        public async Task<bool> PopulateDsiHarnessScopeScopeAssociations(CancellationToken cancellationToken)
        {
            if (!_DsiHarnessScopeScopeAssociationRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiHarnessScopeScopeAssociationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiHarnessScopeScopeAssociationQuery, List<DsiHarnessScopeScopeAssociationGrpc>>>();
                    _DsiHarnessScopeScopeAssociationRefreshInProgress = true;
                    GetDsiHarnessScopeScopeAssociationQuery query = new GetDsiHarnessScopeScopeAssociationQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiHarnessScopeScopeAssociationGrpc>> results = await _DsiHarnessScopeScopeAssociationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiHarnessScopeScopeAssociationGrpc.DsiHarnessScopeScopeAssociationGrpcs.Clear();
                        _ListDsiHarnessScopeScopeAssociationGrpc.DsiHarnessScopeScopeAssociationGrpcs.AddRange(results.Value);
                    }

                    _DsiHarnessScopeScopeAssociationRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiManualBomQuantity
        public async Task<bool> PopulateDsiManualBomQuantities(CancellationToken cancellationToken)
        {
            if (!_DsiManualBomQuantityRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiManualBomQuantityHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiManualBomQuantityQuery, List<DsiManualBomQuantityGrpc>>>();
                    _DsiManualBomQuantityRefreshInProgress = true;
                    GetDsiManualBomQuantityQuery query = new GetDsiManualBomQuantityQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiManualBomQuantityGrpc>> results = await _DsiManualBomQuantityHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiManualBomQuantityGrpc.DsiManualBomQuantityGrpcs.Clear();
                        _ListDsiManualBomQuantityGrpc.DsiManualBomQuantityGrpcs.AddRange(results.Value);
                    }

                    _DsiManualBomQuantityRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiMidWireComponent
        public async Task<bool> PopulateDsiMidWireComponents(CancellationToken cancellationToken)
        {
            if (!_DsiMidWireComponentRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiMidWireComponentHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiMidWireComponentQuery, List<DsiMidWireComponentGrpc>>>();
                    _DsiMidWireComponentRefreshInProgress = true;
                    GetDsiMidWireComponentQuery query = new GetDsiMidWireComponentQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiMidWireComponentGrpc>> results = await _DsiMidWireComponentHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiMidWireComponentGrpc.DsiMidWireComponentGrpcs.Clear();
                        _ListDsiMidWireComponentGrpc.DsiMidWireComponentGrpcs.AddRange(results.Value);
                    }

                    _DsiMidWireComponentRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiModuleChildDetail
        public async Task<bool> PopulateDsiModuleChildDetails(CancellationToken cancellationToken)
        {
            if (!_DsiModuleChildDetailRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiModuleChildDetailHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiModuleChildDetailQuery, List<DsiModuleChildDetailGrpc>>>();
                    _DsiModuleChildDetailRefreshInProgress = true;
                    GetDsiModuleChildDetailQuery query = new GetDsiModuleChildDetailQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiModuleChildDetailGrpc>> results = await _DsiModuleChildDetailHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiModuleChildDetailGrpc.DsiModuleChildDetailGrpcs.Clear();
                        _ListDsiModuleChildDetailGrpc.DsiModuleChildDetailGrpcs.AddRange(results.Value);
                    }

                    _DsiModuleChildDetailRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiModuleCompatibility
        public async Task<bool> PopulateDsiModuleCompatibilities(CancellationToken cancellationToken)
        {
            if (!_DsiModuleCompatibilityRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiModuleCompatibilityHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiModuleCompatibilityQuery, List<DsiModuleCompatibilityGrpc>>>();
                    _DsiModuleCompatibilityRefreshInProgress = true;
                    GetDsiModuleCompatibilityQuery query = new GetDsiModuleCompatibilityQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiModuleCompatibilityGrpc>> results = await _DsiModuleCompatibilityHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiModuleCompatibilityGrpc.DsiModuleCompatibilityGrpcs.Clear();
                        _ListDsiModuleCompatibilityGrpc.DsiModuleCompatibilityGrpcs.AddRange(results.Value);
                    }

                    _DsiModuleCompatibilityRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiMulticoreSpecification
        public async Task<bool> PopulateDsiMulticoreSpecifications(CancellationToken cancellationToken)
        {
            if (!_DsiMulticoreSpecificationRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiMulticoreSpecificationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiMulticoreSpecificationQuery, List<DsiMulticoreSpecificationGrpc>>>();
                    _DsiMulticoreSpecificationRefreshInProgress = true;
                    GetDsiMulticoreSpecificationQuery query = new GetDsiMulticoreSpecificationQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiMulticoreSpecificationGrpc>> results = await _DsiMulticoreSpecificationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiMulticoreSpecificationGrpc.DsiMulticoreSpecificationGrpcs.Clear();
                        _ListDsiMulticoreSpecificationGrpc.DsiMulticoreSpecificationGrpcs.AddRange(results.Value);
                    }

                    _DsiMulticoreSpecificationRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiPinMapping
        public async Task<bool> PopulateDsiPinMappings(CancellationToken cancellationToken)
        {
            if (!_DsiPinMappingRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiPinMappingHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiPinMappingQuery, List<DsiPinMappingGrpc>>>();
                    _DsiPinMappingRefreshInProgress = true;
                    GetDsiPinMappingQuery query = new GetDsiPinMappingQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiPinMappingGrpc>> results = await _DsiPinMappingHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiPinMappingGrpc.DsiPinMappingGrpcs.Clear();
                        _ListDsiPinMappingGrpc.DsiPinMappingGrpcs.AddRange(results.Value);
                    }

                    _DsiPinMappingRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiPinMappingCavityMappingAssociation
        public async Task<bool> PopulateDsiPinMappingCavityMappingAssociations(CancellationToken cancellationToken)
        {
            if (!_DsiPinMappingCavityMappingAssociationRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiPinMappingCavityMappingAssociationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiPinMappingCavityMappingAssociationQuery, List<DsiPinMappingCavityMappingAssociationGrpc>>>();
                    _DsiPinMappingCavityMappingAssociationRefreshInProgress = true;
                    GetDsiPinMappingCavityMappingAssociationQuery query = new GetDsiPinMappingCavityMappingAssociationQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiPinMappingCavityMappingAssociationGrpc>> results = await _DsiPinMappingCavityMappingAssociationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiPinMappingCavityMappingAssociationGrpc.DsiPinMappingCavityMappingAssociationGrpcs.Clear();
                        _ListDsiPinMappingCavityMappingAssociationGrpc.DsiPinMappingCavityMappingAssociationGrpcs.AddRange(results.Value);
                    }

                    _DsiPinMappingCavityMappingAssociationRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiScope
        public async Task<bool> PopulateDsiScopes(CancellationToken cancellationToken)
        {
            if (!_DsiScopeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiScopeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiScopeQuery, List<DsiScopeGrpc>>>();
                    _DsiScopeRefreshInProgress = true;
                    GetDsiScopeQuery query = new GetDsiScopeQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiScopeGrpc>> results = await _DsiScopeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiScopeGrpc.DsiScopeGrpcs.Clear();
                        _ListDsiScopeGrpc.DsiScopeGrpcs.AddRange(results.Value);
                    }

                    _DsiScopeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiSupplier
        public async Task<bool> PopulateDsiSuppliers(CancellationToken cancellationToken)
        {
            if (!_DsiSupplierRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiSupplierHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiSupplierQuery, List<DsiSupplierGrpc>>>();
                    _DsiSupplierRefreshInProgress = true;
                    GetDsiSupplierQuery query = new GetDsiSupplierQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiSupplierGrpc>> results = await _DsiSupplierHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiSupplierGrpc.DsiSupplierGrpcs.Clear();
                        _ListDsiSupplierGrpc.DsiSupplierGrpcs.AddRange(results.Value);
                    }

                    _DsiSupplierRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiTransformedCompositeDetail
        public async Task<bool> PopulateDsiTransformedCompositeDetails(CancellationToken cancellationToken)
        {
            if (!_DsiTransformedCompositeDetailRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiTransformedCompositeDetailHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiTransformedCompositeDetailQuery, List<DsiTransformedCompositeDetailGrpc>>>();
                    _DsiTransformedCompositeDetailRefreshInProgress = true;
                    GetDsiTransformedCompositeDetailQuery query = new GetDsiTransformedCompositeDetailQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiTransformedCompositeDetailGrpc>> results = await _DsiTransformedCompositeDetailHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiTransformedCompositeDetailGrpc.DsiTransformedCompositeDetailGrpcs.Clear();
                        _ListDsiTransformedCompositeDetailGrpc.DsiTransformedCompositeDetailGrpcs.AddRange(results.Value);
                    }

                    _DsiTransformedCompositeDetailRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiTransformedHarness
        public async Task<bool> PopulateDsiTransformedHarnesses(CancellationToken cancellationToken)
        {
            if (!_DsiTransformedHarnessRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiTransformedHarnessHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiTransformedHarnessQuery, List<DsiTransformedHarnessGrpc>>>();
                    _DsiTransformedHarnessRefreshInProgress = true;
                    GetDsiTransformedHarnessQuery query = new GetDsiTransformedHarnessQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiTransformedHarnessGrpc>> results = await _DsiTransformedHarnessHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiTransformedHarnessGrpc.DsiTransformedHarnessGrpcs.Clear();
                        _ListDsiTransformedHarnessGrpc.DsiTransformedHarnessGrpcs.AddRange(results.Value);
                    }

                    _DsiTransformedHarnessRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiTransformedModuleChildDetail
        public async Task<bool> PopulateDsiTransformedModuleChildDetails(CancellationToken cancellationToken)
        {
            if (!_DsiTransformedModuleChildDetailRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiTransformedModuleChildDetailHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiTransformedModuleChildDetailQuery, List<DsiTransformedModuleChildDetailGrpc>>>();
                    _DsiTransformedModuleChildDetailRefreshInProgress = true;
                    GetDsiTransformedModuleChildDetailQuery query = new GetDsiTransformedModuleChildDetailQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiTransformedModuleChildDetailGrpc>> results = await _DsiTransformedModuleChildDetailHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiTransformedModuleChildDetailGrpc.DsiTransformedModuleChildDetailGrpcs.Clear();
                        _ListDsiTransformedModuleChildDetailGrpc.DsiTransformedModuleChildDetailGrpcs.AddRange(results.Value);
                    }

                    _DsiTransformedModuleChildDetailRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiUnitOfMeasure
        public async Task<bool> PopulateDsiUnitOfMeasures(CancellationToken cancellationToken)
        {
            if (!_DsiUnitOfMeasureRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiUnitOfMeasureHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiUnitOfMeasureQuery, List<DsiUnitOfMeasureGrpc>>>();
                    _DsiUnitOfMeasureRefreshInProgress = true;
                    GetDsiUnitOfMeasureQuery query = new GetDsiUnitOfMeasureQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiUnitOfMeasureGrpc>> results = await _DsiUnitOfMeasureHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiUnitOfMeasureGrpc.DsiUnitOfMeasureGrpcs.Clear();
                        _ListDsiUnitOfMeasureGrpc.DsiUnitOfMeasureGrpcs.AddRange(results.Value);
                    }

                    _DsiUnitOfMeasureRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiWireMulticoreMarker
        public async Task<bool> PopulateDsiWireMulticoreMarkers(CancellationToken cancellationToken)
        {
            if (!_DsiWireMulticoreMarkerRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiWireMulticoreMarkerHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiWireMulticoreMarkerQuery, List<DsiWireMulticoreMarkerGrpc>>>();
                    _DsiWireMulticoreMarkerRefreshInProgress = true;
                    GetDsiWireMulticoreMarkerQuery query = new GetDsiWireMulticoreMarkerQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiWireMulticoreMarkerGrpc>> results = await _DsiWireMulticoreMarkerHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiWireMulticoreMarkerGrpc.DsiWireMulticoreMarkerGrpcs.Clear();
                        _ListDsiWireMulticoreMarkerGrpc.DsiWireMulticoreMarkerGrpcs.AddRange(results.Value);
                    }

                    _DsiWireMulticoreMarkerRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiWireSpecification
        public async Task<bool> PopulateDsiWireSpecifications(CancellationToken cancellationToken)
        {
            if (!_DsiWireSpecificationRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiWireSpecificationHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiWireSpecificationQuery, List<DsiWireSpecificationGrpc>>>();
                    _DsiWireSpecificationRefreshInProgress = true;
                    GetDsiWireSpecificationQuery query = new GetDsiWireSpecificationQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiWireSpecificationGrpc>> results = await _DsiWireSpecificationHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiWireSpecificationGrpc.DsiWireSpecificationGrpcs.Clear();
                        _ListDsiWireSpecificationGrpc.DsiWireSpecificationGrpcs.AddRange(results.Value);
                    }

                    _DsiWireSpecificationRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region DsiWireThroughNode
        public async Task<bool> PopulateDsiWireThroughNodes(CancellationToken cancellationToken)
        {
            if (!_DsiWireThroughNodeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _DsiWireThroughNodeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetDsiWireThroughNodeQuery, List<DsiWireThroughNodeGrpc>>>();
                    _DsiWireThroughNodeRefreshInProgress = true;
                    GetDsiWireThroughNodeQuery query = new GetDsiWireThroughNodeQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<DsiWireThroughNodeGrpc>> results = await _DsiWireThroughNodeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListDsiWireThroughNodeGrpc.DsiWireThroughNodeGrpcs.Clear();
                        _ListDsiWireThroughNodeGrpc.DsiWireThroughNodeGrpcs.AddRange(results.Value);
                    }

                    _DsiWireThroughNodeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region RfqNprRequest
        public async Task<bool> PopulateRfqNprRequest(CancellationToken cancellationToken)
        {
            if (!_RfqNprRequestRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _RfqNprRequestHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetRfqNprRequestQuery, List<RfqNprRequestGrpc>>>();
                    _RfqNprRequestRefreshInProgress = true;
                    GetRfqNprRequestQuery query = new GetRfqNprRequestQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<RfqNprRequestGrpc>> results = await _RfqNprRequestHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListRfqNprRequestGrpc.RfqNprRequestGrpcs.Clear();
                        _ListRfqNprRequestGrpc.RfqNprRequestGrpcs.AddRange(results.Value);
                    }

                    _RfqNprRequestRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////
        #endregion
        #endregion
        public async Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig, Action<IEnumerable<T>> setResponseCollection,
        CancellationToken cancellationToken)
        {
            Expression<Func<T, bool>> filterExpression = DynamicExpressionParser.ParseLambda<T, bool>(parsingConfig, false, filterExpressionString);
            Func<T, bool> compiledExpression = filterExpression.Compile();
            IEnumerable<T> filteredList = new List<T>();
            filteredList = await Filter(compiledExpression, cancellationToken);
            setResponseCollection(filteredList);
        }

        public async Task<IEnumerable<T>> Filter<T>(Func<T, bool> func, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return typeof(T).Name.ToUpperInvariant() switch
                {
                    "RFQDRAWINGPARTNUMBERSGRPC" => _ListRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.Cast<T>().Where(func).ToList(),
                    "RFQREASONGRPC" => _ListRfqReasonsGrpc.RfqReasons.Cast<T>().Where(func).ToList(),
                    "RFQNOTESGRPC" => _ListRfqNotesGrpc.RfqNotes.Cast<T>().Where(func).ToList(),
                    "RFQPROJECTGRPC" => _ListRfqProjectsGrpc.RfqProjects.Cast<T>().Where(func).ToList(),
                    "DSIBENDGRPC" => _ListDsiBendsGrpc.DsiBends.Cast<T>().Where(func).ToList(),
                    "DSIBRANCHCONFIGURATIONGRPC" => _ListDsiBranchConfigurationsGrpc.DsiBranchConfigurations.Cast<T>().Where(func).ToList(),
                    "DSIBRANCHCONFIGURATIONBENDASSOCIATIONGRPC" => _ListDsiBranchConfigurationBendAssociationsGrpc.DsiBranchConfigurationBendAssociations.Cast<T>().Where(func).ToList(),
                    "DSIBRANCHINSULATIONGRPC" => _ListDsiBranchInsulationsGrpc.DsiBranchInsulations.Cast<T>().Where(func).ToList(),
                    "DSIBRANCHINSULATIONTHROUGHNODEGRPC" => _ListDsiBranchInsulationThroughNodesGrpc.DsiBranchInsulationThroughNodes.Cast<T>().Where(func).ToList(),
                    "DSICAVITYMAPPINGGRPC" => _ListDsiCavityMappings.DsiCavityMappingGrpcs.Cast<T>().Where(func).ToList(),
                    "DSICENTRESTRIPGRPC" => _ListDsiCentreStripGrpc.DsiCentreStripGrpcs.Cast<T>().Where(func).ToList(),
                    "DSICIRCUITOPTIONGRPC" => _ListDsiCircuitOptionGrpc.DsiCircuitOptionGrpcs.Cast<T>().Where(func).ToList(),
                    "DSICOMPONENTGRPC" => _ListDsiComponentGrpc.DsiComponentGrpcs.Cast<T>().Where(func).ToList(),
                    "DSICOMPOSITEDETAILGRPC" => _ListDsiCompositeDetailGrpc.DsiCompositeDetailGrpcs.Cast<T>().Where(func).ToList(),
                    "DSICOMPOSITEDETAILCIRCUITOPTIONASSOCIATIONGRPC" => _ListDsiCompositeDetailCircuitOptionAssociationGrpc.DsiCompositeDetailCircuitOptionAssociationGrpcs.Cast<T>().Where(func).ToList(),
                    "DSICOMPOSITEOPTIONGRPC" => _ListDsiCompositeOptionGrpc.DsiCompositeOptionGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIHARNESSGRPC" => _ListDsiHarnessGrpc.DsiHarnessGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIHARNESSSCOPEGRPC" => _ListDsiHarnessScopeGrpc.DsiHarnessScopeGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIHARNESSSCOPESCOPEASSOCIATIONGRPC" => _ListDsiHarnessScopeScopeAssociationGrpc.DsiHarnessScopeScopeAssociationGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIMANUALBOMQUANTITYGRPC" => _ListDsiManualBomQuantityGrpc.DsiManualBomQuantityGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIMIDWIRECOMPONENTGRPC" => _ListDsiMidWireComponentGrpc.DsiMidWireComponentGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIMODULECHILDDETAILGRPC" => _ListDsiModuleChildDetailGrpc.DsiModuleChildDetailGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIMODULECOMPATIBILITYGRPC" => _ListDsiModuleCompatibilityGrpc.DsiModuleCompatibilityGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIMULTICORESPECIFICATIONGRPC" => _ListDsiMulticoreSpecificationGrpc.DsiMulticoreSpecificationGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIPINMAPPINGGRPC" => _ListDsiPinMappingGrpc.DsiPinMappingGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIPINMAPPINGCAVITYMAPPINGASSOCIATIONGRPC" => _ListDsiPinMappingCavityMappingAssociationGrpc.DsiPinMappingCavityMappingAssociationGrpcs.Cast<T>().Where(func).ToList(),
                    "DSISCOPEGRPC" => _ListDsiScopeGrpc.DsiScopeGrpcs.Cast<T>().Where(func).ToList(),
                    "DSISUPPLIERGRPC" => _ListDsiSupplierGrpc.DsiSupplierGrpcs.Cast<T>().Where(func).ToList(),
                    "DSITRANSFORMEDCOMPOSITEDETAILGRPC" => _ListDsiTransformedCompositeDetailGrpc.DsiTransformedCompositeDetailGrpcs.Cast<T>().Where(func).ToList(),
                    "DSITRANSFORMEDHARNESSGRPC" => _ListDsiTransformedHarnessGrpc.DsiTransformedHarnessGrpcs.Cast<T>().Where(func).ToList(),
                    "DSITRANSFORMEDMODULECHILDDETAILGRPC" => _ListDsiTransformedModuleChildDetailGrpc.DsiTransformedModuleChildDetailGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIUNITOFMEASUREGRPC" => _ListDsiUnitOfMeasureGrpc.DsiUnitOfMeasureGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIWIREMULTICOREMARKERGRPC" => _ListDsiWireMulticoreMarkerGrpc.DsiWireMulticoreMarkerGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIWIRESPECIFICATIONGRPC" => _ListDsiWireSpecificationGrpc.DsiWireSpecificationGrpcs.Cast<T>().Where(func).ToList(),
                    "DSIWIRETHROUGHNODEGRPC" => _ListDsiWireThroughNodeGrpc.DsiWireThroughNodeGrpcs.Cast<T>().Where(func).ToList(),
                    "RFQNPRREQUESTGRPC" => _ListRfqNprRequestGrpc.RfqNprRequestGrpcs.Cast<T>().Where(func).ToList(),
                    _ => throw new NotSupportedException($"Filtering not supported for type {typeof(T).Name}")
                };
            }, cancellationToken);
        }
        void PopulateSampleData()
        {
            _ListRfqDrawingPartNumbersGrpc = SampleRfqDataService.PopulateRfqDrawingPartNumbersGrpc();
            _ListRfqProjectsGrpc = SampleRfqDataService.PopulateRfqProjectGrpc();
            _ListRfqNotesGrpc = SampleRfqDataService.PopulateRfqNotesGrpc();
            _ListRfqReasonsGrpc = SampleRfqDataService.PopulateRfqReasonGrpc();
            _ListDsiBendsGrpc = SampleRfqDataService.PopulateDsiBendGrpc();
            _ListDsiBranchConfigurationsGrpc = SampleRfqDataService.PopulateDsiBranchConfigurationGrpc();
            _ListDsiBranchConfigurationBendAssociationsGrpc = SampleRfqDataService.PopulateDsiBranchConfigurationBendAssociationGrpc();
            _ListDsiBranchInsulationsGrpc = SampleRfqDataService.PopulateDsiBranchInsulationGrpc();
            _ListDsiBranchInsulationThroughNodesGrpc = SampleRfqDataService.PopulateDsiBranchInsulationThroughNodeGrpc();
            _ListDsiCavityMappings = SampleRfqDataService.PopulateDsiCavityMappingGrpc();
            _ListDsiCircuitOptionGrpc = SampleRfqDataService.PopulateDsiCircuitOptionGrpc();
            _ListDsiCentreStripGrpc = SampleRfqDataService.PopulateDsiCentreStripGrpc();
            _ListDsiComponentGrpc = SampleRfqDataService.PopulateDsiComponentGrpc();
            _ListDsiCompositeDetailGrpc = SampleRfqDataService.PopulateDsiCompositeDetailGrpc();
            _ListDsiCompositeDetailCircuitOptionAssociationGrpc = SampleRfqDataService.PopulateDsiCompositeDetailCircuitOptionAssociationGrpc();
            _ListDsiCompositeOptionGrpc = SampleRfqDataService.PopulateDsiCompositeOptionGrpc();
            _ListDsiHarnessGrpc = SampleRfqDataService.PopulateDsiHarnessGrpc();
            _ListDsiHarnessScopeGrpc = SampleRfqDataService.PopulateDsiHarnessScopeGrpc();
            _ListDsiHarnessScopeScopeAssociationGrpc = SampleRfqDataService.PopulateDsiHarnessScopeScopeAssociationGrpc();
            _ListDsiManualBomQuantityGrpc = SampleRfqDataService.PopulateDsiManualBomQuantityGrpc();
            _ListDsiMidWireComponentGrpc = SampleRfqDataService.PopulateDsiMidWireComponentGrpc();
            _ListDsiModuleChildDetailGrpc = SampleRfqDataService.PopulateDsiModuleChildDetailGrpc();
            _ListDsiModuleCompatibilityGrpc = SampleRfqDataService.PopulateDsiModuleCompatibilityGrpc();
            _ListDsiMulticoreSpecificationGrpc = SampleRfqDataService.PopulateDsiMulticoreSpecificationGrpc();
            _ListDsiPinMappingGrpc = SampleRfqDataService.PopulateDsiPinMappingGrpc();
            _ListDsiPinMappingCavityMappingAssociationGrpc = SampleRfqDataService.PopulateDsiPinMappingCavityMappingAssociationGrpc();
            _ListDsiScopeGrpc = SampleRfqDataService.PopulateDsiScopeGrpc();
            _ListDsiSupplierGrpc = SampleRfqDataService.PopulateDsiSupplierGrpc();
            _ListDsiTransformedCompositeDetailGrpc = SampleRfqDataService.PopulateDsiTransformedCompositeDetailGrpc();
            _ListDsiTransformedHarnessGrpc = SampleRfqDataService.PopulateDsiTransformedHarnessGrpc();
            _ListDsiTransformedModuleChildDetailGrpc = SampleRfqDataService.PopulateDsiTransformedModuleChildDetailGrpc();
            _ListDsiUnitOfMeasureGrpc = SampleRfqDataService.PopulateDsiUnitOfMeasureGrpc();
            _ListDsiWireMulticoreMarkerGrpc = SampleRfqDataService.PopulateDsiWireMulticoreMarkerGrpc();
            _ListDsiWireSpecificationGrpc = SampleRfqDataService.PopulateDsiWireSpecificationGrpc();
            _ListDsiWireThroughNodeGrpc = SampleRfqDataService.PopulateDsiWireThroughNodeGrpc();
            _ListRfqNprRequestGrpc = SampleRfqDataService.PopulateRfqNprRequestGrpc();

        }
    }
}
