using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDPOPriceTypeModel
    {
        private string _poPriceTypeCode;
        [DataMember]
        public string POPriceTypeCode
        {
            get => _poPriceTypeCode;
            set => _poPriceTypeCode = value;
        }

        private string _poPriceTypeDescription;
        [DataMember]
        public string POPriceTypeDescription
        {
            get => _poPriceTypeDescription;
            set =>  _poPriceTypeDescription = value;
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
    public class H1ToCPDPOPriceTypeDataSyncModel : H1ToCPDPOPriceTypeModel
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
