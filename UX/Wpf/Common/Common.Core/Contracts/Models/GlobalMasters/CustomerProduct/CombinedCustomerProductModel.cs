using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.GlobalMasters.CustomerProduct;

namespace Common.Core.Commercial.Contracts.Models.GlobalMasters.CustomerProduct
{
    [DataContract]
    public class CombinedCustomerProductModel : BaseModel<Guid>
    {
        [DataMember]
        public CustomerProductModel CustomerProduct { get; set; }
        [DataMember]
        public CustomerProductNumberModel CustomerProductNumber { get; set; }
        [DataMember]
        public ManufacturingSiteModel ManufacturingSite { get; set; }

        public CombinedCustomerProductModel(Guid combinedId, CustomerProductModel customerProduct,
            CustomerProductNumberModel customerProductNumber, ManufacturingSiteModel manufacturingSite)
        {
            Id = combinedId;
            CustomerProduct = customerProduct;
            CustomerProductNumber = customerProductNumber;
            ManufacturingSite = manufacturingSite;
        }
    }
}
