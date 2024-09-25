using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public  interface IPOPriceValidations : IService
    {
        // Task<IEnumerable<SupplierMaterialPOPricingUploadModel>> ValidateSupplierMaterialPOPricingUploadData(IEnumerable<SupplierMaterialPOPricingUploadModel> modelList);
        Task<string> ValidateSupplierMaterialPOPricingUploadData(string objData,bool H1);
    }
}
