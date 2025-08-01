namespace SharedModels.DocumentConverter.DSI.Aggregates
{
    public class DsiAggregate
    {
        public HarnessDto? Harness
        { get; set; }
        public IEnumerable<CompositeDetailDto>? CompositeDetailList
        { get; set; }
        public IEnumerable<BranchConfigurationDto>? BranchConfigurationList
        { get; set; }
        public IEnumerable<WireSpecificationDto>? WireSpecificationList
        { get; set; }
        public IEnumerable<ComponentDto>? ComponentList
        { get; set; }
        public IEnumerable<BranchInsulationDto>? BranchInsulationList
        { get; set; }
        public IEnumerable<CentreStripDto>? CentreStripList
        { get; set; }
        public IEnumerable<MulticoreSpecificationDto>? MulticoreSpecificationList
        { get; set; }
        public IEnumerable<ModuleChildDetailDto>? ModuleChildDetailList
        { get; set; }
        public IEnumerable<ModuleCompatibilityDto>? ModuleCompatibilityList
        { get; set; }
        public IEnumerable<ManualBomQuantityDto>? ManualBomQuantityList
        { get; set; }
        public IEnumerable<CompositeOptionDto>? CompositeOptionList
        { get; set; }
        public IEnumerable<WireThroughNodeDto>? WireThroughNodeList
        { get; set; }
        public IEnumerable<BranchInsulationThroughNodeDto>? BranchInsulationThroughNodeList
        { get; set; }
        public IEnumerable<MidWireComponentDto>? MidWireComponentList
        { get; set; }
        public IEnumerable<WireMulticoreMarkerDto>? WireMulticoreMarkerList
        { get; set; }
        public IEnumerable<PinMappingDto>? PinMappingList
        { get; set; }
        public IEnumerable<HarnessScopeDto>? HarnessScopeList
        { get; set; }
    }
}
