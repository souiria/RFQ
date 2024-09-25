using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.GlobalMasters.Customer
{
    /// <summary>
    /// An aggregate model that represents a single instance of a customer and the hierarchy of its entities.
    /// </summary>
    [DataContract]
    public class CombinedCustomerModel :BaseModel<Guid>
    {
        public CombinedCustomerModel(Guid id, CustomerBusinessUnitModel businessUnit, CustomerLocationModel location, CustomerSalesEntityModel salesEntity)
        {
            Id = id;
            CustomerBusinessUnit = businessUnit;
            CustomerLocation = location;
            CustomerSalesEntity = salesEntity;
        }

        private CustomerBusinessUnitModel _customerBusinessUnit;
        [DataMember]
        public CustomerBusinessUnitModel CustomerBusinessUnit
        {
            get => _customerBusinessUnit;
            set => SetProperty(ref _customerBusinessUnit, value);
        }

        private CustomerLocationModel _customerLocation;
        [DataMember]
        public CustomerLocationModel CustomerLocation
        {
            get => _customerLocation;
            set => SetProperty(ref _customerLocation, value);
        }

        private CustomerSalesEntityModel _customerSalesEntity;
        [DataMember]
        public CustomerSalesEntityModel CustomerSalesEntity
        {
            get => _customerSalesEntity;
            set => SetProperty(ref _customerSalesEntity, value);
        }
    }
}
