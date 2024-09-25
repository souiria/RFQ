using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.NPA
{
    [DataContract, Serializable]
    public class VWMassNPAFromRFQModel : ExternalDataSourceModel<Guid>
    {
        private string _deleteStatus;
        [DataMember]
        public string DeleteStatus
        {
            get => _deleteStatus;
            set => SetProperty(ref _deleteStatus, value);
        }

        private string _refNo;
        [DataMember, Key, Column("ref_no", Order = 0)]
        public string RefNo
        {
            get => _refNo;
            set => SetProperty(ref _refNo, value);
        }

        private string _suggestedSupplierCode;
        [DataMember, Column("Suggested_supplier_code")]
        public string SuggestedSupplierCode
        {
            get => _suggestedSupplierCode;
            set => SetProperty(ref _suggestedSupplierCode, value);
        }

        private string _actualSupplier;
        [DataMember, Column("actual_supplier")]
        public string ActualSupplier
        {
            get => _actualSupplier;
            set => SetProperty(ref _actualSupplier, value);
        }

        private string _projectCode;
        [DataMember, Column("project_code", Order = 1)]
        public string ProjectCode
        {
            get => _projectCode;
            set => SetProperty(ref _projectCode, value);
        }

        private string _customerCode;
        [DataMember, Column("Customer_Code")]
        public string CustomerCode
        {
            get => _customerCode;
            set => SetProperty(ref _customerCode, value);
        }

        private string _users;
        [DataMember, Column("Users")]
        public string Users
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }

        private string _supplierBuyer;
        [DataMember, Column("supplier_buyer")]
        public string SupplierBuyer
        {
            get => _supplierBuyer;
            set => SetProperty(ref _supplierBuyer, value);
        }

        private string _sumitomoNo;
        [DataMember, Column("sumitomo_no")]
        public string SumitomoNo
        {
            get => _sumitomoNo;
            set => SetProperty(ref _sumitomoNo, value);
        }

        private string _supplierNo;
        [DataMember, Column("supplier_no")]
        public string SupplierNo
        {
            get => _supplierNo;
            set => SetProperty(ref _supplierNo, value);
        }

        private string _status;
        [DataMember, Column("status")]
        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        private string _type;
        [DataMember, Column("Type")]
        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        private double? _qtyPerVehicle;
        [DataMember, Column("qty_per_vehicle")]
        public double? QtyPerVehicle
        {
            get => _qtyPerVehicle;
            set => SetProperty(ref _qtyPerVehicle, value);
        }

        private DateTime? _quotationDate;
        [DataMember, Column("quotation_date")]
        public DateTime? QuotationDate
        {
            get => _quotationDate;
            set => SetProperty(ref _quotationDate, value);
        }

        private double? _price;
        [DataMember, Column("price")]
        public double? Price
        {
            get => _price;
            set => SetProperty(ref _price, value);
        }

        private int? _stdLeadTime;
        [DataMember, Column("std_lead_time")]
        public int? StdLeadTime
        {
            get => _stdLeadTime;
            set => SetProperty(ref _stdLeadTime, value);
        }

        private int? _bagQty;
        [DataMember, Column("bag_qty")]
        public int? BagQty
        {
            get => _bagQty;
            set => SetProperty(ref _bagQty, value);
        }

        private string _originCountry;
        [DataMember, Column("origin_country")]
        public string OriginCountry
        {
            get => _originCountry;
            set => SetProperty(ref _originCountry, value);
        }

        private double? _copperWeight;
        [DataMember, Column("copper_weight")]
        public double? CopperWeight
        {
            get => _copperWeight;
            set => SetProperty(ref _copperWeight, value);
        }

        private int? _packFactor;
        [DataMember, Column("pack_factor")]
        public int? PackFactor
        {
            get => _packFactor;
            set => SetProperty(ref _packFactor, value);
        }

        private decimal? _copperRate;
        [DataMember, Column("copper_rate")]
        public decimal? CopperRate
        {
            get => _copperRate;
            set => SetProperty(ref _copperRate, value);
        }

        private decimal? _stdBoxLength;
        [DataMember, Column("std_box_length")]
        public decimal? StdBoxLength
        {
            get => _stdBoxLength;
            set => SetProperty(ref _stdBoxLength, value);
        }

        private decimal? _height;
        [DataMember, Column("height")]
        public decimal? Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        private string _uom;
        [DataMember, Column("uom")]
        public string UOM
        {
            get => _uom;
            set => SetProperty(ref _uom, value);
        }

        private string _purchaseuom;
        [DataMember, Column("purchase_uom")]
        public string PurchaseUOM
        {
            get => _purchaseuom;
            set => SetProperty(ref _purchaseuom, value);
        }
    }
}
