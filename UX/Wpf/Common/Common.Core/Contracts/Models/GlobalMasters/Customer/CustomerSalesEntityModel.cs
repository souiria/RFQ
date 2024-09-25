using System;
using System.Linq;
using System.Runtime.Serialization;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.GlobalMasters.Customer
{
    [DataContract]
    public class CustomerSalesEntityModel : BaseModel<Guid>, IValidatable
    {
        public CustomerSalesEntityModel() { }

        public CustomerSalesEntityModel(CustomerSalesEntityModel other)
        {
            Id = other.Id;
            City = other.City;
            Code = other.Code;
            Country = other.Country;
            CreatedBy = other.CreatedBy;
            CreatedDate = other.CreatedDate;
            CrudOperationType = other.CrudOperationType;
            IsActive = other.IsActive;
            ModifiedBy = other.ModifiedBy;
            ModifiedDate = other.ModifiedDate;
            Name = other.Name;
            ZipCode = other.ZipCode;
            StreetName = other.StreetName;
            StreetNumber = other.StreetNumber;
            Region = other.Region;
            FinanceCode = other.FinanceCode;
        }

        private string _code;

        [DataMember]
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        private string _financeCode;

        [DataMember]
        public string FinanceCode
        {
            get => _financeCode;
            set => SetProperty(ref _financeCode, value);
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

        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(Name),
            nameof(Code),
            nameof(FinanceCode),
            nameof(StreetNumber),
            nameof(StreetName),
            nameof(City),
            nameof(Region),
            nameof(ZipCode),
            nameof(Country)
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
                        return "Code must not be empty";

                    case nameof(FinanceCode) when string.IsNullOrWhiteSpace(_financeCode):
                        return "Finance code must not be empty.";

                    case nameof(StreetNumber) when _streetNumber != null && !_streetNumber.All(char.IsNumber):
                        return "Street number must only contain numbers.";

                    case nameof(StreetName) when string.IsNullOrWhiteSpace(_streetName):
                        return "Street name must not be empty.";

                    case nameof(StreetName) when !_streetName.All(char.IsLetter):
                        return "Street name cannot contain any special characters.";

                    case nameof(City) when string.IsNullOrWhiteSpace(_city):
                        return "City must not be empty.";

                    case nameof(City) when !_city.All(char.IsLetter):
                        return "City cannot contain any special characters.";

                    case nameof(Region) when string.IsNullOrWhiteSpace(_region):
                        return "Region must not be empty.";

                    case nameof(Region) when !_region.All(char.IsLetter):
                        return "Region cannot contain any special characters.";

                    case nameof(ZipCode) when string.IsNullOrWhiteSpace(_zipCode):
                        return "Zip code must not be empty.";

                    case nameof(ZipCode) when !_zipCode.All(char.IsLetterOrDigit):
                        return "Zip code cannot contain any special characters.";

                    case nameof(Country) when string.IsNullOrWhiteSpace(_country):
                        return "Country must not be empty.";

                    default:
                        return null;
                }
            }
        }
    }
}
