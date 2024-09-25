using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.EMACS
{
    [DataContract, Serializable]
    public class CustomerDataModel : ExternalDataSourceModel<long>
    {
        private string _customerCode;
        [DataMember, Key]
        public string CustomerCode
        {
            get => _customerCode;
            set => SetProperty(ref _customerCode, value);
        }

        private string _customer;
        [DataMember]
        public string Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        private string _customerGroup;
        [DataMember]
        public string CustomerGroup
        {
            get => _customerGroup;
            set => SetProperty(ref _customerGroup, value);
        }
    }
}
