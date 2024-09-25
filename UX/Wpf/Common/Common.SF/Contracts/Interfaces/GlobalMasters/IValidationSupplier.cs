using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Settings;
using Common.Core.Contracts.Models.GlobalMasters;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
    public interface IValidationSupplier : IService
    {
        Task<string> ValidateSupplier(SupplierModel supplierModel, ServiceValidationModel serviceValidationModel);
    }
}
