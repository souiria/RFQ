using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDCurrencyModel
    {
        /// <summary>
        /// Gets or sets a string value for the Global CurrencyCode column.
        /// </summary>
        private string _currencyCode;
        [DataMember]
        public string CurrencyCode
        {
            get => _currencyCode;
            set =>  _currencyCode = value;
        }

        /// <summary>
        /// Gets or sets a string value for the Global CurrencyName column.
        /// </summary>
        private string _currencyName;
        [DataMember]
        public string CurrencyName
        {
            get => _currencyName;
            set => _currencyName = value;
        }

        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }
    }

    [DataContract, Serializable]
    public class H1ToCPDCurrencyDataSyncModel: H1ToCPDCurrencyModel
    { 
        private string _error;
        [DataMember]
        public string Error
        {
            get => _error;
            set => _error = value;
        }
    }
}
