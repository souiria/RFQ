using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.NPA
{
    [DataContract, NotMapped, Serializable]
    public class NpaUploadForRfqResultModel : ExternalDataSourceModel<Guid>
    {
        private int _rowNumber;
        [DataMember, NotMapped]
        public int Rowno
        {
            get => _rowNumber;
            set => SetProperty(ref _rowNumber, value);
        }

        private DateTime? _raisedDate;
        [DataMember, NotMapped]
        public DateTime? Raised_Date
        {
            get => _raisedDate;
            set => SetProperty(ref _raisedDate, value);
        }

        private int _materialType;
        [DataMember, NotMapped]
        public int Material_Type
        {
            get => _materialType;
            set => SetProperty(ref _materialType, value);
        }

        private string _sumitomoNumber;
        [DataMember, NotMapped]
        public string Sumitomo_No
        {
            get => _sumitomoNumber;
            set => SetProperty(ref _sumitomoNumber, value);
        }

        private string _replacedPart;
        [DataMember, NotMapped]
        public string ReplacedPart
        {
            get => _replacedPart;
            set => SetProperty(ref _replacedPart, value);
        }

        private string _name;
        [DataMember, NotMapped]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _description;
        [DataMember, NotMapped]
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private string _supplierNumber;
        [DataMember, NotMapped]
        public string Supplier_No
        {
            get => _supplierNumber;
            set => SetProperty(ref _supplierNumber, value);
        }

        private string _suggestedSupplier;
        [DataMember, NotMapped]
        public string Suggested_Supplier
        {
            get => _suggestedSupplier;
            set => SetProperty(ref _suggestedSupplier, value);
        }

        private string _project;
        [DataMember, NotMapped]
        public string Project
        {
            get => _project;
            set => SetProperty(ref _project, value);
        }

        private string _customer;
        [DataMember, NotMapped]
        public string Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        private string _customerNumber;
        [DataMember, NotMapped]
        public string Customer_No
        {
            get => _customerNumber;
            set => SetProperty(ref _customerNumber, value);
        }

        private string _assemblyNumber;
        [DataMember, NotMapped]
        public string Assembly_No
        {
            get => _assemblyNumber;
            set => SetProperty(ref _assemblyNumber, value);
        }

        private string _unitOfMeasure;
        [DataMember, NotMapped]
        public string UOM
        {
            get => _unitOfMeasure;
            set => SetProperty(ref _unitOfMeasure, value);
        }

        private double? _quantity;
        [DataMember, NotMapped]
        public double? Qty_Per_Vehicle
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }

        private double? _copperWeight;
        [DataMember, NotMapped]
        public double? Copper_Weight
        {
            get => _copperWeight;
            set => SetProperty(ref _copperWeight, value);
        }

        private string _engineerComments;
        [DataMember, NotMapped]
        public string Eng_Comments
        {
            get => _engineerComments;
            set => SetProperty(ref _engineerComments, value);
        }

        private int _reason;
        [DataMember, NotMapped]
        public int Reason
        {
            get => _reason;
            set => SetProperty(ref _reason, value);
        }

        private string _reasonName;
        [DataMember, NotMapped]
        public string ReasonName
        {
            get => _reasonName;
            set => SetProperty(ref _reasonName, value);
        }

        private DateTime? _entDt;
        [DataMember, NotMapped]
        public DateTime? Ent_dt
        {
            get => _entDt;
            set => SetProperty(ref _entDt, value);
        }

        private string _userId;
        [DataMember, NotMapped]
        public string Userid
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private string _npaReferenceNumber;
        [DataMember, NotMapped]
        public string NPA_Ref_No
        {
            get => _npaReferenceNumber;
            set => SetProperty(ref _npaReferenceNumber, value);
        }

        private string _errorDescription;
        [DataMember, NotMapped]
        public string Err_Desc
        {
            get => _errorDescription;
            set => SetProperty(ref _errorDescription, value);
        }
    }
}
