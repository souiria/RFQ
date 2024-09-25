using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPA.Engineering
{
    [DataContract, Serializable]
    public class RaiseSampleNPAModel : BaseModel<Guid>
    {
        private bool? _isRowChecked = false;
        [NotMapped, DataMember]
        public bool? IsRowChecked
        {
            get => _isRowChecked;
            set => SetProperty(ref _isRowChecked, value);
        }

        private Guid _customerGuid;
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }

        private string _activeReason;
        [DataMember]
        public string ActiveReason
        {
            get => _activeReason;
            set => SetProperty(ref _activeReason, value);
        }

        private string _referenceNumber;
        [DataMember]
        [StringLength(20)]
        public string ReferenceNumber
        {
            get { return _referenceNumber; }
            set { SetProperty(ref _referenceNumber, value); }
        }

        private string _comments;
        [DataMember]
        public string Comments
        {
            get { return _comments; }
            set { SetProperty(ref _comments, value); }
        }

        private Guid _type;
        [DataMember]
        public Guid Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
        }

        private Guid _ppapLevelGuid;
        [DataMember]
        public Guid PPAPLevelGuid
        {
            get { return _ppapLevelGuid; }
            set { SetProperty(ref _ppapLevelGuid, value); }
        }

        private Guid _statusGuid;
        [DataMember]
        public Guid StatusGuid
        {
            get { return _statusGuid; }
            set { SetProperty(ref _statusGuid, value); }
        }

        private Guid _userGuid;
        [DataMember]
        public Guid UserGuid
        {
            get { return _userGuid; }
            set { SetProperty(ref _userGuid, value); }
        }

        private Guid _reason;
        [DataMember]
        public Guid Reason
        {
            get { return _reason; }
            set { SetProperty(ref _reason, value); }
        }

        private DateTime _date;
        [DataMember]
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private DateTime _Orderdate;
        [DataMember]
        public DateTime OrderDate
        {
            get { return _Orderdate; }
            set { SetProperty(ref _Orderdate, value); }
        }

        private Guid _OrderBy;
        [DataMember]
        public Guid OrderBy
        {
            get { return _OrderBy; }
            set { SetProperty(ref _OrderBy, value); }
        }

        private string _sumitomoNumber;
        [DataMember]
        [StringLength(26)]
        public string SumitomoNumber
        {
            get { return _sumitomoNumber; }
            set { SetProperty(ref _sumitomoNumber, value); }
        }

        private Guid _materialTypeGuid;
        [DataMember]
        public Guid MaterialTypeGuid
        {
            get { return _materialTypeGuid; }
            set { SetProperty(ref _materialTypeGuid, value); }
        }

        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get { return _supplierGuid; }
            set { SetProperty(ref _supplierGuid, value); }
        }

        private string _name;
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _fullDescription;
        [DataMember]
        public string FullDescription
        {
            get { return _fullDescription; }
            set { SetProperty(ref _fullDescription, value); }
        }

        private Guid _projectGuid;
        [DataMember]
        public Guid ProjectGuid
        {
            get { return _projectGuid; }
            set { SetProperty(ref _projectGuid, value); }
        }

        private string _supplierPartNumber;
        [DataMember]
        public string SupplierPartNumber
        {
            get { return _supplierPartNumber; }
            set { SetProperty(ref _supplierPartNumber, value); }
        }

        private string _assemblyNumber;
        [DataMember]
        public string AssemblyNumber
        {
            get { return _assemblyNumber; }
            set { SetProperty(ref _assemblyNumber, value); }
        }

        private string _customerPartNumber;
        [DataMember]
        public string CustomerPartNumber
        {
            get { return _customerPartNumber; }
            set { SetProperty(ref _customerPartNumber, value); }
        }

        private decimal _quantity;
        [DataMember]
        public decimal Quantity
        {
            get { return _quantity; }
            set { SetProperty(ref _quantity, value); }
        }

        private Guid _uom;
        [DataMember]
        public Guid UOMGuid
        {
            get { return _uom; }
            set { SetProperty(ref _uom, value); }
        }

        private decimal _totalQuantity;
        [DataMember]
        public decimal TotalQuantity
        {
            get { return _totalQuantity; }
            set { SetProperty(ref _totalQuantity, value); }
        }

        private decimal _cuAlWeight;
        [DataMember]
        public decimal CuAlWeight
        {
            get { return _cuAlWeight; }
            set { SetProperty(ref _cuAlWeight, value); }
        }

        private Guid _facilityGuid;
        [DataMember]
        public Guid Facility
        {
            get { return _facilityGuid; }
            set { SetProperty(ref _facilityGuid, value); }
        }

        private bool _developmentAssociatedPart; //AnyDocRequiredChecked
        [DataMember]
        public bool DevelopmentAssociatedPart
        {
            get { return _developmentAssociatedPart; }
            set { SetProperty(ref _developmentAssociatedPart, value); }
        }

        private string _engineerName;
        [DataMember]
        public string EngineerName
        {
            get { return _engineerName; }
            set { SetProperty(ref _engineerName, value); }
        }

        private decimal _quantityPerVehicle;
        [DataMember]
        public decimal QuantityPerVehicle
        {
            get { return _quantityPerVehicle; }
            set { SetProperty(ref _quantityPerVehicle, value); }
        }

        private DateTime _deliveryDate;
        [DataMember]
        public DateTime DeliveryDate
        {
            get { return _deliveryDate; }
            set { SetProperty(ref _deliveryDate, value); }
        }

        private DateTime _quotationDate;
        [DataMember]
        public DateTime QuotationDate
        {
            get { return _quotationDate; }
            set { SetProperty(ref _quotationDate, value); }
        }
    }
}
