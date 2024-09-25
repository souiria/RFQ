using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.ETL.NPA;
using Common.Core.Contracts.Models.NPR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    [DataContract, Serializable]
    [KnownType(typeof(RFQPartModel))]
    public class RFQPartModel : BaseModel<Guid>
    {
        public RFQPartModel() { }

        public RFQPartModel(RFQPartModel p)
        {
            RFQId = p.RFQId;
            GroupedPartId = p.GroupedPartId;
            MatchedPart = p.MatchedPart;
            Currency = p.Currency;
            Price = p.Price;
            UnitOfMeasure = p.UnitOfMeasure;
            Quantity = p.Quantity;
            DerivativeName = p.DerivativeName;
            HarnessName = p.HarnessName;
            IsNPARaised = p.IsNPARaised;
            NPARaisedDate = p.NPARaisedDate;
            NPAReferenceNumber = p.NPAReferenceNumber;
            NPASupplier = p.NPASupplier;
            MatchedOn = p.MatchedOn;
            SumitomoNumber = p.SumitomoNumber;
            CustomerNumber = p.CustomerNumber;
            SupplierNumber = p.SupplierNumber;
            NPAUnitOfMeasure = p.NPAUnitOfMeasure;
            NPAStatus = p.NPAStatus;
            MaterialType = p.MaterialType;
            IsDummyPart = p.IsDummyPart;
            OriginalPart = p.OriginalPart;
            IsExactMatch = p.IsExactMatch;
            IsResultFound = p.IsResultFound;
            IsCPDPrice = p.IsCPDPrice;
            Children = p.Children;
        }

        private Guid _rfqId;
        [DataMember]
        public Guid RFQId
        {
            get => _rfqId;
            set => SetProperty(ref _rfqId, value);
        }

        private Guid _groupedPartId;
        [DataMember]
        public Guid GroupedPartId
        {
            get => _groupedPartId;
            set => SetProperty(ref _groupedPartId, value);
        }

        private string _matchedPart;
        [DataMember]
        public string MatchedPart
        {
            get => _matchedPart;
            set => SetProperty(ref _matchedPart, value);
        }

        private string _currency;
        [DataMember]
        public string Currency
        {
            get => _currency;
            set => SetProperty(ref _currency, value);
        }

        private double? _price;
        [DataMember]
        public double? Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private string _unitOfMeasure;
        [DataMember]
        public string UnitOfMeasure
        {
            get => _unitOfMeasure;
            set => SetProperty(ref _unitOfMeasure, value);
        }

        private double _quantity;
        [DataMember]
        public double Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        private string _derivativeName;
        [DataMember]
        public string DerivativeName
        {
            get => _derivativeName;
            set => SetProperty(ref _derivativeName, value);
        }

        private Guid _derivativeId;
        [DataMember]
        public Guid DerivativeId
        {
            get => _derivativeId;
            set => SetProperty(ref _derivativeId, value);
        }

        private string _harnessName;
        [DataMember]
        public string HarnessName
        {
            get => _harnessName;
            set => SetProperty(ref _harnessName, value);
        }

        private bool _isNPARaised;
        [DataMember]
        public bool IsNPARaised
        {
            get => _isNPARaised;
            set => SetProperty(ref _isNPARaised, value);
        }

        private DateTime? _npaRaisedDate;
        [DataMember]
        public DateTime? NPARaisedDate
        {
            get => _npaRaisedDate;
            set => SetProperty(ref _npaRaisedDate, value);
        }

        private string _npaReferenceNumber;
        [DataMember]
        public string NPAReferenceNumber
        {
            get => _npaReferenceNumber;
            set => SetProperty(ref _npaReferenceNumber, value);
        }

        private NPASupplierModel _npaSupplier;
        [DataMember]
        public NPASupplierModel NPASupplier
        {
            get => _npaSupplier;
            set => SetProperty(ref _npaSupplier, value);
        }

        private string _matchedOn;
        [DataMember]
        public string MatchedOn
        {
            get => _matchedOn;
            set => SetProperty(ref _matchedOn, value);
        }

        private string _sumitomoNumber;
        [DataMember]
        public string SumitomoNumber
        {
            get => _sumitomoNumber;
            set => SetProperty(ref _sumitomoNumber, value);
        }

        private string _customerNumber;
        [DataMember]
        public string CustomerNumber
        {
            get => _customerNumber;
            set => SetProperty(ref _customerNumber, value);
        }

        private string _customer;
        [DataMember, NotMapped]
        public string Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        private string _supplierNumber;
        [DataMember]
        public string SupplierNumber
        {
            get => _supplierNumber;
            set => SetProperty(ref _supplierNumber, value);
        }

        private string _supplier;
        [DataMember, NotMapped]
        public string Supplier
        {
            get => _supplier;
            set => SetProperty(ref _supplier, value);
        }

        private NpaUomModel _npaUnitOfMeasure;
        [DataMember]
        public NpaUomModel NPAUnitOfMeasure
        {
            get => _npaUnitOfMeasure;
            set => SetProperty(ref _npaUnitOfMeasure, value);
        }

        private NewPartRequestModel _npaStatus;
        [DataMember, NotMapped]
        public NewPartRequestModel NPAStatus
        {
            get => _npaStatus;
            set => SetProperty(ref _npaStatus, value);
        }

        [DataMember]
        public string MaterialType { get; set; }

        private bool _isDummyPart;
        [DataMember]
        public bool IsDummyPart
        {
            get => _isDummyPart;
            set => SetProperty(ref _isDummyPart, value);
        }

        private string _originalPart;
        [DataMember, NotMapped]
        public string OriginalPart
        {
            get => _originalPart;
            set => SetProperty(ref _originalPart, value);
        }

        private bool _isExactMatch;
        [DataMember, NotMapped]
        public bool IsExactMatch
        {
            get => _isExactMatch;
            set => SetProperty(ref _isExactMatch, value);
        }

        private bool _isResultFound;
        [DataMember, NotMapped]
        public bool IsResultFound
        {
            get => _isResultFound;
            set => SetProperty(ref _isResultFound, value);
        }

        private bool _isCPDPrice;
        [DataMember, NotMapped]
        public bool IsCPDPrice
        {
            get => _isCPDPrice;
            set => SetProperty(ref _isCPDPrice, value);
        }

        private bool _isEMACS;
        [DataMember, NotMapped]
        public bool IsEMACS
        {
            get => _isEMACS;
            set => SetProperty(ref _isEMACS, value);
        }

        private bool _isCPD;
        [DataMember, NotMapped]
        public bool IsCPD
        {
            get => _isCPD;
            set => SetProperty(ref _isCPD, value);
        }

        private bool _isNPA;
        [DataMember, NotMapped]
        public bool IsNPA
        {
            get => _isNPA;
            set => SetProperty(ref _isNPA, value);
        }

        private bool _isOld;
        [DataMember, NotMapped]
        public bool IsOld
        {
            get => _isOld;
            set => SetProperty(ref _isOld, value);
        }

        private int _colourFlag;
        [DataMember, NotMapped]
        public int ColourFlag
        {
            get => _colourFlag;
            set => SetProperty(ref _colourFlag, value);
        }

        [DataMember, NotMapped]
        public IEnumerable<RFQPartSearchProcedureModel> Children { get; set; }

        [DataMember, NotMapped]
        public IEnumerable<HarnessOneRFQPartModel> H1Children { get; set; }
    }
}