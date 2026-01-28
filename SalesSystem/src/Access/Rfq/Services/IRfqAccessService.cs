namespace Rfq.Services
{
    public interface IRfqAccessService
    {
        #region PartNumber

        Task<ListRfqDrawingPartNumbersGrpc> GetAllRfqDrawingPartNumbers(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListRfqDrawingPartNumbersGrpc> CreateRfqDrawingPartNumbers(RfqDrawingPartNumbersGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqDrawingPartNumbers(RfqDrawingPartNumbersGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqDrawingPartNumbers(CancellationToken cancellationToken);

        #endregion

        #region Project

        Task<ListRfqProjectGrpc> GetAllRfqProjects(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListRfqProjectGrpc> CreateRfqProjects(RfqProjectGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqProjects(RfqProjectGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqProjects(CancellationToken cancellationToken);
        Task<ListRfqProjectGrpc> DeleteRfqProjectByRowId(RfqProjectGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region Notes

        Task<ListRfqNotesGrpc> GetAllRfqNotes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListRfqNotesGrpc> CreateRfqNotes(RfqNotesGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqNotes(RfqNotesGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqNotes(CancellationToken cancellationToken);

        #endregion

        #region Reason

        Task<ListRfqReasonGrpc> GetAllRfqReasons(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListRfqReasonGrpc> CreateRfqReason(RfqReasonGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqReasons(RfqReasonGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqReasons(CancellationToken cancellationToken);
        #endregion

        #region DsiBend

        Task<ListDsiBendGrpc> GetAllDsiBends(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiBendGrpc> CreateDsiBends(DsiBendGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBends(DsiBendGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBends(CancellationToken cancellationToken);

        #endregion

        #region DsiBranchConfiguration

        Task<ListDsiBranchConfigurationGrpc> GetAllDsiBranchConfigurations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiBranchConfigurationGrpc> CreateDsiBranchConfigurations(DsiBranchConfigurationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBranchConfigurations(DsiBranchConfigurationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBranchConfigurations(CancellationToken cancellationToken);

        #endregion

        #region DsiBranchConfigurationBendAssociation

        Task<ListDsiBranchConfigurationBendAssociationGrpc> GetAllDsiBranchConfigurationBendAssociations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiBranchConfigurationBendAssociationGrpc> CreateDsiBranchConfigurationBendAssociations(DsiBranchConfigurationBendAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBranchConfigurationBendAssociations(DsiBranchConfigurationBendAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBranchConfigurationBendAssociations(CancellationToken cancellationToken);

        #endregion

        #region DsiBranchInsulation

        Task<ListDsiBranchInsulationGrpc> GetAllDsiBranchInsulations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiBranchInsulationGrpc> CreateDsiBranchInsulations(DsiBranchInsulationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBranchInsulations(DsiBranchInsulationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBranchInsulations(CancellationToken cancellationToken);

        #endregion

        #region DsiBranchInsulationThroughNode

        Task<ListDsiBranchInsulationThroughNodeGrpc> GetAllDsiBranchInsulationThroughNodes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiBranchInsulationThroughNodeGrpc> CreateDsiBranchInsulationThroughNodes(DsiBranchInsulationThroughNodeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBranchInsulationThroughNodes(DsiBranchInsulationThroughNodeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBranchInsulationThroughNodes(CancellationToken cancellationToken);

        #endregion

        #region DsiCavityMapping

        Task<ListDsiCavityMappingGrpc> GetAllDsiCavityMappings(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiCavityMappingGrpc> CreateDsiCavityMappings(DsiCavityMappingGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiCavityMappings(DsiCavityMappingGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiCavityMappings(CancellationToken cancellationToken);

        #endregion

        #region DsiCentreStrip

        Task<ListDsiCentreStripGrpc> GetAllDsiCentreStrips(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiCentreStripGrpc> CreateDsiCentreStrips(DsiCentreStripGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiCentreStrips(DsiCentreStripGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiCentreStrips(CancellationToken cancellationToken);

        #endregion

        #region DsiCircuitOption

        Task<ListDsiCircuitOptionGrpc> GetAllDsiCircuitOptions(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiCircuitOptionGrpc> CreateDsiCircuitOptions(DsiCircuitOptionGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiCircuitOptions(DsiCircuitOptionGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiCircuitOptions(CancellationToken cancellationToken);

        #endregion

        #region DsiComponent

        Task<ListDsiComponentGrpc> GetAllDsiComponents(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiComponentGrpc> CreateDsiComponents(DsiComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiComponents(DsiComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiComponents(CancellationToken cancellationToken);

        #endregion

        #region DsiCompositeDetail

        Task<ListDsiCompositeDetailGrpc> GetAllDsiCompositeDetails(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiCompositeDetailGrpc> CreateDsiCompositeDetails(DsiCompositeDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiCompositeDetails(DsiCompositeDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiCompositeDetails(CancellationToken cancellationToken);

        #endregion

        #region DsiCompositeDetailCircuitOptionAssociation

        Task<ListDsiCompositeDetailCircuitOptionAssociationGrpc> GetAllDsiCompositeDetailCircuitOptionAssociations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiCompositeDetailCircuitOptionAssociationGrpc> CreateDsiCompositeDetailCircuitOptionAssociations(DsiCompositeDetailCircuitOptionAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiCompositeDetailCircuitOptionAssociations(DsiCompositeDetailCircuitOptionAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiCompositeDetailCircuitOptionAssociations(CancellationToken cancellationToken);

        #endregion

        #region DsiCompositeOption

        Task<ListDsiCompositeOptionGrpc> GetAllDsiCompositeOptions(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiCompositeOptionGrpc> CreateDsiCompositeOptions(DsiCompositeOptionGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiCompositeOptions(DsiCompositeOptionGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiCompositeOptions(CancellationToken cancellationToken);

        #endregion

        #region DsiHarness

        Task<ListDsiHarnessGrpc> GetAllDsiHarnesses(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiHarnessGrpc> CreateDsiHarnesses(DsiHarnessGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiHarnesses(DsiHarnessGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiHarnesses(CancellationToken cancellationToken);

        #endregion

        #region DsiHarnessScope

        Task<ListDsiHarnessScopeGrpc> GetAllDsiHarnessScopes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiHarnessScopeGrpc> CreateDsiHarnessScopes(DsiHarnessScopeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiHarnessScopes(DsiHarnessScopeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiHarnessScopes(CancellationToken cancellationToken);

        #endregion

        #region DsiHarnessScopeScopeAssociation

        Task<ListDsiHarnessScopeScopeAssociationGrpc> GetAllDsiHarnessScopeScopeAssociations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiHarnessScopeScopeAssociationGrpc> CreateDsiHarnessScopeScopeAssociations(DsiHarnessScopeScopeAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiHarnessScopeScopeAssociations(DsiHarnessScopeScopeAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiHarnessScopeScopeAssociations(CancellationToken cancellationToken);

        #endregion

        #region DsiManualBomQuantity

        Task<ListDsiManualBomQuantityGrpc> GetAllDsiManualBomQuantities(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiManualBomQuantityGrpc> CreateDsiManualBomQuantities(DsiManualBomQuantityGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiManualBomQuantities(DsiManualBomQuantityGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiManualBomQuantities(CancellationToken cancellationToken);

        #endregion

        #region DsiMidWireComponent

        Task<ListDsiMidWireComponentGrpc> GetAllDsiMidWireComponents(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiMidWireComponentGrpc> CreateDsiMidWireComponents(DsiMidWireComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiMidWireComponents(DsiMidWireComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiMidWireComponents(CancellationToken cancellationToken);

        #endregion

        #region DsiModuleChildDetail

        Task<ListDsiModuleChildDetailGrpc> GetAllDsiModuleChildDetails(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiModuleChildDetailGrpc> CreateDsiModuleChildDetails(DsiModuleChildDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiModuleChildDetails(DsiModuleChildDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiModuleChildDetails(CancellationToken cancellationToken);

        #endregion

        #region DsiModuleCompatibility

        Task<ListDsiModuleCompatibilityGrpc> GetAllDsiModuleCompatibilities(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiModuleCompatibilityGrpc> CreateDsiModuleCompatibilities(DsiModuleCompatibilityGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiModuleCompatibilities(DsiModuleCompatibilityGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiModuleCompatibilities(CancellationToken cancellationToken);

        #endregion

        #region DsiMulticoreSpecification

        Task<ListDsiMulticoreSpecificationGrpc> GetAllDsiMulticoreSpecifications(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiMulticoreSpecificationGrpc> CreateDsiMulticoreSpecifications(DsiMulticoreSpecificationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiMulticoreSpecifications(DsiMulticoreSpecificationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiMulticoreSpecifications(CancellationToken cancellationToken);

        #endregion

        #region DsiPinMapping

        Task<ListDsiPinMappingGrpc> GetAllDsiPinMappings(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiPinMappingGrpc> CreateDsiPinMappings(DsiPinMappingGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiPinMappings(DsiPinMappingGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiPinMappings(CancellationToken cancellationToken);

        #endregion

        #region DsiPinMappingCavityMappingAssociation

        Task<ListDsiPinMappingCavityMappingAssociationGrpc> GetAllDsiPinMappingCavityMappingAssociations(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiPinMappingCavityMappingAssociationGrpc> CreateDsiPinMappingCavityMappingAssociations(DsiPinMappingCavityMappingAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiPinMappingCavityMappingAssociations(DsiPinMappingCavityMappingAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiPinMappingCavityMappingAssociations(CancellationToken cancellationToken);

        #endregion

        #region DsiScope

        Task<ListDsiScopeGrpc> GetAllDsiScopes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiScopeGrpc> CreateDsiScopes(DsiScopeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiScopes(DsiScopeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiScopes(CancellationToken cancellationToken);

        #endregion

        #region DsiSupplier

        Task<ListDsiSupplierGrpc> GetAllDsiSuppliers(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiSupplierGrpc> CreateDsiSuppliers(DsiSupplierGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiSuppliers(DsiSupplierGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiSuppliers(CancellationToken cancellationToken);

        #endregion

        #region DsiTransformedCompositeDetail

        Task<ListDsiTransformedCompositeDetailGrpc> GetAllDsiTransformedCompositeDetails(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiTransformedCompositeDetailGrpc> CreateDsiTransformedCompositeDetails(DsiTransformedCompositeDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiTransformedCompositeDetails(DsiTransformedCompositeDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiTransformedCompositeDetails(CancellationToken cancellationToken);

        #endregion

        #region DsiTransformedHarness

        Task<ListDsiTransformedHarnessGrpc> GetAllDsiTransformedHarnesses(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiTransformedHarnessGrpc> CreateDsiTransformedHarnesses(DsiTransformedHarnessGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiTransformedHarnesses(DsiTransformedHarnessGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiTransformedHarnesses(CancellationToken cancellationToken);

        #endregion

        #region DsiTransformedModuleChildDetail

        Task<ListDsiTransformedModuleChildDetailGrpc> GetAllDsiTransformedModuleChildDetails(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiTransformedModuleChildDetailGrpc> CreateDsiTransformedModuleChildDetails(DsiTransformedModuleChildDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiTransformedModuleChildDetails(DsiTransformedModuleChildDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiTransformedModuleChildDetails(CancellationToken cancellationToken);

        #endregion

        #region DsiUnitOfMeasure

        Task<ListDsiUnitOfMeasureGrpc> GetAllDsiUnitOfMeasures(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiUnitOfMeasureGrpc> CreateDsiUnitOfMeasures(DsiUnitOfMeasureGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiUnitOfMeasures(DsiUnitOfMeasureGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiUnitOfMeasures(CancellationToken cancellationToken);

        #endregion

        #region DsiWireMulticoreMarker

        Task<ListDsiWireMulticoreMarkerGrpc> GetAllDsiWireMulticoreMarkers(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiWireMulticoreMarkerGrpc> CreateDsiWireMulticoreMarkers(DsiWireMulticoreMarkerGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiWireMulticoreMarkers(DsiWireMulticoreMarkerGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiWireMulticoreMarkers(CancellationToken cancellationToken);

        #endregion

        #region DsiWireSpecification

        Task<ListDsiWireSpecificationGrpc> GetAllDsiWireSpecifications(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiWireSpecificationGrpc> CreateDsiWireSpecifications(DsiWireSpecificationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiWireSpecifications(DsiWireSpecificationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiWireSpecifications(CancellationToken cancellationToken);

        #endregion

        #region DsiWireThroughNode

        Task<ListDsiWireThroughNodeGrpc> GetAllDsiWireThroughNodes(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListDsiWireThroughNodeGrpc> CreateDsiWireThroughNodes(DsiWireThroughNodeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiWireThroughNodes(DsiWireThroughNodeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiWireThroughNodes(CancellationToken cancellationToken);

        #endregion

        Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken);
    }
}
