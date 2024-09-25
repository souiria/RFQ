using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDPOPriceEffectiveDateTypeModel
    {
        private Guid _id = Guid.Empty;
        [DataMember]
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        private string _pOPriceEffectiveDateTypeDescription;
        [DataMember]
        [Required]
        [StringLength(4)]
        public string POPriceEffectiveDateTypeDescription
        {
            get => _pOPriceEffectiveDateTypeDescription;
            set => _pOPriceEffectiveDateTypeDescription = value;
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
    public class H1ToCPDPOPriceEffectiveDateTypeDataSyncModel: H1ToCPDPOPriceEffectiveDateTypeModel
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
