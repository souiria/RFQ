using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("BranchConfiguration")]
    public class BranchConfigurationModel : BaseModel<Guid>
    {
        private string _startNode;
        [DataMember]
        public string StartNode
        {
            get => _startNode;
            set => SetProperty(ref _startNode, value);
        }

        private string _startRoute;
        [DataMember]
        public string StartRoute
        {
            get => _startRoute;
            set => SetProperty(ref _startRoute, value);
        }

        private string _startCoordinates;
        [DataMember]
        public string StartCoordinates
        {
            get => _startCoordinates;
            set => SetProperty(ref _startCoordinates, value);
        }

        private string _endNode;
        [DataMember]
        public string EndNode
        {
            get => _endNode;
            set => SetProperty(ref _endNode, value);
        }

        private string _endRoute;
        [DataMember]
        public string EndRoute
        {
            get => _endRoute;
            set => SetProperty(ref _endRoute, value);
        }

        private string _endCoordinates;
        [DataMember]
        public string EndCoordinates
        {
            get => _endCoordinates;
            set => SetProperty(ref _endCoordinates, value);
        }

        private double _length;
        [DataMember]
        public double Length
        {
            get => _length;
            set => SetProperty(ref _length, value);
        }

        private Guid? _circuitOptionID;
        [DataMember]
        public Guid? CircuitOptionID
        {
            get => _circuitOptionID;
            set => SetProperty(ref _circuitOptionID, value);
        }

        private double _bundleDiameter;
        [DataMember]
        public double BundleDiameter
        {
            get => _bundleDiameter;
            set => SetProperty(ref _bundleDiameter, value);
        }

        private string _userModule;
        [DataMember]
        public string UserModule
        {
            get => _userModule;
            set => SetProperty(ref _userModule, value);
        }

        private string _assignedModule;
        [DataMember]
        public string AssignedModule
        {
            get => _assignedModule;
            set => SetProperty(ref _assignedModule, value);
        }

        private string _moduleFrom;
        [DataMember]
        public string ModuleFrom
        {
            get => _moduleFrom;
            set => SetProperty(ref _moduleFrom, value);
        }

        private string _bendString;
        [DataMember]
        public string BendString
        {
            get => _bendString;
            set => SetProperty(ref _bendString, value);
        }

        private Guid _harnessID;
        [DataMember]
        public Guid HarnessID
        {
            get => _harnessID;
            set => SetProperty(ref _harnessID, value);
        }

        private string _circuitOption;
        [DataMember, NotMapped]
        public string CircuitOption
        {
            get => _circuitOption;
            set => SetProperty(ref _circuitOption, value);
        }

        private string _bend;
        [DataMember, NotMapped]
        public string Bend
        {
            get => _bend;
            set => SetProperty(ref _bend, value);
        }
    }
}
