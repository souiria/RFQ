using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    [DataContract, Serializable]
    public class LanguageHierarchyModel : BaseModel<Guid>
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

        private ObservableCollection<LabelModel> _labels;
        [DataMember]
        public ObservableCollection<LabelModel> Labels
        {
            get => _labels;
            set => SetProperty(ref _labels, value);
        }


        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(Language),
            nameof(LanguageDescription)
            
        };
        public override string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case nameof(Language) when string.IsNullOrWhiteSpace(_language):
                        return "Language must not be empty.";

                    case nameof(LanguageDescription) when string.IsNullOrWhiteSpace(_languageDescription):
                        return "Language Description must not be empty.";


                    default:
                        return null;
                }
            }
        }




    }
}
