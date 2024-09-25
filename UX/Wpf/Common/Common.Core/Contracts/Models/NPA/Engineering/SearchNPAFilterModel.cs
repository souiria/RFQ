using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPA.Engineering
{
    [DataContract, Serializable]
    public class SearchNPAFilterModel : BaseModel<Guid>
    {
        private string _userId;
        [DataMember]
        public string UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private bool _myNPA;
        [DataMember]
        public bool MyNPA
        {
            get => _myNPA;
            set => SetProperty(ref _myNPA, value);
        }

        private string _projectCode;
        [DataMember]
        public string ProjectCode
        {
            get => _projectCode;
            set => SetProperty(ref _projectCode, value);
        }

        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get => _supplierCode;
            set => SetProperty(ref _supplierCode, value);
        }

        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }

        private string _npaStatusCode;
        [DataMember]
        public string NPAStatusCode
        {
            get => _npaStatusCode;
            set => SetProperty(ref _npaStatusCode, value);
        }

        private string _keyword;
        [DataMember]
        public string Keyword
        {
            get => _keyword;
            set => SetProperty(ref _keyword, value);
        }

        private string _subsidiary;
        [DataMember]
        public string Subsidiary
        {
            get => _subsidiary;
            set => SetProperty(ref _subsidiary, value);
        }

        private string _suggestedSupplierCode;
        [DataMember]
        public string SuggestedSupplierCode
        {
            get => _suggestedSupplierCode;
            set => SetProperty(ref _suggestedSupplierCode, value);
        }

        private string _buyerCode;
        [DataMember]
        public string BuyerCode
        {
            get => _buyerCode;
            set => SetProperty(ref _buyerCode, value);
        }
        

        private string _facility;
        [DataMember]
        public string Facility
        {
            get => _facility;
            set => SetProperty(ref _facility, value);
        }

        private string _searchType;
        [DataMember]
        public string SearchType
        {
            get => _searchType;
            set => SetProperty(ref _searchType, value);
        }
    }
}
