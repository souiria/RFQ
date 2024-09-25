using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class MaterialInventorySearchModel
    {
        private Guid _materialTypeGuid;
        [DataMember]
        public Guid MaterialTypeGuid
        {
            get => _materialTypeGuid;
            set => _materialTypeGuid = value;
        }
        private string _materialType = string.Empty;
        [DataMember]
        public string MaterialType
        {
            get => _materialType;
            set => _materialType = value;
        }
        private Guid _materialFromGuid;
        [DataMember]
        public Guid MaterialFromGuid
        {
            get => _materialFromGuid;
            set => _materialFromGuid = value;
        }
        private string _materialNumberFrom = string.Empty;
        [DataMember]
        public string MaterialNumberFrom
        {
            get => _materialNumberFrom;
            set => _materialNumberFrom = value;
        }
        private Guid _materialToGuid;
        [DataMember]
        public Guid MaterialToGuid
        {
            get => _materialToGuid;
            set => _materialToGuid = value;
        }
        private string _materialNumberTo = string.Empty;
        [DataMember]
        public string MaterialNumberTo
        {
            get => _materialNumberTo;
            set => _materialNumberTo = value;
        }
        private string _businessUnit = string.Empty;
        [DataMember]
        public string BusinessUnit
        {
            get => _businessUnit;
            set => _businessUnit = value;
        }
        private Guid _businessUnitGuid;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => _businessUnitGuid = value;
        }
    }
}
