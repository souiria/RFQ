using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.GlobalMasters.Customer
{
    [DataContract]
    public class CustomerLocationModel : BaseModel<Guid>, IValidatable
    {
        private string _code;
        [DataMember]
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        private string _streetNumber;

        [DataMember]
        public string StreetNumber
        {
            get => _streetNumber;
            set => SetProperty(ref _streetNumber, value);
        }

        private string _streetName;

        [DataMember]
        public string StreetName
        {
            get => _streetName;
            set => SetProperty(ref _streetName, value);
        }

        private string _city;

        [DataMember]
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        private string _region;

        [DataMember]
        public string Region
        {
            get => _region;
            set => SetProperty(ref _region, value);
        }

        private string _zipCode;

        [DataMember]
        public string ZipCode
        {
            get => _zipCode;
            set => SetProperty(ref _zipCode, value);
        }

        private string _country;

        [DataMember]
        public string Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        private string _type;

        [DataMember]
        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        private string _iMat;

        [DataMember]
        public string IMat
        {
            get => _iMat;
            set => SetProperty(ref _iMat, value);
        }

        #region  -- Validation --

        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(Code),
            nameof(StreetNumber),
            nameof(StreetName),
            nameof(City),
            nameof(Region),
            nameof(ZipCode),
            nameof(Country),
            nameof(Type),
            nameof(IMat)
        };

        public override string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case nameof(Name) when string.IsNullOrWhiteSpace(Name):
                        return "Name must not be empty.";

                    case nameof(Code) when string.IsNullOrWhiteSpace(_code):
                        return "Code must not be empty.";

                    //case nameof(StreetNumber) when string.IsNullOrWhiteSpace(_streetNumber):
                    //    return "Street number must not be empty.";

                    case nameof(StreetNumber) when _streetNumber != null && !_streetNumber.All(char.IsNumber):
                        return "Street number must only contain numbers.";

                    case nameof(StreetName) when string.IsNullOrWhiteSpace(_streetName):
                        return "Street name must not be empty.";

                    case nameof(City) when string.IsNullOrWhiteSpace(_city):
                        return "City name must not be empty.";

                    case nameof(Region) when string.IsNullOrWhiteSpace(_region):
                        return "Region must not be empty.";

                    case nameof(ZipCode) when string.IsNullOrWhiteSpace(_zipCode):
                        return "Zip Code must not be empty.";

                    case nameof(Country) when string.IsNullOrWhiteSpace(_country):
                        return "Country must not be empty.";

                    case nameof(Type) when string.IsNullOrWhiteSpace(_type):
                        return "Type must not be empty.";

                    case nameof(IMat) when string.IsNullOrWhiteSpace(_iMat):
                        return "Indexed Material must not be empty.";

                    default:
                        return null;
                }
            }
        }

        #endregion
    }
}
