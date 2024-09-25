using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.GlobalMasters.CustomerProduct
{
    [DataContract]
    public class CustomerProductNumberModel : BaseModel<Guid>, IValidatable
    {
        private string _partNumber;

        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        private string _partNumberType;

        [DataMember]
        public string PartNumberType
        {
            get => _partNumberType;
            set => SetProperty(ref _partNumberType, value);
        }

        private string _revisionLevel;

        [DataMember]
        public string RevisionLevel
        {
            get => _revisionLevel;
            set => SetProperty(ref _revisionLevel, value);
        }

        private DateTime _revisionStartDate;

        [DataMember]
        public DateTime RevisionStartDate
        {
            get => _revisionStartDate;
            set => SetProperty(ref _revisionStartDate, value);
        }

        private DateTime _revisionEndDate;

        [DataMember]
        public DateTime RevisionEndDate
        {
            get => _revisionEndDate;
            set => SetProperty(ref _revisionEndDate, value);
        }

        #region -- Validation --

        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(PartNumber),
            nameof(PartNumberType),
            nameof(RevisionLevel),
            nameof(RevisionStartDate),
            nameof(RevisionEndDate)
        };

        public override string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case nameof(PartNumber) when string.IsNullOrWhiteSpace(_partNumber):
                        return "Part Number cannot be left empty.";

                    case nameof(PartNumberType) when string.IsNullOrWhiteSpace(_partNumberType):
                        return "Part Number cannot be left empty.";

                    case nameof(RevisionLevel) when string.IsNullOrWhiteSpace(_revisionLevel):
                        return "Part Number cannot be left empty.";

                    case nameof(RevisionStartDate) when _revisionStartDate < DateTime.UtcNow.Date:
                        return "Revision start date must be set to a date equal to or later than today.";

                    case nameof(RevisionEndDate) when _revisionEndDate < DateTime.UtcNow.Date:
                        return "Revision end date must be set to a date equal to or later than today.";

                    case nameof(RevisionEndDate) when _revisionEndDate < _revisionStartDate:
                        return "Revision end date must be set to a later than the revision start date.";

                    default:
                        return null;
                }
            }
        }


        #endregion
    }
}
