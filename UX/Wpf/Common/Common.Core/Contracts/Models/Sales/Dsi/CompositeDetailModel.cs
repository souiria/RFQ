using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("CompositeDetail")]
    public class CompositeDetailModel : BaseModel<Guid>
    {
        private string _harnessName1;
        [DataMember]
        public string HarnessName1
        {
            get => _harnessName1;
            set => SetProperty(ref _harnessName1, value);
        }

        private string _similarHarnessName1;
        [DataMember]
        public string SimilarHarnessName1
        {
            get => _similarHarnessName1;
            set => SetProperty(ref _similarHarnessName1, value);
        }

        private string _harnessIssue1;
        [DataMember]
        public string HarnessIssue1
        {
            get => _harnessIssue1;
            set => SetProperty(ref _harnessIssue1, value);
        }

        private string _similarHarnessIssue1;
        [DataMember]
        public string SimilarHarnessIssue1
        {
            get => _similarHarnessIssue1;
            set => SetProperty(ref _similarHarnessIssue1, value);
        }

        private DateTime _harnessDate1;
        [DataMember]
        public DateTime HarnessDate1
        {
            get => _harnessDate1 != null ? _harnessDate1 : DateTime.MinValue;
            set => SetProperty(ref _harnessDate1, value);
        }

        private string _harnessName2;
        [DataMember]
        public string HarnessName2
        {
            get => _harnessName2;
            set => SetProperty(ref _harnessName2, value);
        }

        private string _similarHarnessName2;
        [DataMember]
        public string SimilarHarnessName2
        {
            get => _similarHarnessName2;
            set => SetProperty(ref _similarHarnessName2, value);
        }

        private string _harnessIssue2;
        [DataMember]
        public string HarnessIssue2
        {
            get => _harnessIssue2;
            set => SetProperty(ref _harnessIssue2, value);
        }

        private string _similarHarnessIssue2;
        [DataMember]
        public string SimilarHarnessIssue2
        {
            get => _similarHarnessIssue2;
            set => SetProperty(ref _similarHarnessIssue2, value);
        }

        private DateTime _harnessDate2;
        [DataMember]
        public DateTime HarnessDate2
        {
            get => _harnessDate2 != null ? _harnessDate2 : DateTime.MinValue;
            set => SetProperty(ref _harnessDate2, value);
        }

        private string _customer;
        [DataMember]
        public string Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        private string _site;
        [DataMember]
        public string Site
        {
            get => _site;
            set => SetProperty(ref _site, value);
        }

        private string _range;
        [DataMember]
        public string Range
        {
            get => _range;
            set => SetProperty(ref _range, value);
        }

        private double _boardLength;
        [DataMember]
        public double BoardLength
        {
            get => _boardLength;
            set => SetProperty(ref _boardLength, value);
        }

        private double _boardWidth;
        [DataMember]
        public double BoardWidth
        {
            get => _boardWidth;
            set => SetProperty(ref _boardWidth, value);
        }

        private string _datum;
        [DataMember]
        public string Datum
        {
            get => _datum;
            set => SetProperty(ref _datum, value);
        }

        private string _userField1;
        [DataMember]
        public string UserField1
        {
            get => _userField1;
            set => SetProperty(ref _userField1, value);
        }

        private string _userField2;
        [DataMember]
        public string UserField2
        {
            get => _userField2;
            set => SetProperty(ref _userField2, value);
        }

        private string _userField3;
        [DataMember]
        public string UserField3
        {
            get => _userField3;
            set => SetProperty(ref _userField3, value);
        }

        private string _userField4;
        [DataMember]
        public string UserField4
        {
            get => _userField4;
            set => SetProperty(ref _userField4, value);
        }

        private string _userField5;
        [DataMember]
        public string UserField5
        {
            get => _userField5;
            set => SetProperty(ref _userField5, value);
        }

        private string _checker;
        [DataMember]
        public string Checker
        {
            get => _checker;
            set => SetProperty(ref _checker, value);
        }

        private string _inputter;
        [DataMember]
        public string Inputter
        {
            get => _inputter;
            set => SetProperty(ref _inputter, value);
        }

        private string _draftedBy;
        [DataMember]
        public string DraftedBy
        {
            get => _draftedBy;
            set => SetProperty(ref _draftedBy, value);
        }

        private string _preparedBy;
        [DataMember]
        public string PreparedBy
        {
            get => _preparedBy;
            set => SetProperty(ref _preparedBy, value);
        }

        private string _type;
        [DataMember]
        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        private string _title;
        [DataMember]
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _engineSize;
        [DataMember]
        public string EngineSize
        {
            get => _engineSize;
            set => SetProperty(ref _engineSize, value);
        }

        private string _manufacturingCell;
        [DataMember]
        public string ManufacturingCell
        {
            get => _manufacturingCell;
            set => SetProperty(ref _manufacturingCell, value);
        }

        private string _trim;
        [DataMember]
        public string Trim
        {
            get => _trim;
            set => SetProperty(ref _trim, value);
        }

        private string _handDrive;
        [DataMember]
        public string HandDrive
        {
            get => _handDrive;
            set => SetProperty(ref _handDrive, value);
        }

        private string _tubeAddOnType;
        [DataMember]
        public string TubeAddOnType
        {
            get => _tubeAddOnType;
            set => SetProperty(ref _tubeAddOnType, value);
        }

        private double _tubeAddOnFactor;
        [DataMember]
        public double TubeAddOnFactor
        {
            get => _tubeAddOnFactor;
            set => SetProperty(ref _tubeAddOnFactor, value);
        }

        private bool _isManualTerminal;
        [DataMember]
        public bool IsManualTerminal
        {
            get => _isManualTerminal;
            set => SetProperty(ref _isManualTerminal, value);
        }

        private bool _isAllConnectorsSealed;
        [DataMember]
        public bool IsAllConnectorsSealed
        {
            get => _isAllConnectorsSealed;
            set => SetProperty(ref _isAllConnectorsSealed, value);
        }

        private string _alphaCode;
        [DataMember]
        public string AlphaCode
        {
            get => _alphaCode;
            set => SetProperty(ref _alphaCode, value);
        }

        private Guid _harnessID;
        [DataMember]
        public Guid HarnessID
        {
            get => _harnessID;
            set => SetProperty(ref _harnessID, value);
        }

        private string _circuitOption;
        [DataMember]
        public string CircuitOption
        {
            get => _circuitOption;
            set => SetProperty(ref _circuitOption, value);
        }
    }
}
