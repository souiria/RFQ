using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.GlobalMastersAssociation;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.GlobalMastersAssociation
{
    public interface IValidationSupplierMaterialAssociation : IService
    {
        //Task<string> ValidateSupplierMaterialAssociation(SupplierMaterialAssociationModel supplierMaterialAssoicationModel, string serviceName);
        Task<string> ValidateSupplierMaterialAssociation(SupplierMaterialAssociationModel model, List<string> validationsServiceReferences);

    }
}