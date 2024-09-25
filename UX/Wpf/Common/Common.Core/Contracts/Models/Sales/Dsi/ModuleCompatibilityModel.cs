using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("ModuleCompatibility")]
    public class ModuleCompatibilityModel : BaseModel<Guid>
    {
        private string _moduleCode1;
        [DataMember]
        public string ModuleCode1
        {
            get => _moduleCode1;
            set => SetProperty(ref _moduleCode1, value);
        }

        private string _moduleCode2;
        [DataMember]
        public string ModuleCode2
        {
            get => _moduleCode2;
            set => SetProperty(ref _moduleCode2, value);
        }

        private string _relationship;
        [DataMember]
        public string Relationship
        {
            get => _relationship;
            set => SetProperty(ref _relationship, value);
        }

        private Guid _harnessID;
        [DataMember]
        public Guid HarnessID
        {
            get => _harnessID;
            set => SetProperty(ref _harnessID, value);
        }
    }
}
