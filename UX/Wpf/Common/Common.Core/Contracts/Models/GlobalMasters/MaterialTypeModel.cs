using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class MaterialTypeModel : BaseModel<Guid>
    {
       
        private string _materialTypeCode;
        [DataMember]
        [StringLength(1)]
        public string MaterialTypeCode
        {
            get => _materialTypeCode;
            set => SetProperty(ref _materialTypeCode, value);
        }

        private string _materialTypeDescription = null;
        [DataMember]
        [StringLength(50)]
        public string MaterialTypeDescription
        {
            get => _materialTypeDescription;
            set => SetProperty(ref _materialTypeDescription, value);
        }

        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
