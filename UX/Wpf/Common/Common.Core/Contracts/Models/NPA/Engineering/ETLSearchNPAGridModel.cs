using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPA.Engineering
{
    [DataContract, Serializable]
    public class ETLSearchNPAGridModel : BaseModel<Guid>
    {
        private string _referenceNumber;
        [DataMember]
        public string ReferenceNumber
        {
            get => _referenceNumber;
            set => SetProperty(ref _referenceNumber, value);
        }

        private string _npaType;
        [DataMember]
        public string NPAType
        {
            get => _npaType;
            set => SetProperty(ref _npaType, value);
        }

        private DateTime _raiseDate;
        [DataMember]
        public DateTime RaiseDate
        {
            get => _raiseDate;
            set => SetProperty(ref _raiseDate, value);
        }

        private string _raisedBy;
        [DataMember]
        public string RaisedBy
        {
            get => _raisedBy;
            set => SetProperty(ref _raisedBy, value);
        }

        private int _npaStatusCode;
        [DataMember]
        public int NPAStatusCode
        {
            get => _npaStatusCode;
            set => SetProperty(ref _npaStatusCode, value);
        }

        private string _sumitomoNumber;
        [DataMember]
        public string SumitomoNumber
        {
            get => _sumitomoNumber;
            set => SetProperty(ref _sumitomoNumber, value);
        }

        private string _projectCode;
        [DataMember]
        public string ProjectCode
        {
            get => _projectCode;
            set => SetProperty(ref _projectCode, value);
        }

        private string _actualSupplierCode;
        [DataMember]
        public string ActualSupplierCode
        {
            get => _actualSupplierCode;
            set => SetProperty(ref _actualSupplierCode, value);
        }

        private string _actualSupplierBuyerCode;
        [DataMember]
        public string ActualSupplierBuyerCode
        {
            get => _actualSupplierBuyerCode;
            set => SetProperty(ref _actualSupplierBuyerCode, value);
        }

        private string _suggestedSupplierCode;
        [DataMember]
        public string SuggestedSupplierCode
        {
            get => _suggestedSupplierCode;
            set => SetProperty(ref _suggestedSupplierCode, value);
        }

        private string _suggestedSupplierBuyerCode;
        [DataMember]
        public string SuggestedSupplierBuyerCode
        {
            get => _suggestedSupplierBuyerCode;
            set => SetProperty(ref _suggestedSupplierBuyerCode, value);
        }

        private string _replacementPartNumber;
        [DataMember]
        public string ReplacementPartNumber
        {
            get => _replacementPartNumber;
            set => SetProperty(ref _replacementPartNumber, value);
        }

        private string _supplierPartNumber;
        [DataMember]
        public string SupplierPartNumber
        {
            get => _supplierPartNumber;
            set => SetProperty(ref _supplierPartNumber, value);
        }

        private string _customerPartNumber;
        [DataMember]
        public string CustomerPartNumber
        {
            get => _customerPartNumber;
            set => SetProperty(ref _customerPartNumber, value);
        }

        private string _customerCode;
        [DataMember]
        public string CustomerCode
        {
            get => _customerCode;
            set => SetProperty(ref _customerCode, value);
        }

        private string _assemblyNumber;
        [DataMember]
        public string AssemblyNumber
        {
            get => _assemblyNumber;
            set => SetProperty(ref _assemblyNumber, value);
        }

        private string _facility;
        [DataMember]
        public string Facility
        {
            get => _facility;
            set => SetProperty(ref _facility, value);
        }
    }
}
