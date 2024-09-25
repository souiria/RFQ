using System;
using System.Linq;
using System.Runtime.Serialization;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.GlobalMasters.CustomerProduct
{
    [DataContract]
    public class ManufacturingSiteModel : BaseModel<Guid>, IValidatable
    {
        private string _businessUnit;

        [DataMember]
        public string BusinessUnit
        {
            get => _businessUnit;
            set => SetProperty(ref _businessUnit, value);
        }

        private DateTime _startDate;

        [DataMember]
        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime _endDate;

        [DataMember]
        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        #region -- Validation --

        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(BusinessUnit),
            nameof(StartDate),
            nameof(EndDate)
        };

        public override string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case nameof(BusinessUnit) when string.IsNullOrWhiteSpace(_businessUnit):
                        return "Business unit must not be empty";

                    case nameof(StartDate) when _startDate < DateTime.UtcNow.Date:
                        return "Start date must be set to a date equal to today or later.";

                    case nameof(EndDate) when _endDate < DateTime.UtcNow.Date:
                        return "End date must be set to a date equal to today or later.";

                    case nameof(EndDate) when _endDate < _startDate:
                        return "End date must be set to a date later than the start date.";

                    default:
                        return null;
                }
            }
        }
        #endregion

    }
}
