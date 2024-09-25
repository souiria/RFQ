using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("MulticoreSpecification")]
    public class MulticoreSpecificationModel : BaseModel<Guid>
    {
        private string _multicoreName;
        [DataMember]
        public string MulticoreName
        {
            get => _multicoreName;
            set => SetProperty(ref _multicoreName, value);
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

        private string _tag;
        [DataMember]
        public string Tag
        {
            get => _tag;
            set => SetProperty(ref _tag, value);
        }

        private string _note;
        [DataMember]
        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
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

        private string _outerSheathCutBackAtEnd1Type;
        [DataMember]
        public string OuterSheathCutBackAtEnd1Type
        {
            get => _outerSheathCutBackAtEnd1Type;
            set => SetProperty(ref _outerSheathCutBackAtEnd1Type, value);
        }

        private double _outerSheathCutBackAtEnd1Value;
        [DataMember]
        public double OuterSheathCutBackAtEnd1Value
        {
            get => _outerSheathCutBackAtEnd1Value;
            set => SetProperty(ref _outerSheathCutBackAtEnd1Value, value);
        }

        private string _outerSheathCutBackAtEnd2Type;
        [DataMember]
        public string OuterSheathCutBackAtEnd2Type
        {
            get => _outerSheathCutBackAtEnd2Type;
            set => SetProperty(ref _outerSheathCutBackAtEnd2Type, value);
        }

        private double _outerSheathCutBackAtEnd2Value;
        [DataMember]
        public double OuterSheathCutBackAtEnd2Value
        {
            get => _outerSheathCutBackAtEnd2Value;
            set => SetProperty(ref _outerSheathCutBackAtEnd2Value, value);
        }

        private string _colour;
        [DataMember]
        public string Colour
        {
            get => _colour;
            set => SetProperty(ref _colour, value);
        }

        private string _material;
        [DataMember]
        public string Material
        {
            get => _material;
            set => SetProperty(ref _material, value);
        }

        private string _specification;
        [DataMember]
        public string Specification
        {
            get => _specification;
            set => SetProperty(ref _specification, value);
        }

        private bool _isSheathed;
        [DataMember]
        public bool IsSheathed
        {
            get => _isSheathed;
            set => SetProperty(ref _isSheathed, value);
        }

        private string _userModule;
        [DataMember]
        public string UserModule
        {
            get => _userModule;
            set => SetProperty(ref _userModule, value);
        }

        private double _assemblyItemNumber;
        [DataMember]
        public double AssemblyItemNumber
        {
            get => _assemblyItemNumber;
            set => SetProperty(ref _assemblyItemNumber, value);
        }

        private string _parentMulticoreName;
        [DataMember]
        public string ParentMulticoreName
        {
            get => _parentMulticoreName;
            set => SetProperty(ref _parentMulticoreName, value);
        }

        private string _multicoreOption;
        [DataMember]
        public string MulticoreOption
        {
            get => _multicoreOption;
            set => SetProperty(ref _multicoreOption, value);
        }

        private string _parentMulticoreOption;
        [DataMember]
        public string ParentMulticoreOption
        {
            get => _parentMulticoreOption;
            set => SetProperty(ref _parentMulticoreOption, value);
        }

        private double _unmodifiedMulticoreLength;
        [DataMember]
        public double UnmodifiedMulticoreLength
        {
            get => _unmodifiedMulticoreLength;
            set => SetProperty(ref _unmodifiedMulticoreLength, value);
        }

        private double _modifiedMulticoreLength;
        [DataMember]
        public double ModifiedMulticoreLength
        {
            get => _modifiedMulticoreLength;
            set => SetProperty(ref _modifiedMulticoreLength, value);
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

        private Guid _harnessID;
        [DataMember]
        public Guid HarnessID
        {
            get => _harnessID;
            set => SetProperty(ref _harnessID, value);
        }
    }
}
