using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.GlobalMasters.Project
{
    [DataContract]
    public class CombinedProjectModel : BaseModel<Guid>
    {
        public CombinedProjectModel(Guid id, ProjectModel project, PlatformModel platform, VehicleModel vehicle, ModelModel model, EventModel eventModel)
        {
            Id = id;
            Project = project;
            Platform = platform;
            Vehicle = vehicle;
            Model = model;
            Event = eventModel;
        }

        [DataMember]
        public ProjectModel Project { get; set; }

        [DataMember]
        public PlatformModel Platform { get; set; }

        [DataMember]
        public VehicleModel Vehicle { get; set; }

        [DataMember]
        public ModelModel Model { get; set; }

        [DataMember]
        public EventModel Event { get; set; }
    }
}
