using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    [DataContract, Serializable]
    public class H1FieldMasterModel: BaseModel<Guid>
    {
        private string _fieldName;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string FieldName
        {
            get => _fieldName;
            set => SetProperty(ref _fieldName, value);
        }

        private string _fieldDescription;
        [DataMember]
        [Required]
        [StringLength(50)]
        public string FieldDescription
        {
            get => _fieldDescription;
            set => SetProperty(ref _fieldDescription, value);
        }

        private string _variableName;
        [Required]
        [DataMember]
        public string VariableName
        {
            get => _variableName;
            set => SetProperty(ref _variableName, value);
        }
    }
}
