using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public  class ETLMaterialNoXReferenceParamModel
    {
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => _materialGuid = value;
        }
        private string _materialno;
        [DataMember]
        public string MaterialNo
        {
            get => _materialno;
            set => _materialno = value;
        }       
        private Guid _supplierMaterialGuid;
        [DataMember]
        public Guid SupplierMaterialGuid
        {
            get => _supplierMaterialGuid;
            set => _supplierMaterialGuid = value;
        }
        private string _supplierMaterialNo;
        [DataMember]
        public string SupplierMaterialNo
        {
            get => _supplierMaterialNo;
            set => _supplierMaterialNo = value;
        }
        private string _strMode;
        [DataMember]
        public string StrMode
        {
            get => _strMode;
            set => _strMode = value;
        }
        private string _option;
        [DataMember]
        public string Option
        {
            get => _option;
            set => _option = value;
        }
    }
}
