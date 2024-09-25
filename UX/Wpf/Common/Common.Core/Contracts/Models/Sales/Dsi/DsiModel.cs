using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract]
    [NotMapped]
    public class DsiModel : BaseModel<Guid>
    {
        [DataMember]
        public HarnessModel Harness { get; set; }
        [DataMember]
        public List<CompositeDetailModel> CompositeDetailList { get; set; }
        [DataMember]
        public List<BranchConfigurationModel> BranchConfigurationList { get; set; }
        [DataMember]
        public List<WireSpecificationModel> WireSpecificationList { get; set; }
        [DataMember]
        public List<ComponentModel> ComponentList { get; set; }
        [DataMember]
        public List<BranchInsulationModel> BranchInsulationList { get; set; }
        [DataMember]
        public List<CentreStripModel> CentreStripList { get; set; }
        [DataMember]
        public List<MulticoreSpecificationModel> MulticoreSpecificationList { get; set; }
        [DataMember]
        public List<ModuleChildDetailModel> ModuleChildDetailList { get; set; }
        [DataMember]
        public List<ModuleCompatibilityModel> ModuleCompatibilityList { get; set; }
        [DataMember]
        public List<ManualBomQuantityModel> ManualBomQuantityList { get; set; }
        [DataMember]
        public List<CompositeOptionModel> CompositeOptionList { get; set; }
        [DataMember]
        public List<WireThroughNodeModel> WireThroughNodeList { get; set; }
        [DataMember]
        public List<BranchInsulationThroughNodeModel> BranchInsulationThroughNodeList { get; set; }
        [DataMember]
        public List<MidWireComponentModel> MidWireComponentList { get; set; }
        [DataMember]
        public List<WireMulticoreMarkerModel> WireMulticoreMarkerList { get; set; }
        [DataMember]
        public List<PinMappingModel> PinMappingList { get; set; }
        [DataMember]
        public List<HarnessScopeModel> HarnessScopeList { get; set; }
    }
}
