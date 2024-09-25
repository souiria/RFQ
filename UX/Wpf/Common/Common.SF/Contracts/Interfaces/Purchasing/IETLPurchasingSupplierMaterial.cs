using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.GlobalMastersAssociation;
using Common.Core.Contracts.Models.Purchasing;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IETLPurchasingSupplierMaterial : IService
    {
        Task<IEnumerable<ETLPurchasingSupplierMaterialGridModel>> GetGridDataOldWay();
        Task<string> GetGridDataByFilter(PurchasingSupplierMaterialSearchModel purchasingSupplierMaterialSearchModel);
        Task<string> GetPurchasingSupplierMaterialForCombo();
        Task<string> GetTariffCountryRegionAssociation();
        Task<string> GetSupplier();
        Task<string> GetActiveSupplier();
        Task<string> GetMaterial();
        Task<string> GetActiveMaterial();
        Task<string> GetActiveMaterialForNewItem();
        Task<string> GetHeaderSupplierCombo();
        Task<string> GetCountryRegionOrigin();
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
        Task<string> ValidateSupplierMaterialPORatioData(string objData);
        Task<string> SupplierMaterialAssociation_GetGridDataByFilter(SupplierMaterialAssociationSearchModel supplierMaterialAssociationSearchModel);
        Task<string> SupplierMaterialAssociation_GetSupplierData();
        Task<string> MaterialAssociation_GetGridDataByFilter(MaterialAssociationSearchModel  materialAssociationSearchModel);
        Task<string> MaterialAssociation_GetMaterialAssociationDataForCombo();
        Task<string> MaterialAssociation_GetGridListByFilterWithBaseMaterial(MaterialAssociationSearchModel model);
        Task<string> MaterialAssociation_GetMaterialAssociationDataWithBaseMaterial();

    }
}
