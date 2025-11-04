namespace Rfq.Services
{
    public interface IRfqAccessService
    {
        #region PartNumber

        Task<ListRfqDrawingPartNumbersGrpc> GetAllRfqDrawingPartNumbers(CancellationToken cancellationToken);
        Task<ListRfqDrawingPartNumbersGrpc> GetRfqDrawingPartNumbersByRowId(RfqDrawingPartNumbersGrpcRequest request, CancellationToken cancellationToken);
        Task<ListRfqDrawingPartNumbersGrpc> CreateRfqDrawingPartNumbers(RfqDrawingPartNumbersGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqDrawingPartNumbers(RfqDrawingPartNumbersGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqDrawingPartNumbers(CancellationToken cancellationToken);

        #endregion

        #region Project

        Task<ListRfqProjectGrpc> GetAllRfqProjects(CancellationToken cancellationToken);
        Task<ListRfqProjectGrpc> GetRfqProjectByRowId(RfqProjectGrpcRequest request, CancellationToken cancellationToken);
        Task<ListRfqProjectGrpc> CreateRfqProjects(RfqProjectGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqProjects(RfqProjectGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqProjects(CancellationToken cancellationToken);
        Task<ListRfqProjectGrpc> DeleteRfqProjectByRowId(RfqProjectGrpcRequest request, CancellationToken cancellationToken);
        #endregion

        #region Notes

        Task<ListRfqNotesGrpc> GetAllRfqNotes(CancellationToken cancellationToken);
        Task<ListRfqNotesGrpc> GetRfqNotesByRowId(RfqNotesGrpcRequest request, CancellationToken cancellationToken);
        Task<ListRfqNotesGrpc> CreateRfqNotes(RfqNotesGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqNotes(RfqNotesGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqNotes(CancellationToken cancellationToken);

        #endregion

        #region Reason

        Task<ListRfqReasonGrpc> GetAllRfqReasons(CancellationToken cancellationToken);
        Task<ListRfqReasonGrpc> GetRfqReasonsByRowId(RfqReasonGrpcRequest reason, CancellationToken cancellationToken);
        Task<ListRfqReasonGrpc> CreateRfqReason(RfqReasonGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqReasons(RfqReasonGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqReasons(CancellationToken cancellationToken);
        #endregion

        #region DsiBend

        Task<ListDsiBendGrpc> GetAllDsiBends(CancellationToken cancellationToken);
        Task<ListDsiBendGrpc> GetDsiBendsByRowId(DsiBendGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiBendGrpc> CreateDsiBends(DsiBendGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBends(DsiBendGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBends(CancellationToken cancellationToken);

        #endregion

        #region DsiBranchConfiguration

        Task<ListDsiBranchConfigurationGrpc> GetAllDsiBranchConfigurations(CancellationToken cancellationToken);
        Task<ListDsiBranchConfigurationGrpc> GetDsiBranchConfigurationsByRowId(DsiBranchConfigurationGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiBranchConfigurationGrpc> CreateDsiBranchConfigurations(DsiBranchConfigurationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBranchConfigurations(DsiBranchConfigurationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBranchConfigurations(CancellationToken cancellationToken);

        #endregion

        #region DsiBranchConfigurationBendAssociation

        Task<ListDsiBranchConfigurationBendAssociationGrpc> GetAllDsiBranchConfigurationBendAssociations(CancellationToken cancellationToken);
        Task<ListDsiBranchConfigurationBendAssociationGrpc> GetDsiBranchConfigurationBendAssociationsByRowId(DsiBranchConfigurationBendAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiBranchConfigurationBendAssociationGrpc> CreateDsiBranchConfigurationBendAssociations(DsiBranchConfigurationBendAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBranchConfigurationBendAssociations(DsiBranchConfigurationBendAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBranchConfigurationBendAssociations(CancellationToken cancellationToken);

        #endregion

        #region DsiBranchInsulation

        Task<ListDsiBranchInsulationGrpc> GetAllDsiBranchInsulations(CancellationToken cancellationToken);
        Task<ListDsiBranchInsulationGrpc> GetDsiBranchInsulationsByRowId(DsiBranchInsulationGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiBranchInsulationGrpc> CreateDsiBranchInsulations(DsiBranchInsulationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBranchInsulations(DsiBranchInsulationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBranchInsulations(CancellationToken cancellationToken);

        #endregion

        #region DsiBranchInsulationThroughNode

        Task<ListDsiBranchInsulationThroughNodeGrpc> GetAllDsiBranchInsulationThroughNodes(CancellationToken cancellationToken);
        Task<ListDsiBranchInsulationThroughNodeGrpc> GetDsiBranchInsulationThroughNodesByRowId(DsiBranchInsulationThroughNodeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiBranchInsulationThroughNodeGrpc> CreateDsiBranchInsulationThroughNodes(DsiBranchInsulationThroughNodeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBranchInsulationThroughNodes(DsiBranchInsulationThroughNodeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBranchInsulationThroughNodes(CancellationToken cancellationToken);

        #endregion

        #region DsiCavityMapping

        Task<ListDsiCavityMappingGrpc> GetAllDsiCavityMappings(CancellationToken cancellationToken);
        Task<ListDsiCavityMappingGrpc> GetDsiCavityMappingsByRowId(DsiCavityMappingGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiCavityMappingGrpc> CreateDsiCavityMappings(DsiCavityMappingGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiCavityMappings(DsiCavityMappingGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiCavityMappings(CancellationToken cancellationToken);

        #endregion

        #region DsiCentreStrip

        Task<ListDsiCentreStripGrpc> GetAllDsiCentreStrips(CancellationToken cancellationToken);
        Task<ListDsiCentreStripGrpc> GetDsiCentreStripsByRowId(DsiCentreStripGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiCentreStripGrpc> CreateDsiCentreStrips(DsiCentreStripGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiCentreStrips(DsiCentreStripGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiCentreStrips(CancellationToken cancellationToken);

        #endregion

        #region DsiCircuitOption

        Task<ListDsiCircuitOptionGrpc> GetAllDsiCircuitOptions(CancellationToken cancellationToken);
        Task<ListDsiCircuitOptionGrpc> GetDsiCircuitOptionsByRowId(DsiCircuitOptionGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiCircuitOptionGrpc> CreateDsiCircuitOptions(DsiCircuitOptionGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiCircuitOptions(DsiCircuitOptionGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiCircuitOptions(CancellationToken cancellationToken);

        #endregion

        #region DsiComponent

        Task<ListDsiComponentGrpc> GetAllDsiComponents(CancellationToken cancellationToken);
        Task<ListDsiComponentGrpc> GetDsiComponentsByRowId(DsiComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiComponentGrpc> CreateDsiComponents(DsiComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiComponents(DsiComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiComponents(CancellationToken cancellationToken);

        #endregion

        #region DsiCompositeDetail

        Task<ListDsiCompositeDetailGrpc> GetAllDsiCompositeDetails(CancellationToken cancellationToken);
        Task<ListDsiCompositeDetailGrpc> GetDsiCompositeDetailsByRowId(DsiCompositeDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiCompositeDetailGrpc> CreateDsiCompositeDetails(DsiCompositeDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiCompositeDetails(DsiCompositeDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiCompositeDetails(CancellationToken cancellationToken);

        #endregion

        #region DsiCompositeDetailCircuitOptionAssociation

        Task<ListDsiCompositeDetailCircuitOptionAssociationGrpc> GetAllDsiCompositeDetailCircuitOptionAssociations(CancellationToken cancellationToken);
        Task<ListDsiCompositeDetailCircuitOptionAssociationGrpc> GetDsiCompositeDetailCircuitOptionAssociationsByRowId(DsiCompositeDetailCircuitOptionAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiCompositeDetailCircuitOptionAssociationGrpc> CreateDsiCompositeDetailCircuitOptionAssociations(DsiCompositeDetailCircuitOptionAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiCompositeDetailCircuitOptionAssociations(DsiCompositeDetailCircuitOptionAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiCompositeDetailCircuitOptionAssociations(CancellationToken cancellationToken);

        #endregion

        #region DsiCompositeOption

        Task<ListDsiCompositeOptionGrpc> GetAllDsiCompositeOptions(CancellationToken cancellationToken);
        Task<ListDsiCompositeOptionGrpc> GetDsiCompositeOptionsByRowId(DsiCompositeOptionGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiCompositeOptionGrpc> CreateDsiCompositeOptions(DsiCompositeOptionGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiCompositeOptions(DsiCompositeOptionGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiCompositeOptions(CancellationToken cancellationToken);

        #endregion

        #region DsiHarness

        Task<ListDsiHarnessGrpc> GetAllDsiHarnesses(CancellationToken cancellationToken);
        Task<ListDsiHarnessGrpc> GetDsiHarnessesByRowId(DsiHarnessGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiHarnessGrpc> CreateDsiHarnesses(DsiHarnessGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiHarnesses(DsiHarnessGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiHarnesses(CancellationToken cancellationToken);

        #endregion

        #region DsiHarnessScope

        Task<ListDsiHarnessScopeGrpc> GetAllDsiHarnessScopes(CancellationToken cancellationToken);
        Task<ListDsiHarnessScopeGrpc> GetDsiHarnessScopesByRowId(DsiHarnessScopeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiHarnessScopeGrpc> CreateDsiHarnessScopes(DsiHarnessScopeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiHarnessScopes(DsiHarnessScopeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiHarnessScopes(CancellationToken cancellationToken);

        #endregion

        #region DsiHarnessScopeScopeAssociation

        Task<ListDsiHarnessScopeScopeAssociationGrpc> GetAllDsiHarnessScopeScopeAssociations(CancellationToken cancellationToken);
        Task<ListDsiHarnessScopeScopeAssociationGrpc> GetDsiHarnessScopeScopeAssociationsByRowId(DsiHarnessScopeScopeAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiHarnessScopeScopeAssociationGrpc> CreateDsiHarnessScopeScopeAssociations(DsiHarnessScopeScopeAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiHarnessScopeScopeAssociations(DsiHarnessScopeScopeAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiHarnessScopeScopeAssociations(CancellationToken cancellationToken);

        #endregion

        #region DsiManualBomQuantity

        Task<ListDsiManualBomQuantityGrpc> GetAllDsiManualBomQuantities(CancellationToken cancellationToken);
        Task<ListDsiManualBomQuantityGrpc> GetDsiManualBomQuantitiesByRowId(DsiManualBomQuantityGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiManualBomQuantityGrpc> CreateDsiManualBomQuantities(DsiManualBomQuantityGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiManualBomQuantities(DsiManualBomQuantityGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiManualBomQuantities(CancellationToken cancellationToken);

        #endregion

        #region DsiMidWireComponent

        Task<ListDsiMidWireComponentGrpc> GetAllDsiMidWireComponents(CancellationToken cancellationToken);
        Task<ListDsiMidWireComponentGrpc> GetDsiMidWireComponentsByRowId(DsiMidWireComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiMidWireComponentGrpc> CreateDsiMidWireComponents(DsiMidWireComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiMidWireComponents(DsiMidWireComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiMidWireComponents(CancellationToken cancellationToken);

        #endregion

        #region DsiModuleChildDetail

        Task<ListDsiModuleChildDetailGrpc> GetAllDsiModuleChildDetails(CancellationToken cancellationToken);
        Task<ListDsiModuleChildDetailGrpc> GetDsiModuleChildDetailsByRowId(DsiModuleChildDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiModuleChildDetailGrpc> CreateDsiModuleChildDetails(DsiModuleChildDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiModuleChildDetails(DsiModuleChildDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiModuleChildDetails(CancellationToken cancellationToken);

        #endregion

        #region DsiModuleCompatibility

        Task<ListDsiModuleCompatibilityGrpc> GetAllDsiModuleCompatibilities(CancellationToken cancellationToken);
        Task<ListDsiModuleCompatibilityGrpc> GetDsiModuleCompatibilitiesByRowId(DsiModuleCompatibilityGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiModuleCompatibilityGrpc> CreateDsiModuleCompatibilities(DsiModuleCompatibilityGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiModuleCompatibilities(DsiModuleCompatibilityGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiModuleCompatibilities(CancellationToken cancellationToken);

        #endregion

        #region DsiMulticoreSpecification

        Task<ListDsiMulticoreSpecificationGrpc> GetAllDsiMulticoreSpecifications(CancellationToken cancellationToken);
        Task<ListDsiMulticoreSpecificationGrpc> GetDsiMulticoreSpecificationsByRowId(DsiMulticoreSpecificationGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiMulticoreSpecificationGrpc> CreateDsiMulticoreSpecifications(DsiMulticoreSpecificationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiMulticoreSpecifications(DsiMulticoreSpecificationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiMulticoreSpecifications(CancellationToken cancellationToken);

        #endregion

        #region DsiPinMapping

        Task<ListDsiPinMappingGrpc> GetAllDsiPinMappings(CancellationToken cancellationToken);
        Task<ListDsiPinMappingGrpc> GetDsiPinMappingsByRowId(DsiPinMappingGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiPinMappingGrpc> CreateDsiPinMappings(DsiPinMappingGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiPinMappings(DsiPinMappingGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiPinMappings(CancellationToken cancellationToken);

        #endregion

        #region DsiPinMappingCavityMappingAssociation

        Task<ListDsiPinMappingCavityMappingAssociationGrpc> GetAllDsiPinMappingCavityMappingAssociations(CancellationToken cancellationToken);
        Task<ListDsiPinMappingCavityMappingAssociationGrpc> GetDsiPinMappingCavityMappingAssociationsByRowId(DsiPinMappingCavityMappingAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiPinMappingCavityMappingAssociationGrpc> CreateDsiPinMappingCavityMappingAssociations(DsiPinMappingCavityMappingAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiPinMappingCavityMappingAssociations(DsiPinMappingCavityMappingAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiPinMappingCavityMappingAssociations(CancellationToken cancellationToken);

        #endregion

        #region DsiScope

        Task<ListDsiScopeGrpc> GetAllDsiScopes(CancellationToken cancellationToken);
        Task<ListDsiScopeGrpc> GetDsiScopesByRowId(DsiScopeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiScopeGrpc> CreateDsiScopes(DsiScopeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiScopes(DsiScopeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiScopes(CancellationToken cancellationToken);

        #endregion

        #region DsiSupplier

        Task<ListDsiSupplierGrpc> GetAllDsiSuppliers(CancellationToken cancellationToken);
        Task<ListDsiSupplierGrpc> GetDsiSuppliersByRowId(DsiSupplierGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiSupplierGrpc> CreateDsiSuppliers(DsiSupplierGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiSuppliers(DsiSupplierGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiSuppliers(CancellationToken cancellationToken);

        #endregion

        #region DsiTransformedCompositeDetail

        Task<ListDsiTransformedCompositeDetailGrpc> GetAllDsiTransformedCompositeDetails(CancellationToken cancellationToken);
        Task<ListDsiTransformedCompositeDetailGrpc> GetDsiTransformedCompositeDetailsByRowId(DsiTransformedCompositeDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiTransformedCompositeDetailGrpc> CreateDsiTransformedCompositeDetails(DsiTransformedCompositeDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiTransformedCompositeDetails(DsiTransformedCompositeDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiTransformedCompositeDetails(CancellationToken cancellationToken);

        #endregion

        #region DsiTransformedHarness

        Task<ListDsiTransformedHarnessGrpc> GetAllDsiTransformedHarnesses(CancellationToken cancellationToken);
        Task<ListDsiTransformedHarnessGrpc> GetDsiTransformedHarnessesByRowId(DsiTransformedHarnessGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiTransformedHarnessGrpc> CreateDsiTransformedHarnesses(DsiTransformedHarnessGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiTransformedHarnesses(DsiTransformedHarnessGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiTransformedHarnesses(CancellationToken cancellationToken);

        #endregion

        #region DsiTransformedModuleChildDetail

        Task<ListDsiTransformedModuleChildDetailGrpc> GetAllDsiTransformedModuleChildDetails(CancellationToken cancellationToken);
        Task<ListDsiTransformedModuleChildDetailGrpc> GetDsiTransformedModuleChildDetailsByRowId(DsiTransformedModuleChildDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiTransformedModuleChildDetailGrpc> CreateDsiTransformedModuleChildDetails(DsiTransformedModuleChildDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiTransformedModuleChildDetails(DsiTransformedModuleChildDetailGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiTransformedModuleChildDetails(CancellationToken cancellationToken);

        #endregion

        #region DsiUnitOfMeasure

        Task<ListDsiUnitOfMeasureGrpc> GetAllDsiUnitOfMeasures(CancellationToken cancellationToken);
        Task<ListDsiUnitOfMeasureGrpc> GetDsiUnitOfMeasuresByRowId(DsiUnitOfMeasureGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiUnitOfMeasureGrpc> CreateDsiUnitOfMeasures(DsiUnitOfMeasureGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiUnitOfMeasures(DsiUnitOfMeasureGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiUnitOfMeasures(CancellationToken cancellationToken);

        #endregion

        #region DsiWireMulticoreMarker

        Task<ListDsiWireMulticoreMarkerGrpc> GetAllDsiWireMulticoreMarkers(CancellationToken cancellationToken);
        Task<ListDsiWireMulticoreMarkerGrpc> GetDsiWireMulticoreMarkersByRowId(DsiWireMulticoreMarkerGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiWireMulticoreMarkerGrpc> CreateDsiWireMulticoreMarkers(DsiWireMulticoreMarkerGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiWireMulticoreMarkers(DsiWireMulticoreMarkerGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiWireMulticoreMarkers(CancellationToken cancellationToken);

        #endregion

        #region DsiWireSpecification

        Task<ListDsiWireSpecificationGrpc> GetAllDsiWireSpecifications(CancellationToken cancellationToken);
        Task<ListDsiWireSpecificationGrpc> GetDsiWireSpecificationsByRowId(DsiWireSpecificationGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiWireSpecificationGrpc> CreateDsiWireSpecifications(DsiWireSpecificationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiWireSpecifications(DsiWireSpecificationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiWireSpecifications(CancellationToken cancellationToken);

        #endregion

        #region DsiWireThroughNode

        Task<ListDsiWireThroughNodeGrpc> GetAllDsiWireThroughNodes(CancellationToken cancellationToken);
        Task<ListDsiWireThroughNodeGrpc> GetDsiWireThroughNodesByRowId(DsiWireThroughNodeGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiWireThroughNodeGrpc> CreateDsiWireThroughNodes(DsiWireThroughNodeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiWireThroughNodes(DsiWireThroughNodeGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiWireThroughNodes(CancellationToken cancellationToken);

        #endregion
    }
}
