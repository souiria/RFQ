using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    [DataContract, Serializable]
    public class LanguageModel : BaseModel<Guid>
    {
        private string _language;
        [DataMember, Required, StringLength(10)]
        public string Language
        {
            get => _language;
            set => SetProperty(ref _language, value);
        }

        private string _languageDescription;
        [DataMember, Required, StringLength(500)]
        public string LanguageDescription
        {
            get => _languageDescription;
            set => SetProperty(ref _languageDescription, value);
        }

        private List<Guid> _labelIds;
        [DataMember]
        public List<Guid> LabelIds
        {
            get => _labelIds;
            set => SetProperty(ref _labelIds, value);
        }

        private bool _isActive = true;
        [DataMember]
        [Required]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }



    }
}
