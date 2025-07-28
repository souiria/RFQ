namespace SharedModels.DocumentConverter.DSI
{
    public class DsiModel
    {
        public HarnessModel? Harness
        { get; set; }
        public IEnumerable<CompositeDetailModel>? CompositeDetailList
        { get; set; }
        public IEnumerable<BranchConfigurationModel>? BranchConfigurationList
        { get; set; }
        public IEnumerable<WireSpecificationModel>? WireSpecificationList
        { get; set; }
        public IEnumerable<ComponentModel>? ComponentList
        { get; set; }
        public IEnumerable<BranchInsulationModel>? BranchInsulationList
        { get; set; }
        public IEnumerable<CentreStripModel>? CentreStripList
        { get; set; }
        public IEnumerable<MulticoreSpecificationModel>? MulticoreSpecificationList
        { get; set; }
        public IEnumerable<ModuleChildDetailModel>? ModuleChildDetailList
        { get; set; }
        public IEnumerable<ModuleCompatibilityModel>? ModuleCompatibilityList
        { get; set; }
        public IEnumerable<ManualBomQuantityModel>? ManualBomQuantityList
        { get; set; }
        public IEnumerable<CompositeOptionModel>? CompositeOptionList
        { get; set; }
        public IEnumerable<WireThroughNodeModel>? WireThroughNodeList
        { get; set; }
        public IEnumerable<BranchInsulationThroughNodeModel>? BranchInsulationThroughNodeList
        { get; set; }
        public IEnumerable<MidWireComponentModel>? MidWireComponentList
        { get; set; }
        public IEnumerable<WireMulticoreMarkerModel>? WireMulticoreMarkerList
        { get; set; }
        public IEnumerable<PinMappingModel>? PinMappingList
        { get; set; }
        public IEnumerable<HarnessScopeModel>? HarnessScopeList
        { get; set; }
    }
}
