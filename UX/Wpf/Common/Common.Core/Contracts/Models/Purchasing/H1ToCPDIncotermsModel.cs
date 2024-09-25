using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDIncotermsModel
    {
        private string _incotermCode;
        [DataMember]
        [Required]
        [StringLength(4)]
        public string IncotermCode
        {
            get => _incotermCode;
            set => _incotermCode = value;
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
    public class H1ToCPDIncotermsDataSyncModel : H1ToCPDIncotermsModel
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
