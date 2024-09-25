using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("PinMapping")]
    public class PinMappingModel : BaseModel<Guid>
    {
        private string _node1;
        [DataMember]
        public string Node1
        {
            get => _node1;
            set => SetProperty(ref _node1, value);
        }

        private string _node2;
        [DataMember]
        public string Node2
        {
            get => _node2;
            set => SetProperty(ref _node2, value);
        }

        private string _harnessName1;
        [DataMember]
        public string HarnessName1
        {
            get => _harnessName1;
            set => SetProperty(ref _harnessName1, value);
        }

        private string _harnessIssue1;
        [DataMember]
        public string HarnessIssue1
        {
            get => _harnessIssue1;
            set => SetProperty(ref _harnessIssue1, value);
        }

        private string _harnessName2;
        [DataMember]
        public string HarnessName2
        {
            get => _harnessName2;
            set => SetProperty(ref _harnessName2, value);
        }

        private string _harnessIssue2;
        [DataMember]
        public string HarnessIssue2
        {
            get => _harnessIssue2;
            set => SetProperty(ref _harnessIssue2, value);
        }

        private string _separator;
        [DataMember]
        public string Separator
        {
            get => _separator;
            set => SetProperty(ref _separator, value);
        }

        private Guid _harnessID;
        [DataMember]
        public Guid HarnessID
        {
            get => _harnessID;
            set => SetProperty(ref _harnessID, value);
        }

        private string _cavityMapping1;
        [DataMember, NotMapped]
        public string CavityMapping1
        {
            get => _cavityMapping1;
            set => SetProperty(ref _cavityMapping1, value);
        }

        private string _cavityMapping2;
        [DataMember, NotMapped]
        public string CavityMapping2
        {
            get => _cavityMapping2;
            set => SetProperty(ref _cavityMapping2, value);
        }
    }
}
