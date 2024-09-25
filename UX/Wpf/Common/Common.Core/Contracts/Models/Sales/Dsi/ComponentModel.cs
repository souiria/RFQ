using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("Component")]
    public class ComponentModel : BaseModel<Guid>
    {
        private string _nodeName;
        [DataMember]
        public string NodeName
        {
            get => _nodeName;
            set => SetProperty(ref _nodeName, value);
        }

        private string _cavityName;
        [DataMember]
        public string CavityName
        {
            get => _cavityName;
            set => SetProperty(ref _cavityName, value);
        }

        private string _wireName;
        [DataMember]
        public string WireName
        {
            get => _wireName;
            set => SetProperty(ref _wireName, value);
        }

        private string _sequenceNumber;
        [DataMember]
        public string SequenceNumber
        {
            get => _sequenceNumber;
            set => SetProperty(ref _sequenceNumber, value);
        }

        private string _componentTypeCode1;
        [DataMember]
        public string ComponentTypeCode1
        {
            get => _componentTypeCode1;
            set => SetProperty(ref _componentTypeCode1, value);
        }

        private string _componentOption;
        [DataMember]
        public string ComponentOption
        {
            get => _componentOption;
            set => SetProperty(ref _componentOption, value);
        }

        private string _serviceFunction;
        [DataMember]
        public string ServiceFunction
        {
            get => _serviceFunction;
            set => SetProperty(ref _serviceFunction, value);
        }

        private string _route;
        [DataMember]
        public string Route
        {
            get => _route;
            set => SetProperty(ref _route, value);
        }

        private string _partNumber1;
        [DataMember]
        public string PartNumber1
        {
            get => _partNumber1;
            set => SetProperty(ref _partNumber1, value);
        }

        private string _partNumber2;
        [DataMember]
        public string PartNumber2
        {
            get => _partNumber2;
            set => SetProperty(ref _partNumber2, value);
        }

        private string _partNumber3;
        [DataMember]
        public string PartNumber3
        {
            get => _partNumber3;
            set => SetProperty(ref _partNumber3, value);
        }

        private double _quantity;
        [DataMember]
        public double Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        private double _crossSectionalArea;
        [DataMember]
        public double CrossSectionalArea
        {
            get => _crossSectionalArea;
            set => SetProperty(ref _crossSectionalArea, value);
        }

        private bool _isSelectTerminal;
        [DataMember]
        public bool IsSelectTerminal
        {
            get => _isSelectTerminal;
            set => SetProperty(ref _isSelectTerminal, value);
        }

        private bool _isSeal;
        [DataMember]
        public bool IsSeal
        {
            get => _isSeal;
            set => SetProperty(ref _isSeal, value);
        }

        private bool _isPlugged;
        [DataMember]
        public bool IsPlugged
        {
            get => _isPlugged;
            set => SetProperty(ref _isPlugged, value);
        }

        private string _blockNumber;
        [DataMember]
        public string BlockNumber
        {
            get => _blockNumber;
            set => SetProperty(ref _blockNumber, value);
        }

        private string _terminationMethod;
        [DataMember]
        public string TerminationMethod
        {
            get => _terminationMethod;
            set => SetProperty(ref _terminationMethod, value);
        }

        private string _materialCode;
        [DataMember]
        public string MaterialCode
        {
            get => _materialCode;
            set => SetProperty(ref _materialCode, value);
        }

        private string _componentTypeCode2;
        [DataMember]
        public string ComponentTypeCode2
        {
            get => _componentTypeCode2;
            set => SetProperty(ref _componentTypeCode2, value);
        }

        private string _insulationType;
        [DataMember]
        public string InsulationType
        {
            get => _insulationType;
            set => SetProperty(ref _insulationType, value);
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

        private string _splitValue;
        [DataMember]
        public string SplitValue
        {
            get => _splitValue;
            set => SetProperty(ref _splitValue, value);
        }

        private string _datum;
        [DataMember]
        public string Datum
        {
            get => _datum;
            set => SetProperty(ref _datum, value);
        }

        private double _assemblyItemNumber;
        [DataMember]
        public double AssemblyItemNumber
        {
            get => _assemblyItemNumber;
            set => SetProperty(ref _assemblyItemNumber, value);
        }

        private string _colourCode;
        [DataMember]
        public string ColourCode
        {
            get => _colourCode;
            set => SetProperty(ref _colourCode, value);
        }

        private double _numberOfCavities;
        [DataMember]
        public double NumberOfCavities
        {
            get => _numberOfCavities;
            set => SetProperty(ref _numberOfCavities, value);
        }

        private bool _isBackshell;
        [DataMember]
        public bool IsBackshell
        {
            get => _isBackshell;
            set => SetProperty(ref _isBackshell, value);
        }

        private string _wireOption;
        [DataMember]
        public string WireOption
        {
            get => _wireOption;
            set => SetProperty(ref _wireOption, value);
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
