using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("CentreStrip")]
    public class CentreStripModel : BaseModel<Guid>
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

        private double _stripLength;
        [DataMember]
        public double StripLength
        {
            get => _stripLength;
            set => SetProperty(ref _stripLength, value);
        }

        private string _lengthChangeType;
        [DataMember]
        public string LengthChangeType
        {
            get => _lengthChangeType;
            set => SetProperty(ref _lengthChangeType, value);
        }

        private double _lengthChangeValue;
        [DataMember]
        public double LengthChangeValue
        {
            get => _lengthChangeValue;
            set => SetProperty(ref _lengthChangeValue, value);
        }

        private string _option;
        [DataMember]
        public string Option
        {
            get => _option;
            set => SetProperty(ref _option, value);
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
