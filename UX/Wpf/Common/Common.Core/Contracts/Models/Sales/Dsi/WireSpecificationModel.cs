using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("WireSpecification")]
    public class WireSpecificationModel : BaseModel<Guid>
    {
        private string _wireName;
        [DataMember]
        public string WireName
        {
            get => _wireName;
            set => SetProperty(ref _wireName, value);
        }

        private string _compositeOptionString;
        [DataMember]
        public string CompositeOptionString
        {
            get => _compositeOptionString;
            set => SetProperty(ref _compositeOptionString, value);
        }

        private string _wireType;
        [DataMember]
        public string WireType
        {
            get => _wireType;
            set => SetProperty(ref _wireType, value);
        }

        private string _colour;
        [DataMember]
        public string Colour
        {
            get => _colour;
            set => SetProperty(ref _colour, value);
        }

        private double _crossSectionalArea;
        [DataMember]
        public double CrossSectionalArea
        {
            get => _crossSectionalArea;
            set => SetProperty(ref _crossSectionalArea, value);
        }

        private string _material;
        [DataMember]
        public string Material
        {
            get => _material;
            set => SetProperty(ref _material, value);
        }

        private string _userModule;
        [DataMember]
        public string UserModule
        {
            get => _userModule;
            set => SetProperty(ref _userModule, value);
        }

        private string _multicoreName;
        [DataMember]
        public string MulticoreName
        {
            get => _multicoreName;
            set => SetProperty(ref _multicoreName, value);
        }

        private string _end1NodeName;
        [DataMember]
        public string End1NodeName
        {
            get => _end1NodeName;
            set => SetProperty(ref _end1NodeName, value);
        }

        private string _end1Route;
        [DataMember]
        public string End1Route
        {
            get => _end1Route;
            set => SetProperty(ref _end1Route, value);
        }

        private string _end1Cavity;
        [DataMember]
        public string End1Cavity
        {
            get => _end1Cavity;
            set => SetProperty(ref _end1Cavity, value);
        }

        private string _end1MaterialCode;
        [DataMember]
        public string End1MaterialCode
        {
            get => _end1MaterialCode;
            set => SetProperty(ref _end1MaterialCode, value);
        }

        private string _end2NodeName;
        [DataMember]
        public string End2NodeName
        {
            get => _end2NodeName;
            set => SetProperty(ref _end2NodeName, value);
        }

        private string _end2Route;
        [DataMember]
        public string End2Route
        {
            get => _end2Route;
            set => SetProperty(ref _end2Route, value);
        }

        private string _end2Cavity;
        [DataMember]
        public string End2Cavity
        {
            get => _end2Cavity;
            set => SetProperty(ref _end2Cavity, value);
        }

        private string _end2MaterialCode;
        [DataMember]
        public string End2MaterialCode
        {
            get => _end2MaterialCode;
            set => SetProperty(ref _end2MaterialCode, value);
        }

        private bool _isIncludedOnBom;
        [DataMember]
        public bool IsIncludedOnBom
        {
            get => _isIncludedOnBom;
            set => SetProperty(ref _isIncludedOnBom, value);
        }

        private bool _isIncludedOnChart;
        [DataMember]
        public bool IsIncludedOnChart
        {
            get => _isIncludedOnChart;
            set => SetProperty(ref _isIncludedOnChart, value);
        }

        private string _wireTag;
        [DataMember]
        public string WireTag
        {
            get => _wireTag;
            set => SetProperty(ref _wireTag, value);
        }

        private string _wireNote;
        [DataMember]
        public string WireNote
        {
            get => _wireNote;
            set => SetProperty(ref _wireNote, value);
        }

        private string _wireLengthChangeType;
        [DataMember]
        public string WireLengthChangeType
        {
            get => _wireLengthChangeType;
            set => SetProperty(ref _wireLengthChangeType, value);
        }

        private double _wireLengthChangeValue;
        [DataMember]
        public double WireLengthChangeValue
        {
            get => _wireLengthChangeValue;
            set => SetProperty(ref _wireLengthChangeValue, value);
        }

        private double _assemblyItemNumber;
        [DataMember]
        public double AssemblyItemNumber
        {
            get => _assemblyItemNumber;
            set => SetProperty(ref _assemblyItemNumber, value);
        }

        private string _multicoreOption;
        [DataMember]
        public string MulticoreOption
        {
            get => _multicoreOption;
            set => SetProperty(ref _multicoreOption, value);
        }

        private double _unmodifiedWireLength;
        [DataMember]
        public double UnmodifiedWireLength
        {
            get => _unmodifiedWireLength;
            set => SetProperty(ref _unmodifiedWireLength, value);
        }

        private double _modifiedWireLength;
        [DataMember]
        public double ModifiedWireLength
        {
            get => _modifiedWireLength;
            set => SetProperty(ref _modifiedWireLength, value);
        }

        private double _cutbackAtEnd1;
        [DataMember]
        public double CutbackAtEnd1
        {
            get => _cutbackAtEnd1;
            set => SetProperty(ref _cutbackAtEnd1, value);
        }

        private double _cutbackAtEnd2;
        [DataMember]
        public double CutbackAtEnd2
        {
            get => _cutbackAtEnd2;
            set => SetProperty(ref _cutbackAtEnd2, value);
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

        private string _signal;
        [DataMember]
        public string Signal
        {
            get => _signal;
            set => SetProperty(ref _signal, value);
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
