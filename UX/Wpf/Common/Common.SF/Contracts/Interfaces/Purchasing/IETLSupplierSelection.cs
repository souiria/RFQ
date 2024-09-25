using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.Purchasing;


namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IETLSupplierSelection : IService
    {
        Task<IEnumerable<ETLSupplierSelectionGridModel>> GetGridData();
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
        Task<string> GetGridDataByFilter(PurchasingSupplierSelectionSearchModel purchasingSupplierSelectionSearchModel);
        Task<string> FillMaterialHeaderCombo();
        Task<string> FillSupplierHeaderCombo();
        Task<string> FillMaterialWithPORatioComplete();

    }
}
