using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("MidWireComponent")]
    public class MidWireComponentModel : BaseModel<Guid>
    {
        private string _nodeName;
        [DataMember]
        public string NodeName
        {
            get => _nodeName;
            set => SetProperty(ref _nodeName, value);
        }

        private string _route;
        [DataMember]
        public string Route
        {
            get => _route;
            set => SetProperty(ref _route, value);
        }

        private string _wireName;
        [DataMember]
        public string WireName
        {
            get => _wireName;
            set => SetProperty(ref _wireName, value);
        }

        private string _option;
        [DataMember]
        public string Option
        {
            get => _option;
            set => SetProperty(ref _option, value);
        }

        private string _midWireOption;
        [DataMember]
        public string MidWireOption
        {
            get => _midWireOption;
            set => SetProperty(ref _midWireOption, value);
        }

        private string _cavity;
        [DataMember]
        public string Cavity
        {
            get => _cavity;
            set => SetProperty(ref _cavity, value);
        }

        private double _throughOrder;
        [DataMember]
        public double ThroughOrder
        {
            get => _throughOrder;
            set => SetProperty(ref _throughOrder, value);
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
