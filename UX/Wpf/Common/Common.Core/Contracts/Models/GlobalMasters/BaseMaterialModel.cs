using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class BaseMaterialModel
    {
        private string _materialNumber;
        [DataMember]     
          public string MaterialNumber
        {
            get => _materialNumber;
            set =>_materialNumber= value;
        }
        private string _materialName;
        [DataMember]      
        public string MaterialName
        {
            get => _materialName;
            set => _materialName= value;
        }
        private Guid _materialGuid = Guid.Empty;
        [DataMember]       
        public Guid MaterialGuid
        {
            get => _materialGuid;
            set => _materialGuid= value;
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => _isActive=value;
        }

    }
}
