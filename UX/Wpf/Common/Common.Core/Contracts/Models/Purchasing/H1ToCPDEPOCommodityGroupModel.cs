using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class H1ToCPDEPOCommodityGroupModel
    {
        private string _ePOCommodityGroupCode;
        [DataMember]
        [Required]
        [StringLength(4)]
        public string EPOCommodityGroupCode
        {
            get => _ePOCommodityGroupCode;
            set => _ePOCommodityGroupCode = value;
        }

        private CrudOperationType _crudOperationType;
        [DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => _crudOperationType = value;
        }
    }
    public class H1ToCPDEPOCommodityGroupDataSyncModel : H1ToCPDEPOCommodityGroupModel
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
