using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    public class LabelModel : BaseModel<Guid>
    {
        private string _code;
        [DataMember, Required, StringLength(20)]
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        private string _value;
        [DataMember, Required, StringLength(500)]
        public string Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        private string _purpose;
        [DataMember, Required, StringLength(500)]
        public string Purpose
        {
            get => _purpose;
            set => SetProperty(ref _purpose, value);
        }

        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(Value),
            nameof(Code),
            nameof(Purpose)
        };
        public override string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case nameof(Code) when string.IsNullOrWhiteSpace(_code):
                        return "Code must not be empty.";

                    case nameof(Value) when string.IsNullOrWhiteSpace(_value):
                        return "Value must not be empty.";

                    case nameof(Purpose) when string.IsNullOrWhiteSpace(_purpose):
                        return "Purpose must not be empty.";

                    default:
                        return null;
                }
            }
        }
    }
}
