namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
        #region Rfq
        #region RFQMetadata
        public static readonly ServiceEndpointRoutes RFQMetadata = new ServiceEndpointRoutes("RFQMetadata");
        public static readonly ServiceEndpointRoutes RFQMetadataUser = new ServiceEndpointRoutes("RFQMetadata/User");
        public static readonly ServiceEndpointRoutes RFQMetadataUserList = new ServiceEndpointRoutes("RFQMetadata/UserList");
        public static readonly ServiceEndpointRoutes RFQMetadataLast5 = new ServiceEndpointRoutes("RFQMetadata/Last5");
        #endregion
        #region RFQPart
        public static readonly ServiceEndpointRoutes RFQPart = new ServiceEndpointRoutes("RFQPart");
        public static readonly ServiceEndpointRoutes RFQPartNoMatchNpaSearch = new ServiceEndpointRoutes("RFQPart/NoMatchNPAReference");
        #endregion
        #region RFQEnquiry
        public static readonly ServiceEndpointRoutes RFQEnquiry = new ServiceEndpointRoutes("RFQEnquiry");
        public static readonly ServiceEndpointRoutes RFQEnquiryHarnessOneSearchProcedure = new ServiceEndpointRoutes("RFQEnquiry/HarnessOneSearchProcedure");
        public static readonly ServiceEndpointRoutes RFQEnquirySearchProcedure = new ServiceEndpointRoutes("RFQEnquiry/SearchProcedure");
        #endregion
        #endregion

        #region Dsi
        public static readonly ServiceEndpointRoutes DsiDataSynchronisation = new ServiceEndpointRoutes("DsiDataSynchronisation");
        #region Bend
        public static readonly ServiceEndpointRoutes Bend = new ServiceEndpointRoutes("Bend");
        #endregion
        #region BranchConfiguration
        public static readonly ServiceEndpointRoutes BranchConfiguration = new ServiceEndpointRoutes("BranchConfiguration");
        public static readonly ServiceEndpointRoutes BranchConfigurationHarness = new ServiceEndpointRoutes("BranchConfiguration/Harness");
        #endregion
        #region BranchInsulation
        public static readonly ServiceEndpointRoutes BranchInsulation = new ServiceEndpointRoutes("BranchInsulation");
        public static readonly ServiceEndpointRoutes BranchInsulationHarness = new ServiceEndpointRoutes("BranchInsulation/Harness");
        #endregion
        #region BranchInsulationThroughNode
        public static readonly ServiceEndpointRoutes BranchInsulationThroughNode = new ServiceEndpointRoutes("BranchInsulationThroughNode");
        public static readonly ServiceEndpointRoutes BranchInsulationThroughNodeHarness = new ServiceEndpointRoutes("BranchInsulationThroughNode/Harness");
        #endregion
        #region CavityMapping
        public static readonly ServiceEndpointRoutes CavityMapping = new ServiceEndpointRoutes("CavityMapping");
        #endregion
        #region CentreStrip
        public static readonly ServiceEndpointRoutes CentreStrip = new ServiceEndpointRoutes("CentreStrip");
        public static readonly ServiceEndpointRoutes CentreStripHarness = new ServiceEndpointRoutes("CentreStrip/Harness");
        #endregion
        #region CiscuitOption
        public static readonly ServiceEndpointRoutes CircuitOption = new ServiceEndpointRoutes("CircuitOption");
        #endregion
        #region Component
        public static readonly ServiceEndpointRoutes Component = new ServiceEndpointRoutes("Component");
        public static readonly ServiceEndpointRoutes ComponentHarness = new ServiceEndpointRoutes("Component/Harness");
        #endregion
        #region ComponentCompositeDetail
        public static readonly ServiceEndpointRoutes ComponentCompositeDetail = new ServiceEndpointRoutes("Component/CompositeDetail");
        public static readonly ServiceEndpointRoutes ComponentDerivativeInformation = new ServiceEndpointRoutes("Component/DerivativeInformation");
        #endregion
        #region CompositeDetail
        public static readonly ServiceEndpointRoutes CompositeDetail = new ServiceEndpointRoutes("CompositeDetail");
        public static readonly ServiceEndpointRoutes CompositeDetailHarness = new ServiceEndpointRoutes("CompositeDetail/Harness");
        #endregion
        #region CompositeOption
        public static readonly ServiceEndpointRoutes CompositeOption = new ServiceEndpointRoutes("CompositeOption");
        public static readonly ServiceEndpointRoutes CompositeOptionHarness = new ServiceEndpointRoutes("CompositeOption/Harness");
        #endregion
        #region Harness
        public static readonly ServiceEndpointRoutes Harness = new ServiceEndpointRoutes("Harness");
        public static readonly ServiceEndpointRoutes HarnessNameExist = new ServiceEndpointRoutes("Harness/Name");
        #endregion
        #region HarnessScope
        public static readonly ServiceEndpointRoutes HarnessScope = new ServiceEndpointRoutes("HarnessScope");
        public static readonly ServiceEndpointRoutes HarnessScopeHarness = new ServiceEndpointRoutes("HarnessScope/Harness");
        #endregion
        #region ManualBomQuantity
        public static readonly ServiceEndpointRoutes ManualBomQuantity = new ServiceEndpointRoutes("ManualBomQuantity");
        public static readonly ServiceEndpointRoutes ManualBomQuantityHarness = new ServiceEndpointRoutes("ManualBomQuantity/Harness");
        #endregion
        #region MidWireComponent
        public static readonly ServiceEndpointRoutes MidWireComponent = new ServiceEndpointRoutes("MidWireComponent");
        public static readonly ServiceEndpointRoutes MidWireComponentHarness = new ServiceEndpointRoutes("MidWireComponent/Harness");
        #endregion
        #region ModuleChildDetail
        public static readonly ServiceEndpointRoutes ModuleChildDetail = new ServiceEndpointRoutes("ModuleChildDetail");
        public static readonly ServiceEndpointRoutes ModuleChildDetailHarness = new ServiceEndpointRoutes("ModuleChildDetail/Harness");
        #endregion
        #region ModuleCompatibility
        public static readonly ServiceEndpointRoutes ModuleCompatibility = new ServiceEndpointRoutes("ModuleCompatibility");
        public static readonly ServiceEndpointRoutes ModuleCompatibilityHarness = new ServiceEndpointRoutes("ModuleCompatibility/Harness");
        #endregion
        #region MulticoreSpecification
        public static readonly ServiceEndpointRoutes MulticoreSpecification = new ServiceEndpointRoutes("MulticoreSpecification");
        public static readonly ServiceEndpointRoutes MulticoreSpecificationHarness = new ServiceEndpointRoutes("MulticoreSpecification/Harness");
        #endregion
        #region PinMapping
        public static readonly ServiceEndpointRoutes PinMapping = new ServiceEndpointRoutes("PinMapping");
        public static readonly ServiceEndpointRoutes PinMappingHarness = new ServiceEndpointRoutes("PinMapping/Harness");
        #endregion
        #region Scope
        public static readonly ServiceEndpointRoutes Scope = new ServiceEndpointRoutes("Scope");
        #endregion
        #region WireMulticoreMarker
        public static readonly ServiceEndpointRoutes WireMulticoreMarker = new ServiceEndpointRoutes("WireMulticoreMarker");
        public static readonly ServiceEndpointRoutes WireMulticoreMarkerHarness = new ServiceEndpointRoutes("WireMulticoreMarker/Harness");
        #endregion
        #region WireSpecification
        public static readonly ServiceEndpointRoutes WireSpecification = new ServiceEndpointRoutes("WireSpecification");
        public static readonly ServiceEndpointRoutes WireSpecificationHarness = new ServiceEndpointRoutes("WireSpecification/Harness");
        public static readonly ServiceEndpointRoutes WireSpecificationComponets = new ServiceEndpointRoutes("WireSpecification/Componets");
        #endregion
        #region WireThroughNode
        public static readonly ServiceEndpointRoutes WireThroughNode = new ServiceEndpointRoutes("WireThroughNode");
        public static readonly ServiceEndpointRoutes WireThroughNodeHarness = new ServiceEndpointRoutes("WireThroughNode/Harness");
        #endregion
        #endregion

        #region DsiAssociation
        #region BranchConfigurationBend
        public static readonly ServiceEndpointRoutes BranchConfigurationBend = new ServiceEndpointRoutes("BranchConfigurationBend/BranchConfiguration");
        public static readonly ServiceEndpointRoutes BendBranchConfiguration = new ServiceEndpointRoutes("BranchConfigurationBend/Bend");
        public static readonly ServiceEndpointRoutes BranchConfigurationBendHarness = new ServiceEndpointRoutes("BranchConfigurationBend/Harness");
        #endregion
        #region CompositeDetailCircuitOption
        public static readonly ServiceEndpointRoutes CompositeDetailCircuitOption = new ServiceEndpointRoutes("CompositeDetailCircuitOption/CompositeDetail");
        public static readonly ServiceEndpointRoutes CircuitOptionCompositeDetail = new ServiceEndpointRoutes("CompositeDetailCircuitOption/CircuitOption");
        public static readonly ServiceEndpointRoutes CompositeDetailCircuitOptionHarness = new ServiceEndpointRoutes("CompositeDetailCircuitOption/Harness");
        #endregion
        #region HarnessScopeScope
        public static readonly ServiceEndpointRoutes HarnessScopeScope = new ServiceEndpointRoutes("HarnessScopeScope/HarnessScope");
        public static readonly ServiceEndpointRoutes ScopeHarnessScope = new ServiceEndpointRoutes("HarnessScopeScope/Scope");
        public static readonly ServiceEndpointRoutes HarnessScopeScopeHarness = new ServiceEndpointRoutes("HarnessScopeScope/Harness");
        #endregion
        #region PinMappingCavityMapping
        public static readonly ServiceEndpointRoutes PinMappingCavityMapping = new ServiceEndpointRoutes("PinMappingCavityMapping/PinMapping");
        public static readonly ServiceEndpointRoutes CavityMappingPinMapping = new ServiceEndpointRoutes("PinMappingCavityMapping/CavityMapping");
        public static readonly ServiceEndpointRoutes PinMappingCavityMappingHarness = new ServiceEndpointRoutes("PinMappingCavityMapping/Harness");
        #endregion
        #endregion

        #region AlternativeParts
        public static readonly ServiceEndpointRoutes AlternativePart = new ServiceEndpointRoutes("AlternativePart");
        public static readonly ServiceEndpointRoutes AlternativePartSearch = new ServiceEndpointRoutes("AlternativePart/Search");
        public static readonly ServiceEndpointRoutes AlternativePartColourCode = new ServiceEndpointRoutes("AlternativePartCons/PartCodeColour");
        public static readonly ServiceEndpointRoutes AlternativePartClass = new ServiceEndpointRoutes("AlternativePartCons/PartClass");
        public static readonly ServiceEndpointRoutes AlternativePartCategory = new ServiceEndpointRoutes("AlternativePartCons/CatergoryClass");
        public static readonly ServiceEndpointRoutes AlternativePartGroup = new ServiceEndpointRoutes("AlternativePartCons/GroupClass");
        public static readonly ServiceEndpointRoutes AlternativePartSumitomo = new ServiceEndpointRoutes("AlternativePart/PartsBySumitomoNo");
        public static readonly ServiceEndpointRoutes AlternativePartsMaterialGroups = new ServiceEndpointRoutes("AlternativePartCons/GetMaterialGroups");
        public static readonly ServiceEndpointRoutes AlternativePartsMaterialTypes = new ServiceEndpointRoutes("AlternativePartCons/GetMaterialTypes");
        public static readonly ServiceEndpointRoutes AlternativePartDataGet = new ServiceEndpointRoutes("AlternativePartsData/GetPartsData");
        public static readonly ServiceEndpointRoutes AlternativePartDataSave = new ServiceEndpointRoutes("AlternativePartsData/SavePartsData");
        public static readonly ServiceEndpointRoutes AlternativePartCAEAllBom = new ServiceEndpointRoutes("AlternativePartsCAE/GetAllBoM");
        public static readonly ServiceEndpointRoutes AlternativePartCAEGetBom = new ServiceEndpointRoutes("AlternativePartsCAE/GetBoMFile");
        public static readonly ServiceEndpointRoutes AlternativePartCAEPriceInfo = new ServiceEndpointRoutes("AlternativePartsCAE/FindPriceInfo");
        #endregion
    }
}
