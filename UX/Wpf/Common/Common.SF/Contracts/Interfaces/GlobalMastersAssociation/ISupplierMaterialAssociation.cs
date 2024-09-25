using System;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.GlobalMastersAssociation;
using Common.SF.Contracts.Interfaces.Base;
using Common.SF.Contracts.Interfaces.Base.Base64;

namespace Common.SF.Contracts.Interfaces.GlobalMastersAssociation
{
    public interface ISupplierMaterialAssociation : IBase, IBase64Custom
    {
        Task<SupplierMaterialAssociationModel> GetUncompressed(Guid id);
        //Task<string> GetGridDataByFilter(SupplierMaterialAssociationSearchModel supplierMaterialAssociationSearchModel);
        //Task<string> GetSupplierData();
    }
}
