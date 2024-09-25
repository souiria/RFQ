using System;
using System.Linq;
using System.Runtime.Serialization;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.GlobalMasters.CustomerProduct
{
    [DataContract]
    public class CustomerProductModel : BaseModel<Guid>, IValidatable
    {
        //private CustomerBusinessUnitModel _customer;

        //[DataMember]
        //public CustomerBusinessUnitModel Customer
        //{
        //    get => _customer;
        //    set => SetProperty(ref _customer, value);
        //}

        private Guid _customerId;

        [DataMember]
        public Guid CustomerId
        {
            get => _customerId;
            set => SetProperty(ref _customerId, value);
        }

        private string _internalCustomerProductNumber;

        [DataMember]
        public string InternalCustomerProductNumber
        {
            get => _internalCustomerProductNumber;
            set => SetProperty(ref _internalCustomerProductNumber, value);
        }

        #region -- Validation --

        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(InternalCustomerProductNumber),
            nameof(CustomerId)
        };

        public override string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case nameof(CustomerId) when _customerId == Guid.Empty:
                        return "Customer cannot be empty.";

                    case nameof(InternalCustomerProductNumber) when string.IsNullOrWhiteSpace(_internalCustomerProductNumber):
                        return "Internal Customer Product Number cannot be empty.";

                    default:
                        return null;

                }
            }
        }

        #endregion
    }
}
