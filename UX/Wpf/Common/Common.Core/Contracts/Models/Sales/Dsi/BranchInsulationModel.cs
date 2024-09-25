using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("BranchInsulation")]
    public class BranchInsulationModel : BaseModel<Guid>
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

        private string _pieceCode;
        [DataMember]
        public string PieceCode
        {
            get => _pieceCode;
            set => SetProperty(ref _pieceCode, value);
        }

        private string _insulationCode;
        [DataMember]
        public string InsulationCode
        {
            get => _insulationCode;
            set => SetProperty(ref _insulationCode, value);
        }

        private double _diameter;
        [DataMember]
        public double Diameter
        {
            get => _diameter;
            set => SetProperty(ref _diameter, value);
        }

        private Guid? _circuitOptionID;
        [DataMember]
        public Guid? CircuitOptionID
        {
            get => _circuitOptionID;
            set => SetProperty(ref _circuitOptionID, value);
        }

        private string _insulationNote;
        [DataMember]
        public string InsulationNote
        {
            get => _insulationNote;
            set => SetProperty(ref _insulationNote, value);
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

        private string _calculationMethod;
        [DataMember]
        public string CalculationMethod
        {
            get => _calculationMethod;
            set => SetProperty(ref _calculationMethod, value);
        }

        private double _manualAmount;
        [DataMember]
        public double ManualAmount
        {
            get => _manualAmount;
            set => SetProperty(ref _manualAmount, value);
        }

        private string _splitValue;
        [DataMember]
        public string SplitValue
        {
            get => _splitValue;
            set => SetProperty(ref _splitValue, value);
        }

        private double _joinNumber;
        [DataMember]
        public double JoinNumber
        {
            get => _joinNumber;
            set => SetProperty(ref _joinNumber, value);
        }

        private double _assemblyItemNumber;
        [DataMember]
        public double AssemblyItemNumber
        {
            get => _assemblyItemNumber;
            set => SetProperty(ref _assemblyItemNumber, value);
        }

        private double _layer;
        [DataMember]
        public double Layer
        {
            get => _layer;
            set => SetProperty(ref _layer, value);
        }

        private string _insulationType;
        [DataMember]
        public string InsulationType
        {
            get => _insulationType;
            set => SetProperty(ref _insulationType, value);
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

        private string _colour;
        [DataMember]
        public string Colour
        {
            get => _colour;
            set => SetProperty(ref _colour, value);
        }

        private string _type;
        [DataMember]
        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        private string _material;
        [DataMember]
        public string Material
        {
            get => _material;
            set => SetProperty(ref _material, value);
        }

        private double _wallThickness;
        [DataMember]
        public double WallThickness
        {
            get => _wallThickness;
            set => SetProperty(ref _wallThickness, value);
        }

        private double _numberOfTurns;
        [DataMember]
        public double NumberOfTurns
        {
            get => _numberOfTurns;
            set => SetProperty(ref _numberOfTurns, value);
        }

        private double _turnsPerBreakout;
        [DataMember]
        public double TurnsPerBreakout
        {
            get => _turnsPerBreakout;
            set => SetProperty(ref _turnsPerBreakout, value);
        }

        private double _turnsPerBranch;
        [DataMember]
        public double TurnsPerBranch
        {
            get => _turnsPerBranch;
            set => SetProperty(ref _turnsPerBranch, value);
        }

        private double _distanceBetweenItems;
        [DataMember]
        public double DistanceBetweenItems
        {
            get => _distanceBetweenItems;
            set => SetProperty(ref _distanceBetweenItems, value);
        }

        private double _longestDistance;
        [DataMember]
        public double LongestDistance
        {
            get => _longestDistance;
            set => SetProperty(ref _longestDistance, value);
        }

        private double _distanceFromConnector;
        [DataMember]
        public double DistanceFromConnector
        {
            get => _distanceFromConnector;
            set => SetProperty(ref _distanceFromConnector, value);
        }

        private string _tubeSelectionType;
        [DataMember]
        public string TubeSelectionType
        {
            get => _tubeSelectionType;
            set => SetProperty(ref _tubeSelectionType, value);
        }

        private double _tubeSelectionFactor;
        [DataMember]
        public double TubeSelectionFactor
        {
            get => _tubeSelectionFactor;
            set => SetProperty(ref _tubeSelectionFactor, value);
        }

        private double _cutBack;
        [DataMember]
        public double CutBack
        {
            get => _cutBack;
            set => SetProperty(ref _cutBack, value);
        }

        private bool _isConvoluted;
        [DataMember]
        public bool IsConvoluted
        {
            get => _isConvoluted;
            set => SetProperty(ref _isConvoluted, value);
        }

        private bool _isSlit;
        [DataMember]
        public bool IsSlit
        {
            get => _isSlit;
            set => SetProperty(ref _isSlit, value);
        }

        private string _moduleSpecificData;
        [DataMember]
        public string ModuleSpecificData
        {
            get => _moduleSpecificData;
            set => SetProperty(ref _moduleSpecificData, value);
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
    }
}
